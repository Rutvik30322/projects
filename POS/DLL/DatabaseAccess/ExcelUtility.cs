using NDatabaseHandler;
using NErrorHandler;
using System;
using System.Data;
using ClosedXML.Excel;
using System.IO;


namespace NDatabaseAccess
{
    public class ExcelUtility
    {
        private DataAccess objDataAccess;
        private ErrorHandler objErrorLogger;
        XLWorkbook xLWorkbook;
        //private CostSheet objCostSheet;
        private GeneralDB objGeneralDB;
        public ExcelUtility(ErrorHandler errorLogger, DataAccess dataAccess)
        {
            try
            {
                objDataAccess = dataAccess;
                objErrorLogger = errorLogger;
                //objCostSheet = new CostSheet(objErrorLogger, objDataAccess);
                objGeneralDB = new GeneralDB(objErrorLogger, objDataAccess);
            }
            catch (Exception ex)
            {
                errorLogger.WritetoLogFile(ex);
            }
        }

        ~ExcelUtility()
        {
            if (objDataAccess != null)
            {
                objDataAccess = null;
            }
            if (objErrorLogger != null)
            {
                objErrorLogger = null;
            }
            if (objGeneralDB != null)
            {
                objGeneralDB = null;
            }
        }

        public string ExportToExcel(DataTable dt, string sheetName)
        {
            try
            {
                string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), sheetName);
                XLWorkbook xLWorkbook = new XLWorkbook();
                xLWorkbook.Worksheets.Add(dt, sheetName);
                xLWorkbook.SaveAs(folderPath + ".xlsx");
                return folderPath;
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile("ExcelUtility : ExportToExcel", true);
                objErrorLogger.WritetoLogFile(ex);
                return null;
            }
        }
    }
}
