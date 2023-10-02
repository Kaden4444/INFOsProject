using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace INFOsProject.Business
{
    public class Reservation
    {
        string reservationID;
        Client guest;
        Room room;
        double total;
        int days_of_Stay;

        #region Property Methods

        public string ReservationID
        {
            get { return reservationID; }
            set { reservationID = value; }
        }
        public Client Guest
        {
            get { return guest; }
            set { guest = value; }
        }
        public Room Room
        {
            get { return room; }
            set { room = value; }
        }
        public double Total
        {
            get { return total; }
            set { total = value; }
        }
        public int Days
        {
            get { return days_of_Stay; }
            set { days_of_Stay = value; }
        }
        #endregion

    }


}
