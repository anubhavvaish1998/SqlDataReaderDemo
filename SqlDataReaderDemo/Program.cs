using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SqlDataReaderDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Employee; select * from Students";
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            //Console.WriteLine(dr.FieldCount);
            //Console.WriteLine(dr.HasRows);
            //Console.WriteLine(dr.IsClosed);
            //Console.WriteLine(dr.GetName(1));
            while (dr.Read())
            {
                Console.WriteLine("ID: {0}, Name: {1}, Gender: {2}",dr[0], dr[1], dr[2]);
            }
            Console.WriteLine("-----------------------------------------------");
            if (dr.NextResult())
            {
                while (dr.Read())
                {
                    Console.WriteLine("ID: {0}, Name: {1}, Gender: {2}", dr[0], dr[1], dr[2]);
                }
            }

            con.Close();
            Console.ReadLine();

            //while (dr.Read())
            //{
            //    // CONCATANATION WITH COLUMN NAME

            // //Console.WriteLine("ID: " + dr["Id"] + " Name: " + dr["Name"]+ " Gender: "+ dr["Gender"]+ " Age: " +dr["Age"]+ " Salary: " + dr["Salary"]+  " City: " + dr["City"]);

            //    // CONCATANATION WITH COLUMN INDEX NUMBER

            // //Console.WriteLine("ID: " + dr[0] + " Name: " + dr[1] + " Gender: " + dr[2] + " Age: " + dr[3] + " Salary: " + dr[4] + " City: " + dr[5]);

            //    // PLACEHOLDER
            //    Console.WriteLine("ID: {0}, Name: {1}, Gender: {2}, Age: {3}, Salary: {4}, City: {5},",dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
            //}


        }
    }
}
