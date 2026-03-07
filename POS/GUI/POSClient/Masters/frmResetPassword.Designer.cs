
namespace POSClient
{
    partial class frmResetPassword
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
            this.dgvResetRequest = new System.Windows.Forms.DataGridView();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResetRequest)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 7;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.Controls.Add(this.btnHeader, 1, 0);
            this.tlpMain.Controls.Add(this.dgvResetRequest, 1, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(800, 450);
            this.tlpMain.TabIndex = 0;
            // 
            // btnHeader
            // 
            this.btnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.tlpMain.SetColumnSpan(this.btnHeader, 5);
            this.btnHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnHeader.Location = new System.Drawing.Point(18, 3);
            this.btnHeader.Name = "btnHeader";
            this.btnHeader.Size = new System.Drawing.Size(764, 34);
            this.btnHeader.TabIndex = 1;
            this.btnHeader.Text = "Password Reset Request";
            this.btnHeader.UseVisualStyleBackColor = false;
            // 
            // dgvResetRequest
            // 
            this.dgvResetRequest.AllowUserToAddRows = false;
            this.dgvResetRequest.AllowUserToDeleteRows = false;
            this.dgvResetRequest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResetRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlpMain.SetColumnSpan(this.dgvResetRequest, 5);
            this.dgvResetRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResetRequest.Location = new System.Drawing.Point(18, 48);
            this.dgvResetRequest.Name = "dgvResetRequest";
            this.dgvResetRequest.ReadOnly = true;
            this.dgvResetRequest.Size = new System.Drawing.Size(764, 399);
            this.dgvResetRequest.TabIndex = 2;
            this.dgvResetRequest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResetRequest_CellClick);
            this.dgvResetRequest.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResetRequest_CellContentClick);
            this.dgvResetRequest.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResetRequest_CellMouseEnter);
            this.dgvResetRequest.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvResetRequest_CellPainting);
            // 
            // frmResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlpMain);
            this.Name = "frmResetPassword";
            this.Text = "Reset Password";
            this.Load += new System.EventHandler(this.frmResetPassword_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmResetPassword_KeyDown);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResetRequest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnHeader;
        private System.Windows.Forms.DataGridView dgvResetRequest;
    }
}