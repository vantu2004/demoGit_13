namespace Project_Windows_04
{
    partial class UC_ChatBox_ChiTietTin
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
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtbx_boxChat = new System.Windows.Forms.RichTextBox();
            this.btn_gui = new Guna.UI2.WinForms.Guna2GradientButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 10;
            this.guna2Elipse1.TargetControl = this.rtbx_boxChat;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_gui);
            this.panel1.Controls.Add(this.rtbx_boxChat);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(896, 103);
            this.panel1.TabIndex = 1;
            // 
            // rtbx_boxChat
            // 
            this.rtbx_boxChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbx_boxChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.rtbx_boxChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbx_boxChat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rtbx_boxChat.Location = new System.Drawing.Point(44, 29);
            this.rtbx_boxChat.Name = "rtbx_boxChat";
            this.rtbx_boxChat.Size = new System.Drawing.Size(549, 40);
            this.rtbx_boxChat.TabIndex = 27;
            this.rtbx_boxChat.Text = "";
            // 
            // btn_gui
            // 
            this.btn_gui.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_gui.Animated = true;
            this.btn_gui.BackColor = System.Drawing.Color.Transparent;
            this.btn_gui.BorderRadius = 10;
            this.btn_gui.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_gui.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_gui.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_gui.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_gui.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_gui.FillColor = System.Drawing.Color.White;
            this.btn_gui.FillColor2 = System.Drawing.Color.White;
            this.btn_gui.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_gui.ForeColor = System.Drawing.Color.White;
            this.btn_gui.Image = global::Project_Windows_04.Properties.Resources.send_2089310;
            this.btn_gui.ImageSize = new System.Drawing.Size(25, 25);
            this.btn_gui.IndicateFocus = true;
            this.btn_gui.Location = new System.Drawing.Point(599, 29);
            this.btn_gui.Name = "btn_gui";
            this.btn_gui.Size = new System.Drawing.Size(40, 40);
            this.btn_gui.TabIndex = 28;
            this.btn_gui.UseTransparentBackground = true;
            // 
            // UC_ChatBox_ChiTietTin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Name = "UC_ChatBox_ChiTietTin";
            this.Size = new System.Drawing.Size(896, 103);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        public System.Windows.Forms.RichTextBox rtbx_boxChat;
        public System.Windows.Forms.Panel panel1;
        public Guna.UI2.WinForms.Guna2GradientButton btn_gui;
    }
}
