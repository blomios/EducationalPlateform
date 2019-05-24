using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Helpers;
using System.Data.Entity;
using System.Web.UI.WebControls;

namespace LO54_Projet.Repository
{
    public class TotoTableDAO
    {
        public TotoTableDAO() { }

        public string getInfos()
        {
            string ret = "";
            SqlDataReader myReader;

            string strquery = "select * from toto";

            string conn = ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString;

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            
            SqlCommand objCMD = new SqlCommand(strquery, connection);

            myReader = objCMD.ExecuteReader();
           
            while(myReader.Read())
            {
                ret += myReader.GetValue(0).ToString()+" " + myReader.GetValue(1)+";";
            }
            myReader.Close();
            objCMD.Dispose();
            connection.Close();

            return ret;
        }
        

        public string insertToto(string value)
        {

            string conn = ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString;

            SqlConnection connection = new SqlConnection(conn);
            using (var command = new SqlCommand("InsertToto", connection)
            {
                CommandType = CommandType.StoredProcedure
            })
            {

                // 3. add parameter to command, which will be passed to the stored procedure
                command.Parameters.Add(new SqlParameter("@valueToto", value));
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Inserted"); // ici on pourrait mettre un log plutôt;
                connection.Close();
            }
            return "Insertion réussie";
        }

        public void deleteToto()
        {
            string conn = ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString;

            SqlConnection connection = new SqlConnection(conn);
            using (var command = new SqlCommand("DeleteToto", connection)
            {
                CommandType = CommandType.StoredProcedure
            })
            {

                // 3. add parameter to command, which will be passed to the stored procedure
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Deleted"); // ici on pourrait mettre un log plutôt;
                connection.Close();
            }
        }
    }
}