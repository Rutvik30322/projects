using System;
using System.Data;
using NDatabaseHandler;
using NErrorHandler;

namespace NDatabaseAccess
{
    public class EmailConfig
    {
        #region "Private Variable"
        private DataAccess objDataAccess;
        private ErrorHandler objErrorLogger;
        #endregion

        #region "Constructor/Destructor"
        public EmailConfig(ErrorHandler errorLogger, DataAccess dataAccess)
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
        #endregion

        #region "Public Methods"
        public DataTable GetEmailConfig()
        {
            DataTable objDataTable = null;
            try
            {
                string strSQL = "SELECT EmailAddress, UserName, [Password], SmtpHost, SmtpPort, EnableSsl, EmailDisplayName, UseDefaultCredentials FROM " +
                    " EmailConfig Where IsActive = 1 ";
                objDataTable = objDataAccess.GetDataTable(strSQL);
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile("Email Config : GetEmailConfig");
                objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }


        public DataTable GetPendingAppliedLeave()
        {
            DataTable objDataTable = null;
            try
            {
                string strSql = "SELECT L.Id, dbo.GetEmployeeCode(L.EmpId) [EmployeeCode], dbo.GetEmployeeFullName(L.EmpId) [EmployeeName], " +
                    "FORMAT(L.LeaveDate, 'dd-MM-yyyy') [LeaveDate], LT.LeaveType, FORMAT(L.TransactionDate, 'dd-MM-yyyy') [ApplyDate], dbo.GetEmployeeEmail(L.EmpId) [EmpEmail], " +
                    "dbo.GetEmployeeEmail(EM.ApproverId)[ApproverEmail], dbo.GetListText('LeaveSession', DayType) [DayType] FROM LeaveTransaction L Join LeaveTypes LT On L.LeaveType = LT.Id " +
                    "Join EmployeeApproverMapper EM On EM.EmpId = L.EmpId " +
                    "WHERE EM.IsActive = 1 AND AppliedIntimation = 0";
                objDataTable = objDataAccess.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile("Email Config : GetPendingAppliedLeave");
                objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        public DataTable GetPendingApprovedLeave()
        {
            DataTable objDataTable = null;
            try
            {
                string strSql = "SELECT L.Id, dbo.GetEmployeeCode(L.EmpId) [EmployeeCode], dbo.GetEmployeeFullName(L.EmpId) [EmployeeName], FORMAT(L.LeaveDate, 'dd-MM-yyyy') [LeaveDate], " +
                    "LT.LeaveType, FORMAT(L.TransactionDate, 'dd-MM-yyyy') [ApplyDate], FORMAT(L.ApprovalDate, 'dd-MM-yyyy') [ApprovalDate], " +
                    "dbo.GetListText('LeaveStatus', L.LeaveStatus) [LeaveStatus], dbo.GetEmployeeName(L.ApprovalBy) [ApprovalBy], L.ApprovalRemarks, dbo.GetEmployeeEmail(L.EmpId) [EmpEmail], " +
                    "dbo.GetEmployeeEmail(EM.ApproverId) [ApproverEmail], dbo.GetListText('LeaveSession', DayType) [DayType] FROM LeaveTransaction L Join LeaveTypes LT On L.LeaveType = LT.Id " +
                    "Join EmployeeApproverMapper EM On EM.EmpId = L.EmpId " +
                    "WHERE EM.IsActive = 1 AND AppliedIntimation = 1 AND ApprovedIntimation = 1";
                objDataTable = objDataAccess.GetDataTable(strSql);
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile("Email Config : GetPendingAppliedLeave");
                objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        public bool UpdateAppliedIntimation(long id)
        {
            bool retFlag = false;
            try
            {
                string strSql = "UPDATE LeaveTransaction SET AppliedIntimation = 1 Where Id = " + id;
                retFlag = Convert.ToBoolean(objDataAccess.ExecuteNonQuery(strSql));
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile("Email Config : UpdateAppliedIntimation");
                objErrorLogger.WritetoLogFile(ex);
            }
            return retFlag;
        }

        public bool UpdateApprovedIntimation(long id)
        {
            bool retFlag = false;
            try
            {
                string strSql = "UPDATE LeaveTransaction SET ApprovedIntimation = 2 Where Id = " + id;
                retFlag = Convert.ToBoolean(objDataAccess.ExecuteNonQuery(strSql));
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile("Email Config : UpdateApprovedIntimation");
                objErrorLogger.WritetoLogFile(ex);
            }
            return retFlag;
        }

        public DataTable GetPendingAppliedRegularization()
        {
            DataTable objDataTable = null;
            try
            {
                string strSQL = "GetPendingAppliedRegularization";
                objDataTable = objDataAccess.GetDataTable(strSQL, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile("Email Config : GetPendingAppliedRegularization");
                objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        public DataTable GetPendingApprovedRegularization()
        {
            DataTable objDataTable = null;
            try
            {
                string strSQL = "GetPendingApprovedRegularization";
                objDataTable = objDataAccess.GetDataTable(strSQL, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile("Email Config : GetPendingAppliedLeave");
                objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        public bool UpdateRegularizationAppliedIntimation(long id)
        {
            bool retFlag = false;
            try
            {
                string strSql = "UPDATE Regularization SET AppliedIntimation = 1 Where Id = " + id;
                retFlag = Convert.ToBoolean(objDataAccess.ExecuteNonQuery(strSql));
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile("Email Config : UpdateRegularizationAppliedIntimation");
                objErrorLogger.WritetoLogFile(ex);
            }
            return retFlag;
        }

        public bool UpdateRegularizationApprovedIntimation(long id)
        {
            bool retFlag = false;
            try
            {
                string strSql = "UPDATE Regularization SET ApprovedIntimation = 2 Where Id = " + id;
                retFlag = Convert.ToBoolean(objDataAccess.ExecuteNonQuery(strSql));
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile("Email Config : UpdateRegularizationApprovedIntimation");
                objErrorLogger.WritetoLogFile(ex);
            }
            return retFlag;
        }
        #endregion

    }
}
