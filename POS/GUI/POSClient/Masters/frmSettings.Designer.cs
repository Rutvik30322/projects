
namespace POSClient
{
    partial class frmSettings
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblStationName = new System.Windows.Forms.Label();
            this.lblHeaderText = new System.Windows.Forms.Label();
            this.lblBarcodePrinter = new System.Windows.Forms.Label();
            this.lblInvoicePrinter = new System.Windows.Forms.Label();
            this.btnHeader = new System.Windows.Forms.Button();
            this.dgvSettings = new System.Windows.Forms.DataGridView();
            this.cmbInvoicePrinter = new System.Windows.Forms.ComboBox();
            this.cmbBarcodePrinter = new System.Windows.Forms.ComboBox();
            this.txtStation = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSEdit = new System.Windows.Forms.Button();
            this.btnSAdd = new System.Windows.Forms.Button();
            this.btnSSave = new System.Windows.Forms.Button();
            this.lblShortcut = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettings)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 8;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.Controls.Add(this.btnCancel, 5, 3);
            this.tlpMain.Controls.Add(this.btnSave, 4, 3);
            this.tlpMain.Controls.Add(this.lblStationName, 1, 2);
            this.tlpMain.Controls.Add(this.lblHeaderText, 1, 1);
            this.tlpMain.Controls.Add(this.lblBarcodePrinter, 3, 2);
            this.tlpMain.Controls.Add(this.lblInvoicePrinter, 2, 2);
            this.tlpMain.Controls.Add(this.btnHeader, 1, 0);
            this.tlpMain.Controls.Add(this.dgvSettings, 1, 6);
            this.tlpMain.Controls.Add(this.cmbInvoicePrinter, 2, 4);
            this.tlpMain.Controls.Add(this.cmbBarcodePrinter, 3, 4);
            this.tlpMain.Controls.Add(this.txtStation, 1, 4);
            this.tlpMain.Controls.Add(this.tableLayoutPanel1, 1, 7);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 9;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(1047, 450);
            this.tlpMain.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnCancel.Image = global::POSClient.Properties.Resources.cancel_24;
            this.btnCancel.Location = new System.Drawing.Point(908, 103);
            this.btnCancel.Name = "btnCancel";
            this.tlpMain.SetRowSpan(this.btnCancel, 3);
            this.btnCancel.Size = new System.Drawing.Size(94, 34);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = " &Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnSave.Image = global::POSClient.Properties.Resources.save_24;
            this.btnSave.Location = new System.Drawing.Point(808, 103);
            this.btnSave.Name = "btnSave";
            this.tlpMain.SetRowSpan(this.btnSave, 3);
            this.btnSave.Size = new System.Drawing.Size(94, 34);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = " &Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblStationName
            // 
            this.lblStationName.AutoSize = true;
            this.lblStationName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStationName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStationName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblStationName.Location = new System.Drawing.Point(18, 70);
            this.lblStationName.Name = "lblStationName";
            this.lblStationName.Size = new System.Drawing.Size(184, 30);
            this.lblStationName.TabIndex = 2;
            this.lblStationName.Text = "Station";
            this.lblStationName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblHeaderText
            // 
            this.lblHeaderText.AutoSize = true;
            this.lblHeaderText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderText.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblHeaderText.Location = new System.Drawing.Point(18, 40);
            this.lblHeaderText.Name = "lblHeaderText";
            this.lblHeaderText.Size = new System.Drawing.Size(184, 30);
            this.lblHeaderText.TabIndex = 1;
            this.lblHeaderText.Text = "Station / Printer Settings";
            this.lblHeaderText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBarcodePrinter
            // 
            this.lblBarcodePrinter.AutoSize = true;
            this.lblBarcodePrinter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBarcodePrinter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBarcodePrinter.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblBarcodePrinter.Location = new System.Drawing.Point(508, 70);
            this.lblBarcodePrinter.Name = "lblBarcodePrinter";
            this.lblBarcodePrinter.Size = new System.Drawing.Size(294, 30);
            this.lblBarcodePrinter.TabIndex = 6;
            this.lblBarcodePrinter.Text = "Barcode  Printer";
            this.lblBarcodePrinter.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblInvoicePrinter
            // 
            this.lblInvoicePrinter.AutoSize = true;
            this.lblInvoicePrinter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInvoicePrinter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblInvoicePrinter.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblInvoicePrinter.Location = new System.Drawing.Point(208, 70);
            this.lblInvoicePrinter.Name = "lblInvoicePrinter";
            this.lblInvoicePrinter.Size = new System.Drawing.Size(294, 30);
            this.lblInvoicePrinter.TabIndex = 4;
            this.lblInvoicePrinter.Text = "Invoice Printer";
            this.lblInvoicePrinter.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnHeader
            // 
            this.btnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.tlpMain.SetColumnSpan(this.btnHeader, 6);
            this.btnHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnHeader.Location = new System.Drawing.Point(18, 3);
            this.btnHeader.Name = "btnHeader";
            this.btnHeader.Size = new System.Drawing.Size(1011, 34);
            this.btnHeader.TabIndex = 0;
            this.btnHeader.Text = "Settings";
            this.btnHeader.UseVisualStyleBackColor = false;
            // 
            // dgvSettings
            // 
            this.dgvSettings.AllowUserToAddRows = false;
            this.dgvSettings.AllowUserToDeleteRows = false;
            this.dgvSettings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSettings.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.tlpMain.SetColumnSpan(this.dgvSettings, 6);
            this.dgvSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSettings.Location = new System.Drawing.Point(18, 143);
            this.dgvSettings.Name = "dgvSettings";
            this.dgvSettings.ReadOnly = true;
            this.dgvSettings.Size = new System.Drawing.Size(1011, 254);
            this.dgvSettings.TabIndex = 10;
            this.dgvSettings.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSettings_CellClick);
            this.dgvSettings.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSettings_CellDoubleClick);
            this.dgvSettings.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSettings_CellFormatting);
            this.dgvSettings.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSettings_CellMouseEnter);
            this.dgvSettings.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvSettings_CellPainting);
            this.dgvSettings.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSettings_KeyDown);
            // 
            // cmbInvoicePrinter
            // 
            this.cmbInvoicePrinter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbInvoicePrinter.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbInvoicePrinter.FormattingEnabled = true;
            this.cmbInvoicePrinter.Location = new System.Drawing.Point(208, 110);
            this.cmbInvoicePrinter.Name = "cmbInvoicePrinter";
            this.cmbInvoicePrinter.Size = new System.Drawing.Size(294, 25);
            this.cmbInvoicePrinter.TabIndex = 5;
            // 
            // cmbBarcodePrinter
            // 
            this.cmbBarcodePrinter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbBarcodePrinter.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbBarcodePrinter.FormattingEnabled = true;
            this.cmbBarcodePrinter.Location = new System.Drawing.Point(508, 110);
            this.cmbBarcodePrinter.Name = "cmbBarcodePrinter";
            this.cmbBarcodePrinter.Size = new System.Drawing.Size(294, 25);
            this.cmbBarcodePrinter.TabIndex = 7;
            // 
            // txtStation
            // 
            this.txtStation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStation.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtStation.Location = new System.Drawing.Point(18, 110);
            this.txtStation.Name = "txtStation";
            this.txtStation.ReadOnly = true;
            this.txtStation.Size = new System.Drawing.Size(184, 25);
            this.txtStation.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tlpMain.SetColumnSpan(this.tableLayoutPanel1, 2);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnSEdit, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSAdd, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSSave, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblShortcut, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(18, 403);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tlpMain.SetRowSpan(this.tableLayoutPanel1, 2);
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(484, 44);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // btnSEdit
            // 
            this.btnSEdit.BackColor = System.Drawing.Color.PeachPuff;
            this.btnSEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSEdit.ForeColor = System.Drawing.Color.Navy;
            this.btnSEdit.Location = new System.Drawing.Point(188, 3);
            this.btnSEdit.Name = "btnSEdit";
            this.tableLayoutPanel1.SetRowSpan(this.btnSEdit, 2);
            this.btnSEdit.Size = new System.Drawing.Size(114, 29);
            this.btnSEdit.TabIndex = 51;
            this.btnSEdit.Text = "Edit : Ctrl + E";
            this.btnSEdit.UseVisualStyleBackColor = false;
            // 
            // btnSAdd
            // 
            this.btnSAdd.BackColor = System.Drawing.Color.Cornsilk;
            this.btnSAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSAdd.ForeColor = System.Drawing.Color.Navy;
            this.btnSAdd.Location = new System.Drawing.Point(308, 3);
            this.btnSAdd.Name = "btnSAdd";
            this.tableLayoutPanel1.SetRowSpan(this.btnSAdd, 2);
            this.btnSAdd.Size = new System.Drawing.Size(114, 29);
            this.btnSAdd.TabIndex = 50;
            this.btnSAdd.Text = "Cancel : Alt + C";
            this.btnSAdd.UseVisualStyleBackColor = false;
            // 
            // btnSSave
            // 
            this.btnSSave.BackColor = System.Drawing.Color.MistyRose;
            this.btnSSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSSave.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSSave.ForeColor = System.Drawing.Color.Navy;
            this.btnSSave.Location = new System.Drawing.Point(68, 3);
            this.btnSSave.Name = "btnSSave";
            this.tableLayoutPanel1.SetRowSpan(this.btnSSave, 2);
            this.btnSSave.Size = new System.Drawing.Size(114, 29);
            this.btnSSave.TabIndex = 49;
            this.btnSSave.Text = "Save : Ctrl + S";
            this.btnSSave.UseVisualStyleBackColor = false;
            // 
            // lblShortcut
            // 
            this.lblShortcut.AutoSize = true;
            this.lblShortcut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShortcut.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShortcut.Location = new System.Drawing.Point(3, 0);
            this.lblShortcut.Name = "lblShortcut";
            this.lblShortcut.Size = new System.Drawing.Size(59, 30);
            this.lblShortcut.TabIndex = 48;
            this.lblShortcut.Text = "Shortcut";
            this.lblShortcut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 450);
            this.Controls.Add(this.tlpMain);
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSettings_KeyDown);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettings)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnHeader;
        private System.Windows.Forms.DataGridView dgvSettings;
        private System.Windows.Forms.ComboBox cmbInvoicePrinter;
        private System.Windows.Forms.ComboBox cmbBarcodePrinter;
        private System.Windows.Forms.Label lblInvoicePrinter;
        private System.Windows.Forms.Label lblBarcodePrinter;
        private System.Windows.Forms.Label lblHeaderText;
        private System.Windows.Forms.Label lblStationName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtStation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblShortcut;
        private System.Windows.Forms.Button btnSSave;
        private System.Windows.Forms.Button btnSAdd;
        private System.Windows.Forms.Button btnSEdit;
    }
}