namespace Project_Windows_04
{
    partial class TuyenDung_DS_CVs
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
            this.flpl_danhSachCV = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpl_danhSachCV
            // 
            this.flpl_danhSachCV.AutoScroll = true;
            this.flpl_danhSachCV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpl_danhSachCV.Location = new System.Drawing.Point(0, 0);
            this.flpl_danhSachCV.Name = "flpl_danhSachCV";
            this.flpl_danhSachCV.Size = new System.Drawing.Size(1127, 703);
            this.flpl_danhSachCV.TabIndex = 0;
            // 
            // TuyenDung_DS_CVs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 703);
            this.Controls.Add(this.flpl_danhSachCV);
            this.Name = "TuyenDung_DS_CVs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CV list";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.FlowLayoutPanel flpl_danhSachCV;
    }
}