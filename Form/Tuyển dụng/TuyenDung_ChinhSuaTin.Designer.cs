namespace Project_Windows_04
{
    partial class TuyenDung_ChinhSuaTin
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
            this.UC_taoTin = new Project_Windows_04.UC_taoTin();
            this.SuspendLayout();
            // 
            // UC_taoTin
            // 
            this.UC_taoTin.Dock = System.Windows.Forms.DockStyle.Left;
            this.UC_taoTin.Location = new System.Drawing.Point(0, 0);
            this.UC_taoTin.Name = "UC_taoTin";
            this.UC_taoTin.Size = new System.Drawing.Size(1142, 994);
            this.UC_taoTin.TabIndex = 0;
            this.UC_taoTin.Load += new System.EventHandler(this.UC_taoTin_Load_1);
            // 
            // TuyenDung_ChinhSuaTin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 994);
            this.Controls.Add(this.UC_taoTin);
            this.Name = "TuyenDung_ChinhSuaTin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit news";
            this.Load += new System.EventHandler(this.TuyenDung_ChinhSuaTin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public UC_taoTin UC_taoTin;
    }
}