using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace OMS.Helpers
{
    public class DBOperations : IDBOperations
    {
        private IConfiguration _configuration { get; }
        public string _ConnectionString { get; set; }
        SqlConnection con;
        public DBOperations(IConfiguration configuration)
        {
            this._configuration = configuration;

            con = new SqlConnection(_configuration["ConnectionStrings:DBConnection"]);
        }

        DataSet IDBOperations.GetRecord_AS_DataSet(string query)
        {
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return ds;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }

        DataTable IDBOperations.GetRecord_AS_DataTable(string query)
        {
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }

        string IDBOperations.Execute_Query(string query)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                query = query + " set @ID =  SCOPE_IDENTITY()";
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                var id = cmd.Parameters["@ID"].Value.ToString();
                return id;
            }
            catch (Exception ex)
            {

                return ex.Message.ToString();
            }
            finally
            {
                con.Close();
            }
        }

        string IDBOperations.Update_Query(string query)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                return "Update Successfull";
            }
            catch (Exception ex)
            {

                return ex.Message.ToString();
            }
            finally
            {
                con.Close();
            }
        }

        //SqlConnection con = new SqlConnection(connectionString);
    }
}
