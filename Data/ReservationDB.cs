using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INFOsProject.Business;

namespace INFOsProject.Data
{
    public class ReservationDB:DB
    {
        #region  Data members        
        private string table = "Reservations";
        private string sqlLocal = "SELECT * FROM Reservations";
        private Collection<Reservation> Reservations;
        private Reservation aReservation;
        #endregion

        public Collection<Reservation> AllReservations
        {
            get
            {
                return Reservations;
            }
        }

        #region Constructor
        public ReservationDB() : base()
        {
            Reservations = new Collection<Reservation>();
            FillDataSet(sqlLocal, table);
            Add2Collection(table);
        }
        #endregion

        #region Utility Methods
        public DataSet GetDataSet()
        {
            return dsMain;
        }

        public void DataMaintenance(Reservation aReservation, DB.DBOperation operation)
        {
            int index = 0;

            switch (operation)
            {
                case DB.DBOperation.Add:
                    Reservations.Add(aReservation);
                    break;
                case DB.DBOperation.Edit:
                    //index = FindIndex(aReservation);
                    Reservations[index] = aReservation;
                    break;
                case DB.DBOperation.Delete:
                    Reservations.Remove(aReservation);
                    break;
            }
        }
        private void Add2Collection(string table)
        {
            //Declare references to a myRow object and an Reservation object
            DataRow myRow = null;

            //READ from the table  
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    aReservation = new Reservation();
                    aReservation.ReservationID = Convert.ToString(myRow["ID"]).TrimEnd();
                    aReservation.Guest = Convert.ToString(myRow["Guest"]); // Issue: Converting to a class type
                    aReservation.Room = Convert.ToString(myRow["Room"]).TrimEnd(); //Issue: Converting to a class type
                    aReservation.Total = Convert.ToDouble(myRow["Total"]);
                    aReservation.Days = Convert.ToInt32(myRow["days_of_Stay"]);

                }
                Reservations.Add(aReservation);
            }
        }

        private void FillRow(DataRow aRow, Reservation aReservation, DB.DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                aRow["ID"] = aReservation.ReservationID;  //NOTE square brackets to indicate index of collections of fields in row.
                aRow["Guest"] = aReservation.Guest;
                aRow["Room"] = aReservation.Room;
                aRow["Total"] = aReservation.Total;
                aRow["days_of_stay"] = aReservation.Days;

            }
        }
        private int FindRow(Reservation aReservation, String table)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;

            foreach (DataRow myRow_loopvariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopvariable;
                if (myRow.RowState != DataRowState.Deleted)
                    if (aReservation.ReservationID == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["ID"]))
                    {
                        returnValue = rowIndex;
                    }
                rowIndex++;
            }
            return returnValue;
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        private void Build_INSERT_Parameters(Reservation aReservation)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@ID", SqlDbType.NVarChar, 15, "ID");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Name", SqlDbType.NVarChar, 10, "Name");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@StreetAddress", SqlDbType.NVarChar, 100, "StreetAddress");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Area", SqlDbType.NVarChar, 15, "Area");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Town", SqlDbType.NVarChar, 10, "Town");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 10, "PostalCode");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@BookingDate", SqlDbType.DateTime, 10, "BookingDate");
            daMain.InsertCommand.Parameters.Add(param);
        }
        private void Create_INSERT_Command(Reservation aReservation)
        {
            daMain.InsertCommand = new SqlCommand("INSERT into Reservations (ID, Name, StreetAddress, Area, Town, PostalCode, BookingDate) VALUES (@ID, @Name, @StreetAddress, @Area, @Town, @PostalCode, @BookingDate)", cnMain);
            Build_INSERT_Parameters(aReservation);
        }
        private void Build_UPDATE_Parameters(Reservation aReservation)
        {
            //string reservationID;
            //Client guest;
            //Room room;
            //double total;
            //int days_of_Stay;
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@Guest", SqlDbType.Int, 50, "Guest");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Room", SqlDbType.NVarChar, 15, "Room");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Total", SqlDbType.Money, 50, "Total");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@days_of_stay", SqlDbType.Int, 10, "days_of_stay");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Original_ID", SqlDbType.Int, 15, "ID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);
        }
        private void Create_UPDATE_Command(Reservation aReservation)
        {
            daMain.UpdateCommand = new SqlCommand("UPDATE Reservations SET Guest =@Guest, Room =@Room, Total =@Total, days_of_stay = @days_of_stay " + "WHERE ID = @Original_ID", cnMain);
            Build_UPDATE_Parameters(aReservation);

        }
        public bool UpdateDataSource(Reservation aReservation)
        {
            bool success = true;
            Create_INSERT_Command(aReservation);
            Create_UPDATE_Command(aReservation);
            success = UpdateDataSource(sqlLocal, table);
            return success;
        }
        #endregion
    }
}
