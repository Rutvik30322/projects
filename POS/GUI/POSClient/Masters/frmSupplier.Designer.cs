namespace POSClient
{
    partial class frmSupplier
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
            this.btnHeader = new System.Windows.Forms.Button();
            this.dgvSupplier = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tlpShortcut = new System.Windows.Forms.TableLayoutPanel();
            this.btnSEdit = new System.Windows.Forms.Button();
            this.btnSAdd = new System.Windows.Forms.Button();
            this.lblShortcut = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).BeginInit();
            this.tlpShortcut.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 4;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.Controls.Add(this.btnHeader, 1, 0);
            this.tlpMain.Controls.Add(this.dgvSupplier, 1, 3);
            this.tlpMain.Controls.Add(this.btnAdd, 2, 1);
            this.tlpMain.Controls.Add(this.tlpShortcut, 1, 4);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 6;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(800, 450);
            this.tlpMain.TabIndex = 0;
            // 
            // btnHeader
            // 
            this.btnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.tlpMain.SetColumnSpan(this.btnHeader, 2);
            this.btnHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnHeader.Location = new System.Drawing.Point(18, 3);
            this.btnHeader.Name = "btnHeader";
            this.btnHeader.Size = new System.Drawing.Size(764, 34);
            this.btnHeader.TabIndex = 1;
            this.btnHeader.Text = "Suppliers";
            this.btnHeader.UseVisualStyleBackColor = false;
            // 
            // dgvSupplier
            // 
            this.dgvSupplier.AllowUserToAddRows = false;
            this.dgvSupplier.AllowUserToDeleteRows = false;
            this.tlpMain.SetColumnSpan(this.dgvSupplier, 2);
            this.dgvSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSupplier.Location = new System.Drawing.Point(18, 88);
            this.dgvSupplier.Name = "dgvSupplier";
            this.dgvSupplier.ReadOnly = true;
            this.dgvSupplier.Size = new System.Drawing.Size(764, 309);
            this.dgvSupplier.TabIndex = 3;
            this.dgvSupplier.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSupplier_CellClick);
            this.dgvSupplier.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ccdc_Status);
            this.dgvSupplier.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ccdc_Status);
            this.dgvSupplier.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSupplier_CellFormatting);
            this.dgvSupplier.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSupplier_CellMouseEnter);
            this.dgvSupplier.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvSupplier_CellPainting);
            this.dgvSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSupplier_KeyDown);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnAdd.Image = global::POSClient.Properties.Resources.add_24;
            this.btnAdd.Location = new System.Drawing.Point(708, 43);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(74, 34);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = " &Add";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tlpShortcut
            // 
            this.tlpShortcut.ColumnCount = 4;
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 399F));
            this.tlpShortcut.Controls.Add(this.btnSEdit, 2, 0);
            this.tlpShortcut.Controls.Add(this.btnSAdd, 1, 0);
            this.tlpShortcut.Controls.Add(this.lblShortcut, 0, 0);
            this.tlpShortcut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpShortcut.Location = new System.Drawing.Point(18, 403);
            this.tlpShortcut.Name = "tlpShortcut";
            this.tlpShortcut.RowCount = 3;
            this.tlpMain.SetRowSpan(this.tlpShortcut, 2);
            this.tlpShortcut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpShortcut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpShortcut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpShortcut.Size = new System.Drawing.Size(684, 44);
            this.tlpShortcut.TabIndex = 4;
            // 
            // btnSEdit
            // 
            this.btnSEdit.BackColor = System.Drawing.Color.PeachPuff;
            this.btnSEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSEdit.ForeColor = System.Drawing.Color.Navy;
            this.btnSEdit.Location = new System.Drawing.Point(178, 3);
            this.btnSEdit.Name = "btnSEdit";
            this.tlpShortcut.SetRowSpan(this.btnSEdit, 2);
            this.btnSEdit.Size = new System.Drawing.Size(104, 29);
            this.btnSEdit.TabIndex = 50;
            this.btnSEdit.Text = "Edit : Ctrl + E";
            this.btnSEdit.UseVisualStyleBackColor = false;
            // 
            // btnSAdd
            // 
            this.btnSAdd.BackColor = System.Drawing.Color.MistyRose;
            this.btnSAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSAdd.ForeColor = System.Drawing.Color.Navy;
            this.btnSAdd.Location = new System.Drawing.Point(68, 3);
            this.btnSAdd.Name = "btnSAdd";
            this.tlpShortcut.SetRowSpan(this.btnSAdd, 2);
            this.btnSAdd.Size = new System.Drawing.Size(104, 29);
            this.btnSAdd.TabIndex = 49;
            this.btnSAdd.Text = "Add : Alt + A";
            this.btnSAdd.UseVisualStyleBackColor = false;
            // 
            // lblShortcut
            // 
            this.lblShortcut.AutoSize = true;
            this.lblShortcut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShortcut.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblShortcut.Location = new System.Drawing.Point(3, 0);
            this.lblShortcut.Name = "lblShortcut";
            this.lblShortcut.Size = new System.Drawing.Size(59, 30);
            this.lblShortcut.TabIndex = 0;
            this.lblShortcut.Text = "Shortcut";
            this.lblShortcut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlpMain);
            this.Name = "frmSupplier";
            this.Text = "Supplier";
            this.Load += new System.EventHandler(this.frmSupplier_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSupplier_KeyDown);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).EndInit();
            this.tlpShortcut.ResumeLayout(false);
            this.tlpShortcut.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnHeader;
        private System.Windows.Forms.DataGridView dgvSupplier;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TableLayoutPanel tlpShortcut;
        private System.Windows.Forms.Label lblShortcut;
        private System.Windows.Forms.Button btnSAdd;
        private System.Windows.Forms.Button btnSEdit;
    }
}