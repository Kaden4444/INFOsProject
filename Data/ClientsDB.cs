using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INFOsProject.Business
namespace INFOsProject.Data
{
    public class ClientsDB:DB
    {
        #region  Data members        
        private string table1 = "Clients";
        private string sqlLocal1 = "SELECT * FROM Clients";
        private Collection<Client> clients;
        #endregion

        public Collection<Client> AllClients
        {
            get
            {
                return clients;
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
    }
}
