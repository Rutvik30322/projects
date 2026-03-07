using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSClient
{
    public static class Themes
    {
        public static Color FormBackColor = Color.FromArgb(221, 221, 221);

        public static Color LabelForeColor = Color.FromArgb(34, 60, 74);
        public static Color LabelBackColor = Color.FromArgb(221, 221, 221);

        public static Color ButtonBackColor = Color.FromArgb(221, 221, 221);
        public static Color ButtonForeColor = Color.FromArgb(34, 60, 74);
        public static Color ButtonBorderColor = Color.FromArgb(34, 60, 74);

        public static Color ButtonActiveBackColor = Color.FromArgb(170, 170, 170);

        public static Color HeaderBackColor = Color.FromArgb(187, 187, 187);
        public static Color HeaderForeColor = Color.FromArgb(34, 60, 74);
        public static Color HeaderBorderColor = Color.FromArgb(59, 113, 202);

        public static Color CrudButtonBackColor = Color.FromArgb(34, 60, 74);
        public static Color CrudButtonForeColor = Color.FromArgb(221, 221, 221);

        public static Color searchPlaceHolder = Color.Gray;
        public static Color searchTextColor = Color.Black;

        public static void DataGridTheme(DataGridView Grid)
        {
            Grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            Grid.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            Grid.Height = 30;

            Grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            Grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            Grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            Grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            Grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;


            Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            Grid.ColumnHeadersHeight = 30;

            //Grid.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            Grid.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Window;
            Grid.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Grid.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            Grid.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            Grid.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;


            Grid.EnableHeadersVisualStyles = false;
            Grid.GridColor = System.Drawing.SystemColors.ControlDark;
            Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            Grid.RowHeadersVisible = false;

            Grid.RowHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            Grid.RowHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            Grid.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Grid.RowHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            Grid.RowHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            Grid.RowHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        }

    }
}
