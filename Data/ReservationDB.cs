using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INFOsProject.Business;

namespace INFOsProject.Data
{
    public class ReservationDB:DB
    {
        #region  Data members        
        private string table1 = "Reservations";
        private string sqlLocal1 = "SELECT * FROM Reservations";
        private Collection<Reservation> Reservations;
        private Reservation aReservation;

        #endregion

        public Collection<Reservation> AllClients
        {
            get
            {
                return Reservations;
            }
        }
        #endregion

        #region Constructor
        public ReservationDB() : base()
        {
            Reservations = new Collection<Reservation>();
            FillDataSet(sqlLocal1, table1);
            Add2Collection(table1);
        }
        #endregion

        #region Utility Methods
        public DataSet GetDataSet()
        {
            return dsMain;
        }

        public void DataMaintenance(Reservation aReservation, DB.DBOperation operation)
        {
            int index = 0;

            switch (operation)
            {
                case DB.DBOperation.Add:
                    Reservations.Add(aReservation);
                    break;
                case DB.DBOperation.Edit:
                    //index = FindIndex(aReservation);
                    Reservations[index] = aReservation;
                    break;
                case DB.DBOperation.Delete:
                    Reservations.Remove(aReservation);
                    break;
            }
        }
        private void Add2Collection(string table)
        {
            //Declare references to a myRow object and an Reservation object
            DataRow myRow = null;

            //READ from the table  
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    aReservation = new Reservation();
                    aReservation.ReservationID = Convert.ToString(myRow["ID"]).TrimEnd();
                    aReservation. = Convert.ToString(myRow["Name"]).TrimEnd();
                    aReservation.getStreetAddress = Convert.ToString(myRow["StreetAddress"]).TrimEnd();
                    aReservation.getArea = Convert.ToString(myRow["Area"]).TrimEnd();
                    aReservation.getTown = Convert.ToString(myRow["Town"]).TrimEnd();
                    aReservation.getArea = Convert.ToString(myRow["Area"]).TrimEnd();
                    aReservation.getPostal_code = Convert.ToString(myRow["PostalCode"]).TrimEnd();
                    aReservation.getBooking = Convert.ToDateTime(myRow["BookingDate"]);
                    }
                Reservations.Add(aReservation);
                }
            }

        private void FillRow(DataRow aRow, Reservation aReservation, DB.DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                aRow["ID"] = aReservation.getID;  //NOTE square brackets to indicate index of collections of fields in row.
                aRow["Name"] = aReservation.getName;
                aRow["StreetAddress"] = aReservation.getStreetAddress;
                aRow["Area"] = aReservation.getArea;
                aRow["Town"] = aReservation.getTown;
                aRow["PostalCode"] = aReservation.getPostal_code;
                aRow["BookingDate"] = aReservation.getBooking;
            }
        }
        private int FindRow(Reservation aReservation, String table)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;

            foreach (DataRow myRow_loopvariable in dsMain.Tables[table].Rows)
        {
                myRow = myRow_loopvariable;
                if (myRow.RowState != DataRowState.Deleted)
                    if (aReservation.getID == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["ID"]))
            {
                        returnValue = rowIndex;
            }
                rowIndex++;
        }
            return returnValue;
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        private void Build_INSERT_Parameters(Reservation aReservation)
        {
            //Create Parameters to communicate with SQL INSERT...add the input parameter and set its properties.
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@ID", SqlDbType.NVarChar, 15, "ID");
            daMain.InsertCommand.Parameters.Add(param);//Add the parameter to the Parameters collection.

            param = new SqlParameter("@EMPID", SqlDbType.NVarChar, 10, "EMPID");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Name", SqlDbType.NVarChar, 10, "Name");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@StreetAddress", SqlDbType.NVarChar, 100, "StreetAddress");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Area", SqlDbType.NVarChar, 15, "Area");
            daMain.InsertCommand.Parameters.Add(param);
            switch (anEmp.role.getRoleValue)
            {
                case Role.RoleType.Headwaiter:
                    param = new SqlParameter("@Salary", SqlDbType.Money, 8, "Salary");
                    daMain.InsertCommand.Parameters.Add(param);
                    break;
                case Role.RoleType.Waiter:
                    param = new SqlParameter("@Tips", SqlDbType.Money, 8, "Tips");
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@DayRate", SqlDbType.Money, 8, "DayRate");
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@NoOfShifts", SqlDbType.SmallInt, 4, "NoOfShifts");
                    daMain.InsertCommand.Parameters.Add(param);
                    break;
                case Role.RoleType.Runner:
                    param = new SqlParameter("@DayRate", SqlDbType.Money, 8, "DayRate");
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@NoOfShifts", SqlDbType.SmallInt, 4, "NoOfShifts");
                    daMain.InsertCommand.Parameters.Add(param);
                    break;
            }
            //***https://msdn.microsoft.com/en-za/library/ms179882.aspx
        }

        private void Create_INSERT_Command(Reservation anEmp)
        {
            //Create the command that must be used to insert values into the Books table..
            switch (anEmp.role.getRoleValue)
            {
                case Role.RoleType.Headwaiter:
                    daMain.InsertCommand = new SqlCommand("INSERT into HeadWaiter (ID, EMPID, Name, Phone, Role, Salary) VALUES (@ID, @EmpID, @Name, @Phone, @Role, @Salary)", cnMain);
                    break;
                case Role.RoleType.Waiter:
                    daMain.InsertCommand = new SqlCommand("INSERT into Waiter (ID, EMPID, Name, Phone, Role, Tips, DayRate, NoOfShifts) VALUES (@ID, @EmpID, @Name, @Phone, @Role, @Tips, @DayRate, @NoOfShifts)", cnMain);
                    break;
                case Role.RoleType.Runner:
                    daMain.InsertCommand = new SqlCommand("INSERT into Runner (ID, EMPID, Name, Phone, Role, DayRate, NoOfShifts) VALUES (@ID, @EmpID, @Name, @Phone, @Role, @DayRate, @NoOfShifts)", cnMain);
                    break;
            }
            Build_INSERT_Parameters(anEmp);
        }

        public bool UpdateDataSource(Reservation anEmp)
        {
            bool success = true;
            Create_INSERT_Command(anEmp);
            switch (anEmp.role.getRoleValue)
            {
                case Role.RoleType.Headwaiter:
                    success = UpdateDataSource(sqlLocal1, table);
                    break;
                case Role.RoleType.Waiter:
                    success = UpdateDataSource(sqlLocal2, table2);
                    break;
                case Role.RoleType.Runner:
                    success = UpdateDataSource(sqlLocal3, table3);
                    break;
            }
            return success;
        }

        #endregion

    }
}
