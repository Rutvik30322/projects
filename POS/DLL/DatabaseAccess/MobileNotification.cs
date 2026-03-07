using System;
using System.Data;
using NDatabaseHandler;
using NErrorHandler;

namespace NotificationSequence
{
    public class MobileNotification
    {
        #region "Private Variable"
        private DataAccess _objDataAccess;
        private ErrorHandler _objErrorLogger;
        #endregion

        #region "Constructor/Destructor"
        public MobileNotification(ErrorHandler errorLogger, DataAccess dataAccess)
        {
            try
            {
                _objDataAccess = dataAccess;
                _objErrorLogger = errorLogger;
            }
            catch (Exception ex)
            {
                errorLogger.WritetoLogFile(ex);
            }
        }
        #endregion

        #region "Public Methods"
        public bool GenerateMobileNotification()
        {
            bool retFlag = false;
            try
            {
                string strSQL = "GenerateMobileNotification";
                //objDataTable = objDataAccess.GetDataTable(strSQL, CommandType.StoredProcedure);
                retFlag = Convert.ToBoolean(_objDataAccess.ExecuteNonQuery(strSQL));
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile(string.Format("Message:{0}, Exception:{1}", ex.Message, ex));
                return retFlag;
            }
            return retFlag;
        }

        public DataTable GetPendingNotification()
        {
            DataTable objDataTable = null;
            try
            {
                //string strSQL = "SELECT Id, EmpId, GroupNotification, NotificationTitle, NotificationText, DateAdded FROM MobileNotification " +
                //    "WHERE IsSend = 0 AND CAST(ScheduleDate AS DATE) = CAST(GETDATE() AS DATE) AND ResponseMessageId IS NULL";
                string strSQL = "GetPendingNotification";
                objDataTable = _objDataAccess.GetDataTable(strSQL, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        public bool UpdateNotificationStatus(long id, string responsemessageId)
        {
            bool retFlag = false;
            try
            {
                string strSQL = string.Format("UPDATE MobileNotification SET IsSend = 1, ResponseMessageId = '{1}' WHERE Id = {0}", id, responsemessageId);
                retFlag = Convert.ToBoolean(_objDataAccess.ExecuteNonQuery(strSQL));
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile(ex);
            }
            return retFlag;
        }

        public bool GenerateBirthdayNotification()
        {
            bool retFlag = false;
            try
            {
                string strSQL = "GenerateBirthDayNotification";
                retFlag = Convert.ToBoolean(_objDataAccess.ExecuteNonQuery(strSQL));
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile(string.Format("Message:{0}, Exception:{1}", ex.Message, ex));
                return retFlag;
            }
            return retFlag;
        }

        public void GenerateNotificationforRegularizationApproval(int month, int year)
        {
            try
            {
                string[] param = new string[2] { "@Month", "@Year"};
                object[] values = new object[2] { month, year };

                string strSQL = "GenNotificationForPendingRegApproval";
                _objDataAccess.ExecuteNonQuery(strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("GenerateNotificationforRegularizationApproval");
                _objErrorLogger.WritetoLogFile(string.Format("Message:{0}, Exception:{1}", ex.Message, ex));
                
            }
        }

        public void GenerateNotificationforApplyRegularization(int month, int year)
        {
            try
            {
                string[] param = new string[2] { "@Month", "@Year" };
                object[] values = new object[2] { month, year };

                string strSQL = "GenNotificationForApplyRegularization";
                _objDataAccess.ExecuteNonQuery(strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("GenerateNotificationforApplyRegularization");
                _objErrorLogger.WritetoLogFile(string.Format("Message:{0}, Exception:{1}", ex.Message, ex));

            }
        }
        #endregion
    }
}
