using System;
using System.Data;
using NDatabaseHandler;
using NErrorHandler;

namespace NDatabaseAccess
{
    public class Users
    {
        #region "Private Variable"
        private string _strSQL;
        private DataAccess _objDataAccess;
        private ErrorHandler _objErrorLogger;
        #endregion

        #region "Constructor/Destructor"
        public Users(ErrorHandler errorLogger, DataAccess dataAccess)
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

        ~Users()
        {
            if (_objDataAccess != null)
                _objDataAccess = null;

            if (_objErrorLogger != null)
                _objErrorLogger = null;

            if (_strSQL != null)
                _strSQL = null;
        }
        #endregion

        #region "Public Methods"
        public DataTable ValidateUser(string userName)
        {
            DataTable objDataTable = null;
            try
            {
                string[] param = new string[1] { "@UserName" };
                object[] values = new object[1] { userName };
                _strSQL = "ValidateUser";

                objDataTable = _objDataAccess.GetDataTable(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Users : ValidateUser");
                _objErrorLogger.WritetoLogFile(ex);
            }

            return objDataTable;
        }

        public bool RequestForResetPwd(string uName)
        {
            bool retFlag = false;
            int uID = 0;
            try
            {
                string strSQL = "SELECT Id FROM Users WHERE UserName = '" + uName + "' AND IsActive = 1";
                uID = Convert.ToInt16(_objDataAccess.ExecuteScalar(strSQL));
                strSQL = "UPDATE Users  SET  ResetPasswordRequest = 1, ResetPasswordRequestDate = GETDATE()  WHERE ID = '" + uID + " ' ";
                retFlag = Convert.ToBoolean(_objDataAccess.ExecuteNonQuery(strSQL));
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Users : RequestForResetPwd");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return retFlag;
        }

        public DataTable GetUser(int userId, int isActive, int roleType)
        {
            DataTable objDataTable = null;
            try
            {
                string[] param = new string[3] { "@UserId", "@IsActive", "@RoleType" };
                object[] values = new object[3] { userId, isActive, roleType };

                _strSQL = "GetUser";
                objDataTable = _objDataAccess.GetDataTable(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("User : GetUser");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }

        public int SaveUser(string firstName, string lastName, string userName, string password, DateTime expiryDate, int roleId, string passwordSalt, int updatedBy, string systemName)
        {
            int ReturnValue = -1;
            try
            {
                string[] param = new string[9];
                param[0] = "@FirstName";
                param[1] = "@LastName";
                param[2] = "@UserName";
                param[3] = "@Password";
                param[4] = "@ExpiryDate";
                param[5] = "@RoleId";
                param[6] = "@PasswordSalt";
                param[7] = "@UpdatedBy";
                param[8] = "@SystemName";

                object[] values = new object[9];
                values[0] = firstName;
                values[1] = lastName;
                values[2] = userName;
                values[3] = password;
                values[4] = expiryDate;
                values[5] = roleId;
                values[6] = passwordSalt;
                values[7] = updatedBy;
                values[8] = systemName;

                _strSQL = "SaveUser";
                ReturnValue = _objDataAccess.ExecuteNonQueryWithReturnValue(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("UOM : SaveUOM");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return ReturnValue;
        }

        public int UpdateUser(int id, string firstName, string lastName, DateTime expiryDate, int roleId, int updatedBy, string systemName)
        {
            int ReturnValue = -1;
            try
            {
                string[] param = new string[7];
                param[0] = "@Id";
                param[1] = "@FirstName";
                param[2] = "@LastName";
                param[3] = "@ExpiryDate";
                param[4] = "@RoleId";
                param[5] = "@UpdatedBy";
                param[6] = "@SystemName";

                object[] values = new object[7];
                values[0] = id;
                values[1] = firstName;
                values[2] = lastName;
                values[3] = expiryDate;
                values[4] = roleId;
                values[5] = updatedBy;
                values[6] = systemName;

                _strSQL = "UpdateUser";
                ReturnValue = _objDataAccess.ExecuteNonQueryWithReturnValue(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("UOM : SaveUOM");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return ReturnValue;
        }

        public DataTable GetRole(int roleId, int isActive)
        {
            DataTable objDataTable = null;
            try
            {
                string[] param = new string[2] { "@RoleId", "@IsActive" };
                object[] values = new object[2] { roleId, isActive };

                _strSQL = "GetRole";
                objDataTable = _objDataAccess.GetDataTable(_strSQL, param, values, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Users : GetRole");
                _objErrorLogger.WritetoLogFile(ex);
            }
            return objDataTable;
        }
        #endregion

        #region "Change Password"
        public string GetUserPassword(long userId)
        {
            string password = "";
            try
            {
                _strSQL = "GetUserPassword";
                string[] param = new string[1] { "@UserId" };
                object[] values = new object[1] { userId };

                password = Convert.ToString(_objDataAccess.ExecuteScalar(_strSQL, param, values, CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile(string.Format("Message:{0}, Exception:{1}", ex.Message, ex));
                return password;
            }
            return password;
        }

        public bool UpdateChangePassword(long userId, string password, string passwordSalt)
        {
            bool retFlag = false;
            try
            {
                string[] param = new string[4];
                param[0] = "@UserId";
                param[1] = "@Password";
                param[2] = "@PasswordSalt";
                param[3] = "@UpdatedBy";

                object[] values = new object[4];
                values[0] = userId;
                values[1] = password;
                values[2] = passwordSalt;
                values[3] = userId;

                string strSQL = "ChangePassword";
                retFlag = Convert.ToBoolean(_objDataAccess.ExecuteNonQuery(strSQL, param, values, CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile(string.Format("Message:{0}, Exception:{1}", ex.Message, ex));
                return retFlag;
            }
            return retFlag;
        }
        #endregion

        #region "Reset Password"
        public DataTable GetUserDetailsForResetPassword()
        {
            DataTable objDataTable = null;
            try
            {
                _strSQL = "GetUserDetailsForResetPassword";

                objDataTable = _objDataAccess.GetDataTable(_strSQL, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile("Users : ValidateUser");
                _objErrorLogger.WritetoLogFile(ex);
            }

            return objDataTable;
        }

        public bool ResetUserPassword(long userId, string password, string passwordSalt)
        {
            bool retFlag = false;
            try
            {
                string[] param = new string[4];
                param[0] = "@Id";
                param[1] = "@Password";
                param[2] = "@PasswordSalt";
                param[3] = "@UpdatedBy";

                object[] values = new object[4];
                values[0] = userId;
                values[1] = password;
                values[2] = passwordSalt;
                values[3] = userId;

                string strSQL = "ResetUserPassword";
                retFlag = Convert.ToBoolean(_objDataAccess.ExecuteNonQuery(strSQL, param, values, CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                _objErrorLogger.WritetoLogFile(string.Format("Message:{0}, Exception:{1}", ex.Message, ex));
                return retFlag;
            }
            return retFlag;
        }
        #endregion
    }
}
