
namespace bai3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNapLai = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHoSoBenhNhan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLichTrucBacSi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhoaPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.cửaSổToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTileHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTileVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblDoctorOnDuty = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.prgStatusProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.quảnLýToolStripMenuItem,
            this.cửaSổToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNapLai,
            this.mnuDangXuat,
            this.mnuThoat});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // mnuNapLai
            // 
            this.mnuNapLai.Name = "mnuNapLai";
            this.mnuNapLai.Size = new System.Drawing.Size(180, 22);
            this.mnuNapLai.Text = "Nạp lại dữ liệu";
            this.mnuNapLai.Click += new System.EventHandler(this.mnuNapLai_Click);
            // 
            // mnuDangXuat
            // 
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Size = new System.Drawing.Size(180, 22);
            this.mnuDangXuat.Text = "Đăng xuất";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(180, 22);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHoSoBenhNhan,
            this.mnuLichTrucBacSi,
            this.mnuKhoaPhong});
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.quảnLýToolStripMenuItem.Text = "Quản lý";
            // 
            // mnuHoSoBenhNhan
            // 
            this.mnuHoSoBenhNhan.Name = "mnuHoSoBenhNhan";
            this.mnuHoSoBenhNhan.Size = new System.Drawing.Size(199, 22);
            this.mnuHoSoBenhNhan.Text = "Hồ sơ bênh nhân";
            this.mnuHoSoBenhNhan.Click += new System.EventHandler(this.mnuHoSoBenhNhan_Click);
            // 
            // mnuLichTrucBacSi
            // 
            this.mnuLichTrucBacSi.Name = "mnuLichTrucBacSi";
            this.mnuLichTrucBacSi.Size = new System.Drawing.Size(199, 22);
            this.mnuLichTrucBacSi.Text = "Lịch trực bác sĩ";
            this.mnuLichTrucBacSi.Click += new System.EventHandler(this.mnuLichTrucBacSi_Click);
            // 
            // mnuKhoaPhong
            // 
            this.mnuKhoaPhong.Name = "mnuKhoaPhong";
            this.mnuKhoaPhong.Size = new System.Drawing.Size(199, 22);
            this.mnuKhoaPhong.Text = "Danh mục Khoa/Phòng";
            this.mnuKhoaPhong.Click += new System.EventHandler(this.mnuKhoaPhong_Click);
            // 
            // cửaSổToolStripMenuItem
            // 
            this.cửaSổToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCascade,
            this.mnuTileHorizontal,
            this.mnuTileVertical,
            this.mnuCloseAll});
            this.cửaSổToolStripMenuItem.Name = "cửaSổToolStripMenuItem";
            this.cửaSổToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.cửaSổToolStripMenuItem.Text = "Cửa sổ";
            // 
            // mnuCascade
            // 
            this.mnuCascade.Name = "mnuCascade";
            this.mnuCascade.Size = new System.Drawing.Size(241, 22);
            this.mnuCascade.Text = "Sắp xếp Xếp tầng (Cascade)";
            this.mnuCascade.Click += new System.EventHandler(this.mnuCascade_Click);
            // 
            // mnuTileHorizontal
            // 
            this.mnuTileHorizontal.Name = "mnuTileHorizontal";
            this.mnuTileHorizontal.Size = new System.Drawing.Size(241, 22);
            this.mnuTileHorizontal.Text = "Sắp xếp Ngang (Tile Horizontal)";
            this.mnuTileHorizontal.Click += new System.EventHandler(this.mnuTileHorizontal_Click);
            // 
            // mnuTileVertical
            // 
            this.mnuTileVertical.Name = "mnuTileVertical";
            this.mnuTileVertical.Size = new System.Drawing.Size(241, 22);
            this.mnuTileVertical.Text = "Sắp xếp Dọc (Tile Vertical)";
            this.mnuTileVertical.Click += new System.EventHandler(this.mnuTileVertical_Click);
            // 
            // mnuCloseAll
            // 
            this.mnuCloseAll.Name = "mnuCloseAll";
            this.mnuCloseAll.Size = new System.Drawing.Size(241, 22);
            this.mnuCloseAll.Text = "Đóng tất cả cửa sổ";
            this.mnuCloseAll.Click += new System.EventHandler(this.mnuCloseAll_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDoctorOnDuty,
            this.lblStatusMsg,
            this.prgStatusProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblDoctorOnDuty
            // 
            this.lblDoctorOnDuty.Name = "lblDoctorOnDuty";
            this.lblDoctorOnDuty.Size = new System.Drawing.Size(178, 17);
            this.lblDoctorOnDuty.Text = "Bác sĩ trực: BS. Nguyễn Hải Nam";
            this.lblDoctorOnDuty.Click += new System.EventHandler(this.lblDoctorOnDuty_Click);
            // 
            // lblStatusMsg
            // 
            this.lblStatusMsg.Name = "lblStatusMsg";
            this.lblStatusMsg.Size = new System.Drawing.Size(109, 17);
            this.lblStatusMsg.Text = "Hệ thống sẵn sàng.";
            this.lblStatusMsg.Click += new System.EventHandler(this.lblStatusMsg_Click);
            // 
            // prgStatusProgress
            // 
            this.prgStatusProgress.Name = "prgStatusProgress";
            this.prgStatusProgress.Size = new System.Drawing.Size(100, 16);
            this.prgStatusProgress.Visible = false;
            this.prgStatusProgress.Click += new System.EventHandler(this.prgStatusProgress_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HỆ THỐNG MDI QUẢN LÝ BỆNH VIỆN & TRUY XUẤT HỒ SƠ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuNapLai;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuHoSoBenhNhan;
        private System.Windows.Forms.ToolStripMenuItem mnuLichTrucBacSi;
        private System.Windows.Forms.ToolStripMenuItem mnuKhoaPhong;
        private System.Windows.Forms.ToolStripMenuItem cửaSổToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCascade;
        private System.Windows.Forms.ToolStripMenuItem mnuTileHorizontal;
        private System.Windows.Forms.ToolStripMenuItem mnuTileVertical;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseAll;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblDoctorOnDuty;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusMsg;
        private System.Windows.Forms.ToolStripProgressBar prgStatusProgress;
    }
}

