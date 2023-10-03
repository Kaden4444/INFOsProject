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
        private string table1 = "Reservations";
        private string sqlLocal1 = "SELECT * FROM Reservations";
        private Collection<Reservation> Reservations;
        private Reservation aReservation;
        #endregion

        public Collection<Reservation> AllClients
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
            FillDataSet(sqlLocal1, table1);
            Add2Collection(table1);
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
                    aReservation. = Convert.ToString(myRow["Name"]).TrimEnd();
                    aReservation.getStreetAddress = Convert.ToString(myRow["StreetAddress"]).TrimEnd();
                    aReservation.getArea = Convert.ToString(myRow["Area"]).TrimEnd();
                    aReservation.getTown = Convert.ToString(myRow["Town"]).TrimEnd();
                    aReservation.getArea = Convert.ToString(myRow["Area"]).TrimEnd();
                    aReservation.getPostal_code = Convert.ToString(myRow["PostalCode"]).TrimEnd();
                    aReservation.getBooking = Convert.ToDateTime(myRow["BookingDate"]);
                }
                Reservations.Add(aReservation);
            }
        }

        private void FillRow(DataRow aRow, Reservation aReservation, DB.DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                aRow["ID"] = aReservation.getID;  //NOTE square brackets to indicate index of collections of fields in row.
                aRow["Name"] = aReservation.getName;
                aRow["StreetAddress"] = aReservation.getStreetAddress;
                aRow["Area"] = aReservation.getArea;
                aRow["Town"] = aReservation.getTown;
                aRow["PostalCode"] = aReservation.getPostal_code;
                aRow["BookingDate"] = aReservation.getBooking;
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
                    if (aReservation.getID == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["ID"]))
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
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@Name", SqlDbType.NVarChar, 100, "Name");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@StreetAddress", SqlDbType.NVarChar, 15, "StreetAddress");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Area", SqlDbType.NVarChar, 10, "Area");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Area", SqlDbType.NVarChar, 10, "Area");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Town", SqlDbType.NVarChar, 10, "Town");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 10, "PostalCode");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@BookingDate", SqlDbType.DateTime, 10, "BookingDate");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Original_ID", SqlDbType.NVarChar, 15, "ID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);
        }
        private void Create_UPDATE_Command(Reservation aReservation)
        {
            daMain.UpdateCommand = new SqlCommand("UPDATE HeadWaiter SET Name =@Name, StreetAdress =@StreetAdress, Area =@Area, Town = @Town, PostalCode = @PostalCode, BookingDate = @BookingDate " + "WHERE ID = @Original_ID", cnMain);
            Build_UPDATE_Parameters(aReservation);

        }
        public bool UpdateDataSource(Reservation aReservation)
        {
            bool success = true;
            Create_INSERT_Command(aReservation);
            Create_UPDATE_Command(aReservation);
            success = UpdateDataSource(sqlLocal1, table1);
            return success;
        }
        #endregion
    }
}
