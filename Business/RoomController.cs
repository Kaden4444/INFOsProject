using INFOsProject.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFOsProject.Business
{
    public class RoomController
    {
        #region Data Members
        RoomDB RoomDB;
        Collection<Room> Rooms;
        #endregion

        #region Properties
        public Collection<Room> AllRooms
        {
            get
            {
                return Rooms;
            }
        }
        #endregion

        #region Constructor
        public RoomController()
        {
            //***instantiate the RoomDB object to communicate with the database
            RoomDB = new RoomDB();
            Rooms = RoomDB.AllRooms;
        }
        #endregion

        #region Database Communication.
        public void DataMaintenance(Room aRoom, DB.DBOperation operation)
        {
            int index = 0;

            switch (operation)
            {
                case DB.DBOperation.Add:
                    Rooms.Add(aRoom);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aRoom);
                    Rooms[index] = aRoom;
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aRoom);
                    Rooms.RemoveAt(index);
                    break;
            }
        }

        public bool FinalizeChanges(Room Room)
        {
            return RoomDB.UpdateDataSource(Room);
        }



        #endregion

        #region Search Method


        public Room Find(string ID)
        {
            int index = 0;
            bool found = (Rooms[index].RoomID == ID);
            int count = Rooms.Count;
            while (!(found) && (index < Rooms.Count - 1))
            {
                index = index + 1;
                found = (Rooms[index].RoomID == ID);
            }
            return Rooms[index];
        }

        public int FindIndex(Room aRoom)
        {
            int counter = 0;
            bool found = false;
            found = (aRoom.RoomID == Rooms[counter].RoomID);
            while (found == false && counter != Rooms.Count - 1)
            {
                counter++;
                found = (aRoom.RoomID == Rooms[counter].RoomID);
            }
            if (found)
            {
                return counter;
            }
            else
            {
                return -1;
            }
        }
        #endregion
    }
}
