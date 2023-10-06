using INFOsProject.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INFOsProject.Data
    {
        public class DB
        {
        #region Variable declaration
        //***Once the database is created you can find the correct connection string by using the Settings.Default object to select the correct connection string
        private string strConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\dzivh\\Source\\Repos\\INFOsProjec\\DatabaseFiles\\HotelDatabase.mdf;Integrated Security=True";
            protected SqlConnection cnMain;
            protected DataSet dsMain;
            protected SqlDataAdapter daMain;
            public enum DBOperation
            {
                Add,
                Edit,
                Delete
            }

            #endregion

        #region Constructor
            public DB()
            {
                try
                {
                    //Open a connection & create a new dataset object
                    cnMain = new SqlConnection(strConn);
                    dsMain = new DataSet();
                }
                catch (SystemException e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message, "Error DB file 41");
                    return;
                }
            }

            #endregion

        #region Update the DateSet
            public void FillDataSet(string aSQLstring, string aTable)
            {
                //fills dataset fresh from the db for a specific table and with a specific Query
                try
                {
                    daMain = new SqlDataAdapter(aSQLstring, cnMain);
                    cnMain.Open();
                    dsMain.Clear();
                    daMain.Fill(dsMain, aTable);
                    cnMain.Close();
                }
                catch (Exception errObj)
                {
                    MessageBox.Show(errObj.Message + " fill data set error DB " + errObj.StackTrace);
                }
            }

            #endregion

        #region Update the data source 
            protected bool UpdateDataSource(string sqlLocal, string table)
            {
                bool success;
                try
                {
                    //open the connection
                    cnMain.Open();
                    //***update the database table via the data adapter
                    daMain.Update(dsMain, table);
                    //---close the connection
                    cnMain.Close();
                    //refresh the dataset
                    FillDataSet(sqlLocal, table);
                    success = true;
                }
                catch (Exception errObj)
                {
                    MessageBox.Show(errObj.Message + " Update data source error " + errObj.StackTrace);
                    success = false;
                }
                finally
                {
                }
                return success;
            }
            #endregion
        }
    }


/*Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Data\ProjectDatabase.mdf;Integrated Security=True */