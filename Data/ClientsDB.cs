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
                   
                    aClient.ID = Convert.ToString(myRow["ID"]).TrimEnd();

                    //Do the same for all other attributes
                    aClient.Name = Convert.ToString(myRow["Name"]).TrimEnd();
                    aClient.StreetAddress = Convert.ToString(myRow["StreetAddress"]).TrimEnd();
                    
                    //Depending on Role read more Values
                    switch (aClient.role.getRoleValue)
                    {
                        case Role.RoleType.Headwaiter:
                            headw = (HeadWaiter)aClient.role;
                            headw.SalaryAmount = Convert.ToDecimal(myRow["Salary"]);
                            break;
                        case Role.RoleType.Waiter:
                            waiter = (Waiter)aClient.role;
                            waiter.getRate = Convert.ToDecimal(myRow["DayRate"]);
                            waiter.getShifts = Convert.ToInt32(myRow["NoOfShifts"]);
                            break;
                        case Role.RoleType.Runner:
                            runner = (Runner)aClient.role;
                            runner.getRate = Convert.ToDecimal(myRow["DayRate"]);
                            runner.getShifts = Convert.ToInt32(myRow["NoOfShifts"]);
                            break;
                    }
                    employees.Add(aClient);
                }
            }
        }
    }
}
