namespace Bai1_QuanLyThietBi
{
    partial class frmDeviceManager
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
            grpInput = new GroupBox();
            lblDeviceId = new Label();
            txtDeviceId = new TextBox();
            lblDeviceName = new Label();
            txtDeviceName = new TextBox();
            lblCategory = new Label();
            cboCategory = new ComboBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            lblQuantity = new Label();
            numQuantity = new NumericUpDown();
            grpActions = new GroupBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            dgvDevices = new DataGridView();
            errProvider = new ErrorProvider(components);
            grpInput.SuspendLayout();
            grpActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDevices).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errProvider).BeginInit();
            SuspendLayout();
            // 
            // grpInput
            // 
            grpInput.Controls.Add(numQuantity);
            grpInput.Controls.Add(lblQuantity);
            grpInput.Controls.Add(txtPrice);
            grpInput.Controls.Add(lblPrice);
            grpInput.Controls.Add(cboCategory);
            grpInput.Controls.Add(lblCategory);
            grpInput.Controls.Add(txtDeviceName);
            grpInput.Controls.Add(lblDeviceName);
            grpInput.Controls.Add(txtDeviceId);
            grpInput.Controls.Add(lblDeviceId);
            grpInput.Location = new Point(12, 12);
            grpInput.Size = new Size(560, 210);
            grpInput.TabStop = false;
            grpInput.Text = "Thông tin thiết bị";
            grpInput.Name = "grpInput";
            grpInput.TabIndex = 0;
            // 
            // lblDeviceId
            // 
            lblDeviceId.AutoSize = true;
            lblDeviceId.Location = new Point(20, 33);
            lblDeviceId.Text = "Mã thiết bị:";
            lblDeviceId.Name = "lblDeviceId";
            // 
            // txtDeviceId
            // 
            txtDeviceId.Location = new Point(140, 30);
            txtDeviceId.ReadOnly = true;
            txtDeviceId.Size = new Size(200, 23);
            txtDeviceId.TabStop = false;
            txtDeviceId.TabIndex = 99;
            txtDeviceId.Name = "txtDeviceId";
            // 
            // lblDeviceName
            // 
            lblDeviceName.AutoSize = true;
            lblDeviceName.Location = new Point(20, 68);
            lblDeviceName.Text = "Tên thiết bị:";
            lblDeviceName.Name = "lblDeviceName";
            // 
            // txtDeviceName
            // 
            txtDeviceName.Location = new Point(140, 65);
            txtDeviceName.MaxLength = 100;
            txtDeviceName.Size = new Size(390, 23);
            txtDeviceName.Name = "txtDeviceName";
            txtDeviceName.TabIndex = 1;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(20, 103);
            lblCategory.Text = "Loại thiết bị:";
            lblCategory.Name = "lblCategory";
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(140, 100);
            cboCategory.Size = new Size(200, 23);
            cboCategory.Name = "cboCategory";
            cboCategory.TabIndex = 2;
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
            txtPrice.TabIndex = 3;
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
            numQuantity.TabIndex = 4;
            // 
            // grpActions
            // 
            grpActions.Controls.Add(btnClear);
            grpActions.Controls.Add(btnDelete);
            grpActions.Controls.Add(btnUpdate);
            grpActions.Controls.Add(btnAdd);
            grpActions.Location = new Point(590, 12);
            grpActions.Size = new Size(298, 210);
            grpActions.TabStop = false;
            grpActions.Text = "Chức năng";
            grpActions.Name = "grpActions";
            grpActions.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(24, 30);
            btnAdd.Size = new Size(250, 36);
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Name = "btnAdd";
            btnAdd.TabIndex = 6;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(24, 72);
            btnUpdate.Size = new Size(250, 36);
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Name = "btnUpdate";
            btnUpdate.TabIndex = 7;
            // 
            // btnDelete
            // 
            btnDelete.CausesValidation = false;
            btnDelete.Location = new Point(24, 114);
            btnDelete.Size = new Size(250, 36);
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Name = "btnDelete";
            btnDelete.TabIndex = 8;
            // 
            // btnClear
            // 
            btnClear.CausesValidation = false;
            btnClear.Location = new Point(24, 156);
            btnClear.Size = new Size(250, 36);
            btnClear.Text = "Làm mới / Hủy";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Name = "btnClear";
            btnClear.TabIndex = 9;
            // 
            // dgvDevices
            // 
            dgvDevices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDevices.CausesValidation = false;
            dgvDevices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDevices.Location = new Point(12, 230);
            dgvDevices.Size = new Size(876, 358);
            dgvDevices.Name = "dgvDevices";
            dgvDevices.TabIndex = 10;
            // 
            // errProvider
            // 
            errProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errProvider.ContainerControl = this;
            // 
            // frmDeviceManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmDeviceManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý danh mục thiết bị điện tử";
            Controls.Add(dgvDevices);
            Controls.Add(grpActions);
            Controls.Add(grpInput);
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDevices).EndInit();
            ((System.ComponentModel.ISupportInitialize)errProvider).EndInit();
            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            grpActions.ResumeLayout(false);
            grpActions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpInput;
        private Label lblDeviceId;
        private TextBox txtDeviceId;
        private Label lblDeviceName;
        private TextBox txtDeviceName;
        private Label lblCategory;
        private ComboBox cboCategory;
        private Label lblPrice;
        private TextBox txtPrice;
        private Label lblQuantity;
        private NumericUpDown numQuantity;
        private GroupBox grpActions;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private DataGridView dgvDevices;
        private ErrorProvider errProvider;
    }
}
