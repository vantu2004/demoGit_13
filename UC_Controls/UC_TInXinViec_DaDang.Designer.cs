namespace Project_Windows_04
{
    partial class UC_TInXinViec_DaDang
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
            this.pbx_avatar = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lbl_tenUV = new System.Windows.Forms.Label();
            this.lbl_thoiGian = new System.Windows.Forms.Label();
            this.btn_xoaTin = new Guna.UI2.WinForms.Guna2GradientButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // pbx_avatar
            // 
            this.pbx_avatar.BackColor = System.Drawing.Color.Transparent;
            this.pbx_avatar.BorderRadius = 15;
            this.pbx_avatar.Image = global::Project_Windows_04.Properties.Resources.z5011919728665_08ca092652c4fe51aa8a16cc1aac04a1;
            this.pbx_avatar.ImageRotate = 0F;
            this.pbx_avatar.Location = new System.Drawing.Point(12, 6);
            this.pbx_avatar.Name = "pbx_avatar";
            this.pbx_avatar.Size = new System.Drawing.Size(40, 40);
            this.pbx_avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_avatar.TabIndex = 128;
            this.pbx_avatar.TabStop = false;
            this.pbx_avatar.UseTransparentBackground = true;
            // 
            // lbl_tenUV
            // 
            this.lbl_tenUV.AutoSize = true;
            this.lbl_tenUV.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_tenUV.Location = new System.Drawing.Point(69, 6);
            this.lbl_tenUV.Name = "lbl_tenUV";
            this.lbl_tenUV.Size = new System.Drawing.Size(141, 23);
            this.lbl_tenUV.TabIndex = 129;
            this.lbl_tenUV.Text = "Candidate name";
            // 
            // lbl_thoiGian
            // 
            this.lbl_thoiGian.AutoSize = true;
            this.lbl_thoiGian.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_thoiGian.Location = new System.Drawing.Point(70, 29);
            this.lbl_thoiGian.Name = "lbl_thoiGian";
            this.lbl_thoiGian.Size = new System.Drawing.Size(55, 15);
            this.lbl_thoiGian.TabIndex = 130;
            this.lbl_thoiGian.Text = "Datetime";
            // 
            // btn_xoaTin
            // 
            this.btn_xoaTin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_xoaTin.Animated = true;
            this.btn_xoaTin.BackColor = System.Drawing.Color.Transparent;
            this.btn_xoaTin.BorderRadius = 10;
            this.btn_xoaTin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_xoaTin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_xoaTin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_xoaTin.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_xoaTin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_xoaTin.FillColor = System.Drawing.Color.Transparent;
            this.btn_xoaTin.FillColor2 = System.Drawing.Color.Transparent;
            this.btn_xoaTin.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btn_xoaTin.ForeColor = System.Drawing.Color.White;
            this.btn_xoaTin.Image = global::Project_Windows_04.Properties.Resources.kisspng_rubbish_bins_waste_paper_baskets_computer_icons_lixo_5b25c01b15f310_9266541715292006670899;
            this.btn_xoaTin.IndicateFocus = true;
            this.btn_xoaTin.Location = new System.Drawing.Point(259, 10);
            this.btn_xoaTin.Name = "btn_xoaTin";
            this.btn_xoaTin.Size = new System.Drawing.Size(30, 30);
            this.btn_xoaTin.TabIndex = 131;
            this.btn_xoaTin.UseTransparentBackground = true;
            // 
            // UC_TInXinViec_DaDang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_xoaTin);
            this.Controls.Add(this.lbl_thoiGian);
            this.Controls.Add(this.lbl_tenUV);
            this.Controls.Add(this.pbx_avatar);
            this.Name = "UC_TInXinViec_DaDang";
            this.Size = new System.Drawing.Size(300, 50);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_avatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Guna.UI2.WinForms.Guna2PictureBox pbx_avatar;
        public System.Windows.Forms.Label lbl_tenUV;
        public System.Windows.Forms.Label lbl_thoiGian;
        public Guna.UI2.WinForms.Guna2GradientButton btn_xoaTin;
    }
}
