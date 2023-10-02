using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFOsProject.Business
{
    public class Room
    {
        int roomID;
        bool booked;
        double price;

        public Room()
        {

        }

        #region Property Methods
        public int RoomID
        {
            get { return roomID; }
            set { roomID = value; }
        }
        public bool Booked
        {
            get { return booked; }
            set { booked = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        #endregion
    }
}
