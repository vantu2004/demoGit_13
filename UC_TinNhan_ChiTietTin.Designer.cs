namespace Project_Windows_04
{
    partial class UC_TinNhan_ChiTietTin
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnl_tinNhan = new System.Windows.Forms.Panel();
            this.lbl_thoiGianDang = new System.Windows.Forms.Label();
            this.rtbx_noiDung = new System.Windows.Forms.RichTextBox();
            this.lbl_tenUV = new System.Windows.Forms.Label();
            this.pbx_avatar = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.pnl_tinNhan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_tinNhan
            // 
            this.pnl_tinNhan.BackColor = System.Drawing.Color.White;
            this.pnl_tinNhan.Controls.Add(this.lbl_thoiGianDang);
            this.pnl_tinNhan.Controls.Add(this.rtbx_noiDung);
            this.pnl_tinNhan.Controls.Add(this.lbl_tenUV);
            this.pnl_tinNhan.Controls.Add(this.pbx_avatar);
            this.pnl_tinNhan.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_tinNhan.Location = new System.Drawing.Point(0, 0);
            this.pnl_tinNhan.Name = "pnl_tinNhan";
            this.pnl_tinNhan.Size = new System.Drawing.Size(499, 83);
            this.pnl_tinNhan.TabIndex = 0;
            // 
            // lbl_thoiGianDang
            // 
            this.lbl_thoiGianDang.AutoSize = true;
            this.lbl_thoiGianDang.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_thoiGianDang.Location = new System.Drawing.Point(74, 31);
            this.lbl_thoiGianDang.Name = "lbl_thoiGianDang";
            this.lbl_thoiGianDang.Size = new System.Drawing.Size(71, 20);
            this.lbl_thoiGianDang.TabIndex = 145;
            this.lbl_thoiGianDang.Tag = "40, 40";
            this.lbl_thoiGianDang.Text = "Datetime";
            // 
            // rtbx_noiDung
            // 
            this.rtbx_noiDung.BackColor = System.Drawing.Color.White;
            this.rtbx_noiDung.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbx_noiDung.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rtbx_noiDung.Location = new System.Drawing.Point(78, 54);
            this.rtbx_noiDung.Name = "rtbx_noiDung";
            this.rtbx_noiDung.ReadOnly = true;
            this.rtbx_noiDung.Size = new System.Drawing.Size(408, 32);
            this.rtbx_noiDung.TabIndex = 144;
            this.rtbx_noiDung.Text = "";
            this.rtbx_noiDung.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // lbl_tenUV
            // 
            this.lbl_tenUV.AutoSize = true;
            this.lbl_tenUV.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_tenUV.Location = new System.Drawing.Point(73, 6);
            this.lbl_tenUV.Name = "lbl_tenUV";
            this.lbl_tenUV.Size = new System.Drawing.Size(150, 25);
            this.lbl_tenUV.TabIndex = 143;
            this.lbl_tenUV.Tag = "40, 40";
            this.lbl_tenUV.Text = "Candidate name";
            // 
            // pbx_avatar
            // 
            this.pbx_avatar.BackColor = System.Drawing.Color.Transparent;
            this.pbx_avatar.BorderRadius = 22;
            this.pbx_avatar.Image = global::Project_Windows_04.Properties.Resources.z5011919728665_08ca092652c4fe51aa8a16cc1aac04a1;
            this.pbx_avatar.ImageRotate = 0F;
            this.pbx_avatar.Location = new System.Drawing.Point(8, 6);
            this.pbx_avatar.Name = "pbx_avatar";
            this.pbx_avatar.Size = new System.Drawing.Size(50, 50);
            this.pbx_avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_avatar.TabIndex = 142;
            this.pbx_avatar.TabStop = false;
            this.pbx_avatar.Tag = "40, 40";
            this.pbx_avatar.UseTransparentBackground = true;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this.pnl_tinNhan;
            // 
            // UC_TinNhan_ChiTietTin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnl_tinNhan);
            this.Name = "UC_TinNhan_ChiTietTin";
            this.Size = new System.Drawing.Size(643, 83);
            this.pnl_tinNhan.ResumeLayout(false);
            this.pnl_tinNhan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_avatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel pnl_tinNhan;
        public Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        public System.Windows.Forms.Label lbl_thoiGianDang;
        public System.Windows.Forms.RichTextBox rtbx_noiDung;
        public System.Windows.Forms.Label lbl_tenUV;
        public Guna.UI2.WinForms.Guna2PictureBox pbx_avatar;
    }
}
