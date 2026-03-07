using System;
using System.Data;
using System.Globalization;
using NDatabaseHandler;
using NErrorHandler;

namespace NDatabaseAccess
{
    public class DayEndOperations
    {
        #region "Private Variable"
        private string strSQL;
        private DataAccess objDataAccess;
        private ErrorHandler objErrorLogger;
        #endregion

        #region "Constructor/Destructor"
        public DayEndOperations(ErrorHandler errorLogger, DataAccess dataAccess)
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

        ~DayEndOperations()
        {
            if (objDataAccess != null)
                objDataAccess = null;

            if (objErrorLogger != null)
                objErrorLogger = null;

            if (strSQL != null)
                strSQL = null;
        }
        #endregion

        #region "Public Methods"
        public DataTable GetEmployees()
        {
            DataTable objDataTable = null;
            try
            {
                strSQL = "SELECT Id [EmpId] FROM EmployeeMaster WHERE IsActive = 1";
                objDataTable = objDataAccess.GetDataTable(strSQL);
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile("DayEndOperation : GetEmployees");
                objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        public void SaveLeaveEarned(long empId, int currMonth, int currYear, int leaveType, double leaveDays)
        {
            try
            {
                strSQL = "SaveLeaveEarned";

                string[] param = new string[6] { "@EmployeeId", "@Month", "@Year", "@LeaveType", "@LeaveDays", "@UpdatedBy" };
                object[] values = new object[6] { empId , currMonth, currYear, leaveType, leaveDays, 1};

                int id = objDataAccess.ExecuteNonQueryWithReturnValue(strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile("DayEndOperation : SaveLeaveEarned");
                objErrorLogger.WritetoLogFile(ex);
            }
        }

        public bool CheckAlareadyExistLeaveEarned(long empId, int month, int year)
        {
            bool retFlag = false;
            try
            {
                strSQL = string.Format("SELECT COUNT(*) FROM LeaveEarned WHERE EmployeeId = {0} AND [Month] = {1} AND [Year] = {2}", empId, month, year);
                retFlag = Convert.ToBoolean(objDataAccess.ExecuteScalar(strSQL));
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile("DayEndOperation : SaveLeaveEarned");
                objErrorLogger.WritetoLogFile(ex);
            }
            return retFlag;
        }
        #endregion
    }
}
