using System;
using System.Data;
using System.Globalization;
using NDatabaseHandler;
using NErrorHandler;

namespace NDatabaseAccess
{
    public class GeneralSettings
    {
        #region "Private Variable"
        private string strSQL;
        private DataAccess objDataAccess;
        private ErrorHandler objErrorLogger;
        #endregion

        #region "Constructor/Destructor"
        public GeneralSettings(ErrorHandler errorLogger, DataAccess dataAccess)
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

        ~GeneralSettings()
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
        public object GetParamValue(int id)
        {
            object paramValue = 0;
            try
            {
                strSQL = "SELECT ParamValue From GeneralSettings Where Id = " + id;
                paramValue = objDataAccess.ExecuteScalar(strSQL);
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile(ex);
            }
            return paramValue;
        }

        public bool UpdateParamValue(int id, object val)
        {
            bool retFlag = false;
            try
            {
                strSQL = "UPDATE GeneralSettings SET ParamValue = '" + val + "' Where Id = " + id;
                retFlag = Convert.ToBoolean(objDataAccess.ExecuteNonQuery(strSQL));
            }
            catch (Exception ex)
            {
                objErrorLogger.WritetoLogFile(ex);
            }
            return retFlag;
        }

        #endregion
    }
}
