namespace Bai3_MdiSieuThi
{
    partial class frmImportExport
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblInfo = new Label();
            SuspendLayout();
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(30, 30);
            lblInfo.Text = "Chức năng quản lý nhập xuất (đang phát triển)";
            lblInfo.Name = "lblInfo";
            // 
            // frmImportExport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 400);
            Name = "frmImportExport";
            Text = "Quản lý nhập xuất";
            Controls.Add(lblInfo);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblInfo;
    }
}
