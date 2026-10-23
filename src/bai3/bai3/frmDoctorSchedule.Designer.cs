
namespace bai3
{
    partial class frmDoctorSchedule
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDoctorSchedule = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctorSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "BẢNG PHÂN CÔNG LỊCH TRỰC BÁC SĨ";
            // 
            // dgvDoctorSchedule
            // 
            this.dgvDoctorSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoctorSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDoctorSchedule.Location = new System.Drawing.Point(0, 0);
            this.dgvDoctorSchedule.Name = "dgvDoctorSchedule";
            this.dgvDoctorSchedule.Size = new System.Drawing.Size(800, 450);
            this.dgvDoctorSchedule.TabIndex = 1;
            this.dgvDoctorSchedule.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDoctorSchedule_CellContentClick);
            // 
            // frmDoctorSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvDoctorSchedule);
            this.Controls.Add(this.label1);
            this.Name = "frmDoctorSchedule";
            this.Text = "Lịch trực của Bác sĩ";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctorSchedule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDoctorSchedule;
    }
}