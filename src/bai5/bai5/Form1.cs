using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai5
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource _cts;
        private BindingList<TickerLog> _logList = new BindingList<TickerLog>();

        private decimal _lastPrice = 65000.00m;
        private int _syncCount = 0;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Mô phỏng Giám sát Tỷ giá Tài chính Thời gian thực";
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
            btnStart.Enabled = true;
            btnStop.Enabled = false;

            lblBTCPrice.Text = $"${_lastPrice:N2}";
            lblBTCPrice.ForeColor = Color.Black;

            lblLastUpdate.Text = "Lần cập nhật cuối: Chưa có";
            lblSyncCount.Text = "Số lượt đồng bộ: 0";
        }

        private void ThietLapGridBangCode()
        {
            dgvHistoryLog.AutoGenerateColumns = false;
            dgvHistoryLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistoryLog.ReadOnly = true;
            dgvHistoryLog.AllowUserToAddRows = false;
            dgvHistoryLog.Columns.Clear();

            dgvHistoryLog.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TimeLog", HeaderText = "Thời Gian", Width = 130 });
            dgvHistoryLog.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Price", HeaderText = "Giá BTC/USD", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });
            dgvHistoryLog.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ChangeType", HeaderText = "Biến Động", Width = 110 });
            dgvHistoryLog.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ChangeAmount", HeaderText = "Mức Thay Đổi", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });

            dgvHistoryLog.DataSource = _logList;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            _cts = new CancellationTokenSource();
            CancellationToken token = _cts.Token;
            Task.Run(() => BackgroundTickerLoop(token), token);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                _cts.Cancel();
            }

            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }
        private void BackgroundTickerLoop(CancellationToken token)
        {
            Random rand = new Random();

            while (!token.IsCancellationRequested)
            {
                try
                {
                    Thread.Sleep(2000);

                    if (token.IsCancellationRequested) break;
                    decimal change = (decimal)(rand.NextDouble() * 1000 - 500);
                    decimal newPrice = Math.Max(1000, _lastPrice + change);

                    string changeType = "Không đổi";
                    if (change > 0) changeType = "Tăng";
                    else if (change < 0) changeType = "Giảm";

                    string timeStr = DateTime.Now.ToString("HH:mm:ss");
                    CapNhatGiaoDienThreadSafe(newPrice, change, changeType, timeStr);

                    _lastPrice = newPrice;
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private void CapNhatGiaoDienThreadSafe(decimal newPrice, decimal changeAmount, string changeType, string timeStr)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => CapNhatGiaoDienThreadSafe(newPrice, changeAmount, changeType, timeStr)));
                return;
            }
            _syncCount++;
            lblBTCPrice.Text = $"${newPrice:N2}";
            if (changeAmount > 0)
            {
                lblBTCPrice.ForeColor = Color.Green;
            }
            else if (changeAmount < 0)
            {
                lblBTCPrice.ForeColor = Color.Red;
            }
            else
            {
                lblBTCPrice.ForeColor = Color.Black;
            }
            _logList.Insert(0, new TickerLog(timeStr, newPrice, changeType, changeAmount));
            lblLastUpdate.Text = $"Lần cập nhật cuối: {timeStr}";
            lblSyncCount.Text = $"Số lượt đồng bộ: {_syncCount}";
        }
        public class TickerLog
        {
            public string TimeLog { get; set; }
            public decimal Price { get; set; }
            public string ChangeType { get; set; } // Tăng / Giảm / Không đổi
            public decimal ChangeAmount { get; set; }

            public TickerLog(string timeLog, decimal price, string changeType, decimal changeAmount)
            {
                TimeLog = timeLog;
                Price = price;
                ChangeType = changeType;
                ChangeAmount = changeAmount;
            }
        }


        private void lblBTCPrice_Click(object sender, EventArgs e) { }
        private void dgvHistoryLog_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}