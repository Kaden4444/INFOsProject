using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INFOsProject.Business;
using INFOsProject.Data;

namespace INFOsProject.Business
{
    public class ClientsController
    {
        #region Data Members
        ClientsDB ClientDB;
        Collection<Client> Clients;
        #endregion

        #region Properties
        public Collection<Client> AllClients
        {
            get
            {
                return Clients;
            }
        }
        #endregion

        #region Constructor
        public ClientsController()
        {
            //***instantiate the ClientDB object to communicate with the database
            ClientDB = new ClientsDB();
            Clients = ClientDB.AllClients;
        }
        #endregion

        #region Database Communication.
        public void DataMaintenance(Client aClient, DB.DBOperation operation)
        {
            int index = 0;
            ClientDB.DataSetChange(aClient, operation);
            switch (operation)
            {
                case DB.DBOperation.Add:
                    Clients.Add(aClient);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aClient);
                    Clients[index] = aClient;  
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aClient);
                    Clients.RemoveAt(index);
                    break;
            }
        }


        public bool FinalizeChanges(Client Client)
        {
            return ClientDB.UpdateDataSource(Client);
        }

        #endregion

        #region Search Method


        public Client Find(string ID)
        {
            int index = 0;
            bool found = (Clients[index].getID == ID);
            int count = Clients.Count;
            while (!(found) && (index < Clients.Count - 1))
            {
                index = index + 1;
                found = (Clients[index].getID == ID);
            }
            return Clients[index];
        }

        public int FindIndex(Client aClient)
        {
            int counter = 0;
            bool found = false;
            found = (aClient.getID == Clients[counter].getID);
            while (!(found) & counter < Clients.Count - 1)
            {
                counter++;
                found = (aClient.getID == Clients[counter].getID);
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

