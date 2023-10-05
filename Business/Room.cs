using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFOsProject.Business
{
    public class Room
    {
        #region Data fields
        string roomID;
        double price;
        #endregion

        #region Constructor
        public Room()
        {

        }
        #endregion

        #region Property Methods
        public string RoomID
        {
            get { return roomID; }
            set { roomID = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        #endregion
    }
}
