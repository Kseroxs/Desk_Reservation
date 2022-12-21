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
    public partial class Administration_Panel : System.Web.UI.Page
    {
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DeskReservationConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            LocationsGridView.DataSource = this.LocationsList();
            LocationsGridView.DataBind();
            DesksGridView.DataSource = this.DesksList();
            DesksGridView.DataBind();
        }
        //adding location
        protected void AddLocationButton_Click(object sender, EventArgs e)
        {
            myConnection.Open();
            string query = "insert into [dbo].[Locations](Location) Values(@location)";
            SqlCommand insertCommand = new SqlCommand(query, myConnection);
            insertCommand.Parameters.AddWithValue("@location", LocationTextBox.Text);
            insertCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        // adding desk
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
        //creating list of locations in gridview
        public List<LocationsClass> LocationsList()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT Location FROM Locations", myConnection))
            {
                List<LocationsClass> locations = new List<LocationsClass>();
                cmd.CommandType = CommandType.Text;
                myConnection.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        locations.Add(new LocationsClass
                        {
                            Location = sdr["Location"].ToString()

                        });
                    }
                }
                myConnection.Close();
                return locations;
            }

        }
        // deleting locations
        protected void LocationsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteButton")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string locations = Convert.ToString(LocationsGridView.Rows[index].Cells[1].Text);
                myConnection.Open();
                string query = "Delete from Locations WHERE Location = '" + locations + "'";
                SqlCommand delete = new SqlCommand(query, myConnection);
                delete.ExecuteNonQuery();
                myConnection.Close();
                Response.Redirect("Administration_Panel.aspx");

            }
        }
        // creating list of desks in location choosen in dropdownlist
        public List<DesksClass> DesksList()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT DeskID, Location, DeskNumber FROM Desk where Location= '"+ LocationDropDownList.Text +"'", myConnection))
            {
                List<DesksClass> desks = new List<DesksClass>();
                cmd.CommandType = CommandType.Text;
                myConnection.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        desks.Add(new DesksClass
                        {
                            DeskID = Convert.ToInt32(sdr["DeskID"]),
                            Location = sdr["Location"].ToString(),
                            DeskNumber = Convert.ToInt32(sdr["DeskNumber"])

                        });
                    }
                }
                myConnection.Close();
                return desks;
            }

        }
        // deleting desks
        protected void DesksGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteButton")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int desks = Convert.ToInt32(DesksGridView.Rows[index].Cells[1].Text);
                myConnection.Open();
                string query = "Delete from Desk WHERE DeskID = '" + desks + "'";
                SqlCommand delete = new SqlCommand(query, myConnection);
                delete.ExecuteNonQuery();
                myConnection.Close();
                Response.Redirect("Administration_Panel.aspx");

            }
        }
    }
}