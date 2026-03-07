using System;
using System.Data;
using NDatabaseHandler;
using NErrorHandler;
namespace NDatabaseAccess
{
    public class ServicesConfig : IDisposable
    {
        #region Private Variable
        private DataAccess objDataAccess;
        private ErrorHandler objErrorLogger;
        #endregion

        #region Constructor/Destructor
        public ServicesConfig(ErrorHandler errorLogger, DataAccess dataAccess)
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

        #region Dispose
        private bool _disposed = false;

        /// <summary>
        /// Dispose method (public)
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///  Dispose method (protected)
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) { return; }
            if (disposing)
            {
                // TODO: Dispose managed objects - created, managed and under scope of CLR. (string, int, bool variables, etc.)

            }
            // TODO: Dispose unmanaged objects - wrapped around operating system resources like file streams, database connections, network related instances, handles to different classes, registries, pointers, etc.
            // TODO: set large fields to null

            if (objDataAccess != null)
            {
                objDataAccess = null;
            }
            if (objErrorLogger != null)
            {
                objErrorLogger = null;
            }

            _disposed = true;
        }
        #endregion

        /// <summary>
        /// Destructor
        /// </summary>
        ~ServicesConfig()
        {
            Dispose(false);
        }
        #endregion

        #region Public Methods  
        public DataTable GetServicesConfigList()
        {
            DataTable objDataTable = null;
            try
            {
                string strSQL = "select Id,ServiceName From ServicesConfig WHERE IsActive = 1 ORDER BY Id ASC";
                objDataTable = objDataAccess.GetDataTable(strSQL);
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
