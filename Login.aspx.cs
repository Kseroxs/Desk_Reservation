﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Desk_Reservation
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DeskReservationConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            myConnection.Open();
            string query = "Select count(*) from [dbo].[Users] where [Login] = '" + LoginTextBox.Text.Trim() + "' and [Password] = '" + PasswordTextBox.Text + "'";
            SqlCommand command = new SqlCommand(query, myConnection);
            int accountExist = int.Parse(command.ExecuteScalar().ToString());
            myConnection.Close();

            if (accountExist > 0)
            {

                FormsAuthentication.RedirectFromLoginPage(LoginTextBox.Text, true);
                
            }
            InvalidCredentialsMessage.Visible = true;
        }
    }
}