using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INFOsProject.Business;
namespace INFOsProject.Data
{
    public class ClientsDB:DB
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
            //Declare references to a myRow object and an Employee object
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
        }
    }

