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
        string ID;
        int client;
        int room;
        double total;
        int days_of_Stay;

        #region Property Methods

        public string ReservationID
        {
            get { return ID; }
            set { ID = value; }
        }
        public int Client
        {
            get { return client; }
            set { client = value; }
        }
        public int Room
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
