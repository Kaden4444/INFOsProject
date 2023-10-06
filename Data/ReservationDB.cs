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

        #region Collection Methods
        public Collection<Reservation> AllReservations
        {
            get
            {
                return Reservations;
            }
        }
        #endregion

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
                    aReservation.Client = Convert.ToString(myRow["Client"]).TrimEnd();
                    aReservation.Room = Convert.ToString(myRow["Room"]).TrimEnd(); 
                    aReservation.Total = Convert.ToDouble(myRow["Total"]);
                    aReservation.Days = Convert.ToInt32(myRow["DaysOfStay"]);
                    Reservations.Add(aReservation);
                }
                
            }
        }

        private void FillRow(DataRow aRow, Reservation aReservation, DB.DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                aRow["ID"] = aReservation.ReservationID;  //NOTE square brackets to indicate index of collections of fields in row.
                aRow["Client"] = aReservation.Client;
                aRow["Room"] = aReservation.Room;
                aRow["Total"] = aReservation.Total;
                aRow["DaysOfStay"] = aReservation.Days;

            }
        }
        private int FindRow(Reservation aReservation, String table)
        {
            int returnValue = 0;
            returnValue = int.Parse(aReservation.ReservationID);
            return returnValue;

        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        private void Build_INSERT_Parameters(Reservation aReservation)
        {

            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@ID", SqlDbType.NVarChar, 5, "ID");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Client", SqlDbType.NVarChar, 5, "Client");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Room", SqlDbType.NVarChar, 5, "Room");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Total", SqlDbType.Money, 10, "Total");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@DaysOfStay", SqlDbType.Int, 5, "DaysOfStay");
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

            param = new SqlParameter("@Client", SqlDbType.NVarChar, 5, "Client");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Room", SqlDbType.NVarChar, 5, "Room");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Total", SqlDbType.Money, 10, "Total");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@DaysOfStay", SqlDbType.Money, 5, "DaysOfStay");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@OriginalID", SqlDbType.NVarChar, 5, "ID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);
        }
        private void Create_UPDATE_Command(Reservation aReservation)
        {
            daMain.UpdateCommand = new SqlCommand("UPDATE Reservations SET Client=@Client, Room=@Room, Total=@Total, DaysOfStay=@DaysOfStay) " + "WHERE ID = @ID", cnMain);
            Build_UPDATE_Parameters(aReservation);

        }
        private void Build_DELETE_Parameters()
        {
            //--Create Parameters to communicate with SQL DELETE
            SqlParameter param;
            param = new SqlParameter("@ID", SqlDbType.NVarChar, 5, "ID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);
        }

        private string Create_DELETE_Command(Reservation aReservation)
        {
            string errorString = null;
            daMain.DeleteCommand = new SqlCommand("DELETE FROM Reservations WHERE ID = @ID", cnMain);

            try
            {
                Build_DELETE_Parameters();
            }
            catch (Exception errObj)
            {
                errorString = errObj.Message + "  " + errObj.StackTrace;
            }
            return errorString;
        }

        public bool UpdateDataSource(Reservation aReservation)
        {
            bool success = true;
            Create_INSERT_Command(aReservation);
            Create_UPDATE_Command(aReservation);
            Create_DELETE_Command(aReservation);
            success = UpdateDataSource(sqlLocal, table);
            return success;
        }
        #endregion

        #region Database Operations CRUD
        public void DataSetChange(Reservation aReservation, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table;
            dataTable = table;

            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aReservation, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow); //Add to the dataset
                    break;

                case DB.DBOperation.Edit:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aReservation, dataTable)];
                    FillRow(aRow, aReservation, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DB.DBOperation.Delete:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aReservation, dataTable)];
                    aRow.Delete();
                    break;
            }
        }
        }

        #endregion
    }


