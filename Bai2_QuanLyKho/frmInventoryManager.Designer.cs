namespace Bai2_QuanLyKho
{
    partial class frmInventoryManager
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
            components = new System.ComponentModel.Container();
            menuStrip = new MenuStrip();
            mnuSystem = new ToolStripMenuItem();
            mnuOpenFile = new ToolStripMenuItem();
            mnuSaveReport = new ToolStripMenuItem();
            mnuSeparator1 = new ToolStripSeparator();
            mnuExit = new ToolStripMenuItem();
            mnuTools = new ToolStripMenuItem();
            mnuImportCsv = new ToolStripMenuItem();
            mnuExportCsv = new ToolStripMenuItem();
            toolStrip = new ToolStrip();
            tsbOpen = new ToolStripButton();
            tsbSave = new ToolStripButton();
            tsbSeparator1 = new ToolStripSeparator();
            tsbImport = new ToolStripButton();
            tsbExport = new ToolStripButton();
            tsbSeparator2 = new ToolStripSeparator();
            tsbExit = new ToolStripButton();
            statusStrip = new StatusStrip();
            lblTotalQuantity = new ToolStripStatusLabel();
            lblTotalValue = new ToolStripStatusLabel();
            lblSpacer = new ToolStripStatusLabel();
            lblClock = new ToolStripStatusLabel();
            grpInput = new GroupBox();
            lblProductId = new Label();
            txtProductId = new TextBox();
            lblProductName = new Label();
            txtProductName = new TextBox();
            lblCategory = new Label();
            cboCategory = new ComboBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            lblQuantity = new Label();
            numQuantity = new NumericUpDown();
            grpImage = new GroupBox();
            picProductImage = new PictureBox();
            btnChooseImage = new Button();
            grpActions = new GroupBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            dgvProducts = new DataGridView();
            errProvider = new ErrorProvider(components);
            tmrClock = new System.Windows.Forms.Timer(components);
            ofdImage = new OpenFileDialog();
            menuStrip.SuspendLayout();
            toolStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            grpInput.SuspendLayout();
            grpImage.SuspendLayout();
            grpActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picProductImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errProvider).BeginInit();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { mnuSystem, mnuTools });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Size = new Size(1000, 24);
            menuStrip.Name = "menuStrip";
            menuStrip.TabIndex = 0;
            // 
            // mnuSystem
            // 
            mnuSystem.DropDownItems.AddRange(new ToolStripItem[] { mnuOpenFile, mnuSaveReport, mnuSeparator1, mnuExit });
            mnuSystem.Text = "&System";
            mnuSystem.Name = "mnuSystem";
            // 
            // mnuOpenFile
            // 
            mnuOpenFile.ShortcutKeys = Keys.Control | Keys.O;
            mnuOpenFile.Text = "Open File";
            mnuOpenFile.Name = "mnuOpenFile";
            // 
            // mnuSaveReport
            // 
            mnuSaveReport.ShortcutKeys = Keys.Control | Keys.S;
            mnuSaveReport.Text = "Save Report";
            mnuSaveReport.Name = "mnuSaveReport";
            // 
            // mnuSeparator1
            // 
            mnuSeparator1.Name = "mnuSeparator1";
            // 
            // mnuExit
            // 
            mnuExit.Text = "Exit";
            mnuExit.Name = "mnuExit";
            // 
            // mnuTools
            // 
            mnuTools.DropDownItems.AddRange(new ToolStripItem[] { mnuImportCsv, mnuExportCsv });
            mnuTools.Text = "&Tools";
            mnuTools.Name = "mnuTools";
            // 
            // mnuImportCsv
            // 
            mnuImportCsv.ShortcutKeys = Keys.Control | Keys.I;
            mnuImportCsv.Text = "Import CSV";
            mnuImportCsv.Name = "mnuImportCsv";
            // 
            // mnuExportCsv
            // 
            mnuExportCsv.ShortcutKeys = Keys.Control | Keys.E;
            mnuExportCsv.Text = "Export CSV";
            mnuExportCsv.Name = "mnuExportCsv";
            // 
            // toolStrip
            // 
            toolStrip.Items.AddRange(new ToolStripItem[] { tsbOpen, tsbSave, tsbSeparator1, tsbImport, tsbExport, tsbSeparator2, tsbExit });
            toolStrip.Location = new Point(0, 24);
            toolStrip.Size = new Size(1000, 25);
            toolStrip.Name = "toolStrip";
            toolStrip.TabIndex = 1;
            // 
            // tsbOpen
            // 
            tsbOpen.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            tsbOpen.Text = "Mở";
            tsbOpen.ToolTipText = "Mở file dữ liệu (JSON)";
            tsbOpen.Name = "tsbOpen";
            // 
            // tsbSave
            // 
            tsbSave.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            tsbSave.Text = "Lưu báo cáo";
            tsbSave.ToolTipText = "Lưu báo cáo tổng hợp";
            tsbSave.Name = "tsbSave";
            // 
            // tsbSeparator1
            // 
            tsbSeparator1.Name = "tsbSeparator1";
            // 
            // tsbImport
            // 
            tsbImport.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            tsbImport.Text = "Nhập CSV";
            tsbImport.ToolTipText = "Nhập dữ liệu từ file CSV";
            tsbImport.Name = "tsbImport";
            // 
            // tsbExport
            // 
            tsbExport.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            tsbExport.Text = "Xuất CSV";
            tsbExport.ToolTipText = "Xuất danh sách ra file CSV";
            tsbExport.Name = "tsbExport";
            // 
            // tsbSeparator2
            // 
            tsbSeparator2.Name = "tsbSeparator2";
            // 
            // tsbExit
            // 
            tsbExit.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            tsbExit.Text = "Thoát";
            tsbExit.ToolTipText = "Thoát chương trình";
            tsbExit.Name = "tsbExit";
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { lblTotalQuantity, lblTotalValue, lblSpacer, lblClock });
            statusStrip.Location = new Point(0, 658);
            statusStrip.Size = new Size(1000, 22);
            statusStrip.Name = "statusStrip";
            statusStrip.TabIndex = 2;
            // 
            // lblTotalQuantity
            // 
            lblTotalQuantity.BorderSides = ToolStripStatusLabelBorderSides.Right;
            lblTotalQuantity.Text = "Tổng số lượng: 0";
            lblTotalQuantity.Name = "lblTotalQuantity";
            // 
            // lblTotalValue
            // 
            lblTotalValue.BorderSides = ToolStripStatusLabelBorderSides.Right;
            lblTotalValue.Text = "Tổng giá trị kho: 0 ₫";
            lblTotalValue.Name = "lblTotalValue";
            // 
            // lblSpacer
            // 
            lblSpacer.Spring = true;
            lblSpacer.Text = "";
            lblSpacer.Name = "lblSpacer";
            // 
            // lblClock
            // 
            lblClock.Text = "00:00:00";
            lblClock.Name = "lblClock";
            // 
            // grpInput
            // 
            grpInput.Controls.Add(numQuantity);
            grpInput.Controls.Add(lblQuantity);
            grpInput.Controls.Add(txtPrice);
            grpInput.Controls.Add(lblPrice);
            grpInput.Controls.Add(cboCategory);
            grpInput.Controls.Add(lblCategory);
            grpInput.Controls.Add(txtProductName);
            grpInput.Controls.Add(lblProductName);
            grpInput.Controls.Add(txtProductId);
            grpInput.Controls.Add(lblProductId);
            grpInput.Location = new Point(12, 60);
            grpInput.Size = new Size(560, 210);
            grpInput.TabStop = false;
            grpInput.Text = "Thông tin sản phẩm";
            grpInput.Name = "grpInput";
            grpInput.TabIndex = 3;
            // 
            // lblProductId
            // 
            lblProductId.AutoSize = true;
            lblProductId.Location = new Point(20, 33);
            lblProductId.Text = "Mã sản phẩm:";
            lblProductId.Name = "lblProductId";
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(140, 30);
            txtProductId.ReadOnly = true;
            txtProductId.Size = new Size(200, 23);
            txtProductId.TabStop = false;
            txtProductId.TabIndex = 99;
            txtProductId.Name = "txtProductId";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(20, 68);
            lblProductName.Text = "Tên sản phẩm:";
            lblProductName.Name = "lblProductName";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(140, 65);
            txtProductName.MaxLength = 100;
            txtProductName.Size = new Size(390, 23);
            txtProductName.Name = "txtProductName";
            txtProductName.TabIndex = 4;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(20, 103);
            lblCategory.Text = "Loại sản phẩm:";
            lblCategory.Name = "lblCategory";
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(140, 100);
            cboCategory.Size = new Size(200, 23);
            cboCategory.Name = "cboCategory";
            cboCategory.TabIndex = 5;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(20, 138);
            lblPrice.Text = "Đơn giá:";
            lblPrice.Name = "lblPrice";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(140, 135);
            txtPrice.Size = new Size(200, 23);
            txtPrice.TextAlign = HorizontalAlignment.Right;
            txtPrice.Name = "txtPrice";
            txtPrice.TabIndex = 6;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(20, 173);
            lblQuantity.Text = "Số lượng tồn:";
            lblQuantity.Name = "lblQuantity";
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(140, 170);
            numQuantity.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numQuantity.Size = new Size(120, 23);
            numQuantity.TextAlign = HorizontalAlignment.Right;
            numQuantity.ThousandsSeparator = true;
            numQuantity.Name = "numQuantity";
            numQuantity.TabIndex = 7;
            // 
            // grpImage
            // 
            grpImage.Controls.Add(btnChooseImage);
            grpImage.Controls.Add(picProductImage);
            grpImage.Location = new Point(584, 60);
            grpImage.Size = new Size(200, 210);
            grpImage.TabStop = false;
            grpImage.Text = "Ảnh sản phẩm";
            grpImage.Name = "grpImage";
            grpImage.TabIndex = 8;
            // 
            // picProductImage
            // 
            picProductImage.BorderStyle = BorderStyle.FixedSingle;
            picProductImage.Location = new Point(10, 22);
            picProductImage.Size = new Size(180, 140);
            picProductImage.SizeMode = PictureBoxSizeMode.Zoom;
            picProductImage.TabStop = false;
            picProductImage.Name = "picProductImage";
            picProductImage.TabIndex = 9;
            // 
            // btnChooseImage
            // 
            btnChooseImage.Location = new Point(10, 168);
            btnChooseImage.Size = new Size(180, 32);
            btnChooseImage.Text = "Chọn ảnh";
            btnChooseImage.UseVisualStyleBackColor = true;
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.TabIndex = 10;
            // 
            // grpActions
            // 
            grpActions.Controls.Add(btnClear);
            grpActions.Controls.Add(btnDelete);
            grpActions.Controls.Add(btnUpdate);
            grpActions.Controls.Add(btnAdd);
            grpActions.Location = new Point(796, 60);
            grpActions.Size = new Size(192, 210);
            grpActions.TabStop = false;
            grpActions.Text = "Chức năng";
            grpActions.Name = "grpActions";
            grpActions.TabIndex = 11;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(16, 28);
            btnAdd.Size = new Size(160, 36);
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Name = "btnAdd";
            btnAdd.TabIndex = 12;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(16, 70);
            btnUpdate.Size = new Size(160, 36);
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Name = "btnUpdate";
            btnUpdate.TabIndex = 13;
            // 
            // btnDelete
            // 
            btnDelete.CausesValidation = false;
            btnDelete.Location = new Point(16, 112);
            btnDelete.Size = new Size(160, 36);
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Name = "btnDelete";
            btnDelete.TabIndex = 14;
            // 
            // btnClear
            // 
            btnClear.CausesValidation = false;
            btnClear.Location = new Point(16, 154);
            btnClear.Size = new Size(160, 36);
            btnClear.Text = "Làm mới / Hủy";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Name = "btnClear";
            btnClear.TabIndex = 15;
            // 
            // dgvProducts
            // 
            dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProducts.CausesValidation = false;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(12, 282);
            dgvProducts.Size = new Size(976, 370);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.TabIndex = 16;
            // 
            // errProvider
            // 
            errProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errProvider.ContainerControl = this;
            // 
            // tmrClock
            // 
            tmrClock.Interval = 1000;
            // 
            // ofdImage
            // 
            ofdImage.FileName = "";
            ofdImage.Filter = "Hình ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            ofdImage.Title = "Chọn ảnh sản phẩm";
            // 
            // frmInventoryManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 680);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip;
            MaximizeBox = false;
            Name = "frmInventoryManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Phần mềm quản lý kho hàng";
            Controls.Add(dgvProducts);
            Controls.Add(grpActions);
            Controls.Add(grpImage);
            Controls.Add(grpInput);
            Controls.Add(statusStrip);
            Controls.Add(toolStrip);
            Controls.Add(menuStrip);
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)picProductImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)errProvider).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            grpImage.ResumeLayout(false);
            grpImage.PerformLayout();
            grpActions.ResumeLayout(false);
            grpActions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem mnuSystem;
        private ToolStripMenuItem mnuOpenFile;
        private ToolStripMenuItem mnuSaveReport;
        private ToolStripSeparator mnuSeparator1;
        private ToolStripMenuItem mnuExit;
        private ToolStripMenuItem mnuTools;
        private ToolStripMenuItem mnuImportCsv;
        private ToolStripMenuItem mnuExportCsv;
        private ToolStrip toolStrip;
        private ToolStripButton tsbOpen;
        private ToolStripButton tsbSave;
        private ToolStripSeparator tsbSeparator1;
        private ToolStripButton tsbImport;
        private ToolStripButton tsbExport;
        private ToolStripSeparator tsbSeparator2;
        private ToolStripButton tsbExit;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblTotalQuantity;
        private ToolStripStatusLabel lblTotalValue;
        private ToolStripStatusLabel lblSpacer;
        private ToolStripStatusLabel lblClock;
        private GroupBox grpInput;
        private Label lblProductId;
        private TextBox txtProductId;
        private Label lblProductName;
        private TextBox txtProductName;
        private Label lblCategory;
        private ComboBox cboCategory;
        private Label lblPrice;
        private TextBox txtPrice;
        private Label lblQuantity;
        private NumericUpDown numQuantity;
        private GroupBox grpImage;
        private PictureBox picProductImage;
        private Button btnChooseImage;
        private GroupBox grpActions;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private DataGridView dgvProducts;
        private ErrorProvider errProvider;
        private System.Windows.Forms.Timer tmrClock;
        private OpenFileDialog ofdImage;
    }
}
