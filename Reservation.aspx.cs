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

                date = Convert.ToString(DateTime.Now);
                Label1.Text = date;
            }
            myConnection.Open();
            string query1 = "Select [UserID] from[dbo].[Users] where [Login] = '" + User.Identity.Name + "'";
            SqlCommand command = new SqlCommand(query1, myConnection);
            SqlDataReader dataReader = command.ExecuteReader();
            dataReader.Read();
            userid = (int)dataReader["UserID"];
            myConnection.Close();

            myConnection.Open();
            SqlCommand com = new SqlCommand("select *from Desk where Location= '"+LocationDropDownList.Text+"'", myConnection);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  
            DropDownList1.DataTextField = ds.Tables[0].Columns["DeskNumber"].ToString(); // text field name of table dispalyed in dropdown       
            DropDownList1.DataValueField = ds.Tables[0].Columns["DeskID"].ToString();
            // to retrive specific  textfield name   
            DropDownList1.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            DropDownList1.DataBind();  //binding dropdownlist
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            date = Calendar1.SelectedDate.ToShortDateString();
            Label1.Text = date;
        }


        protected void Book_Click(object sender, EventArgs e)
        {

            myConnection.Open();
            string query = "insert into [dbo].[Reservation](UserID,DeskNumber,Location,ReservationDate) Values(@userid,@desknumber,@location,@reservationdate)";
            SqlCommand insertCommand = new SqlCommand(query, myConnection);
            insertCommand.Parameters.AddWithValue("@userid", userid);
            insertCommand.Parameters.AddWithValue("@desknumber", DropDownList1.Text);
            insertCommand.Parameters.AddWithValue("@location", LocationDropDownList.Text);
            insertCommand.Parameters.AddWithValue("@reservationdate", Convert.ToDateTime(Label1.Text));
            insertCommand.ExecuteNonQuery();
            myConnection.Close();
        }
    }
}