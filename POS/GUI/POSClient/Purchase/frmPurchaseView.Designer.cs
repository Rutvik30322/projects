
namespace POSClient
{
    partial class frmPurchaseView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchaseView));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpShortcut = new System.Windows.Forms.TableLayoutPanel();
            this.btnSReset = new System.Windows.Forms.Button();
            this.btnSGetData = new System.Windows.Forms.Button();
            this.btnSPrintBarcode = new System.Windows.Forms.Button();
            this.lblShortcut2 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.btnHeader = new System.Windows.Forms.Button();
            this.dgvPurchaseView = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.lblPurchaseNo = new System.Windows.Forms.Label();
            this.cmbPurchaseNo = new System.Windows.Forms.ComboBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.pbBarcode = new System.Windows.Forms.PictureBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.chkStockAvaliable = new System.Windows.Forms.CheckBox();
            this.btnTotalSelectedCount = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tlpSelectedRowCount = new System.Windows.Forms.TableLayoutPanel();
            this.btnSelectedCount = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.tlpShortcut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBarcode)).BeginInit();
            this.tlpSelectedRowCount.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 12;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.Controls.Add(this.tlpShortcut, 1, 9);
            this.tlpMain.Controls.Add(this.btnReset, 8, 1);
            this.tlpMain.Controls.Add(this.btnPrint, 9, 1);
            this.tlpMain.Controls.Add(this.dtpToDate, 4, 2);
            this.tlpMain.Controls.Add(this.label2, 8, 9);
            this.tlpMain.Controls.Add(this.lblToDate, 3, 2);
            this.tlpMain.Controls.Add(this.dtpFromDate, 2, 2);
            this.tlpMain.Controls.Add(this.lblFromDate, 1, 2);
            this.tlpMain.Controls.Add(this.btnHeader, 1, 0);
            this.tlpMain.Controls.Add(this.dgvPurchaseView, 1, 6);
            this.tlpMain.Controls.Add(this.txtSearch, 5, 2);
            this.tlpMain.Controls.Add(this.lblMaterial, 2, 4);
            this.tlpMain.Controls.Add(this.cmbMaterial, 3, 4);
            this.tlpMain.Controls.Add(this.lblPurchaseNo, 4, 4);
            this.tlpMain.Controls.Add(this.cmbPurchaseNo, 5, 4);
            this.tlpMain.Controls.Add(this.lblSupplier, 6, 4);
            this.tlpMain.Controls.Add(this.cmbSupplier, 10, 4);
            this.tlpMain.Controls.Add(this.pbBarcode, 8, 4);
            this.tlpMain.Controls.Add(this.btnGetData, 7, 1);
            this.tlpMain.Controls.Add(this.chkStockAvaliable, 1, 4);
            this.tlpMain.Controls.Add(this.btnTotalSelectedCount, 10, 2);
            this.tlpMain.Controls.Add(this.tlpSelectedRowCount, 1, 7);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 11;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(1162, 453);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpShortcut
            // 
            this.tlpShortcut.ColumnCount = 7;
            this.tlpMain.SetColumnSpan(this.tlpShortcut, 7);
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpShortcut.Controls.Add(this.btnSReset, 2, 0);
            this.tlpShortcut.Controls.Add(this.btnSGetData, 1, 0);
            this.tlpShortcut.Controls.Add(this.btnSPrintBarcode, 3, 0);
            this.tlpShortcut.Controls.Add(this.lblShortcut2, 0, 0);
            this.tlpShortcut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpShortcut.Location = new System.Drawing.Point(18, 406);
            this.tlpShortcut.Name = "tlpShortcut";
            this.tlpShortcut.RowCount = 3;
            this.tlpMain.SetRowSpan(this.tlpShortcut, 2);
            this.tlpShortcut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpShortcut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpShortcut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpShortcut.Size = new System.Drawing.Size(706, 44);
            this.tlpShortcut.TabIndex = 0;
            // 
            // btnSReset
            // 
            this.btnSReset.BackColor = System.Drawing.Color.PeachPuff;
            this.btnSReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSReset.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSReset.ForeColor = System.Drawing.Color.Navy;
            this.btnSReset.Location = new System.Drawing.Point(203, 3);
            this.btnSReset.Name = "btnSReset";
            this.tlpShortcut.SetRowSpan(this.btnSReset, 2);
            this.btnSReset.Size = new System.Drawing.Size(134, 29);
            this.btnSReset.TabIndex = 0;
            this.btnSReset.Text = "Reset : Alt + R";
            this.btnSReset.UseVisualStyleBackColor = false;
            // 
            // btnSGetData
            // 
            this.btnSGetData.BackColor = System.Drawing.Color.MistyRose;
            this.btnSGetData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSGetData.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSGetData.ForeColor = System.Drawing.Color.Navy;
            this.btnSGetData.Location = new System.Drawing.Point(63, 3);
            this.btnSGetData.Name = "btnSGetData";
            this.tlpShortcut.SetRowSpan(this.btnSGetData, 2);
            this.btnSGetData.Size = new System.Drawing.Size(134, 29);
            this.btnSGetData.TabIndex = 0;
            this.btnSGetData.Text = "Get Data : Alt + G";
            this.btnSGetData.UseVisualStyleBackColor = false;
            // 
            // btnSPrintBarcode
            // 
            this.btnSPrintBarcode.BackColor = System.Drawing.Color.Cornsilk;
            this.btnSPrintBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSPrintBarcode.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSPrintBarcode.ForeColor = System.Drawing.Color.Navy;
            this.btnSPrintBarcode.Location = new System.Drawing.Point(343, 3);
            this.btnSPrintBarcode.Name = "btnSPrintBarcode";
            this.tlpShortcut.SetRowSpan(this.btnSPrintBarcode, 2);
            this.btnSPrintBarcode.Size = new System.Drawing.Size(134, 29);
            this.btnSPrintBarcode.TabIndex = 0;
            this.btnSPrintBarcode.Text = "Print Barcode : Alt + P";
            this.btnSPrintBarcode.UseVisualStyleBackColor = false;
            // 
            // lblShortcut2
            // 
            this.lblShortcut2.AutoSize = true;
            this.lblShortcut2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShortcut2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShortcut2.Location = new System.Drawing.Point(3, 0);
            this.lblShortcut2.Name = "lblShortcut2";
            this.lblShortcut2.Size = new System.Drawing.Size(54, 30);
            this.lblShortcut2.TabIndex = 0;
            this.lblShortcut2.Text = "Shortcut";
            this.lblShortcut2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnReset
            // 
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReset.Image = global::POSClient.Properties.Resources.refresh_24;
            this.btnReset.Location = new System.Drawing.Point(730, 43);
            this.btnReset.Name = "btnReset";
            this.tlpMain.SetRowSpan(this.btnReset, 3);
            this.btnReset.Size = new System.Drawing.Size(114, 34);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = " &Reset";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrint.Image = global::POSClient.Properties.Resources.printer_24;
            this.btnPrint.Location = new System.Drawing.Point(850, 43);
            this.btnPrint.Name = "btnPrint";
            this.tlpMain.SetRowSpan(this.btnPrint, 3);
            this.btnPrint.Size = new System.Drawing.Size(114, 34);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = " &Print Barcode";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click_1);
            // 
            // dtpToDate
            // 
            this.dtpToDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.CustomFormat = "dd-MM-yyyy";
            this.dtpToDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpToDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(273, 50);
            this.dtpToDate.Name = "dtpToDate";
            this.tlpMain.SetRowSpan(this.dtpToDate, 2);
            this.dtpToDate.Size = new System.Drawing.Size(114, 25);
            this.dtpToDate.TabIndex = 5;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblToDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblToDate.Location = new System.Drawing.Point(213, 47);
            this.lblToDate.Name = "lblToDate";
            this.tlpMain.SetRowSpan(this.lblToDate, 2);
            this.lblToDate.Size = new System.Drawing.Size(54, 33);
            this.lblToDate.TabIndex = 4;
            this.lblToDate.Text = "To Date";
            this.lblToDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.CustomFormat = "dd-MM-yyyy";
            this.dtpFromDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFromDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(93, 50);
            this.dtpFromDate.Name = "dtpFromDate";
            this.tlpMain.SetRowSpan(this.dtpFromDate, 2);
            this.dtpFromDate.Size = new System.Drawing.Size(114, 25);
            this.dtpFromDate.TabIndex = 3;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFromDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFromDate.Location = new System.Drawing.Point(18, 47);
            this.lblFromDate.Name = "lblFromDate";
            this.tlpMain.SetRowSpan(this.lblFromDate, 2);
            this.lblFromDate.Size = new System.Drawing.Size(69, 33);
            this.lblFromDate.TabIndex = 2;
            this.lblFromDate.Text = "From Date";
            this.lblFromDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnHeader
            // 
            this.tlpMain.SetColumnSpan(this.btnHeader, 10);
            this.btnHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHeader.Location = new System.Drawing.Point(18, 3);
            this.btnHeader.Name = "btnHeader";
            this.btnHeader.Size = new System.Drawing.Size(1126, 34);
            this.btnHeader.TabIndex = 1;
            this.btnHeader.Text = "Purchase View";
            this.btnHeader.UseVisualStyleBackColor = true;
            // 
            // dgvPurchaseView
            // 
            this.dgvPurchaseView.AllowUserToAddRows = false;
            this.dgvPurchaseView.AllowUserToDeleteRows = false;
            this.dgvPurchaseView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlpMain.SetColumnSpan(this.dgvPurchaseView, 10);
            this.dgvPurchaseView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPurchaseView.Location = new System.Drawing.Point(18, 108);
            this.dgvPurchaseView.Name = "dgvPurchaseView";
            this.dgvPurchaseView.ReadOnly = true;
            this.dgvPurchaseView.Size = new System.Drawing.Size(1126, 252);
            this.dgvPurchaseView.TabIndex = 10;
            this.dgvPurchaseView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvPurchaseView_CellBeginEdit);
            this.dgvPurchaseView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchaseView_CellClick);
            this.dgvPurchaseView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchaseView_CellContentClick);
            this.dgvPurchaseView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchaseView_CellDoubleClick);
            this.dgvPurchaseView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchaseView_CellEndEdit);
            this.dgvPurchaseView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchaseView_CellValueChanged);
            this.dgvPurchaseView.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvPurchaseView_CurrentCellDirtyStateChanged);
            this.dgvPurchaseView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvPurchaseView_EditingControlShowing);
            this.dgvPurchaseView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPurchaseView_KeyDown);
            // 
            // txtSearch
            // 
            this.tlpMain.SetColumnSpan(this.txtSearch, 2);
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSearch.Location = new System.Drawing.Point(393, 50);
            this.txtSearch.Name = "txtSearch";
            this.tlpMain.SetRowSpan(this.txtSearch, 2);
            this.txtSearch.Size = new System.Drawing.Size(211, 25);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.Enter += new System.EventHandler(this.RemovePlaceHolder);
            this.txtSearch.Leave += new System.EventHandler(this.AddPlaceHolder);
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaterial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMaterial.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblMaterial.Location = new System.Drawing.Point(93, 80);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(114, 20);
            this.lblMaterial.TabIndex = 45;
            this.lblMaterial.Text = "Material";
            this.lblMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMaterial.Visible = false;
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbMaterial.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(213, 83);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(54, 25);
            this.cmbMaterial.TabIndex = 46;
            this.cmbMaterial.Visible = false;
            // 
            // lblPurchaseNo
            // 
            this.lblPurchaseNo.AutoSize = true;
            this.lblPurchaseNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPurchaseNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPurchaseNo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPurchaseNo.Location = new System.Drawing.Point(273, 80);
            this.lblPurchaseNo.Name = "lblPurchaseNo";
            this.lblPurchaseNo.Size = new System.Drawing.Size(114, 20);
            this.lblPurchaseNo.TabIndex = 48;
            this.lblPurchaseNo.Text = "Purchase No.";
            this.lblPurchaseNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPurchaseNo.Visible = false;
            // 
            // cmbPurchaseNo
            // 
            this.cmbPurchaseNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbPurchaseNo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbPurchaseNo.FormattingEnabled = true;
            this.cmbPurchaseNo.Location = new System.Drawing.Point(393, 83);
            this.cmbPurchaseNo.Name = "cmbPurchaseNo";
            this.cmbPurchaseNo.Size = new System.Drawing.Size(64, 25);
            this.cmbPurchaseNo.TabIndex = 47;
            this.cmbPurchaseNo.Visible = false;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSupplier.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplier.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSupplier.Location = new System.Drawing.Point(463, 80);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(141, 20);
            this.lblSupplier.TabIndex = 30;
            this.lblSupplier.Text = "Supplier";
            this.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSupplier.Visible = false;
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.BackColor = System.Drawing.SystemColors.Window;
            this.cmbSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSupplier.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.IntegralHeight = false;
            this.cmbSupplier.Location = new System.Drawing.Point(970, 83);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(174, 25);
            this.cmbSupplier.TabIndex = 31;
            this.cmbSupplier.Visible = false;
            // 
            // pbBarcode
            // 
            this.pbBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBarcode.Location = new System.Drawing.Point(730, 83);
            this.pbBarcode.Name = "pbBarcode";
            this.pbBarcode.Size = new System.Drawing.Size(114, 14);
            this.pbBarcode.TabIndex = 33;
            this.pbBarcode.TabStop = false;
            this.pbBarcode.Visible = false;
            // 
            // btnGetData
            // 
            this.btnGetData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetData.Image = global::POSClient.Properties.Resources.getdata_24;
            this.btnGetData.Location = new System.Drawing.Point(610, 43);
            this.btnGetData.Name = "btnGetData";
            this.tlpMain.SetRowSpan(this.btnGetData, 3);
            this.btnGetData.Size = new System.Drawing.Size(114, 34);
            this.btnGetData.TabIndex = 7;
            this.btnGetData.Text = " &Get Data";
            this.btnGetData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGetData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click_2);
            // 
            // chkStockAvaliable
            // 
            this.chkStockAvaliable.AutoSize = true;
            this.chkStockAvaliable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkStockAvaliable.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStockAvaliable.Location = new System.Drawing.Point(18, 83);
            this.chkStockAvaliable.Name = "chkStockAvaliable";
            this.chkStockAvaliable.Size = new System.Drawing.Size(69, 14);
            this.chkStockAvaliable.TabIndex = 52;
            this.chkStockAvaliable.Text = "Stock Avaliable";
            this.chkStockAvaliable.UseVisualStyleBackColor = true;
            this.chkStockAvaliable.Visible = false;
            // 
            // btnTotalSelectedCount
            // 
            this.btnTotalSelectedCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btnTotalSelectedCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTotalSelectedCount.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTotalSelectedCount.Location = new System.Drawing.Point(970, 50);
            this.btnTotalSelectedCount.Name = "btnTotalSelectedCount";
            this.btnTotalSelectedCount.Size = new System.Drawing.Size(174, 24);
            this.btnTotalSelectedCount.TabIndex = 44;
            this.btnTotalSelectedCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTotalSelectedCount.UseVisualStyleBackColor = false;
            this.btnTotalSelectedCount.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(37)))), ((int)(((byte)(62)))));
            this.label2.Location = new System.Drawing.Point(730, 403);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 30);
            this.label2.TabIndex = 49;
            this.label2.Text = "Note : Double-click on the \"Sale Price\" cell to edit the price. And to print the " +
    "barcode, select the row using the selection box.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Visible = false;
            // 
            // tlpSelectedRowCount
            // 
            this.tlpSelectedRowCount.ColumnCount = 2;
            this.tlpMain.SetColumnSpan(this.tlpSelectedRowCount, 2);
            this.tlpSelectedRowCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tlpSelectedRowCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSelectedRowCount.Controls.Add(this.btnSelectedCount, 0, 0);
            this.tlpSelectedRowCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSelectedRowCount.Location = new System.Drawing.Point(18, 366);
            this.tlpSelectedRowCount.Name = "tlpSelectedRowCount";
            this.tlpSelectedRowCount.RowCount = 1;
            this.tlpMain.SetRowSpan(this.tlpSelectedRowCount, 2);
            this.tlpSelectedRowCount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSelectedRowCount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSelectedRowCount.Size = new System.Drawing.Size(189, 34);
            this.tlpSelectedRowCount.TabIndex = 53;
            // 
            // btnSelectedCount
            // 
            this.btnSelectedCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btnSelectedCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectedCount.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectedCount.Location = new System.Drawing.Point(3, 3);
            this.btnSelectedCount.Name = "btnSelectedCount";
            this.btnSelectedCount.Size = new System.Drawing.Size(162, 28);
            this.btnSelectedCount.TabIndex = 1;
            this.btnSelectedCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectedCount.UseVisualStyleBackColor = false;
            // 
            // frmPurchaseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 453);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPurchaseView";
            this.Text = "Purchase View";
            this.Load += new System.EventHandler(this.frmPurchaseView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPurchaseView_KeyDown);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpShortcut.ResumeLayout(false);
            this.tlpShortcut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBarcode)).EndInit();
            this.tlpSelectedRowCount.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnHeader;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.DataGridView dgvPurchaseView;
        private System.Windows.Forms.PictureBox pbBarcode;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Button btnTotalSelectedCount;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.ComboBox cmbPurchaseNo;
        private System.Windows.Forms.Label lblPurchaseNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckBox chkStockAvaliable;
        private System.Windows.Forms.TableLayoutPanel tlpShortcut;
        private System.Windows.Forms.Button btnSReset;
        private System.Windows.Forms.Button btnSGetData;
        private System.Windows.Forms.Button btnSPrintBarcode;
        private System.Windows.Forms.Label lblShortcut2;
        private System.Windows.Forms.TableLayoutPanel tlpSelectedRowCount;
        private System.Windows.Forms.Button btnSelectedCount;
    }
}