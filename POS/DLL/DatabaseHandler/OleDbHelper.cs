namespace NDatabaseHandler
{
    using System.Data;
    using  NErrorHandler;
    using System;

    public class OleDbHelper
    {
        DataAccess objDataAccess;
        private ErrorHandler errHandler;

        public OleDbHelper(string connString)
        {
            errHandler = new ErrorHandler("OleDbHelper");
            objDataAccess = new DataAccess(connString, errHandler);
        }

        public object ExecuteScalar(CommandType cmdType, string strSql)
        {
            object result=null;
            try
            {
                result = objDataAccess.ExecuteScalar(strSql);
            }
            catch (Exception ex)
            {
                if (errHandler != null)
                    errHandler.WritetoLogFile(ex);
            }
            return result;
        }

        public object ExecuteScalar(CommandType cmdType, string strSql, object[] paramList)
        {
            object result = null;
            try
            {
                // //Pendign:: Replace {S} or {F} with ParamList values
                //for (int i = 0; i < paramList.Length; i++)
                //{

                //}
                result = objDataAccess.ExecuteScalar(strSql);
            }
            catch (Exception ex)
            {
                if (errHandler != null)
                    errHandler.WritetoLogFile(ex);
            }
            return result;
        }

        public int ExecuteNonQuery(CommandType cmdType, string strSql)
        {
            int result = 0;
            try
            {
                result = objDataAccess.ExecuteNonQuery(strSql);
            }
            catch (Exception ex)
            {
                if (errHandler != null)
                    errHandler.WritetoLogFile(ex);
            }
            return result;
        }

        public int ExecuteNonQuery(CommandType cmdType, string strSql, object[] paramList)
        {
            int result = 0;
            try
            {
                // //Pendign:: Replace {S} or {F} with ParamList values
                //for (int i = 0; i < paramList.Length; i++)
                //{
                    
                //}

                result = objDataAccess.ExecuteNonQuery(strSql);
            }
            catch (Exception ex)
            {
                if (errHandler != null)
                    errHandler.WritetoLogFile(ex);
            }
            return result;
        }

        public DataSet ExecuteDataSet(CommandType cmdType, string strSql)
        {
            DataSet objDataSetTemp = new DataSet();
            try
            {
                objDataAccess.GetDataSet(strSql);
            }
            catch (Exception ex)
            {
                if (errHandler != null)
                    errHandler.WritetoLogFile(ex);
            }
            return objDataSetTemp;
        }

        public DataSet ExecuteDataSet(CommandType cmdType, string strSql, object[] paramList)
        {
            DataSet objDataSetTemp = new DataSet();
            try
            {
                // //Pendign:: Replace {S} or {F} with ParamList values
                //for (int i = 0; i < paramList.Length; i++)
                //{

                //}
                objDataAccess.GetDataSet(strSql);
            }
            catch (Exception ex)
            {
                if (errHandler != null)
                    errHandler.WritetoLogFile(ex);
            }
            return objDataSetTemp;
        }
        public void FillDataset(CommandType cmdType, string strSql, ref DataSet objDataSet, string[] tableName)
        {
            try
            {
                DataSet objDataSetTemp = new DataSet();
                objDataAccess.GetDataSet(strSql);

                int index = 0;
                foreach (DataTable dt in objDataSetTemp.Tables)
                {
                    if (index < tableName.Length)
                    {
                        objDataSetTemp.Tables[index].TableName = tableName[index];
                    }
                }

                objDataSet = objDataSetTemp;

            }
            catch (Exception ex)
            {
                if (errHandler != null)
                    errHandler.WritetoLogFile(ex);
            }
        }

        public static short ShortCheckNull(DataRow dr, string fieldname)
        {
            short result = 0;
            try
            {
                if (dr[fieldname] != null)
                {
                    result = Convert.ToInt16(dr[fieldname]);
                }

            }
            catch
            {
            }
            return result;
        }

        public static int IntCheckNull(DataRow dr, string fieldname)
        {
            int result = 0;
            try
            {
                if (dr[fieldname] != null)
                {
                    result = Convert.ToInt32(dr[fieldname]);
                }

            }
            catch
            {
            }
            return result;
        }

        public static double DblCheckNull(DataRow dr, string fieldname)
        {
            double result = 0.0;
            try
            {
                if (dr[fieldname] != null)
                {
                    result = Convert.ToDouble(dr[fieldname]);
                }

            }
            catch
            {
            }
            return result;
        }

        public static string StrCheckNull(DataRow dr, string fieldname)
        {
            string result = "";
            try
            {
                if (dr[fieldname] != null)
                {
                    result = Convert.ToString(dr[fieldname]);
                }

            }
            catch
            {
            }
            return result;
        }

    }
}
