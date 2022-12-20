using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Desk_Reservation
{
    public partial class User_Panel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                WelcomeMessage.Text = "Welcome back, " + User.Identity.Name + "!";
                AuthenticatedMessagePanel.Visible = true;
            }
        }

        protected void MakeReservationButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reservation.aspx");
        }
    }
}