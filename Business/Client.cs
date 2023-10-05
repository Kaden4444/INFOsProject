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
        #region Data fields
        string ID;
        string Name;
        string StreetAddress;
        string Area;
        string Town;
        string PostalCode;
        DateTime BookingDate;
        #endregion

        #region Constructor
        public Client() { BookingDate = DateTime.MinValue; }
        #endregion

        #region Property Methods
        public string getID
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
        public string getPostal_code
        {
            get { return PostalCode; }
            set { PostalCode = value; }    
        }

        public DateTime getBooking
        { get { return BookingDate; }
            set { BookingDate = value;  }
        }
        #endregion

    }
}
