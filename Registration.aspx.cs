using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Desk_Reservation
{
    public partial class Registration : System.Web.UI.Page
    {
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DeskReservationConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegistrationButton_Click(object sender, EventArgs e)
        {
            myConnection.Open();
            string query = "insert into [dbo].[Users]([Login],[Password],[Email]) Values(@login,@password,@email)";
            SqlCommand insertCommand = new SqlCommand(query, myConnection);
            insertCommand.Parameters.AddWithValue("@login", LoginTextBox.Text);
            insertCommand.Parameters.AddWithValue("@password", PasswordTextBox.Text);
            insertCommand.Parameters.AddWithValue("@email", EmailTextBox.Text);
            insertCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        
    }
}