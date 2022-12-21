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
    public partial class User_Panel : System.Web.UI.Page
    {
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DeskReservationConnectionString"].ConnectionString);
        int userid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                WelcomeMessage.Text = "Welcome back, " + User.Identity.Name + "!";
                AuthenticatedMessagePanel.Visible = true;
            }
            myConnection.Open();
            string query1 = "Select [UserID] from[dbo].[Users] where [Login] = '" + User.Identity.Name + "'";
            SqlCommand command = new SqlCommand(query1, myConnection);
            SqlDataReader dataReader = command.ExecuteReader();
            dataReader.Read();
            userid = (int)dataReader["UserID"];
            myConnection.Close();
            ReservationGridView.DataSource = this.ReservationList();
            ReservationGridView.DataBind();

        }

        protected void MakeReservationButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reservation.aspx");
        }

        public List<ReservationClass> ReservationList()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT ReservationID, DeskNumber, Location, ReservationDate FROM Reservation where UserID= '" + userid + "'", myConnection))
            {
                List<ReservationClass> reservations = new List<ReservationClass>();
                cmd.CommandType = CommandType.Text;
                myConnection.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        reservations.Add(new ReservationClass
                        {
                            ReservationID = Convert.ToInt32(sdr["ReservationID"]),
                            DeskNumber = Convert.ToInt32(sdr["DeskNumber"]),
                            Location = sdr["Location"].ToString(),
                            ReservationDate = sdr["ReservationDate"].ToString()

                        });
                    }
                }
                myConnection.Close();
                return reservations;
            }

        }
        protected void ReservationGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteButton")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int reservationid = Convert.ToInt32(ReservationGridView.Rows[index].Cells[1].Text);
                //string imie = GridView2.Rows[index].Cells[2].Text;
                //string nazwisko = GridView2.Rows[index].Cells[3].Text;
                myConnection.Open();
                string query = "Delete from Reservation WHERE ReservationID = '" + reservationid + "'";
                SqlCommand delete = new SqlCommand(query, myConnection);
                delete.ExecuteNonQuery();
                myConnection.Close();
                Response.Redirect("User_Panel.aspx");

            }
        }
    }
}