using System;
using System.Data;
using NDatabaseHandler;
using NErrorHandler;

namespace NDatabaseAccess
{
    public class ComputerLists
    {
        #region "Private Variable"
        private int computerCode;
        private string computerName;
        private int status;
        private string strSQL;
        private DataAccess objDataAccess;

        private ErrorHandler objErrorLogger;
        #endregion

        #region "Public Property"
        public int ComputerCode
        {
            get
            {
                return computerCode;
            }
            set
            {
                computerCode = value;
            }
        }

        public string ComputerName
        {
            get
            {
                return computerName;
            }
            set
            {
                computerName = value;
            }
        }
        public int Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
        #endregion

        #region "Public Methods
        public ComputerLists(ErrorHandler errorLogger, DataAccess dataAccess)
        {
            try
            {
                objDataAccess = dataAccess;
                objErrorLogger = errorLogger;
            }
            catch (Exception ex)
            {
                errorLogger.WritetoLogFile(ex);
            }

        }
        public bool GetComputerLists(ref DataTable objDataTable)
        {
            try
            {
                //DataTable objDataTable = new DataTable();
                objDataTable = objDataAccess.GetDataTable("select * From GetComputerLists");

                return true;
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile(ex);
                return false;
            }
        }

        public int GetComputerId(string computerName)
        {
            int retValue = 0;
            try
            {
                retValue = Convert.ToInt16(objDataAccess.ExecuteScalar("SELECT ComputerCode From ComputerLists WHERE ComputerName = '" + computerName + "'"));
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile(ex);
            }
            return retValue;
        }

        public bool InsertComputerLists(string computerName, int status)
        {

            try
            {
                strSQL = "Insert Into ComputerLists (computerName, status) Values('"
                      + computerName + "', '" + +status;

                int result = objDataAccess.ExecuteNonQuery(strSQL);
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile(ex);
                return false;
            }
        }

        public bool UpdateComputerLists(int computerCode, string computerName, int status)
        {
            try
            {
                strSQL = "UPDATE ComputerLists SET ComputerCode = '" + computerCode + "' ComputerName = " + computerName + "', status = '" + status + "' WHERE ComputerCode = '" + computerCode + "'";
                int result = objDataAccess.ExecuteNonQuery(strSQL);
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile(ex);
                return false;
            }
        }

        public bool DeleteComputerLists(int computerCode)
        {
            try
            {
                strSQL = "Delete from ComputerLists Where ComputerCode = " + computerCode;
                int result = objDataAccess.ExecuteNonQuery(strSQL);
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile(ex);
                return false;
            }
        }

        public string GetBarcodePrinter(string computerName)
        {
            string barcodePrinter = "";
            try
            {
                string[] param = new string[1] { "@ComputerName" };
                object[] values = new object[1] { computerName };
                strSQL = "GetBarcodePrinter";
                barcodePrinter = Convert.ToString(objDataAccess.ExecuteScalar(strSQL, param, values, CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile("ComputerLists : GetBarcodePrinter");
                objErrorLogger.WritetoLogFile(ex);
            }
            return barcodePrinter;
        }

        public string GetInvoicePrinter(string computerName)
        {
            string barcodePrinter = "";
            try
            {
                string[] param = new string[1] { "@ComputerName" };
                object[] values = new object[1] { computerName };
                strSQL = "GetInvoicePrinter";
                barcodePrinter = Convert.ToString(objDataAccess.ExecuteScalar(strSQL, param, values, CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile("ComputerLists : GetInvoicePrinter");
                objErrorLogger.WritetoLogFile(ex);
            }
            return barcodePrinter;
        }
        #endregion
    }
}
