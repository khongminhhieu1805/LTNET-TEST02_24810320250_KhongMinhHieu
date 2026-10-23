
namespace bai5
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBTCPrice = new System.Windows.Forms.Label();
            this.dgvHistoryLog = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblLastUpdate = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSyncCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryLog)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblBTCPrice);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điều khiển && Tỷ giá thời gian thực";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(11, 19);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(186, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Bắt đầu Giám sát";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(9, 48);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(188, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Tạm dừng";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tỷ giá BTC/USD hiện tại:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblBTCPrice
            // 
            this.lblBTCPrice.AutoSize = true;
            this.lblBTCPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBTCPrice.Location = new System.Drawing.Point(40, 99);
            this.lblBTCPrice.Name = "lblBTCPrice";
            this.lblBTCPrice.Size = new System.Drawing.Size(76, 29);
            this.lblBTCPrice.TabIndex = 3;
            this.lblBTCPrice.Text = "$0.00";
            this.lblBTCPrice.Click += new System.EventHandler(this.lblBTCPrice_Click);
            // 
            // dgvHistoryLog
            // 
            this.dgvHistoryLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistoryLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistoryLog.Location = new System.Drawing.Point(221, 12);
            this.dgvHistoryLog.Name = "dgvHistoryLog";
            this.dgvHistoryLog.ReadOnly = true;
            this.dgvHistoryLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistoryLog.Size = new System.Drawing.Size(567, 426);
            this.dgvHistoryLog.TabIndex = 1;
            this.dgvHistoryLog.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistoryLog_CellContentClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblLastUpdate,
            this.lblSyncCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(151, 17);
            this.lblLastUpdate.Text = "Lần cập nhật cuối: Chưa có";
            // 
            // lblSyncCount
            // 
            this.lblSyncCount.Name = "lblSyncCount";
            this.lblSyncCount.Size = new System.Drawing.Size(104, 17);
            this.lblSyncCount.Text = "Số lượt đồng bộ: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvHistoryLog);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "MÔ PHỎNG GIÁM SÁT TỶ GIÁ TÀI CHÍNH THỜI GIAN THỰC";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryLog)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblBTCPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataGridView dgvHistoryLog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblLastUpdate;
        private System.Windows.Forms.ToolStripStatusLabel lblSyncCount;
    }
}

