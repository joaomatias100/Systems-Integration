using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace RestfulAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    string sqlConnectionString = "Data Source=LAPTOP-JEMJPJK4\\MEIBI2024;Initial Catalog = Student; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent = ReadWrite; MultiSubnetFailover=False";

    [HttpGet(Name = "GetAllUsers")]
    public ActionResult Get()
    {
        try
        {
            Console.Write("GET Request");
            List<Student> students = new List<Student>();

            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                string query = "SELECT id, name, course FROM Student";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Student item = new Student();

                    item.id = (int)reader["id"];
                    item.name = reader["name"].ToString();
                    item.course = reader["course"].ToString();
                    students.Add(item);
                    Console.WriteLine($"Id: {item.id}, Name: {item.name}, Course: {item.course}");
                }
                reader.Close();
                return Ok(students);
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.ToString());
            return BadRequest();
        }
    }
}
