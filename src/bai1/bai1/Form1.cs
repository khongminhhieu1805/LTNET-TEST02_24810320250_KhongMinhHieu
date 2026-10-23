using System;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace bai1
{
    public partial class Form1 : Form
    {
        private BindingList<MemberModel> _memberList = new BindingList<MemberModel>();
        private BindingSource _bindingSource = new BindingSource();
        private int _autoIncrementId = 1;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Hệ thống Quản lý Dịch vụ Phòng Gym & Hội viên";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KhoiTaoGiaoDienControls();
            ThietLapGridBangCode();
            ThietLapDataBinding2Chieu();
            NapDuLieuMau();
            LamMoiForm();
        }

        private void KhoiTaoGiaoDienControls()
        {
            cboPackage.Items.Clear();
            cboPackage.Items.AddRange(new string[] { "Theo tháng", "6 tháng", "1 năm" });
            cboPackage.SelectedIndex = 0;

            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.CustomFormat = "dd/MM/yyyy";
        }

        // YÊU CẦU 1: CẤU HÌNH DATAGRIDVIEW HOÀN TOÀN BẰNG CODE
        private void ThietLapGridBangCode()
        {
            dgvMembers.AutoGenerateColumns = false;
            dgvMembers.Columns.Clear();

            dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMembers.ReadOnly = true;
            dgvMembers.MultiSelect = false;
            dgvMembers.AllowUserToAddRows = false;

            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MemberId",
                HeaderText = "Mã HV",
                Width = 90
            });

            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FullName",
                HeaderText = "Tên hội viên",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Phone",
                HeaderText = "Số điện thoại",
                Width = 110
            });

            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Package",
                HeaderText = "Gói tập",
                Width = 110
            });

            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StartDate",
                HeaderText = "Ngày ĐK",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Fee",
                HeaderText = "Phí dịch vụ",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });
        }

        // YÊU CẦU 3: RÀNG BUỘC DATA BINDING 2 CHIỀU
        private void ThietLapDataBinding2Chieu()
        {
            _bindingSource.DataSource = _memberList;
            dgvMembers.DataSource = _bindingSource;

            txtMemberId.DataBindings.Clear();
            txtFullName.DataBindings.Clear();
            txtPhone.DataBindings.Clear();
            cboPackage.DataBindings.Clear();
            dtpStartDate.DataBindings.Clear();
            txtFee.DataBindings.Clear();

            txtMemberId.DataBindings.Add("Text", _bindingSource, "MemberId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtFullName.DataBindings.Add("Text", _bindingSource, "FullName", true, DataSourceUpdateMode.OnPropertyChanged);
            txtPhone.DataBindings.Add("Text", _bindingSource, "Phone", true, DataSourceUpdateMode.OnPropertyChanged);
            cboPackage.DataBindings.Add("Text", _bindingSource, "Package", true, DataSourceUpdateMode.OnPropertyChanged);
            dtpStartDate.DataBindings.Add("Value", _bindingSource, "StartDate", true, DataSourceUpdateMode.OnPropertyChanged);

            Binding feeBinding = new Binding("Text", _bindingSource, "Fee", true, DataSourceUpdateMode.OnPropertyChanged);
            feeBinding.Format += (s, e) => { if (e.Value is decimal val) e.Value = val.ToString("0.#"); };
            txtFee.DataBindings.Add(feeBinding);
        }

        private void NapDuLieuMau()
        {
            _memberList.Add(new MemberModel(TaoMaTuDong(), "Nguyễn Văn Anh", "0912345678", "6 tháng", DateTime.Now.AddDays(-10), 3000000));
            _memberList.Add(new MemberModel(TaoMaTuDong(), "Trần Thị Bình", "0987654321", "1 năm", DateTime.Now.AddDays(-30), 5500000));
        }

        private string TaoMaTuDong()
        {
            return $"HV{_autoIncrementId++:D3}";
        }

        // YÊU CẦU 2: KIỂM TRA HỢP LỆ BẰNG ERRORPROVIDER
        private bool KiemTraHopLe()
        {
            bool isValid = true;
            epInput.Clear();

            string fullName = txtFullName.Text.Trim();
            if (string.IsNullOrWhiteSpace(fullName))
            {
                epInput.SetError(txtFullName, "Họ và tên không được để trống!");
                isValid = false;
            }
            else if (Regex.IsMatch(fullName, @"[@#$%^&*()_+=\[{\];:<>|\\/~`]"))
            {
                epInput.SetError(txtFullName, "Tên hội viên không được chứa ký tự đặc biệt!");
                isValid = false;
            }

            string phone = txtPhone.Text.Trim();
            if (string.IsNullOrWhiteSpace(phone))
            {
                epInput.SetError(txtPhone, "Số điện thoại không được để trống!");
                isValid = false;
            }
            else if (!Regex.IsMatch(phone, @"^\d{10}$"))
            {
                epInput.SetError(txtPhone, "Số điện thoại phải bao gồm đúng 10 chữ số!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtFee.Text.Trim()))
            {
                epInput.SetError(txtFee, "Phí dịch vụ không được để trống!");
                isValid = false;
            }
            else if (!decimal.TryParse(txtFee.Text.Trim(), out decimal fee) || fee <= 0)
            {
                epInput.SetError(txtFee, "Phí dịch vụ phải là một số nguyên dương!");
                isValid = false;
            }

            return isValid;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe()) return;

            string idMoi = TaoMaTuDong();
            MemberModel memberMoi = new MemberModel(
                idMoi,
                txtFullName.Text.Trim(),
                txtPhone.Text.Trim(),
                cboPackage.SelectedItem.ToString(),
                dtpStartDate.Value,
                decimal.Parse(txtFee.Text.Trim())
            );

            _memberList.Add(memberMoi);
            _bindingSource.MoveLast();
            MessageBox.Show($"Thêm thành công hội viên {memberMoi.FullName} ({idMoi})!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is MemberModel currentMember)
            {
                if (!KiemTraHopLe()) return;

                _bindingSource.ResetCurrentItem();
                MessageBox.Show("Cập nhật thông tin hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hội viên để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is MemberModel currentMember)
            {
                DialogResult dr = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa hội viên [{currentMember.MemberId}] - {currentMember.FullName}?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (dr == DialogResult.Yes)
                {
                    _memberList.Remove(currentMember);
                    LamMoiForm();
                    MessageBox.Show("Đã xóa hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hội viên cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LamMoiForm();
        }

        private void LamMoiForm()
        {
            txtMemberId.Text = $"HV{_autoIncrementId:D3}";
            txtFullName.Text = "";
            txtPhone.Text = "";
            cboPackage.SelectedIndex = 0;
            dtpStartDate.Value = DateTime.Now;
            txtFee.Text = "";
            epInput.Clear();
            dgvMembers.ClearSelection();
        }
        public class MemberModel : INotifyPropertyChanged
        {
            private string _memberId;
            private string _fullName;
            private string _phone;
            private string _package;
            private DateTime _startDate;
            private decimal _fee;

            public string MemberId
            {
                get => _memberId;
                set { _memberId = value; OnPropertyChanged(nameof(MemberId)); }
            }

            public string FullName
            {
                get => _fullName;
                set { _fullName = value; OnPropertyChanged(nameof(FullName)); }
            }

            public string Phone
            {
                get => _phone;
                set { _phone = value; OnPropertyChanged(nameof(Phone)); }
            }

            public string Package
            {
                get => _package;
                set { _package = value; OnPropertyChanged(nameof(Package)); }
            }

            public DateTime StartDate
            {
                get => _startDate;
                set { _startDate = value; OnPropertyChanged(nameof(StartDate)); }
            }

            public decimal Fee
            {
                get => _fee;
                set { _fee = value; OnPropertyChanged(nameof(Fee)); }
            }

            public MemberModel() { }

            public MemberModel(string id, string name, string phone, string pkg, DateTime startDate, decimal fee)
            {
                MemberId = id;
                FullName = name;
                Phone = phone;
                Package = pkg;
                StartDate = startDate;
                Fee = fee;
            }

            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // Các sự kiện rỗng giữ lại để đảm bảo không lỗi giao diện Designer
        private void label4_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void dtpStartDate_ValueChanged(object sender, EventArgs e) { }
        private void cboPackage_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}