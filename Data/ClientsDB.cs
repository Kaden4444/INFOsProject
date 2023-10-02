using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INFOsProject.Business;
using INFOsProject.Presentation;
using static INFOsProject.Data.DB;

namespace INFOsProject.Data
{
    public class ClientsDB : DB
    {
        #region  Data members        
        private string table1 = "Clients";
        private string sqlLocal1 = "SELECT * FROM Clients";
        private Collection<Client> Clients;
        private Client aClient;
        #endregion

        public Collection<Client> AllClients
        {
            get
            {
                return Clients;
            }
        }

        #region Constructor
        public ClientsDB() : base()
        {
            Clients = new Collection<Client>();
            FillDataSet(sqlLocal1, table1);
            Add2Collection(table1);
        }
        #endregion
        #region Utility Methods
        public DataSet GetDataSet()
        {
            return dsMain;
        }

        public void DataMaintenance(Client aClient, DB.DBOperation operation)
        {
            int index = 0;

            switch (operation)
            {
                case DB.DBOperation.Add:
                    Clients.Add(aClient);
                    break;
                case DB.DBOperation.Edit:
                    //index = FindIndex(aClient);
                    Clients[index] = aClient;
                    break;
                case DB.DBOperation.Delete:
                    Clients.Remove(aClient);
                    break;
            }
        }
        private void Add2Collection(string table)
        {
            //Declare references to a myRow object and an Client object
            DataRow myRow = null;

            //READ from the table  
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    aClient = new Client();
                    aClient.getID = Convert.ToString(myRow["ID"]).TrimEnd();
                    aClient.getName = Convert.ToString(myRow["Name"]).TrimEnd();
                    aClient.getStreetAddress = Convert.ToString(myRow["StreetAddress"]).TrimEnd();
                    aClient.getArea = Convert.ToString(myRow["Area"]).TrimEnd();
                    aClient.getTown = Convert.ToString(myRow["Town"]).TrimEnd();
                    aClient.getArea = Convert.ToString(myRow["Area"]).TrimEnd();
                    aClient.getPostal_code = Convert.ToString(myRow["PostalCode"]).TrimEnd();
                    aClient.getBooking = Convert.ToDateTime(myRow["BookingDate"]);
                }
                Clients.Add(aClient);
            }
        }

        private void FillRow(DataRow aRow, Client aClient, DB.DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                aRow["ID"] = aClient.getID;  //NOTE square brackets to indicate index of collections of fields in row.
                aRow["Name"] = aClient.getName;
                aRow["StreetAddress"] = aClient.getStreetAddress;
                aRow["Area"] = aClient.getArea;
                aRow["Town"] = aClient.getTown;
                aRow["PostalCode"] = aClient.getPostal_code;
                aRow["BookingDate"] = aClient.getBooking;
            }
        }
        private int FindRow(Client aClient, String table)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;

            foreach (DataRow myRow_loopvariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopvariable;
                if (myRow.RowState != DataRowState.Deleted)
                    if (aClient.getID == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["ID"]))
                    {
                        returnValue = rowIndex;
                    }
                rowIndex++;
            }
            return returnValue;
        }
        #endregion
        #region Build Parameters, Create Commands & Update database
        private void Build_INSERT_Parameters(Client aClient)
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
        private void Create_INSERT_Command(Client aClient)
        {
            daMain.InsertCommand = new SqlCommand("INSERT into Clients (ID, Name, StreetAddress, Area, Town, PostalCode, BookingDate) VALUES (@ID, @Name, @StreetAddress, @Area, @Town, @PostalCode, @BookingDate)", cnMain);
            Build_INSERT_Parameters(aClient);
        }

        private void Build_UPDATE_Parameters(Client aClient)
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
        #endregion
    }
}



