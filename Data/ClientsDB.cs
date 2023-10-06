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
    public class ClientsDB : DB
    {
        #region  Data members        
        private string table = "Clients";
        private string sqlLocal1 = "SELECT * FROM Clients";
        private Collection<Client> Clients;
        private Client aClient;
        #endregion

        #region Collection Methods
        public Collection<Client> AllClients
        {
            get
            {
                return Clients;
            }
        }
        #endregion

        #region Constructor
        public ClientsDB() : base()
        {
            Clients = new Collection<Client>();
            FillDataSet(sqlLocal1, table);
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
            //Declare references to a myRow object and an Client object
            DataRow myRow = null;
            //Client aClient;
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
                    aClient.getPostal_code = Convert.ToString(myRow["PostalCode"]).TrimEnd();
                    //if (!(myRow["BookingDate"] == null)){ aClient.getBooking = Convert.ToDateTime(myRow["BookingDate"]); }

                    Clients.Add(aClient);
                }

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
            /* 
            foreach (DataRow myRow_loopvariable in dsMain.Tables[table].Rows)
            {
               myRow = myRow_loopvariable;
                if (myRow.RowState != DataRowState.Deleted)
                   
                     if (aClient.getID.Equals(Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["ID"])))
                {
                        MessageBox.Show(aClient.getID + " - " + Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["ID"]));
                        returnValue = rowIndex;
                }
                rowIndex++;
                
            }*/
            returnValue = int.Parse(aClient.getID);
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

            param = new SqlParameter("@BookingDate", SqlDbType.Date, 10, "BookingDate");
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
            param = new SqlParameter("@Name", SqlDbType.NVarChar, 10, "Name");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@StreetAddress", SqlDbType.NVarChar, 100, "StreetAddress");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Area", SqlDbType.NVarChar, 15, "Area");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Town", SqlDbType.NVarChar, 10, "Town");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 10, "PostalCode");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@BookingDate", SqlDbType.Date, 10, "BookingDate");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Original_ID", SqlDbType.NVarChar, 15, "ID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);
        }
        private void Create_UPDATE_Command(Client aClient)
        {
            daMain.UpdateCommand = new SqlCommand("UPDATE HeadWaiter SET Name =@Name, StreetAdress =@StreetAdress, Area =@Area, Town = @Town, PostalCode = @PostalCode, BookingDate = @BookingDate " + "WHERE ID = @Original_ID", cnMain);
            Build_UPDATE_Parameters(aClient);

        }

        // Make delete methods
        public bool UpdateDataSource(Client aClient)
        {
            bool success = true;
            Create_INSERT_Command(aClient);
            Create_UPDATE_Command(aClient);
            success = UpdateDataSource(sqlLocal1, table);
            return success;
        }
        #endregion

        #region Database Operations CRUD
        public void DataSetChange(Client aClient, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = table;
            dataTable = table;

            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, aClient, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow); //Add to the dataset
                    break;

                case DB.DBOperation.Edit:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aClient, dataTable)];
                    aRow.BeginEdit();
                    FillRow(aRow, aClient, operation);
                    aRow.EndEdit();
                    
                    MessageBox.Show(aClient.getName);
                    //dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DB.DBOperation.Delete:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(aClient, dataTable)];
                    aRow.Delete();
                    break;
            }
        }


        #endregion

    }
}



