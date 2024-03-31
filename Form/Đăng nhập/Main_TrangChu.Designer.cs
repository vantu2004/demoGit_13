namespace Project_Windows_04
{
    partial class Main_TrangChu
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
            this.UC_Main_TrangChu = new Project_Windows_04.UC_BangTin();
            this.SuspendLayout();
            // 
            // UC_Main_TrangChu
            // 
            this.UC_Main_TrangChu.BackColor = System.Drawing.Color.White;
            this.UC_Main_TrangChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UC_Main_TrangChu.Location = new System.Drawing.Point(0, 0);
            this.UC_Main_TrangChu.Name = "UC_Main_TrangChu";
            this.UC_Main_TrangChu.Size = new System.Drawing.Size(1332, 703);
            this.UC_Main_TrangChu.TabIndex = 0;
            // 
            // Main_TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1332, 703);
            this.Controls.Add(this.UC_Main_TrangChu);
            this.Name = "Main_TrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Main_TrangChu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UC_BangTin UC_Main_TrangChu;
    }
}

