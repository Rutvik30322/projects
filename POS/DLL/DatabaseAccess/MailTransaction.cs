using System;
using System.Data;
using NDatabaseHandler;
using NErrorHandler;

namespace NDatabaseAccess
{
    public class MailTransaction
    {
        #region "Private Variable"
        private DataAccess objDataAccess;
        private ErrorHandler objErrorLogger;
        #endregion

        #region "Constructor/Destructor"
        public MailTransaction(ErrorHandler errorLogger, DataAccess dataAccess)
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
              public DataTable GetPendingMail()
        {
            DataTable objDataTable = null;
            try
            {
                string strSQL = "SELECT MT.Id [Id], MM.CandidateId, MM.PostJobId, MM.EmailTempleteId, MT.UserId " +
                    " FROM MailMaster MM LEFT JOIN MailTransaction MT ON MM.Id = MT.MailMasterId " +
                    " WHERE MT.IsMailSent = 0";
                objDataTable = objDataAccess.GetDataTable(strSQL);
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        public bool UpdateEmailSendStatus(long id)
        {
            bool retFlag = false;
            try
            {
                string strSQL = "UPDATE MailTransaction SET IsMailSent = 1 WHERE Id = " + id;
                retFlag = Convert.ToBoolean(objDataAccess.ExecuteNonQuery(strSQL));
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile(ex);
            }
            return retFlag;
        }

        public DataTable GetMailDetails(int candidateId, int postJobId, int emailTemplete, int userId)
        {
            DataTable objDataTable = null;
            try
            {
                string strSQL = "GetEmailSendData";
                string[] paramArray = new string[4] { "@param0", "@param1", "@param2", "@param3" };
                object[] values = new object[4] { candidateId, postJobId, emailTemplete, userId };
                objDataTable = objDataAccess.GetDataTable(strSQL, paramArray, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }
        #endregion

    }
}
