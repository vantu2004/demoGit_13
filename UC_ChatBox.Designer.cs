namespace Project_Windows_04
{
    partial class UC_ChatBox
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_gui = new Guna.UI2.WinForms.Guna2GradientButton();
            this.rtbx_boxChat = new System.Windows.Forms.RichTextBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.btn_gui);
            this.panel6.Controls.Add(this.rtbx_boxChat);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(447, 95);
            this.panel6.TabIndex = 11;
            // 
            // btn_gui
            // 
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
            this.btn_gui.Location = new System.Drawing.Point(390, 26);
            this.btn_gui.Name = "btn_gui";
            this.btn_gui.Size = new System.Drawing.Size(40, 40);
            this.btn_gui.TabIndex = 24;
            this.btn_gui.UseTransparentBackground = true;
            // 
            // rtbx_boxChat
            // 
            this.rtbx_boxChat.BackColor = System.Drawing.Color.Gainsboro;
            this.rtbx_boxChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbx_boxChat.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rtbx_boxChat.Location = new System.Drawing.Point(28, 22);
            this.rtbx_boxChat.Name = "rtbx_boxChat";
            this.rtbx_boxChat.Size = new System.Drawing.Size(343, 52);
            this.rtbx_boxChat.TabIndex = 23;
            this.rtbx_boxChat.Text = "";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 10;
            this.guna2Elipse1.TargetControl = this.rtbx_boxChat;
            // 
            // UC_ChatBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel6);
            this.Name = "UC_ChatBox";
            this.Size = new System.Drawing.Size(447, 95);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        public Guna.UI2.WinForms.Guna2GradientButton btn_gui;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        public System.Windows.Forms.RichTextBox rtbx_boxChat;
    }
}
