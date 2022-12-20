using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Desk_Reservation
{
    public partial class Administration_Panel : System.Web.UI.Page
    {
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DeskReservationConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddLocationButton_Click(object sender, EventArgs e)
        {
            myConnection.Open();
            string query = "insert into [dbo].[Locations](Location) Values(@location)";
            SqlCommand insertCommand = new SqlCommand(query, myConnection);
            insertCommand.Parameters.AddWithValue("@location", LocationTextBox.Text);
            insertCommand.ExecuteNonQuery();
            myConnection.Close();
        }

        protected void AddDeskButton_Click(object sender, EventArgs e)
        {
            myConnection.Open();
            string query = "insert into [dbo].[Desk](Location,DeskNumber) Values(@location,@desknumber)";
            SqlCommand insertCommand = new SqlCommand(query, myConnection);
            insertCommand.Parameters.AddWithValue("@location", LocationDropDownList.Text);
            insertCommand.Parameters.AddWithValue("@desknumber", DeskTextBox.Text);
            insertCommand.ExecuteNonQuery();
            myConnection.Close();
        }
    }
}