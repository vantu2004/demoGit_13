namespace Project_Windows_04
{
    partial class DinhDangChu
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
            this.UC_DinhDang_rtbx = new Project_Windows_04.UC_DinhDang_rtbx();
            this.SuspendLayout();
            // 
            // UC_DinhDang_rtbx
            // 
            this.UC_DinhDang_rtbx.BackColor = System.Drawing.SystemColors.Control;
            this.UC_DinhDang_rtbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UC_DinhDang_rtbx.Location = new System.Drawing.Point(0, 0);
            this.UC_DinhDang_rtbx.Name = "UC_DinhDang_rtbx";
            this.UC_DinhDang_rtbx.Size = new System.Drawing.Size(810, 165);
            this.UC_DinhDang_rtbx.TabIndex = 0;
            // 
            // DinhDangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 165);
            this.Controls.Add(this.UC_DinhDang_rtbx);
            this.Name = "DinhDangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Format";
            this.ResumeLayout(false);

        }

        #endregion

        public UC_DinhDang_rtbx UC_DinhDang_rtbx;
    }
}