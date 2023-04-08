using System;
using System.Collections.Generic;
using System.Data;
using Backend.App.Models.Model;
using Microsoft.Data.SqlClient;

namespace Backend.App.Data.Sevices
{
    public class PersonDataService
    {
        public string _connectionStr = "server=localhost; database=DemoDB; Integrated Security=True; TrustServerCertificate=True";
        public PersonDataService()
        {

        }

        public IEnumerable<Person> GetData()
        {
            var result = new List<Person>();

            //Create the object of SqlConnection class to connect with database sql server
            using (var conn = new SqlConnection())
            {
                //prepare conectio string
                conn.ConnectionString = _connectionStr;

                try
                {

                    //Prepare SQL command that we want to query
                    var cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    // cmd.CommandText = "SELECT * FROM MYTABLE";
                    cmd.CommandText = "SELECT * FROM Persons";
                    cmd.Connection = conn;

                    // open database connection.
                    conn.Open();

                    Console.WriteLine("Connection Open ! ");

                    //Execute the query 
                    var sdr = cmd.ExecuteReader();

                    ////Retrieve data from table and Display result
                    while (sdr.Read())
                    {
                        var p = new Person()
                        {
                            PersonId = (int)sdr["Personid"],
                            LastName = sdr["LastName"].ToString() ?? string.Empty,
                            FirstName = sdr["FirstName"].ToString() ?? string.Empty,
                            Age = (int)sdr["Age"],
                            Address = sdr["Address"].ToString() ?? string.Empty,
                            City = sdr["City"].ToString() ?? string.Empty

                        };
                        result.Add(p);

                        //int id = (int)sdr["Personid"];
                        //string ln = sdr["LastName"].ToString();
                        //string fn = sdr["FirstName"].ToString();
                        //int age = (int)sdr["Age"];
                        //string address = sdr["Address"].ToString();
                        //string city = sdr["City"].ToString();
                        //Console.WriteLine(id);
                    }
                    //Close the connection
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can not open connection !");
                    Console.WriteLine(ex.StackTrace);

                }

            }

            return result;
        }
    }
}

