using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace bai3
{
    // 1. CLASS MÔ HÌNH DỮ LIỆU LỊCH TRỰC BÁC SĨ
    // 2. CLASS GIAO DIỆN CỬA SỔ CON
    public partial class frmDoctorSchedule : Form
    {
        private BindingList<DoctorScheduleModel> _scheduleList = new BindingList<DoctorScheduleModel>();

        public frmDoctorSchedule()
        {
            InitializeComponent();
            this.Text = "Lịch trực Bác sĩ";
            this.Load += FrmDoctorSchedule_Load;
        }

        private void FrmDoctorSchedule_Load(object sender, EventArgs e)
        {
            ThietLapGridBangCode();
            NapDuLieuMau();
        }

        private void ThietLapGridBangCode()
        {
            dgvDoctorSchedule.AutoGenerateColumns = false;
            dgvDoctorSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDoctorSchedule.ReadOnly = true;
            dgvDoctorSchedule.AllowUserToAddRows = false;
            dgvDoctorSchedule.Columns.Clear();

            // Khai báo các cột hiển thị thông tin
            dgvDoctorSchedule.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DoctorId", HeaderText = "Mã BS", Width = 80 });
            dgvDoctorSchedule.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DoctorName", HeaderText = "Họ và Tên Bác Sĩ", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvDoctorSchedule.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Department", HeaderText = "Khoa Công Tác", Width = 150 });
            dgvDoctorSchedule.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DutyDate", HeaderText = "Ngày Trực", Width = 110, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvDoctorSchedule.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Shift", HeaderText = "Ca Trực", Width = 100 });
            dgvDoctorSchedule.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RoomNo", HeaderText = "Phòng Trực", Width = 110 });
        }

        private void NapDuLieuMau()
        {
            DateTime today = DateTime.Now;

            _scheduleList.Add(new DoctorScheduleModel("BS001", "BS. Nguyễn Hữu Trường", "Khoa Cấp cứu", "Ca Đêm (22h - 6h)", today, "Phòng CC-01"));
            _scheduleList.Add(new DoctorScheduleModel("BS002", "BS. Trần Văn Nam", "Khoa Nội tổng hợp", "Ca Sáng (6h - 14h)", today, "Phòng N-102"));
            _scheduleList.Add(new DoctorScheduleModel("BS003", "BS. Lê Thị Mai", "Khoa Ngoại", "Ca Chiều (14h - 22h)", today, "Phòng PT-03"));
            _scheduleList.Add(new DoctorScheduleModel("BS004", "BS. Phạm Minh Hoàng", "Khoa Nhi", "Ca Sáng (6h - 14h)", today.AddDays(1), "Phòng N-201"));

            dgvDoctorSchedule.DataSource = _scheduleList;
        }
        public class DoctorScheduleModel
        {
            public string DoctorId { get; set; }
            public string DoctorName { get; set; }
            public string Department { get; set; }
            public string Shift { get; set; }        // Ca trực (Sáng/Chiều/Đêm)
            public DateTime DutyDate { get; set; }   // Ngày trực
            public string RoomNo { get; set; }       // Phòng trực

            public DoctorScheduleModel(string id, string name, string dept, string shift, DateTime date, string room)
            {
                DoctorId = id;
                DoctorName = name;
                Department = dept;
                Shift = shift;
                DutyDate = date;
                RoomNo = room;
            }
        }
        private void dgvDoctorSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Hàm sự kiện rỗng để khắc phục lỗi Designer
        }

    }
}