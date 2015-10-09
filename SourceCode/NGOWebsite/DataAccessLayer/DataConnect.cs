using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

namespace DataAccessLayer
{
    public class DataConnect
    {
        private static SqlConnection cnn = null;

        public DataConnect()
        {
        }

        /// <summary>
        /// Connect to database
        /// </summary>
        public static void OpenConnection()
        {
            try
            {
                cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["NGOWebsite"].ConnectionString);

                if (cnn.State != ConnectionState.Open)
                {
                    cnn.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Close connetion
        /// </summary>
        public static void CloseConnection()
        {
            try
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// get all data from table in database using sql store procedure
        /// </summary>
        /// <param name="proc"> procedure name </param>
        /// <returns></returns>
        public static DataTable GetAllData(string proc)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand(proc, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CloseConnection();
            return dt;
        }

        /// <summary>
        /// manipulate data ( add new, update, delete)
        /// </summary>
        /// <param name="proc"> procedure name </param>
        /// <param name="param"> list parameter in procedure </param>
        /// <param name="values"> list value </param>
        /// <returns></returns>
        public static int CRUDData(string proc, List<string> param, List<object> values)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand(proc, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < param.Count; i++)
            {
                cmd.Parameters.AddWithValue(param[i], values[i]);
            }

            int kt = cmd.ExecuteNonQuery();
            CloseConnection();
            return kt;
        }



        public static DataTable FindData(string proc, List<string> param, List<object> values)
        {
            OpenConnection();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand(proc, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (param != null && param.Count > 0)
            {
                for (int i = 0; i < param.Count; i++)
                {
                    cmd.Parameters.AddWithValue(param[i], values[i]);
                }
            }
         
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            CloseConnection();

            return dt;
        }


        #region Encode MD5
        public static string GetMd5Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash. 
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Create a new Stringbuilder to collect the bytes 
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data  
                // and format each one as a hexadecimal string. 
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string. 
                return sBuilder.ToString();
            }
        }
        #endregion


        public static string SubStringText(string text)
        {
            StringBuilder mes = new StringBuilder();
            string[] mesStr = text.Split(' ');
            if (mesStr.Length > 15)
            {
                for (int i = 0; i <= 15; i++)
                {
                    mes.Append(mesStr[i] + " ");
                }
            }
            else
            {
                for (int i = 0; i < mesStr.Length; i++)
                {
                    mes.Append(mesStr[i] + " ");
                }
            }

            return mes.ToString()+"...";
        }

    }
}
