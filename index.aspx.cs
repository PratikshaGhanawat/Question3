using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserData
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve values from the form controls
                int studentID = Convert.ToInt32(studentid.Text);
                string firstName = fname.Text;
                string lastName = lname.Text;
                int age = Convert.ToInt32(age1.Text);

                // Assuming you have a database connection string in the configuration
                string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the database connection
                    connection.Open();

                    // Example: Inserting data into the Students table
                    string insertQuery = "INSERT INTO Students (StudentID, FirstName, LastName, Age) " +
                                         "VALUES (@studentID, @firstName, @lastName, @age)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters to the SQL command
                        command.Parameters.AddWithValue("@studentID", studentID);
                        command.Parameters.AddWithValue("@firstName", firstName);
                        command.Parameters.AddWithValue("@lastName", lastName);
                        command.Parameters.AddWithValue("@age", age);

                        // Execute the SQL command
                        command.ExecuteNonQuery();
                    }

                    // Close the database connection
                    connection.Close();

                    // You can add any additional logic or messages here
                    success1.Text = "Inserted Succesful";


                    // For example, display success message
                    // Response.Write("Data added successfully!");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception, you can display an error message or log it
                // For example, display an error message
                 Response.Write("Error: " + ex.Message);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try { GridView1.DataBind(); 
            }
            catch (Exception c)
            {
                Response.Write(c.Message);
            }
           

        }
    }
}