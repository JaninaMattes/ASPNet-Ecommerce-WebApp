using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.DAL
{
    //source: https://gist.github.com/selim07/4705ae22db316416308c

    public class SqlDataAccess
    {
        //Default connection string. a connection named MsSql should be defined in web.config file.
        //tutorial: https://www.youtube.com/watch?v=aoFDyt8oG0k&list=PL6n9fhu94yhX5dzHunAI2t4kE0kOuv4D7 
        //public const string CONNECTION_STRING_LOCALH = "datasource = .; database = LaitBrasseurDatabase; integrated security=SSPI"; 
        public const string CONNECTION_STRING_NAME = "LaitBrasseurDB";

            //This returns the connection string  
            private static string _connectionString = string.Empty;
            public static string ConnectionString
            {
                get
                {
                    if (_connectionString == string.Empty)
                    {
                        try
                        {
                            _connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_STRING_NAME].ConnectionString;
                        }
                        catch (ConfigurationErrorsException e)
                        {
                            e.GetBaseException();
                        }
                       
                    }
                    return _connectionString;
                }
            }

        /// <summary>
        /// Brings a SqlCommand object to be able to add some parameters in it. 
        /// After send this to Execute method.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public SqlCommand GetCommand(string sql)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlCmd = new SqlCommand(sql, conn);
            return sqlCmd;
        }

        public DataTable Execute(string sql)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = GetCommand(sql);
            cmd.Connection.Open();
            dt.Load(cmd.ExecuteReader());
            cmd.Connection.Close();
            return dt;
        }

        public int ExecuteStoredProcedure(SqlCommand command)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Connection.Open();
            int result = command.ExecuteNonQuery();
            command.Connection.Close();
            return result;
        }
    }
}