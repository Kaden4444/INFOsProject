using INFOsProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace INFOsProject.Business
{
    public class Client
    {
        String ID;
        string Name;
        string StreetAddress;
        string Area;
        string Town;
        int Postal_code;
        DateTime BookingDate;

        public Client() { }

        #region Property Methods
        public String getID
        {
            get { return ID; }
            set { ID = value; }
        }
        public string getName
        {
            get { return Name; }
            set { Name = value; }
        }
        public string getStreetAddress
        {
            get { return StreetAddress; }
            set { StreetAddress = value; }
        }
        public string getArea
        {
            get { return Area; }
            set { Area = value; }
        }
        public string getTown
        {
            get { return Town; }
            set { Town = value; }
        }
        public int getPostal_code
        {
            get { return Postal_code; }
            set { Postal_code = value; }    
        }

        public DateTime getBooking
        { get { return BookingDate; }
            set { BookingDate = value;  }
        }
        #endregion

    }
}
