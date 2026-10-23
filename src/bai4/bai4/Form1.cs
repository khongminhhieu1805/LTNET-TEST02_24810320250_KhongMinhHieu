using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai4
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource _cts;
        private BindingList<RevenueTransaction> _revenueList = new BindingList<RevenueTransaction>();

        public Form1()
        {
            InitializeComponent();
            this.Text = "Bảng điều khiển Thống kê Doanh thu Multi-Threading";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KhoiTaoControls();
            ThietLapGridBangCode();
        }

        private void KhoiTaoControls()
        {
            cboBranch.Items.Clear();
            cboBranch.Items.AddRange(new string[] { "Tất cả chi nhánh", "Chi nhánh Bắc Ninh", "Chi nhánh Hà Nội", "Chi nhánh TP.HCM" });
            cboBranch.SelectedIndex = 0;

            dtpFromDate.Value = DateTime.Now.AddDays(-30);
            dtpToDate.Value = DateTime.Now;

            dtpFromDate.Format = DateTimePickerFormat.Custom;
            dtpFromDate.CustomFormat = "dd/MM/yyyy";
            dtpToDate.Format = DateTimePickerFormat.Custom;
            dtpToDate.CustomFormat = "dd/MM/yyyy";

            pgbLoading.Value = 0;
            lblProcessingStatus.Text = "Sẵn sàng thống kê.";
            btnCancel.Enabled = false;
        }

        private void ThietLapGridBangCode()
        {
            dgvRevenueData.AutoGenerateColumns = false;
            dgvRevenueData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRevenueData.ReadOnly = true;
            dgvRevenueData.AllowUserToAddRows = false;
            dgvRevenueData.Columns.Clear();

            dgvRevenueData.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TransId", HeaderText = "Mã GD", Width = 90 });
            dgvRevenueData.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TransDate", HeaderText = "Ngày GD", Width = 110, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dgvRevenueData.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BranchName", HeaderText = "Chi Nhánh", Width = 150 });
            dgvRevenueData.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CustomerName", HeaderText = "Khách Hàng", Width = 160 });
            dgvRevenueData.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ServiceName", HeaderText = "Dịch Vụ / Sản Phẩm", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvRevenueData.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Amount", HeaderText = "Doanh Thu", Width = 130, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });

            dgvRevenueData.DataSource = _revenueList;
        }
        private async void btnAnalyze_Click(object sender, EventArgs e)
        {
            btnAnalyze.Enabled = false;
            btnCancel.Enabled = true;
            pgbLoading.Value = 0;
            _revenueList.Clear();

            lblProcessingStatus.Text = "Đang kết nối CSDL và tổng hợp dữ liệu giao dịch lớn...";

            _cts = new CancellationTokenSource();
            CancellationToken token = _cts.Token;

            var progress = new Progress<int>(percent =>
            {
                pgbLoading.Value = Math.Min(percent, 100);
                lblProcessingStatus.Text = $"Đang xử lý dữ liệu doanh thu: {percent}%";
            });

            try
            {
                string selectedBranch = cboBranch.SelectedItem?.ToString() ?? "Tất cả chi nhánh";
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date;

                List<RevenueTransaction> result = await Task.Run(() =>
                    ThucHienThongKeNgam(selectedBranch, fromDate, toDate, progress, token), token);

                foreach (var item in result)
                {
                    _revenueList.Add(item);
                }

                decimal totalRevenue = result.Sum(x => x.Amount);
                lblProcessingStatus.Text = $"Hoàn tất! Tổng số: {result.Count} giao dịch | Doanh thu: {totalRevenue:N0} VNĐ";
                MessageBox.Show($"Thống kê thành công {result.Count} giao dịch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                lblProcessingStatus.Text = "Đã hủy thao tác thống kê!";
                pgbLoading.Value = 0;
                MessageBox.Show("Tiến trình thống kê đã bị hủy bởi người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                lblProcessingStatus.Text = "Xảy ra lỗi trong quá trình tổng hợp!";
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAnalyze.Enabled = true;
                btnCancel.Enabled = false;
                _cts?.Dispose();
                _cts = null;
            }
        }
        private List<RevenueTransaction> ThucHienThongKeNgam(string branch, DateTime fromDate, DateTime toDate, IProgress<int> progress, CancellationToken token)
        {
            List<RevenueTransaction> list = new List<RevenueTransaction>();
            int totalSteps = 50;

            Random rand = new Random();
            string[] customers = { "Nguyễn Văn A", "Trần Thị B", "Lê Hoàng C", "Phạm Minh D", "Vũ Thị E" };
            string[] services = { "Gói tập Gym 1 năm", "Đăng ký khám tổng quát", "Mua tài liệu lập trình", "Gói bảo trì SCADA" };

            for (int i = 1; i <= totalSteps; i++)
            {
                token.ThrowIfCancellationRequested();
                Thread.Sleep(100);

                string transId = $"GD{i:D4}";
                DateTime date = fromDate.AddDays(rand.Next(0, Math.Max(1, (int)(toDate - fromDate).TotalDays)));
                string cust = customers[rand.Next(customers.Length)];
                string serv = services[rand.Next(services.Length)];
                decimal amount = rand.Next(100, 5000) * 1000;

                list.Add(new RevenueTransaction(transId, date, branch, cust, serv, amount));

                int percent = (int)((double)i / totalSteps * 100);
                progress?.Report(percent);
            }

            return list;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                lblProcessingStatus.Text = "Đang gởi yêu cầu hủy thao tác...";
                _cts.Cancel();
            }
        }
        public class RevenueTransaction
        {
            public string TransId { get; set; }
            public DateTime TransDate { get; set; }
            public string BranchName { get; set; }
            public string CustomerName { get; set; }
            public string ServiceName { get; set; }
            public decimal Amount { get; set; }

            public RevenueTransaction(string id, DateTime date, string branch, string customer, string service, decimal amount)
            {
                TransId = id;
                TransDate = date;
                BranchName = branch;
                CustomerName = customer;
                ServiceName = service;
                Amount = amount;
            }
        }


        private void dtpFromDate_ValueChanged(object sender, EventArgs e) { }
        private void dtpToDate_ValueChanged(object sender, EventArgs e) { }
        private void cboBranch_SelectedIndexChanged(object sender, EventArgs e) { }
        private void pgbLoading_Click(object sender, EventArgs e) { }
    }
}