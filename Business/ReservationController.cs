using INFOsProject.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFOsProject.Business
{
    public class ReservationController
    {

        #region Data Members
        ReservationDB ReservationDB;
        Collection<Reservation> Reservations;
        private Collection<int> rooms;
        #endregion

        #region Properties
        public Collection<Reservation> AllReservations
        {
            get
            {
                return Reservations;
            }
        }
        #endregion

        #region Constructor
        public ReservationController()
        {
            //***instantiate the ReservationDB object to communicate with the database
            ReservationDB = new ReservationDB();
            Reservations = ReservationDB.AllReservations;
            rooms = new Collection<int>();
        }
        #endregion

        #region Rooms management

        public void UpdateRooms()
        {
            rooms = new Collection<int>
            {
                0,1,2,3,4
            };
        }
        public Collection<int> RoomsAvailable(DateTime dateIn, DateTime dateOut)
        {
            Collection<int> AvailableRooms = new Collection<int>(rooms);
            Reservations = AllReservations;
            foreach (Reservation reservation in Reservations)
            {
                if (dateIn.Date >= Convert.ToDateTime(reservation.EndDate).Date || dateOut < Convert.ToDateTime(reservation.StartDate).Date)
                {
                    AvailableRooms.Remove(Convert.ToInt32(reservation.Room));
                }
            }
            UpdateRooms();
            return AvailableRooms;
        }
        #endregion

        #region Database Communication.
        public void DataMaintenance(Reservation aReservations, DB.DBOperation operation)
        {
            int index = 0;
            ReservationDB.DataSetChange(aReservations, operation);
            switch (operation)
            {
                case DB.DBOperation.Add:
                    Reservations.Add(aReservations);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aReservations);
                    Reservations[index] = aReservations;
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aReservations);
                    Reservations.RemoveAt(index);
                    break;
            }
        }
        
        public bool FinalizeChanges(Reservation Reservation)
        {
            return ReservationDB.UpdateDataSource(Reservation);
        }

        #endregion

        #region Search Method


        public Reservation Find(String ID)
        {
            int index = 0;
            bool found = (Reservations[index].ReservationID == ID);
            int count = Reservations.Count;
            while (!(found) && (index < Reservations.Count - 1))
            {
                index = index + 1;
                found = (Reservations[index].ReservationID == ID);
            }
            return Reservations[index];
        }

        public int FindIndex(Reservation aReservations)
        {
            int counter = 0;
            bool found = false;
            found = (aReservations.ReservationID == Reservations[counter].ReservationID);
            while (found == false && counter != Reservations.Count - 1)
            {
                counter++;
                found = (aReservations.ReservationID == Reservations[counter].ReservationID);
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
