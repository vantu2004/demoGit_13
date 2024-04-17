namespace Project_Windows_04
{
    partial class UC_DinhDang_rtbx
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
            this.cbx_phongChu = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbx_kieuChu = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbx_coChu = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbx_mauChu = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_hoanTat = new Guna.UI2.WinForms.Guna2GradientButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbx_phongChu
            // 
            this.cbx_phongChu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbx_phongChu.AutoRoundedCorners = true;
            this.cbx_phongChu.BackColor = System.Drawing.Color.Transparent;
            this.cbx_phongChu.BorderRadius = 17;
            this.cbx_phongChu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbx_phongChu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_phongChu.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbx_phongChu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbx_phongChu.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.cbx_phongChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbx_phongChu.ItemHeight = 30;
            this.cbx_phongChu.Items.AddRange(new object[] {
            "Arial",
            "Times New Roman",
            "Verdana",
            "Courier New",
            "Calibri",
            "Tahoma",
            "Segoe UI",
            "Century Gothic",
            "Comic Sans MS",
            "Georgia"});
            this.cbx_phongChu.Location = new System.Drawing.Point(15, 43);
            this.cbx_phongChu.Name = "cbx_phongChu";
            this.cbx_phongChu.Size = new System.Drawing.Size(189, 36);
            this.cbx_phongChu.TabIndex = 0;
            // 
            // cbx_kieuChu
            // 
            this.cbx_kieuChu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbx_kieuChu.AutoRoundedCorners = true;
            this.cbx_kieuChu.BackColor = System.Drawing.Color.Transparent;
            this.cbx_kieuChu.BorderRadius = 17;
            this.cbx_kieuChu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbx_kieuChu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_kieuChu.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbx_kieuChu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbx_kieuChu.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.cbx_kieuChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbx_kieuChu.ItemHeight = 30;
            this.cbx_kieuChu.Items.AddRange(new object[] {
            "Regular",
            "Bold",
            "Italic",
            "Underline",
            "Strikeout"});
            this.cbx_kieuChu.Location = new System.Drawing.Point(210, 43);
            this.cbx_kieuChu.Name = "cbx_kieuChu";
            this.cbx_kieuChu.Size = new System.Drawing.Size(140, 36);
            this.cbx_kieuChu.TabIndex = 1;
            // 
            // cbx_coChu
            // 
            this.cbx_coChu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbx_coChu.AutoRoundedCorners = true;
            this.cbx_coChu.BackColor = System.Drawing.Color.Transparent;
            this.cbx_coChu.BorderRadius = 17;
            this.cbx_coChu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbx_coChu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_coChu.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbx_coChu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbx_coChu.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.cbx_coChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbx_coChu.ItemHeight = 30;
            this.cbx_coChu.Items.AddRange(new object[] {
            "6",
            "8",
            "10",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24"});
            this.cbx_coChu.Location = new System.Drawing.Point(356, 43);
            this.cbx_coChu.Name = "cbx_coChu";
            this.cbx_coChu.Size = new System.Drawing.Size(140, 36);
            this.cbx_coChu.TabIndex = 2;
            // 
            // cbx_mauChu
            // 
            this.cbx_mauChu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbx_mauChu.AutoRoundedCorners = true;
            this.cbx_mauChu.BackColor = System.Drawing.Color.Transparent;
            this.cbx_mauChu.BorderRadius = 17;
            this.cbx_mauChu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbx_mauChu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_mauChu.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbx_mauChu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbx_mauChu.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.cbx_mauChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbx_mauChu.ItemHeight = 30;
            this.cbx_mauChu.Items.AddRange(new object[] {
            "Black",
            "White",
            "Red",
            "Green",
            "Blue",
            "Yellow",
            "Orange",
            "Purple",
            "Gray",
            "Brown"});
            this.cbx_mauChu.Location = new System.Drawing.Point(44, 43);
            this.cbx_mauChu.Name = "cbx_mauChu";
            this.cbx_mauChu.Size = new System.Drawing.Size(189, 36);
            this.cbx_mauChu.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(41, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Color";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Font";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(353, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(207, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Font stype";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbx_mauChu);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 103);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Color";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbx_phongChu);
            this.groupBox2.Controls.Add(this.cbx_kieuChu);
            this.groupBox2.Controls.Add(this.cbx_coChu);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox2.Location = new System.Drawing.Point(291, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(511, 103);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Format";
            // 
            // btn_hoanTat
            // 
            this.btn_hoanTat.Animated = true;
            this.btn_hoanTat.BackColor = System.Drawing.Color.Transparent;
            this.btn_hoanTat.BorderRadius = 10;
            this.btn_hoanTat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_hoanTat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_hoanTat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_hoanTat.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_hoanTat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_hoanTat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_hoanTat.FillColor2 = System.Drawing.Color.LimeGreen;
            this.btn_hoanTat.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.btn_hoanTat.ForeColor = System.Drawing.Color.White;
            this.btn_hoanTat.IndicateFocus = true;
            this.btn_hoanTat.Location = new System.Drawing.Point(3, 112);
            this.btn_hoanTat.Name = "btn_hoanTat";
            this.btn_hoanTat.Size = new System.Drawing.Size(799, 44);
            this.btn_hoanTat.TabIndex = 10;
            this.btn_hoanTat.Text = "Complete";
            this.btn_hoanTat.UseTransparentBackground = true;
            // 
            // UC_DinhDang_rtbx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btn_hoanTat);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UC_DinhDang_rtbx";
            this.Size = new System.Drawing.Size(807, 165);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public Guna.UI2.WinForms.Guna2ComboBox cbx_phongChu;
        public Guna.UI2.WinForms.Guna2ComboBox cbx_kieuChu;
        public Guna.UI2.WinForms.Guna2ComboBox cbx_coChu;
        public Guna.UI2.WinForms.Guna2ComboBox cbx_mauChu;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.GroupBox groupBox2;
        public Guna.UI2.WinForms.Guna2GradientButton btn_hoanTat;
    }
}
