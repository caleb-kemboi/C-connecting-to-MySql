// See https://aka.ms/new-console-template for more information
using System.Data;
using System;
using System.Data.SqlClient;


public class EmployeeDALTests
    {

        public  void SetUp(string[] args)

        {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=employee;Integrated Security=True");
            string query =
              @"
                    CREATE PROCEDURE UpdateEmployeeSalary
                    (
                    IN empID INT(50),
                    IN newSalary VARCHAR(50),
                    OUT oldSalary INT
                    )
                  AS
                    INSERT INTO employeesalary(empID,newSalary,oldSalary) Values(@empID,@newSalary,@oldSalary)
                ";

            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Store Procedure Created Successfully");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }
            finally
            {
                con.Close();
                Console.ReadKey();
            }
        }



     public void Teardown()
    {
        var server = new Server(ServerName);
        server.KillDatabase(employee);
    }

    public void TestUpdateEmloyeeSalary()
    {


    }

    }