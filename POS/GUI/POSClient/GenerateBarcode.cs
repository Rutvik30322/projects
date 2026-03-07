using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSClient
{
    public class GenerateBarcode
    {
        /// <summary>
		/// The encoding library for all allowed characters.
		/// </summary>
		private readonly Dictionary<char, string> _codeDictionary;

        /// <summary>
        /// Init a new instance of the code-39 barcode generator.
        /// </summary>
        public GenerateBarcode()
        {
            _codeDictionary = new Dictionary<char, string>();
            _codeDictionary['0'] = "101001101101";
            _codeDictionary['1'] = "110100101011";
            _codeDictionary['2'] = "101100101011";
            _codeDictionary['3'] = "110110010101";
            _codeDictionary['4'] = "101001101011";
            _codeDictionary['5'] = "110100110101";
            _codeDictionary['6'] = "101100110101";
            _codeDictionary['7'] = "101001011011";
            _codeDictionary['8'] = "110100101101";
            _codeDictionary['9'] = "101100101101";
            _codeDictionary['A'] = "110101001011";
            _codeDictionary['B'] = "101101001011";
            _codeDictionary['C'] = "110110100101";
            _codeDictionary['D'] = "101011001011";
            _codeDictionary['E'] = "110101100101";
            _codeDictionary['F'] = "101101100101";
            _codeDictionary['G'] = "101010011011";
            _codeDictionary['H'] = "110101001101";
            _codeDictionary['I'] = "101101001101";
            _codeDictionary['J'] = "101011001101";
            _codeDictionary['K'] = "110101010011";
            _codeDictionary['L'] = "101101010011";
            _codeDictionary['M'] = "110110101001";
            _codeDictionary['N'] = "101011010011";
            _codeDictionary['O'] = "110101101001";
            _codeDictionary['P'] = "101101101001";
            _codeDictionary['Q'] = "101010110011";
            _codeDictionary['R'] = "110101011001";
            _codeDictionary['S'] = "101101011001";
            _codeDictionary['T'] = "101011011001";
            _codeDictionary['U'] = "110010101011";
            _codeDictionary['V'] = "100110101011";
            _codeDictionary['W'] = "110011010101";
            _codeDictionary['X'] = "100101101011";
            _codeDictionary['Y'] = "110010110101";
            _codeDictionary['Z'] = "100110110101";
            _codeDictionary['-'] = "100101011011";
            _codeDictionary['.'] = "110010101101";
            _codeDictionary[' '] = "100110101101";
            _codeDictionary['$'] = "100100100101";
            _codeDictionary['/'] = "100100101001";
            _codeDictionary['+'] = "100101001001";
            _codeDictionary['%'] = "101001001001";
            _codeDictionary['*'] = "100101101101";
        }

        /// <summary>
        /// Generate a code-39 barcode.
        /// </summary>
        /// <param name="height">Height (in px) of the finished generated image.</param>
        /// <param name="content">The code to create barcode from.</param>
        /// <param name="padding">Padding (in px) to apply to each side of the image.</param>
        /// <param name="includeCode">Whether or not to write out the code on the generated image (below the barcode).</param>
        /// <param name="barWidth">Width of the bars to draw.</param>
        /// <returns></returns>
        public Bitmap Create(int height, string content, int padding = 0, bool includeCode = false, int barWidth = 1)
        {
            var encodedBits = new StringBuilder();

            encodedBits.Append("1001011011010");

            foreach (var c in content.ToUpper())
            {
                string encoded;

                if (!_codeDictionary.TryGetValue(c, out encoded))
                    throw new ArgumentOutOfRangeException("content", "Characher '" + c + "' is not compatible with this Code39 implementation!");

                encodedBits.Append(encoded + '0');
            }

            encodedBits.Append("100101101101");

            var offsetLeft = padding;
            var width = (encodedBits.Length * barWidth) + (offsetLeft * 2);
            var canvas = new Bitmap(width, height);
            var graphics = Graphics.FromImage(canvas);
            var textLayerSizeHeight = 0;

            graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, width, height));

            if (includeCode)
            {
                var textLayerSize = graphics.MeasureString(content, new Font("Segoe UI", 8));
                var textLayerSizeWidth = (int)Math.Ceiling(textLayerSize.Width);

                textLayerSizeHeight = (int)Math.Ceiling(textLayerSize.Height);

                graphics.DrawString(content, new Font("Segoe UI", 8), Brushes.Black,
                    new RectangleF((width / 2) - (textLayerSizeWidth / 2), height - textLayerSizeHeight, textLayerSizeWidth,
                        textLayerSizeHeight));
            }

            foreach (var c in encodedBits.ToString())
            {
                var rectangle = new Rectangle(offsetLeft += barWidth, 0, barWidth, height - textLayerSizeHeight);
                graphics.FillRectangle(c == '0' ? Brushes.White : Brushes.Black, rectangle);
            }

            return canvas;
        }


        public Bitmap GenerateLabelPreviewWithBitmap(Bitmap barcodeBitmap, string productName, string size, string artNo, string mrp)
        {
            Bitmap retBitMap = null;
            try
            {
                int dpi = 85;
                //Temporary Commented
                float labelWidthInches = 2.0f;
                float labelHeightInches = 1.0f;

                int width = (int)(labelWidthInches * dpi);
                int height = (int)(labelHeightInches * dpi);

                //int width = 167;  // 50mm at 85 DPI
                //int height = 83;  // 25mm at 85 DPI

                Bitmap labelBitmap = new Bitmap(width, height);
                labelBitmap.SetResolution(dpi, dpi);

                using (Graphics g = Graphics.FromImage(labelBitmap))
                {
                    g.Clear(Color.White);

                    // Fonts
                    Font labelFont = new Font("Segoe UI", 7F, FontStyle.Bold);
                    Font valueFont = new Font("Segoe UI", 7F, FontStyle.Regular);
                    Brush brush = Brushes.Black;

                    // Barcode area
                    int barcodeHeight = (int)(height * 0.45);
                    Rectangle barcodeArea = new Rectangle(5, 5, width - 10, barcodeHeight);
                    if (barcodeBitmap != null)
                        g.DrawImage(barcodeBitmap, barcodeArea);
                    else
                        g.DrawString("Barcode image not available", valueFont, Brushes.Red, new PointF(10, 10));

                    // Text content
                    float textY = barcodeArea.Bottom + 2;
                    float lineHeight = valueFont.GetHeight(g) + 1;

                    // Draw "Product:" label and value
                    g.DrawString("Product:", labelFont, brush, new PointF(5, textY));
                    g.DrawString(productName, valueFont, brush, new PointF(40, textY));
                    textY += lineHeight;

                    // Draw "Size:" and "Art no."
                    g.DrawString("Size:", labelFont, brush, new PointF(5, textY));
                    g.DrawString(size, valueFont, brush, new PointF(30, textY));
                    g.DrawString("Art no.", labelFont, brush, new PointF(60, textY));
                    g.DrawString(artNo, valueFont, brush, new PointF(90, textY));
                    textY += lineHeight;

                    // Draw "MRP:"
                    g.DrawString("MRP:", labelFont, brush, new PointF(5, textY));
                    g.DrawString(mrp, valueFont, brush, new PointF(30, textY));
                }
                retBitMap = labelBitmap;
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Generate Barcode : GenerateLabelPreviewWithBitmap");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
            return retBitMap;
        }

        //public Bitmap GenerateLabelPreviewWithBitmap(Bitmap barcodeBitmap, string productName, string size, string artNo, string mrp)
        //{
        //    Bitmap retBitMap = null;
        //    try
        //    {
        //        //int dpi = 85;
        //        //Temporary Commented
        //        //float labelWidthInches = 2.0f;
        //        //float labelHeightInches = 1.0f;

        //        //int width = (int)(labelWidthInches * dpi);
        //        //int height = (int)(labelHeightInches * dpi);

        //        int width = 833;  // 104.1mm at 8dpmm
        //        int height = 1219; // 152.4mm at 8dpmm
        //        int dpi = 203; // 8 dpmm ≈ 203 dpi

        //        Bitmap labelBitmap = new Bitmap(width, height);
        //        labelBitmap.SetResolution(dpi, dpi);

        //        using (Graphics g = Graphics.FromImage(labelBitmap))
        //        {
        //            g.Clear(Color.White);

        //            // Fonts
        //            Font labelFont = new Font("Segoe UI", 20F, FontStyle.Bold);
        //            Font valueFont = new Font("Segoe UI", 20F, FontStyle.Regular);
        //            Brush brush = Brushes.Black;

        //            // Barcode area
        //            //int barcodeHeight = (int)(height * 0.45);
        //            int barcodeHeight = 300;
        //            Rectangle barcodeArea = new Rectangle(50, 50, width - 100, barcodeHeight);
        //            if (barcodeBitmap != null)
        //                g.DrawImage(barcodeBitmap, barcodeArea);
        //            else
        //                g.DrawString("Barcode image not available", valueFont, Brushes.Red, new PointF(10, 10));

        //            // Text content
        //            float textY = barcodeArea.Bottom + 40;
        //            //float lineHeight = valueFont.GetHeight(g) + 1;
        //            float spacing = 50;

        //            // Draw "Product:" label and value
        //            g.DrawString("Product:", labelFont, brush, new PointF(50, textY));
        //            g.DrawString(productName, valueFont, brush, new PointF(250, textY));
        //            textY += spacing;

        //            // Draw "Size:" and "Art no."
        //            g.DrawString("Size:", labelFont, brush, new PointF(50, textY));
        //            g.DrawString(size, valueFont, brush, new PointF(250, textY));
        //            g.DrawString("Art no.", labelFont, brush, new PointF(500, textY));
        //            g.DrawString(artNo, valueFont, brush, new PointF(650, textY));
        //            textY += spacing;

        //            // Draw "MRP:"
        //            g.DrawString("MRP:", labelFont, brush, new PointF(50, textY));
        //            g.DrawString(mrp, valueFont, brush, new PointF(250, textY));
        //        }
        //        retBitMap = labelBitmap;
        //    }
        //    catch (Exception ex)
        //    {
        //        GeneralObjects.ErrLogger.WritetoLogFile("Generate Barcode : GenerateLabelPreviewWithBitmap");
        //        GeneralObjects.ErrLogger.WritetoLogFile(ex);
        //    }
        //    return retBitMap;
        //}

        //public void PrintLabel(Bitmap labelBitmap, string printerName)
        //{
        //    PrintDocument printDoc = new PrintDocument();

        //    // Set the printer name (optional - set to TSC P-200 if installed)
        //    //printDoc.PrinterSettings.PrinterName = "TSC P-200";
        //    printDoc.PrinterSettings.PrinterName = printerName;

        //    // Optional: Set paper size if your label is custom
        //    //printDoc.DefaultPageSettings.PaperSize = new PaperSize("Label", labelBitmap.Width, labelBitmap.Height);
        //    printDoc.DefaultPageSettings.PaperSize = new PaperSize("Label85DPI", labelBitmap.Width, labelBitmap.Height);
        //    printDoc.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
        //    printDoc.PrintPage += (sender, e) =>
        //    {
        //        // Draw the label bitmap onto the print graphics
        //        e.Graphics.DrawImage(labelBitmap, new Rectangle(0, 0, labelBitmap.Width, labelBitmap.Height));
        //    };

        //    try
        //    {
        //        printDoc.Print(); // Fire the print job
        //    }
        //    catch (Exception ex)
        //    {
        //        GeneralObjects.ErrLogger.WritetoLogFile("Generate Barcode : PrintLabel : Printing failed");
        //        GeneralObjects.ErrLogger.WritetoLogFile(ex);
        //    }
        //}

        public void PrintLabel(Bitmap labelBitmap, string printerName)
        {
            PrintDocument printDoc = new PrintDocument();

            // Set the printer name (optional - set to TSC P-200 if installed)
            //printDoc.PrinterSettings.PrinterName = "TSC P-200";
            printDoc.PrinterSettings.PrinterName = printerName;

            // Optional: Set paper size if your label is custom
            //printDoc.DefaultPageSettings.PaperSize = new PaperSize("Label", labelBitmap.Width, labelBitmap.Height);
            printDoc.DefaultPageSettings.PaperSize = new PaperSize("USER (104.1 mm X 152.4 mm)", 833, 1219);
            printDoc.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
            printDoc.PrintPage += (sender, e) =>
            {
                // Draw the label bitmap onto the print graphics
                e.Graphics.DrawImage(labelBitmap, new Rectangle(0, 0, labelBitmap.Width, labelBitmap.Height));
            };

            try
            {
                printDoc.Print(); // Fire the print job
            }
            catch (Exception ex)
            {
                GeneralObjects.ErrLogger.WritetoLogFile("Generate Barcode : PrintLabel : Printing failed");
                GeneralObjects.ErrLogger.WritetoLogFile(ex);
            }
        }
    }
}
