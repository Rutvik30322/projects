using System;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.Text;
using NDatabaseAccess;
using System.Data;

namespace POSClient
{
    public class RptPrinter
    {
        #region "Private Variables"
        PrintDocument pdoc = null;

        int HeaderFontSize = 8;
        int TextFontSize = 6;
        string FontName = "Courier New";
        string _projCustName = "Summi Fashion LLP";
        string _projCustAddress = "GF/8, Trivia Complex, \n 9/10, Natubhai Cir, Race Course, \n Vadiwadi, Vadodara, Gujarat 390007";
        string custName;
        string invoiceNo;
        string invoiceDate;
        string[] srNo;
        string[] description;
        string[] hsnCode;
        string[] rate;
        string[] qty;
        string grossTotal;
        string discount;
        string netTotal;
        #endregion

        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        public void PrintLocalReport(string rptPath, ReportDataSource dataSource, string printerName = "")
        {
            LocalReport report = new LocalReport
            {
                ReportPath = rptPath
            };

            report.DataSources.Add(dataSource);

            Export(report);
            Print(printerName);
        }

        private void Export(LocalReport report)
        {
            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.5in</PageWidth>
                <PageHeight>11in</PageHeight>
                <MarginTop>0.25in</MarginTop>
                <MarginLeft>0.25in</MarginLeft>
                <MarginRight>0.25in</MarginRight>
                <MarginBottom>0.25in</MarginBottom>
            </DeviceInfo>";

            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);

            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }

        private Stream CreateStream(string name, string fileNameExtension,
        Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        private void Print(string printerName)
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("No stream to print.");

            PrintDocument printDoc = new PrintDocument();

            if (!string.IsNullOrEmpty(printerName))
                printDoc.PrinterSettings.PrinterName = printerName;

            if (!printDoc.PrinterSettings.IsValid)
                throw new Exception("Printer not valid.");

            m_currentPageIndex = 0;
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            printDoc.Print();
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);

            ev.Graphics.DrawImage(pageImage, ev.PageBounds);

            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }


        //Below Code for Text to Thermal
        public void PrintFAN(DataTable dtSalesData, string printerName)
        {
            
            //  PrintDialog pd = new PrintDialog();
            pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font(FontName, 15);
            // pd.Document = pdoc;
            pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

            if(dtSalesData != null && dtSalesData.Rows.Count> 0)
            {
                custName = dtSalesData.Rows[0]["CustomerName"].ToString();
                invoiceNo = dtSalesData.Rows[0]["InvNo"].ToString();
                invoiceDate = dtSalesData.Rows[0]["InvDate"].ToString();
                grossTotal = dtSalesData.Rows[0]["FinacialGrossAmount"].ToString();
                discount = dtSalesData.Rows[0]["FinacialDiscount"].ToString();
                netTotal = dtSalesData.Rows[0]["FinacialNetAmount"].ToString();

                srNo = new string[dtSalesData.Rows.Count];
                description = new string[dtSalesData.Rows.Count];
                hsnCode = new string[dtSalesData.Rows.Count];
                rate = new string[dtSalesData.Rows.Count];
                qty = new string[dtSalesData.Rows.Count];
                for (int i = 0; i < dtSalesData.Rows.Count; i++)
                {
                    srNo[i] = dtSalesData.Rows[i]["SrNo"].ToString();
                    description[i] = dtSalesData.Rows[i]["Description"].ToString();
                    hsnCode[i] = dtSalesData.Rows[i]["HSNCode"].ToString();
                    rate[i] = dtSalesData.Rows[i]["FinacialGrossRate"].ToString();
                    qty[i] = dtSalesData.Rows[i]["Qty"].ToString();
                }

                //GetDataForPrint(salesId);
                //pdoc.PrinterSettings.PrinterName = "PDFCreator";
                pdoc.PrinterSettings.PrinterName = printerName;
                pdoc.Print();
            }

            //if (salesId > 0)
            //{
            //    Sale _objSales = new Sale(GeneralObjects.ErrLogger, GeneralObjects.DbHelper);
            //    DataTable dtSales = _objSales.GetInvReportData(salesId);
            //    if (dtSales.Rows.Count > 0)
            //    {
            //        srNo = new string[dtSales.Rows.Count];
            //        description = new string[dtSales.Rows.Count]; 
            //        hsnCode = new string[dtSales.Rows.Count];
            //        rate = new string[dtSales.Rows.Count];
            //        for(int i=0;i< dtSales.Rows.Count;i++)
            //        {
            //            srNo[i] = i+1.ToString();
            //            description[i] = dtSales.Rows[i]["Description"].ToString();
            //            hsnCode[i] = dtSales.Rows[i]["HSNCode"].ToString();
            //            rate[i] = dtSales.Rows[i]["GrossRate"].ToString();
            //        }

            //        //GetDataForPrint(salesId);
            //        pdoc.PrinterSettings.PrinterName = "PDFCreator";
            //        pdoc.Print();
            //    }
            //}
            //else
            //{
            //    //MessageBox.Show("Enter Valid Load Numbre");
            //}
        }

        void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font(FontName, HeaderFontSize);
            int fontHeightHeader = 20; // Convert.ToInt32(font.GetHeight());
            font = new Font(FontName, TextFontSize);
            int fontHeightText = 20; // Convert.ToInt32(font.GetHeight());
            int startX = 50;
            int startY = 10;
            int Offset = 10;
            string strvalue = "";


            graphics.DrawString("\t"+ _projCustName, new Font(FontName, HeaderFontSize),
                                new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + fontHeightHeader;
            graphics.DrawString("\t"+_projCustAddress, new Font(FontName, TextFontSize),
                                new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + fontHeightHeader;
            Offset = Offset + fontHeightHeader;
           
            string underLine = "------------------------------------";
            graphics.DrawString(underLine, new Font(FontName, TextFontSize),
                     new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + fontHeightText;
            graphics.DrawString("Name :" + this.custName + "\t" + "Invoice No.: " + this.invoiceNo, 
                    new Font(FontName, TextFontSize),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + fontHeightText;
           
            graphics.DrawString("\t\t\tDate:" + this.invoiceDate,
                       new Font(FontName, TextFontSize),
                       new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + fontHeightText;
            
            graphics.DrawString("Sr.No." + "\t" + "Desc." + "\t" + "HSN" + "\t\t" + "Qty." + "\t" + "Rate",
      new Font(FontName, TextFontSize),
      new SolidBrush(Color.Black), startX, startY + Offset);

            Offset = Offset + fontHeightText;

            for (int i = 0; i < this.srNo.Length; i++)
            {
                if (srNo[i] != null)
                {
                    hsnCode[i] = string.IsNullOrEmpty(hsnCode[i]) ? "        " : hsnCode[i];

                    strvalue = srNo[i] + "\t" + description[i] + "\t" + hsnCode[i] + "\t" + qty[i] + "\t" + rate[i];
                    graphics.DrawString(strvalue,
                    new Font(FontName, TextFontSize),
                    new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + fontHeightText;
                }
            }
            graphics.DrawString(underLine, new Font(FontName, TextFontSize),
                     new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + fontHeightText;
            graphics.DrawString("\t\t Gross Total:\t"+ this.grossTotal,
                     new Font(FontName, TextFontSize),
                     new SolidBrush(Color.Black), startX, startY + Offset);
            //Offset = Offset + fontHeightText + fontHeightText;
            Offset = Offset + fontHeightText;
            graphics.DrawString("\t\t Discount:\t\t" + this.discount,
                     new Font(FontName, TextFontSize),
                     new SolidBrush(Color.Black), startX, startY + Offset);
            //Offset = Offset + fontHeightText + fontHeightText;
            Offset = Offset + fontHeightText;
            graphics.DrawString("\t\t Net Total:\t\t" + this.netTotal,
                     new Font(FontName, TextFontSize),
                     new SolidBrush(Color.Black), startX, startY + Offset);

            Offset = Offset + fontHeightText;// + fontHeightText + fontHeightText + fontHeightText;
            graphics.DrawString(underLine, new Font(FontName, TextFontSize),
                    new SolidBrush(Color.Black), startX, startY + Offset);

        }

    }
}
