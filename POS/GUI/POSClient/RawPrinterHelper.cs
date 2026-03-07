using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing.Printing;

namespace POSClient
{
    public class RawPrinterHelper
    {
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true)]
        public static extern bool OpenPrinter(string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter")]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, int level, [In] ref DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter")]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter")]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter")]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter")]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

        [StructLayout(LayoutKind.Sequential)]
        public struct DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }

        //public static bool SendStringToPrinter(string printerName, string tsplCommand)
        //{
        //    IntPtr pPrinter;
        //    DOCINFOA docInfo = new DOCINFOA
        //    {
        //        pDocName = "TSPL_Label",
        //        pDataType = "RAW"
        //    };

        //    if (OpenPrinter(printerName.Normalize(), out pPrinter, IntPtr.Zero))
        //    {
        //        if (StartDocPrinter(pPrinter, 1, ref docInfo))
        //        {
        //            StartPagePrinter(pPrinter);

        //            IntPtr pBytes = Marshal.StringToCoTaskMemAnsi(tsplCommand);
        //            WritePrinter(pPrinter, pBytes, tsplCommand.Length, out _);
        //            Marshal.FreeCoTaskMem(pBytes);

        //            EndPagePrinter(pPrinter);
        //            EndDocPrinter(pPrinter);
        //        }
        //        ClosePrinter(pPrinter);
        //        return true;
        //    }
        //    return false;
        //}

        public static bool SendStringToPrinter(string printerName, string tsplCommand)
        {
            IntPtr pPrinter;
            DOCINFOA docInfo = new DOCINFOA
            {
                pDocName = "TSPL Command",
                pDataType = "RAW"
            };
            bool success = false;

            if (OpenPrinter(printerName.Normalize(), out pPrinter, IntPtr.Zero))
            {
                if (StartDocPrinter(pPrinter, 1, ref docInfo))
                {
                    if (StartPagePrinter(pPrinter))
                    {
                        IntPtr pUnmanagedBytes = Marshal.StringToCoTaskMemAnsi(tsplCommand);
                        success = WritePrinter(pPrinter, pUnmanagedBytes, tsplCommand.Length, out _);
                        Marshal.FreeCoTaskMem(pUnmanagedBytes);
                        EndPagePrinter(pPrinter);
                    }
                    EndDocPrinter(pPrinter);
                }
                ClosePrinter(pPrinter);
            }
            return success;
        }

        //public void PrintLabel(string printerName, string barcodeValue, string productName, string size, string artNo, string mrp)
        //{
        //    string command = $@"
        //SIZE 104 mm, 25 mm
        //GAP 2 mm, 0
        //DIRECTION 1
        //CLS

        //BARCODE 50,40,""128"",60,1,0,2,2,""{barcodeValue}""
        //TEXT 50,130,""2"",0,1,1,""Product: {productName}""
        //TEXT 50,155,""2"",0,1,1,""Size: {size}  Art no.: {artNo}""
        //TEXT 50,180,""2"",0,1,1,""MRP: {mrp}""

        //BARCODE 470,40,""128"",60,1,0,2,2,""{barcodeValue}""
        //TEXT 470,130,""2"",0,1,1,""Product: {productName}""
        //TEXT 470,155,""2"",0,1,1,""Size: {size}  Art no.: {artNo}""
        //TEXT 470,180,""2"",0,1,1,""MRP: {mrp}""

        //PRINT 1,1
        //";
        //    RawPrinterHelper.SendStringToPrinter(printerName, command);
        //}

        //        public void PrintLabel(string printerName, string barcodeValue, string productName, string size, string artNo, string mrp, string secondBarcodeValue = null, string secondProductName = null, string secondSize = null, string secondArtNo = null, string secondMrp = null)
        //        {
        //            string command = $@"
        //SIZE 104 mm, 25 mm
        //GAP 2 mm, 0
        //DIRECTION 1
        //CLS

        //BARCODE 50,40,""128"",60,1,0,2,2,""{barcodeValue}""
        //TEXT 50,130,""2"",0,1,1,""Product: {productName}""
        //TEXT 50,155,""2"",0,1,1,""Size: {size}  Art no.: {artNo}""
        //TEXT 50,180,""2"",0,1,1,""MRP: {mrp}""";

        //            // Check if the second barcode and its details are provided
        //            if (!string.IsNullOrEmpty(secondBarcodeValue))
        //            {
        //                // If second barcode and its details are available, add them to the print command
        //                command += $@"
        //BARCODE 470,40,""128"",60,1,0,2,2,""{secondBarcodeValue}""
        //TEXT 470,130,""2"",0,1,1,""Product: {(secondProductName ?? "N/A")}""
        //TEXT 470,155,""2"",0,1,1,""Size: {(secondSize ?? "N/A")}  Art no.: {(secondArtNo ?? "N/A")}""
        //TEXT 470,180,""2"",0,1,1,""MRP: {(secondMrp ?? "N/A")}""";
        //            }
        //            command += "PRINT 1,1";
        //            RawPrinterHelper.SendStringToPrinter(printerName, command);
        //        }

        public void PrintLabel(string printerName, string barcodeValue, string productName, string size, string artNo, string mrp, string secondBarcodeValue = null, string secondProductName = null, string secondSize = null, string secondArtNo = null, string secondMrp = null)
        {
            string command = $@"
SIZE 104 mm, 25 mm
GAP 2 mm, 0
DIRECTION 1
CLS

BARCODE 20,40,""128"",60,1,0,2,2,""{barcodeValue}""
TEXT 20,130,""2"",0,1,1,""Product: {productName}""
TEXT 20,155,""2"",0,1,1,""Size: {size}  Art no.: {artNo}""
TEXT 20,180,""2"",0,1,1,""MRP: {mrp}""

BARCODE 440,40,""128"",60,1,0,2,2,""{secondBarcodeValue}""
TEXT 440,130,""2"",0,1,1,""Product: {secondProductName}""
TEXT 440,155,""2"",0,1,1,""Size: {secondSize}  Art no.: {secondArtNo}""
TEXT 440,180,""2"",0,1,1,""MRP: {secondMrp}""

PRINT 1,1";

            RawPrinterHelper.SendStringToPrinter(printerName, command);
        }
    }
}
