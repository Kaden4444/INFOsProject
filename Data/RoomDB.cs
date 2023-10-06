using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INFOsProject.Business;
using INFOsProject.Presentation;
using static INFOsProject.Data.DB;

namespace INFOsProject.Data
{
    public class RoomDB:DB
    {
        #region  Data members        
        private string table = "Rooms";
        private string sqlLocal = "SELECT * FROM Rooms";
        private Collection<Room> Rooms;
        private Room aRoom;
        #endregion

        #region Collection Methods
        public Collection<Room> AllRooms
        {
            get
            {
                return Rooms;
            }
        }
        #endregion

        #region Constructor
        public RoomDB() : base()
        {
            Rooms = new Collection<Room>();
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
            //Declare references to a myRow object and an Room object
            DataRow myRow = null;
            //Room aRoom;
            //READ from the table  
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    aRoom = new Room();
                    aRoom.RoomID = Convert.ToString(myRow["ID"]).TrimEnd();
                    aRoom.Price = Convert.ToDouble(myRow["Price"]);
                    Rooms.Add(aRoom);  
                }              
            }
        }

        private void FillRow(DataRow aRow, Room aRoom, DB.DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                aRow["ID"] = aRoom.RoomID;  //NOTE square brackets to indicate index of collections of fields in row.   
                aRow["Price"] = aRoom.Price;

            }
        }
        private int FindRow(Room aRoom, String table)
        {
            int returnValue = 0;
            returnValue = int.Parse(aRoom.RoomID);
            return returnValue;
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        private void Build_INSERT_Parameters(Room aRoom)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@ID", SqlDbType.NVarChar, 5, "ID");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Price", SqlDbType.Money, 10, "Price");
            daMain.InsertCommand.Parameters.Add(param);
        }
        private void Create_INSERT_Command(Room aRoom)
        {
            daMain.InsertCommand = new SqlCommand("INSERT into Rooms (ID, Price) VALUES (@ID, @Price)", cnMain);
            Build_INSERT_Parameters(aRoom);
        }
        private void Build_UPDATE_Parameters(Room aRoom)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@OriginalID", SqlDbType.NVarChar, 5, "ID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Price", SqlDbType.Money, 10, "Price");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param); 
        }
        private void Create_UPDATE_Command(Room aRoom)
        {
            daMain.UpdateCommand = new SqlCommand("UPDATE Rooms SET Price =@Price " + "WHERE ID = @OriginalID", cnMain);
            Build_UPDATE_Parameters(aRoom);

        }
        public bool UpdateDataSource(Room aRoom)
        {
            bool success = true;
            Create_INSERT_Command(aRoom);
            Create_UPDATE_Command(aRoom);
            Create_DELETE_Command(aRoom);
            return success;
        }

        private void Build_DELETE_Parameters()
        {
            //--Create Parameters to communicate with SQL DELETE
            SqlParameter param;
            param = new SqlParameter("@ID", SqlDbType.NVarChar, 5, "ID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);
        }

        private string Create_DELETE_Command(Room aRoom)
        {
            string errorString = null;
            daMain.DeleteCommand = new SqlCommand("DELETE FROM Rooms WHERE ID = @ID", cnMain);

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

        #endregion

        #region Database Operations CRUD
        public void DataSetChange(Room aRoom, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table;
            dataTable = table;

            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aRoom, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow); //Add to the dataset
                    break;

                case DB.DBOperation.Edit:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aRoom, dataTable)];
                    FillRow(aRow, aRoom, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;

                case DB.DBOperation.Delete:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aRoom, dataTable)];
                    aRow.Delete();
                    break;
            }
        }
        }

        #endregion
    }

