namespace POSClient
{
    partial class frmInventoryDetails
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
            this.tlpShortcut = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.lblShortcut2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnHeader = new System.Windows.Forms.Button();
            this.dgvInventoryDetail = new System.Windows.Forms.DataGridView();
            this.labelNote = new System.Windows.Forms.Label();
            this.btnTotalSelectedCount = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.tlpShortcut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 6;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.Controls.Add(this.tlpShortcut, 3, 4);
            this.tlpMain.Controls.Add(this.button2, 4, 1);
            this.tlpMain.Controls.Add(this.btnHeader, 1, 0);
            this.tlpMain.Controls.Add(this.dgvInventoryDetail, 1, 3);
            this.tlpMain.Controls.Add(this.labelNote, 2, 4);
            this.tlpMain.Controls.Add(this.btnTotalSelectedCount, 1, 4);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 6;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(1121, 565);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpShortcut
            // 
            this.tlpShortcut.ColumnCount = 2;
            this.tlpMain.SetColumnSpan(this.tlpShortcut, 2);
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tlpShortcut.Controls.Add(this.button3, 1, 0);
            this.tlpShortcut.Controls.Add(this.lblShortcut2, 0, 0);
            this.tlpShortcut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpShortcut.Location = new System.Drawing.Point(899, 518);
            this.tlpShortcut.Name = "tlpShortcut";
            this.tlpShortcut.RowCount = 1;
            this.tlpShortcut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpShortcut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tlpShortcut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tlpShortcut.Size = new System.Drawing.Size(204, 39);
            this.tlpShortcut.TabIndex = 47;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.MistyRose;
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Navy;
            this.button3.Location = new System.Drawing.Point(63, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 33);
            this.button3.TabIndex = 8;
            this.button3.Text = "Print Barcode : Alt + P";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // lblShortcut2
            // 
            this.lblShortcut2.AutoSize = true;
            this.lblShortcut2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShortcut2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShortcut2.Location = new System.Drawing.Point(3, 0);
            this.lblShortcut2.Name = "lblShortcut2";
            this.lblShortcut2.Size = new System.Drawing.Size(54, 39);
            this.lblShortcut2.TabIndex = 7;
            this.lblShortcut2.Text = "Shortcut";
            this.lblShortcut2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::POSClient.Properties.Resources.printer_24;
            this.button2.Location = new System.Drawing.Point(979, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = " &Print Barcode";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnHeader
            // 
            this.btnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.tlpMain.SetColumnSpan(this.btnHeader, 4);
            this.btnHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnHeader.Location = new System.Drawing.Point(18, 3);
            this.btnHeader.Name = "btnHeader";
            this.btnHeader.Size = new System.Drawing.Size(1085, 34);
            this.btnHeader.TabIndex = 1;
            this.btnHeader.Text = "Inventory Details";
            this.btnHeader.UseVisualStyleBackColor = false;
            // 
            // dgvInventoryDetail
            // 
            this.dgvInventoryDetail.AllowUserToAddRows = false;
            this.dgvInventoryDetail.AllowUserToDeleteRows = false;
            this.dgvInventoryDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlpMain.SetColumnSpan(this.dgvInventoryDetail, 4);
            this.dgvInventoryDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventoryDetail.Location = new System.Drawing.Point(18, 88);
            this.dgvInventoryDetail.Name = "dgvInventoryDetail";
            this.dgvInventoryDetail.Size = new System.Drawing.Size(1085, 424);
            this.dgvInventoryDetail.TabIndex = 2;
            this.dgvInventoryDetail.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvInventoryDetail_CellBeginEdit);
            this.dgvInventoryDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventoryDetail_CellDoubleClick);
            this.dgvInventoryDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventoryDetail_CellEndEdit);
            this.dgvInventoryDetail.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvInventoryDetail_CellValidating);
            this.dgvInventoryDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventoryDetail_CellValueChanged);
            this.dgvInventoryDetail.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvInventoryDetail_CurrentCellDirtyStateChanged);
            this.dgvInventoryDetail.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvInventoryDetail_EditingControlShowing);
            this.dgvInventoryDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvInventoryDetail_KeyDown);
            // 
            // labelNote
            // 
            this.labelNote.AutoSize = true;
            this.labelNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNote.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(37)))), ((int)(((byte)(62)))));
            this.labelNote.Location = new System.Drawing.Point(218, 515);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(675, 45);
            this.labelNote.TabIndex = 6;
            this.labelNote.Text = "Note : Double-click on the \"Sale Price\" cell to edit the price. And to print the " +
    "barcode, select the row using the selection box.";
            this.labelNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnTotalSelectedCount
            // 
            this.btnTotalSelectedCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.btnTotalSelectedCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTotalSelectedCount.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTotalSelectedCount.Location = new System.Drawing.Point(18, 518);
            this.btnTotalSelectedCount.Name = "btnTotalSelectedCount";
            this.btnTotalSelectedCount.Size = new System.Drawing.Size(194, 39);
            this.btnTotalSelectedCount.TabIndex = 5;
            this.btnTotalSelectedCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTotalSelectedCount.UseVisualStyleBackColor = false;
            // 
            // frmInventoryDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 565);
            this.Controls.Add(this.tlpMain);
            this.Name = "frmInventoryDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InventoryDetails";
            this.Load += new System.EventHandler(this.frmInventoryDetails_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInventoryDetails_KeyDown);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpShortcut.ResumeLayout(false);
            this.tlpShortcut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnHeader;
        private System.Windows.Forms.DataGridView dgvInventoryDetail;
        private System.Windows.Forms.Label labelNote;
        private System.Windows.Forms.Button btnTotalSelectedCount;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TableLayoutPanel tlpShortcut;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblShortcut2;
    }
}