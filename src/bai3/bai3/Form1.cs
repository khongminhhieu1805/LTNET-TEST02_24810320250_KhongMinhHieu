using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Hệ thống MDI Quản lý Bệnh viện & Truy xuất Hồ sơ Bệnh án";
            this.IsMdiContainer = true; // Bắt buộc đặt Form1 làm MDI Container
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblDoctorOnDuty.Text = "Bác sĩ trực: BS. Nguyễn Hữu Trường";
            CapNhatTrangThai("Hệ thống MDI Quản lý Bệnh viện đã sẵn sàng.");
        }
        private void MoFormConMDI(Type formType)
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child.GetType() == formType)
                {
                    child.Activate();
                    CapNhatTrangThai($"Kích hoạt lại cửa sổ: {child.Text}");
                    return;
                }
            }
            try
            {
                Form newChild = (Form)Activator.CreateInstance(formType);
                newChild.MdiParent = this;
                newChild.Show();
                CapNhatTrangThai($"Đã mở cửa sổ: {newChild.Text}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở cửa sổ con: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CapNhatTrangThai(string msg)
        {
            lblStatusMsg.Text = $"[{DateTime.Now:HH:mm:ss}] {msg}";
        }
        private void mnuHoSoBenhNhan_Click(object sender, EventArgs e)
        {
            MoFormConMDI(typeof(frmPatientProfiles));
        }

        private void mnuLichTrucBacSi_Click(object sender, EventArgs e)
        {
            MoFormConMDI(typeof(frmDoctorSchedule));
        }

        private void mnuKhoaPhong_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Danh mục Khoa/Phòng đang được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CapNhatTrangThai("Truy cập Danh mục Khoa/Phòng.");
        }
        private void mnuCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
            CapNhatTrangThai("Sắp xếp cửa sổ dạng Cascade (Xếp tầng).");
        }

        private void mnuTileHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
            CapNhatTrangThai("Sắp xếp cửa sổ dạng Tile Horizontal (Ngang).");
        }

        private void mnuTileVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
            CapNhatTrangThai("Sắp xếp cửa sổ dạng Tile Vertical (Dọc).");
        }

        private void mnuCloseAll_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
            CapNhatTrangThai("Đã đóng toàn bộ cửa sổ con.");
        }
        private void mnuNapLai_Click(object sender, EventArgs e)
        {
            CapNhatTrangThai("Đã nạp lại dữ liệu toàn hệ thống.");
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            mnuCloseAll_Click(sender, e);
            CapNhatTrangThai("Đã đăng xuất tài khoản.");
            MessageBox.Show("Đã đăng xuất phiên làm việc và đóng các cửa sổ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void lblDoctorOnDuty_Click(object sender, EventArgs e) { }
        private void lblStatusMsg_Click(object sender, EventArgs e) { }
        private void prgStatusProgress_Click(object sender, EventArgs e) { }
    }
}