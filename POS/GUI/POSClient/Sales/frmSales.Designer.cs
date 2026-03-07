namespace POSClient
{
    partial class frmSales
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
    

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label label1;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.cmbDiscountType = new System.Windows.Forms.ComboBox();
            this.lblDiscountType = new System.Windows.Forms.Label();
            this.txtTotalItems = new System.Windows.Forms.TextBox();
            this.lblTotalItems = new System.Windows.Forms.Label();
            this.btnHeader = new System.Windows.Forms.Button();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.txtGrossTotal = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtNetTotal = new System.Windows.Forms.TextBox();
            this.lblGrossTotal = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblNetTotal = new System.Windows.Forms.Label();
            this.dgvSalesItem = new System.Windows.Forms.DataGridView();
            this.SrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarcodeValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArticleNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Classification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPaymentMode = new System.Windows.Forms.Label();
            this.lblAmtCollected = new System.Windows.Forms.Label();
            this.lblAmtReturned = new System.Windows.Forms.Label();
            this.cmbPaymentMode = new System.Windows.Forms.ComboBox();
            this.txtAmtCollected = new System.Windows.Forms.TextBox();
            this.txtAmountReturn = new System.Windows.Forms.TextBox();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.lblCustMobileNo = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblInvoiceDt = new System.Windows.Forms.Label();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.tlpOptButton = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnViewInvoice = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSavePrint = new System.Windows.Forms.Button();
            this.btnReprint = new System.Windows.Forms.Button();
            this.cmbPrinter = new System.Windows.Forms.ComboBox();
            this.tlpShortCut = new System.Windows.Forms.TableLayoutPanel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblShortcut = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesItem)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.tlpOptButton.SuspendLayout();
            this.tlpShortCut.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 15;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.Controls.Add(this.cmbDiscountType, 12, 6);
            this.tlpMain.Controls.Add(this.lblDiscountType, 11, 6);
            this.tlpMain.Controls.Add(this.txtTotalItems, 2, 5);
            this.tlpMain.Controls.Add(this.lblTotalItems, 1, 5);
            this.tlpMain.Controls.Add(this.btnHeader, 1, 0);
            this.tlpMain.Controls.Add(this.lblInvoiceNo, 1, 2);
            this.tlpMain.Controls.Add(this.txtInvoiceNo, 2, 2);
            this.tlpMain.Controls.Add(this.txtGrossTotal, 12, 5);
            this.tlpMain.Controls.Add(this.txtDiscount, 12, 7);
            this.tlpMain.Controls.Add(this.txtNetTotal, 12, 8);
            this.tlpMain.Controls.Add(this.lblGrossTotal, 11, 5);
            this.tlpMain.Controls.Add(this.lblDiscount, 11, 7);
            this.tlpMain.Controls.Add(this.lblNetTotal, 11, 8);
            this.tlpMain.Controls.Add(this.dgvSalesItem, 1, 4);
            this.tlpMain.Controls.Add(this.lblPaymentMode, 9, 5);
            this.tlpMain.Controls.Add(this.lblAmtCollected, 9, 6);
            this.tlpMain.Controls.Add(this.lblAmtReturned, 9, 7);
            this.tlpMain.Controls.Add(this.cmbPaymentMode, 10, 5);
            this.tlpMain.Controls.Add(this.txtAmtCollected, 10, 6);
            this.tlpMain.Controls.Add(this.txtAmountReturn, 10, 7);
            this.tlpMain.Controls.Add(this.txtMobileNo, 8, 5);
            this.tlpMain.Controls.Add(this.txtCustName, 8, 6);
            this.tlpMain.Controls.Add(this.lblCustMobileNo, 7, 5);
            this.tlpMain.Controls.Add(this.lblCustomerName, 7, 6);
            this.tlpMain.Controls.Add(this.lblInvoiceDt, 3, 2);
            this.tlpMain.Controls.Add(this.dtpInvoiceDate, 4, 2);
            this.tlpMain.Controls.Add(this.lblBarcode, 5, 2);
            this.tlpMain.Controls.Add(this.txtBarcode, 6, 2);
            this.tlpMain.Controls.Add(this.pnlButtons, 13, 1);
            this.tlpMain.Controls.Add(this.tlpShortCut, 1, 9);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 10;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpMain.Size = new System.Drawing.Size(1453, 450);
            this.tlpMain.TabIndex = 0;
            // 
            // cmbDiscountType
            // 
            this.cmbDiscountType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDiscountType.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbDiscountType.FormattingEnabled = true;
            this.cmbDiscountType.Location = new System.Drawing.Point(1161, 318);
            this.cmbDiscountType.Name = "cmbDiscountType";
            this.cmbDiscountType.Size = new System.Drawing.Size(144, 25);
            this.cmbDiscountType.TabIndex = 11;
            this.cmbDiscountType.SelectedIndexChanged += new System.EventHandler(this.cmbDiscountType_SelectedIndexChanged);
            // 
            // lblDiscountType
            // 
            this.lblDiscountType.AutoSize = true;
            this.lblDiscountType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDiscountType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiscountType.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDiscountType.Location = new System.Drawing.Point(1041, 315);
            this.lblDiscountType.Name = "lblDiscountType";
            this.lblDiscountType.Size = new System.Drawing.Size(114, 30);
            this.lblDiscountType.TabIndex = 10;
            this.lblDiscountType.Text = "Disc. Type";
            this.lblDiscountType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotalItems
            // 
            this.txtTotalItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalItems.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTotalItems.Enabled = false;
            this.txtTotalItems.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.txtTotalItems.Location = new System.Drawing.Point(98, 288);
            this.txtTotalItems.Name = "txtTotalItems";
            this.txtTotalItems.Size = new System.Drawing.Size(92, 23);
            this.txtTotalItems.TabIndex = 27;
            this.txtTotalItems.Text = "0";
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.AutoSize = true;
            this.lblTotalItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalItems.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalItems.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTotalItems.Location = new System.Drawing.Point(18, 285);
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(74, 30);
            this.lblTotalItems.TabIndex = 26;
            this.lblTotalItems.Text = "Total Items";
            this.lblTotalItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnHeader
            // 
            this.btnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.tlpMain.SetColumnSpan(this.btnHeader, 13);
            this.btnHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnHeader.Location = new System.Drawing.Point(18, 3);
            this.btnHeader.Name = "btnHeader";
            this.btnHeader.Size = new System.Drawing.Size(1417, 34);
            this.btnHeader.TabIndex = 0;
            this.btnHeader.Text = "Sales";
            this.btnHeader.UseVisualStyleBackColor = false;
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInvoiceNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceNo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblInvoiceNo.Location = new System.Drawing.Point(18, 47);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(74, 35);
            this.lblInvoiceNo.TabIndex = 1;
            this.lblInvoiceNo.Text = "Invoice No.";
            this.lblInvoiceNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInvoiceNo.Enabled = false;
            this.txtInvoiceNo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtInvoiceNo.Location = new System.Drawing.Point(98, 50);
            this.txtInvoiceNo.MaxLength = 250;
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(144, 25);
            this.txtInvoiceNo.TabIndex = 2;
            this.txtInvoiceNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvoiceNo_KeyDown);
            // 
            // txtGrossTotal
            // 
            this.txtGrossTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGrossTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGrossTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtGrossTotal.Location = new System.Drawing.Point(1161, 288);
            this.txtGrossTotal.MaxLength = 18;
            this.txtGrossTotal.Name = "txtGrossTotal";
            this.txtGrossTotal.ReadOnly = true;
            this.txtGrossTotal.Size = new System.Drawing.Size(144, 25);
            this.txtGrossTotal.TabIndex = 9;
            this.txtGrossTotal.Text = "0.00";
            this.txtGrossTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGrossTotal_KeyPress);
            // 
            // txtDiscount
            // 
            this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDiscount.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDiscount.Location = new System.Drawing.Point(1161, 348);
            this.txtDiscount.MaxLength = 18;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(144, 25);
            this.txtDiscount.TabIndex = 13;
            this.txtDiscount.Text = "0.00";
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            this.txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscount_KeyPress);
            // 
            // txtNetTotal
            // 
            this.txtNetTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNetTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNetTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtNetTotal.Location = new System.Drawing.Point(1161, 378);
            this.txtNetTotal.MaxLength = 18;
            this.txtNetTotal.Name = "txtNetTotal";
            this.txtNetTotal.Size = new System.Drawing.Size(144, 25);
            this.txtNetTotal.TabIndex = 15;
            this.txtNetTotal.Text = "0.00";
            this.txtNetTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNetTotal_KeyPress);
            // 
            // lblGrossTotal
            // 
            this.lblGrossTotal.AutoSize = true;
            this.lblGrossTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGrossTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGrossTotal.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblGrossTotal.Location = new System.Drawing.Point(1041, 285);
            this.lblGrossTotal.Name = "lblGrossTotal";
            this.lblGrossTotal.Size = new System.Drawing.Size(114, 30);
            this.lblGrossTotal.TabIndex = 8;
            this.lblGrossTotal.Text = "Gross Total (₹)";
            this.lblGrossTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiscount.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDiscount.Location = new System.Drawing.Point(1041, 345);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(114, 30);
            this.lblDiscount.TabIndex = 12;
            this.lblDiscount.Text = "Discount (₹)";
            this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNetTotal
            // 
            this.lblNetTotal.AutoSize = true;
            this.lblNetTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNetTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNetTotal.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNetTotal.Location = new System.Drawing.Point(1041, 375);
            this.lblNetTotal.Name = "lblNetTotal";
            this.lblNetTotal.Size = new System.Drawing.Size(114, 30);
            this.lblNetTotal.TabIndex = 14;
            this.lblNetTotal.Text = "Net Total (₹)";
            this.lblNetTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvSalesItem
            // 
            this.dgvSalesItem.AllowUserToAddRows = false;
            this.dgvSalesItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSalesItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalesItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SrNo,
            this.InventoryId,
            this.BarcodeValue,
            this.Material,
            this.ArticleNo,
            this.Classification,
            this.Size,
            this.Color,
            this.HSN,
            this.Rate,
            this.Qty});
            this.tlpMain.SetColumnSpan(this.dgvSalesItem, 12);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalesItem.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSalesItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalesItem.EnableHeadersVisualStyles = false;
            this.dgvSalesItem.Location = new System.Drawing.Point(18, 88);
            this.dgvSalesItem.Name = "dgvSalesItem";
            this.dgvSalesItem.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSalesItem.RowHeadersVisible = false;
            this.dgvSalesItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSalesItem.Size = new System.Drawing.Size(1287, 194);
            this.dgvSalesItem.TabIndex = 7;
            this.dgvSalesItem.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvSalesItem_CellBeginEdit);
            this.dgvSalesItem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesItem_CellDoubleClick);
            this.dgvSalesItem.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesItem_CellEndEdit);
            this.dgvSalesItem.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvSalesItem_CellValidating);
            this.dgvSalesItem.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvSalesItem_EditingControlShowing);
            this.dgvSalesItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSalesItem_KeyDown);
            // 
            // SrNo
            // 
            this.SrNo.HeaderText = "Sr. No.";
            this.SrNo.Name = "SrNo";
            this.SrNo.ReadOnly = true;
            this.SrNo.Width = 55;
            // 
            // InventoryId
            // 
            this.InventoryId.HeaderText = "InventoryId";
            this.InventoryId.Name = "InventoryId";
            this.InventoryId.ReadOnly = true;
            this.InventoryId.Visible = false;
            // 
            // BarcodeValue
            // 
            this.BarcodeValue.HeaderText = "Barcode";
            this.BarcodeValue.Name = "BarcodeValue";
            this.BarcodeValue.ReadOnly = true;
            this.BarcodeValue.Visible = false;
            // 
            // Material
            // 
            this.Material.HeaderText = "Material";
            this.Material.Name = "Material";
            this.Material.ReadOnly = true;
            this.Material.Width = 256;
            // 
            // ArticleNo
            // 
            this.ArticleNo.HeaderText = "ArticleNo";
            this.ArticleNo.Name = "ArticleNo";
            this.ArticleNo.ReadOnly = true;
            this.ArticleNo.Width = 200;
            // 
            // Classification
            // 
            this.Classification.HeaderText = "Classification";
            this.Classification.Name = "Classification";
            this.Classification.ReadOnly = true;
            this.Classification.Width = 200;
            // 
            // Size
            // 
            this.Size.HeaderText = "Size";
            this.Size.Name = "Size";
            this.Size.ReadOnly = true;
            this.Size.Width = 120;
            // 
            // Color
            // 
            this.Color.HeaderText = "Color";
            this.Color.Name = "Color";
            this.Color.ReadOnly = true;
            this.Color.Width = 200;
            // 
            // HSN
            // 
            this.HSN.HeaderText = "HSN";
            this.HSN.Name = "HSN";
            this.HSN.ReadOnly = true;
            this.HSN.Width = 150;
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            this.Rate.ReadOnly = true;
            this.Rate.Width = 150;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Quantity";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // lblPaymentMode
            // 
            this.lblPaymentMode.AutoSize = true;
            this.lblPaymentMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPaymentMode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPaymentMode.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPaymentMode.Location = new System.Drawing.Point(751, 285);
            this.lblPaymentMode.Name = "lblPaymentMode";
            this.lblPaymentMode.Size = new System.Drawing.Size(134, 30);
            this.lblPaymentMode.TabIndex = 20;
            this.lblPaymentMode.Text = "Payment Mode";
            this.lblPaymentMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAmtCollected
            // 
            this.lblAmtCollected.AutoSize = true;
            this.lblAmtCollected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAmtCollected.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAmtCollected.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblAmtCollected.Location = new System.Drawing.Point(751, 315);
            this.lblAmtCollected.Name = "lblAmtCollected";
            this.lblAmtCollected.Size = new System.Drawing.Size(134, 30);
            this.lblAmtCollected.TabIndex = 22;
            this.lblAmtCollected.Text = "Amount Collected (₹)";
            this.lblAmtCollected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAmtReturned
            // 
            this.lblAmtReturned.AutoSize = true;
            this.lblAmtReturned.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAmtReturned.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAmtReturned.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblAmtReturned.Location = new System.Drawing.Point(751, 345);
            this.lblAmtReturned.Name = "lblAmtReturned";
            this.lblAmtReturned.Size = new System.Drawing.Size(134, 30);
            this.lblAmtReturned.TabIndex = 24;
            this.lblAmtReturned.Text = "Amount Returned (₹)";
            this.lblAmtReturned.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbPaymentMode
            // 
            this.cmbPaymentMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbPaymentMode.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbPaymentMode.FormattingEnabled = true;
            this.cmbPaymentMode.Location = new System.Drawing.Point(891, 288);
            this.cmbPaymentMode.Name = "cmbPaymentMode";
            this.cmbPaymentMode.Size = new System.Drawing.Size(144, 25);
            this.cmbPaymentMode.TabIndex = 21;
            // 
            // txtAmtCollected
            // 
            this.txtAmtCollected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmtCollected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAmtCollected.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAmtCollected.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtAmtCollected.Location = new System.Drawing.Point(891, 318);
            this.txtAmtCollected.MaxLength = 18;
            this.txtAmtCollected.Name = "txtAmtCollected";
            this.txtAmtCollected.Size = new System.Drawing.Size(144, 25);
            this.txtAmtCollected.TabIndex = 23;
            this.txtAmtCollected.Text = "0.00";
            this.txtAmtCollected.TextChanged += new System.EventHandler(this.txtAmtCollected_TextChanged);
            this.txtAmtCollected.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmtCollected_KeyPress);
            // 
            // txtAmountReturn
            // 
            this.txtAmountReturn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmountReturn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAmountReturn.Enabled = false;
            this.txtAmountReturn.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAmountReturn.Location = new System.Drawing.Point(891, 348);
            this.txtAmountReturn.MaxLength = 18;
            this.txtAmountReturn.Name = "txtAmountReturn";
            this.txtAmountReturn.Size = new System.Drawing.Size(144, 25);
            this.txtAmountReturn.TabIndex = 25;
            this.txtAmountReturn.Text = "0.00";
            this.txtAmountReturn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmountReturn_KeyPress);
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMobileNo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMobileNo.Location = new System.Drawing.Point(571, 288);
            this.txtMobileNo.MaxLength = 10;
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(174, 25);
            this.txtMobileNo.TabIndex = 17;
            this.txtMobileNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobileNo_KeyPress);
            this.txtMobileNo.Leave += new System.EventHandler(this.txtMobileNo_Leave);
            // 
            // txtCustName
            // 
            this.txtCustName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCustName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCustName.Location = new System.Drawing.Point(571, 318);
            this.txtCustName.MaxLength = 200;
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(174, 25);
            this.txtCustName.TabIndex = 19;
            this.txtCustName.Leave += new System.EventHandler(this.txtCustName_Leave);
            // 
            // lblCustMobileNo
            // 
            this.lblCustMobileNo.AutoSize = true;
            this.lblCustMobileNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustMobileNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCustMobileNo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCustMobileNo.Location = new System.Drawing.Point(471, 285);
            this.lblCustMobileNo.Name = "lblCustMobileNo";
            this.lblCustMobileNo.Size = new System.Drawing.Size(94, 30);
            this.lblCustMobileNo.TabIndex = 16;
            this.lblCustMobileNo.Text = "Mobile No. *";
            this.lblCustMobileNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCustomerName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCustomerName.Location = new System.Drawing.Point(471, 315);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(94, 30);
            this.lblCustomerName.TabIndex = 18;
            this.lblCustomerName.Text = "Name *";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInvoiceDt
            // 
            this.lblInvoiceDt.AutoSize = true;
            this.lblInvoiceDt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInvoiceDt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblInvoiceDt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblInvoiceDt.Location = new System.Drawing.Point(248, 47);
            this.lblInvoiceDt.Name = "lblInvoiceDt";
            this.lblInvoiceDt.Size = new System.Drawing.Size(44, 35);
            this.lblInvoiceDt.TabIndex = 3;
            this.lblInvoiceDt.Text = "Date";
            this.lblInvoiceDt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpInvoiceDate.CustomFormat = "dd-MM-yyyy";
            this.dtpInvoiceDate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInvoiceDate.Location = new System.Drawing.Point(298, 50);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(104, 25);
            this.dtpInvoiceDate.TabIndex = 4;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBarcode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBarcode.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblBarcode.Location = new System.Drawing.Point(408, 47);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(54, 35);
            this.lblBarcode.TabIndex = 5;
            this.lblBarcode.Text = "Barcode";
            this.lblBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBarcode
            // 
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlpMain.SetColumnSpan(this.txtBarcode, 3);
            this.txtBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtBarcode.Location = new System.Drawing.Point(468, 50);
            this.txtBarcode.MaxLength = 50;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(277, 25);
            this.txtBarcode.TabIndex = 6;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // pnlButtons
            // 
            this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlButtons.Controls.Add(this.tlpOptButton);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.Location = new System.Drawing.Point(1311, 43);
            this.pnlButtons.Name = "pnlButtons";
            this.tlpMain.SetRowSpan(this.pnlButtons, 9);
            this.pnlButtons.Size = new System.Drawing.Size(124, 404);
            this.pnlButtons.TabIndex = 41;
            // 
            // tlpOptButton
            // 
            this.tlpOptButton.ColumnCount = 1;
            this.tlpOptButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOptButton.Controls.Add(this.btnCancel, 0, 2);
            this.tlpOptButton.Controls.Add(this.btnViewInvoice, 0, 4);
            this.tlpOptButton.Controls.Add(this.btnView, 0, 5);
            this.tlpOptButton.Controls.Add(this.btnNew, 0, 0);
            this.tlpOptButton.Controls.Add(this.btnSavePrint, 0, 1);
            this.tlpOptButton.Controls.Add(this.btnReprint, 0, 3);
            this.tlpOptButton.Controls.Add(this.cmbPrinter, 0, 7);
            this.tlpOptButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOptButton.Location = new System.Drawing.Point(0, 0);
            this.tlpOptButton.Name = "tlpOptButton";
            this.tlpOptButton.RowCount = 8;
            this.tlpOptButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpOptButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpOptButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpOptButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpOptButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpOptButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpOptButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpOptButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOptButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpOptButton.Size = new System.Drawing.Size(122, 402);
            this.tlpOptButton.TabIndex = 28;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnCancel.Image = global::POSClient.Properties.Resources.cancel_24;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(3, 83);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 34);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = " &Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnViewInvoice
            // 
            this.btnViewInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnViewInvoice.Image = global::POSClient.Properties.Resources.sales_24;
            this.btnViewInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewInvoice.Location = new System.Drawing.Point(3, 163);
            this.btnViewInvoice.Name = "btnViewInvoice";
            this.btnViewInvoice.Size = new System.Drawing.Size(116, 34);
            this.btnViewInvoice.TabIndex = 33;
            this.btnViewInvoice.Text = " View &Invoice";
            this.btnViewInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewInvoice.UseVisualStyleBackColor = true;
            this.btnViewInvoice.Click += new System.EventHandler(this.btnViewInvoice_Click);
            // 
            // btnView
            // 
            this.btnView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnView.Image = global::POSClient.Properties.Resources.view_24;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(3, 203);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(116, 34);
            this.btnView.TabIndex = 34;
            this.btnView.Text = " &View Sales";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnNew
            // 
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnNew.Image = global::POSClient.Properties.Resources.neworder_24;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(3, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(116, 34);
            this.btnNew.TabIndex = 29;
            this.btnNew.Text = " &New Order";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSavePrint
            // 
            this.btnSavePrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSavePrint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnSavePrint.Image = global::POSClient.Properties.Resources.printer_24;
            this.btnSavePrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSavePrint.Location = new System.Drawing.Point(3, 43);
            this.btnSavePrint.Name = "btnSavePrint";
            this.btnSavePrint.Size = new System.Drawing.Size(116, 34);
            this.btnSavePrint.TabIndex = 30;
            this.btnSavePrint.Text = " Save && Print";
            this.btnSavePrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSavePrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSavePrint.UseVisualStyleBackColor = true;
            this.btnSavePrint.Click += new System.EventHandler(this.btnSavePrint_Click);
            // 
            // btnReprint
            // 
            this.btnReprint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReprint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReprint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnReprint.Image = global::POSClient.Properties.Resources.Reprint_24;
            this.btnReprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReprint.Location = new System.Drawing.Point(3, 123);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Size = new System.Drawing.Size(116, 34);
            this.btnReprint.TabIndex = 32;
            this.btnReprint.Text = " &Reprint";
            this.btnReprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReprint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReprint.UseVisualStyleBackColor = true;
            this.btnReprint.Click += new System.EventHandler(this.btnReprint_Click);
            // 
            // cmbPrinter
            // 
            this.cmbPrinter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmbPrinter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPrinter.FormattingEnabled = true;
            this.cmbPrinter.Location = new System.Drawing.Point(3, 376);
            this.cmbPrinter.Name = "cmbPrinter";
            this.cmbPrinter.Size = new System.Drawing.Size(116, 23);
            this.cmbPrinter.TabIndex = 35;
            this.cmbPrinter.Visible = false;
            // 
            // tlpShortCut
            // 
            this.tlpShortCut.ColumnCount = 8;
            this.tlpMain.SetColumnSpan(this.tlpShortCut, 11);
            this.tlpShortCut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tlpShortCut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpShortCut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpShortCut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpShortCut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpShortCut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpShortCut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpShortCut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpShortCut.Controls.Add(this.button6, 6, 0);
            this.tlpShortCut.Controls.Add(this.button5, 5, 0);
            this.tlpShortCut.Controls.Add(this.button4, 4, 0);
            this.tlpShortCut.Controls.Add(this.button3, 3, 0);
            this.tlpShortCut.Controls.Add(this.button2, 2, 0);
            this.tlpShortCut.Controls.Add(this.button1, 1, 0);
            this.tlpShortCut.Controls.Add(this.lblShortcut, 0, 0);
            this.tlpShortCut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpShortCut.Location = new System.Drawing.Point(18, 408);
            this.tlpShortCut.Name = "tlpShortCut";
            this.tlpShortCut.RowCount = 1;
            this.tlpShortCut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpShortCut.Size = new System.Drawing.Size(1137, 39);
            this.tlpShortCut.TabIndex = 42;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(233)))), ((int)(((byte)(210)))));
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.Navy;
            this.button6.Location = new System.Drawing.Point(718, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(124, 33);
            this.button6.TabIndex = 7;
            this.button6.Text = "View Sales : Alt + V";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.LavenderBlush;
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Navy;
            this.button5.Location = new System.Drawing.Point(588, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(124, 33);
            this.button5.TabIndex = 6;
            this.button5.Text = "View Invoice : Alt + I";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightCyan;
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Navy;
            this.button4.Location = new System.Drawing.Point(458, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(124, 33);
            this.button4.TabIndex = 5;
            this.button4.Text = "Reprint : Alt + R";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Cornsilk;
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Navy;
            this.button3.Location = new System.Drawing.Point(328, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(124, 33);
            this.button3.TabIndex = 4;
            this.button3.Text = "Cancel : Alt + C";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.PeachPuff;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Navy;
            this.button2.Location = new System.Drawing.Point(198, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 33);
            this.button2.TabIndex = 3;
            this.button2.Text = "Save && Print : Ctrl + P";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MistyRose;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Navy;
            this.button1.Location = new System.Drawing.Point(68, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "New Order : Alt + N";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lblShortcut
            // 
            this.lblShortcut.AutoSize = true;
            this.lblShortcut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShortcut.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShortcut.Location = new System.Drawing.Point(3, 0);
            this.lblShortcut.Name = "lblShortcut";
            this.lblShortcut.Size = new System.Drawing.Size(59, 39);
            this.lblShortcut.TabIndex = 1;
            this.lblShortcut.Text = "Shortcut";
            this.lblShortcut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1453, 450);
            this.Controls.Add(this.tlpMain);
            this.Name = "frmSales";
            this.Text = "Sales";
            this.Load += new System.EventHandler(this.frmSales_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSales_KeyDown);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesItem)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.tlpOptButton.ResumeLayout(false);
            this.tlpShortCut.ResumeLayout(false);
            this.tlpShortCut.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnHeader;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label lblInvoiceDt;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.TextBox txtGrossTotal;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtNetTotal;
        private System.Windows.Forms.Label lblGrossTotal;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblNetTotal;
        private System.Windows.Forms.DataGridView dgvSalesItem;
        private System.Windows.Forms.Label lblPaymentMode;
        private System.Windows.Forms.Label lblAmtCollected;
        private System.Windows.Forms.Label lblAmtReturned;
        private System.Windows.Forms.ComboBox cmbPaymentMode;
        private System.Windows.Forms.TextBox txtAmtCollected;
        private System.Windows.Forms.TextBox txtAmountReturn;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.Label lblTotalItems;
        private System.Windows.Forms.TextBox txtTotalItems;
        private System.Windows.Forms.Button btnSavePrint;
        private System.Windows.Forms.Label lblDiscountType;
        private System.Windows.Forms.ComboBox cmbDiscountType;
        private System.Windows.Forms.Button btnReprint;
        private System.Windows.Forms.Label lblCustMobileNo;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TableLayoutPanel tlpOptButton;
        private System.Windows.Forms.ComboBox cmbPrinter;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnViewInvoice;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarcodeValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArticleNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Classification;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn HSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.TableLayoutPanel tlpShortCut;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblShortcut;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}