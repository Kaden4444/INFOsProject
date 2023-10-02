using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFOsProject.Data
{
    internal class HotelDB:DB
    {
        #region  Data members        
        private string table1 = "Clients";
        private string sqlLocal1 = "SELECT * FROM Clients";
        private string table2 = "Room";
        private string sqlLocal2 = "SELECT * FROM Room";
        private string table3 = "Reservations";
        private string sqlLocal3 = "SELECT * FROM Reservations";

        #endregion


    }
}
