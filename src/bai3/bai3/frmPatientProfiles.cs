using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace bai3
{
    public partial class frmPatientProfiles : Form
    {
        private BindingList<PatientModel> _list = new BindingList<PatientModel>();

        public frmPatientProfiles()
        {
            InitializeComponent();
            this.Text = "Hồ sơ Bệnh nhân";
            this.Load += FrmPatientProfiles_Load;
        }

        private void FrmPatientProfiles_Load(object sender, EventArgs e)
        {
            dgvPatients.AutoGenerateColumns = false;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.ReadOnly = true;

            dgvPatients.Columns.Clear();
            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PatientId", HeaderText = "Mã BN", Width = 80 });
            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FullName", HeaderText = "Họ và Tên", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Gender", HeaderText = "Giới tính", Width = 80 });
            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Age", HeaderText = "Tuổi", Width = 60 });
            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Department", HeaderText = "Khoa Điều Trị", Width = 130 });
            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Diagnosis", HeaderText = "Chẩn Đoán", Width = 180 });

            _list.Add(new PatientModel("BN001", "Trần Văn Nam", "Nam", 45, "Khoa Nội tổng hợp", "Viêm dạ dày cấp"));
            _list.Add(new PatientModel("BN002", "Nguyễn Thị Hoa", "Nữ", 32, "Khoa Ngoại", "Theo dõi ruột thừa"));

            dgvPatients.DataSource = _list;
        }
        public class PatientModel
        {
            public string PatientId { get; set; }
            public string FullName { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public string Department { get; set; }
            public string Diagnosis { get; set; }

            public PatientModel(string id, string name, string gender, int age, string dept, string diag)
            {
                PatientId = id;
                FullName = name;
                Gender = gender;
                Age = age;
                Department = dept;
                Diagnosis = diag;
            }
        }
    }
}