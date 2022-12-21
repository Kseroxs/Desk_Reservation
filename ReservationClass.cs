using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desk_Reservation
{
    public class ReservationClass
    {
        public int ReservationID { get; set; }
        public int DeskNumber { get; set; }
        public string Location { get; set; }
        public string ReservationDate { get; set; }
    }
}