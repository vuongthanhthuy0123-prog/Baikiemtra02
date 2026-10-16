namespace Bai3_MdiSieuThi
{
    partial class frmMain
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
            mnuMain = new MenuStrip();
            mnuSystem = new ToolStripMenuItem();
            mnuLogout = new ToolStripMenuItem();
            mnuSeparator1 = new ToolStripSeparator();
            mnuExit = new ToolStripMenuItem();
            mnuCatalog = new ToolStripMenuItem();
            mnuProducts = new ToolStripMenuItem();
            mnuStock = new ToolStripMenuItem();
            mnuReport = new ToolStripMenuItem();
            mnuRevenue = new ToolStripMenuItem();
            mnuWindow = new ToolStripMenuItem();
            mnuCascade = new ToolStripMenuItem();
            mnuTileHorizontal = new ToolStripMenuItem();
            mnuTileVertical = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            lblUser = new ToolStripStatusLabel();
            lblMessage = new ToolStripStatusLabel();
            lblSync = new ToolStripStatusLabel();
            prgLoading = new ToolStripProgressBar();
            mnuMain.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // mnuMain
            // 
            mnuMain.Items.AddRange(new ToolStripItem[] { mnuSystem, mnuCatalog, mnuReport, mnuWindow });
            mnuMain.Location = new Point(0, 0);
            mnuMain.MdiWindowListItem = mnuWindow;
            mnuMain.Size = new Size(1184, 24);
            mnuMain.Name = "mnuMain";
            mnuMain.TabIndex = 0;
            // 
            // mnuSystem
            // 
            mnuSystem.DropDownItems.AddRange(new ToolStripItem[] { mnuLogout, mnuSeparator1, mnuExit });
            mnuSystem.Text = "&Hệ thống";
            mnuSystem.Name = "mnuSystem";
            // 
            // mnuLogout
            // 
            mnuLogout.Text = "Đăng xuất";
            mnuLogout.Name = "mnuLogout";
            // 
            // mnuSeparator1
            // 
            mnuSeparator1.Name = "mnuSeparator1";
            // 
            // mnuExit
            // 
            mnuExit.Text = "Thoát";
            mnuExit.Name = "mnuExit";
            // 
            // mnuCatalog
            // 
            mnuCatalog.DropDownItems.AddRange(new ToolStripItem[] { mnuProducts, mnuStock });
            mnuCatalog.Text = "&Danh mục";
            mnuCatalog.Name = "mnuCatalog";
            // 
            // mnuProducts
            // 
            mnuProducts.Text = "Quản lý Sản phẩm";
            mnuProducts.Name = "mnuProducts";
            // 
            // mnuStock
            // 
            mnuStock.Text = "Quản lý Nhập xuất";
            mnuStock.Name = "mnuStock";
            // 
            // mnuReport
            // 
            mnuReport.DropDownItems.AddRange(new ToolStripItem[] { mnuRevenue });
            mnuReport.Text = "&Báo cáo";
            mnuReport.Name = "mnuReport";
            // 
            // mnuRevenue
            // 
            mnuRevenue.Text = "Thống kê Doanh thu";
            mnuRevenue.Name = "mnuRevenue";
            // 
            // mnuWindow
            // 
            mnuWindow.DropDownItems.AddRange(new ToolStripItem[] { mnuCascade, mnuTileHorizontal, mnuTileVertical });
            mnuWindow.Text = "&Cửa sổ";
            mnuWindow.Name = "mnuWindow";
            // 
            // mnuCascade
            // 
            mnuCascade.Text = "Cascade";
            mnuCascade.Name = "mnuCascade";
            // 
            // mnuTileHorizontal
            // 
            mnuTileHorizontal.Text = "Tile Horizontal";
            mnuTileHorizontal.Name = "mnuTileHorizontal";
            // 
            // mnuTileVertical
            // 
            mnuTileVertical.Text = "Tile Vertical";
            mnuTileVertical.Name = "mnuTileVertical";
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { lblUser, lblMessage, lblSync, prgLoading });
            statusStrip.Location = new Point(0, 689);
            statusStrip.Size = new Size(1184, 22);
            statusStrip.Name = "statusStrip";
            statusStrip.TabIndex = 1;
            // 
            // lblUser
            // 
            lblUser.BorderSides = ToolStripStatusLabelBorderSides.Right;
            lblUser.Text = "Người dùng: admin";
            lblUser.Name = "lblUser";
            // 
            // lblMessage
            // 
            lblMessage.Spring = true;
            lblMessage.Text = "Sẵn sàng";
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;
            lblMessage.Name = "lblMessage";
            // 
            // lblSync
            // 
            lblSync.Text = "";
            lblSync.Name = "lblSync";
            // 
            // prgLoading
            // 
            prgLoading.Size = new Size(200, 16);
            prgLoading.Visible = false;
            prgLoading.Name = "prgLoading";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 711);
            IsMdiContainer = true;
            MainMenuStrip = mnuMain;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống quản lý siêu thị";
            WindowState = FormWindowState.Maximized;
            Controls.Add(statusStrip);
            Controls.Add(mnuMain);
            mnuMain.ResumeLayout(false);
            mnuMain.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnuMain;
        private ToolStripMenuItem mnuSystem;
        private ToolStripMenuItem mnuLogout;
        private ToolStripSeparator mnuSeparator1;
        private ToolStripMenuItem mnuExit;
        private ToolStripMenuItem mnuCatalog;
        private ToolStripMenuItem mnuProducts;
        private ToolStripMenuItem mnuStock;
        private ToolStripMenuItem mnuReport;
        private ToolStripMenuItem mnuRevenue;
        private ToolStripMenuItem mnuWindow;
        private ToolStripMenuItem mnuCascade;
        private ToolStripMenuItem mnuTileHorizontal;
        private ToolStripMenuItem mnuTileVertical;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblUser;
        private ToolStripStatusLabel lblMessage;
        private ToolStripStatusLabel lblSync;
        private ToolStripProgressBar prgLoading;
    }
}
