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
        DateTime Start;
        DateTime End;
        bool deposit;
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

        public DateTime StartDate { get { return Start; } set {  Start = value; } }
        public DateTime EndDate { get { return End;} set { End = value; } }
        public bool Deposit {  get { return deposit; } set {  deposit = value; } }
        #endregion

    }


}
