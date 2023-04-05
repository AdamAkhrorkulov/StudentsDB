using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using Microsoft.Data.SqlClient;

namespace StudentBackendApplicationData
{
    public class StudentDataService
    {
        public string ConnectionStr = "server=localhost; database=Students; Integrated Security=True; TrustServerCertificate=True";
        public StudentDataService()
        {

        }   

        public IEnumerable<Student> GetData()
        {
            var result = new List<Student>();

            
            using (var conn = new SqlConnection())
            {

                conn.ConnectionString = ConnectionStr;

                try
                {


                    var cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "SELECT * FROM Students_info";
                    cmd.Connection = conn;

                    
                    conn.Open();

                    Console.WriteLine("Connection Open ! ");

                   
                    var sdr = cmd.ExecuteReader();

                    
                    while (sdr.Read())
                    {

                        var p = new Student()
                        {
                            Name = sdr["Name"].ToString(),
                            Age = sdr["Age"].ToString(),
                            Major = sdr["Major"].ToString() ?? string.Empty,
                            Course = sdr["Course"].ToString() ?? string.Empty,

                        };
                        result.Add(p);


                    }

                    
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
