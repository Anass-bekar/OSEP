using System;
using System.Data.SqlClient;

namespace SQL
{
    class Program
    {
        public void auth(string sqlServer, string database)
        {
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

            con.Close();
        }
        public void exec(string sqlServer, string database, string command)
        {
            String conString = "Server = " + sqlServer + "; Database = " + database + "; Integrated Security = True;";
            SqlConnection con = new SqlConnection(conString);

            //String querylogin = command;
            SqlCommand cmd = new SqlCommand(command, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read() == true)
            {
              Console.WriteLine("Result: " + reader[0]);
            }
            reader.Close();

            con.Close();
        }
        public void impersonated(string sqlServer, string database)
        {
            String conString = "Server = " + sqlServer + "; Database = " + database + "; Integrated Security = True;";
            SqlConnection con = new SqlConnection(conString);

            String query = "SELECT distinct b.name FROM sys.server_permissions a INNER JOIN sys.server_principals b ON a.grantor_principal_id = b.principal_id WHERE a.permission_name = 'IMPERSONATE';";
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read() == true)
            {
                Console.WriteLine("Logins that can be impersonated: " + reader[0]);
            }
            reader.Close();

            con.Close();
        }
        static void Main(string[] args)
        {
            String sqlServer = args[0];
            String database = args[1];
            
            if (args[2] == "auth")
            {
                Program pr = new Program();
                pr.auth(sqlServer, database);

            }
            else if (args[2] == "impersonated")
            {
                Program pr = new Program();
                pr.impersonated(sqlServer, database);
            }
            else
            {
                String command = args[3];
                Program pr = new Program();
                pr.exec(sqlServer, database, command);
            }
            
        }

    }
    
}
