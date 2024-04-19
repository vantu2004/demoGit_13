namespace Project_Windows_04
{
    partial class ChiTietThu
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
            this.components = new System.ComponentModel.Container();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.UC_Thu = new Project_Windows_04.UC_Thu();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this;
            // 
            // UC_Thu
            // 
            this.UC_Thu.BackColor = System.Drawing.Color.White;
            this.UC_Thu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UC_Thu.Location = new System.Drawing.Point(0, 0);
            this.UC_Thu.Name = "UC_Thu";
            this.UC_Thu.Size = new System.Drawing.Size(765, 570);
            this.UC_Thu.TabIndex = 0;
            // 
            // ChiTietThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 570);
            this.Controls.Add(this.UC_Thu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChiTietThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thu";
            this.Load += new System.EventHandler(this.ChiTietThu_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        public UC_Thu UC_Thu;
    }
}