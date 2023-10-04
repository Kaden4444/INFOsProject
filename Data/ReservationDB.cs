using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INFOsProject.Business;
using System.Windows.Forms;

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
            Reservation aReservation;
            //READ from the table  
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    aReservation = new Reservation();
                    aReservation.ReservationID = Convert.ToString(myRow["ID"]).TrimEnd();
                    aReservation.Client = Convert.ToInt32(myRow["Guest"]);
                    aReservation.Room = Convert.ToInt32(myRow["Room"]); 
                    aReservation.Total = Convert.ToDouble(myRow["Total"]);
                    aReservation.Days = Convert.ToInt32(myRow["DaysOfStay"]);
                    Reservations.Add(aReservation);
                    MessageBox.Show("Reservation added");
                }
                
            }
        }

        private void FillRow(DataRow aRow, Reservation aReservation, DB.DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                aRow["ID"] = aReservation.ReservationID;  //NOTE square brackets to indicate index of collections of fields in row.
                aRow["Guest"] = aReservation.Client;
                aRow["Room"] = aReservation.Room;
                aRow["Total"] = aReservation.Total;
                aRow["DaysOfStay"] = aReservation.Days;

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

            param = new SqlParameter("@Client", SqlDbType.NVarChar, 10, "Client");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Room", SqlDbType.NVarChar, 10, "Room");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Total", SqlDbType.Money, 10, "Total");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@DaysOfStay", SqlDbType.Money, 10, "DaysOfStay");
            daMain.InsertCommand.Parameters.Add(param);

        }
        private void Create_INSERT_Command(Reservation aReservation)
        {
            daMain.InsertCommand = new SqlCommand("INSERT into Reservations (ID, Client, Room, Total, DaysOfStay) VALUES (@ID, @Client, @Room, @Total, @DaysOfStay)", cnMain);
            Build_INSERT_Parameters(aReservation);
        }
        private void Build_UPDATE_Parameters(Reservation aReservation)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@ID", SqlDbType.NVarChar, 15, "ID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Client", SqlDbType.NVarChar, 10, "Client");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Room", SqlDbType.NVarChar, 10, "Room");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Total", SqlDbType.Money, 10, "Total");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@DaysOfStay", SqlDbType.Money, 10, "DaysOfStay");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);
        }
        private void Create_UPDATE_Command(Reservation aReservation)
        {
            daMain.UpdateCommand = new SqlCommand("UPDATE Reservations SET Client=@Client, Room=@Room, Total=@Total, DaysOfStay=@DaysOfStay) " + "WHERE ID = @ID", cnMain);
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

