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
    public partial class Reservation : System.Web.UI.Page
    {
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DeskReservationConnectionString"].ConnectionString);
        string date;
        int userid;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
            }
            myConnection.Open();
            string query1 = "Select [UserID] from[dbo].[Users] where [Login] = '" + User.Identity.Name + "'";
            SqlCommand command = new SqlCommand(query1, myConnection);
            SqlDataReader dataReader = command.ExecuteReader();
            dataReader.Read();
            userid = (int)dataReader["UserID"];
            myConnection.Close();

            
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            date = Calendar1.SelectedDate.ToShortDateString();
            Label1.Text = date;
            var sqlFormattedDate = Calendar1.SelectedDate.ToString("yyyy-MM-dd HH:mm:ss");
            myConnection.Open();
            SqlCommand com = new SqlCommand("select * from Desk left join Reservation on Desk.DeskID = Reservation.DeskID where Reservation.ReservationDate !='" + sqlFormattedDate + "' or Reservation.DeskID is null and Desk.Location= '" + LocationDropDownList.Text + "'", myConnection);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DropDownList1.DataTextField = ds.Tables[0].Columns["DeskNumber"].ToString();
            DropDownList1.DataValueField = ds.Tables[0].Columns["DeskID"].ToString();
            DropDownList1.DataSource = ds.Tables[0];
            DropDownList1.DataBind();
            myConnection.Close();
        }


        protected void Book_Click(object sender, EventArgs e)
        {
            myConnection.Open();
            string query1 = "Select [DeskID] from[dbo].[Desk] where [DeskNumber] = '" + DropDownList1.Text + "' and Location= '" + LocationDropDownList.Text + "'";
            SqlCommand command = new SqlCommand(query1, myConnection);
            SqlDataReader dataReader = command.ExecuteReader();
            dataReader.Read();
            int deskid = (int)dataReader["DeskID"];
            myConnection.Close();
            myConnection.Open();
            string query = "insert into [dbo].[Reservation](UserID,DeskNumber,Location,ReservationDate,DeskID) Values(@userid,@desknumber,@location,@reservationdate,@deskid)";
            SqlCommand insertCommand = new SqlCommand(query, myConnection);
            insertCommand.Parameters.AddWithValue("@userid", userid);
            insertCommand.Parameters.AddWithValue("@desknumber", DropDownList1.Text);
            insertCommand.Parameters.AddWithValue("@location", LocationDropDownList.Text);
            insertCommand.Parameters.AddWithValue("@reservationdate", Convert.ToDateTime(Label1.Text));
            insertCommand.Parameters.AddWithValue("@deskid", deskid);
            insertCommand.ExecuteNonQuery();
            myConnection.Close();
            Response.Redirect("User_Panel.aspx");
        }
    }
}