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
        #region Data fields
        string ID;
        string client;
        string room;
        double total;
        int days_of_Stay;
        #endregion

        #region Constructor
        public Reservation(){}
        #endregion

        #region Property Methods

        public string ReservationID
        {
            get { return ID; }
            set { ID = value; }
        }
        public string Client
        {
            get { return client; }
            set { client = value; }
        }
        public string Room
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
