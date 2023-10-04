using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using INFOsProject.Data;
using INFOsProject.Business;
using System.Collections.ObjectModel;
using System.Reflection.Emit;
using System.Xml;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;

namespace INFOsProject.Presentation
{

    /*
        #region Events
        private void MainListView_FormClosed(object sender, FormClosedEventArgs e)
        {
            listFormClosed = true;//4.4 Set the Boolean value of listFormClosed to true in the FormClosed event of the form(first create a FormClosed event for the form).

        }
        private void MainListView_Load(object sender, EventArgs e)
        {
            MainListView.View = View.Details;
        }

        private void MainListView_Activated(object sender, EventArgs e)
        {
            // 4.3.1 Set the view of the MainListView to Details view
            MainListView.View = View.Details;

            // 4.3.2 Call the setUpMainListView method
            setUpMainListView();

            // 4.3.3 Call the ShowAll method to reset the controls
            ShowAll(false, roleValue);
        }
        #endregion

        #region List View
        public void setUpMainListView()
        {
            ListViewItem clientDetails;   //Declare variables
            HeadWaiter headW;
            Waiter waiter;
            Runner runner;
            //Clear current List View Control
            MainListView.Clear();
            //Set Up Columns of List View
            MainListView.Columns.Insert(0, "ID", 120, HorizontalAlignment.Left);
            MainListView.Columns.Insert(1, "EMPID", 120, HorizontalAlignment.Left);
            MainListView.Columns.Insert(2, "Name", 150, HorizontalAlignment.Left);
            MainListView.Columns.Insert(3, "Phone", 100, HorizontalAlignment.Left);
            //TO DO  … do this for the other generic elements
            clients = null;                      //clients collection will be filled by role
            switch (roleValue)                     //  Check which role to add specific headings
            {
                case Role.RoleType.NoRole:
                    // TO DO Get all the clients from the ClientController object 
                    // (use the property) and assign to a local clients collection reference
                    clients = clientController.AllClients;
                    listLabel.Text = "Listing of all clients";
                    MainListView.Columns.Insert(4, "Payment", 100, HorizontalAlignment.Center);
                    break;
                case Role.RoleType.Headwaiter:
                    //Add a FindByRole method to the ClientController 
                    clients = clientController.FindByRole(clientController.AllClients, Role.RoleType.Headwaiter);
                    listLabel.Text = "Listing of all Headwaiters";
                    //Set Up Columns of List View
                    MainListView.Columns.Insert(4, "Salary", 100, HorizontalAlignment.Center);
                    break;
                //do for the others
                case Role.RoleType.Waiter:
                    //Add a FindByRole method to the ClientController 
                    clients = clientController.FindByRole(clientController.AllClients, Role.RoleType.Waiter);
                    listLabel.Text = "Listing of all Waiters";
                    //Set Up Columns of List View
                    MainListView.Columns.Insert(4, "Rate", 100, HorizontalAlignment.Center);
                    MainListView.Columns.Insert(4, "Number of Shifts", 100, HorizontalAlignment.Center);
                    break;
                case Role.RoleType.Runner:
                    //Add a FindByRole method to the ClientController 
                    clients = clientController.FindByRole(clientController.AllClients, Role.RoleType.Runner);
                    listLabel.Text = "Listing of all Runners";
                    //Set Up Columns of List View
                    MainListView.Columns.Insert(4, "Rate", 100, HorizontalAlignment.Center);
                    MainListView.Columns.Insert(4, "Number of Shifts", 100, HorizontalAlignment.Center);
                    break;

            }
            //Add client details to each ListView item 
            foreach (Client client in clients)
            {
                clientDetails = new ListViewItem();
                clientDetails.Text = client.ID.ToString();
                // Do the same for EmpID, Name and Phone
                clientDetails.SubItems.Add(client.ClientID);
                clientDetails.SubItems.Add(client.Name);
                clientDetails.SubItems.Add(client.Telephone);

                switch (client.role.getRoleValue)
                {
                    case Role.RoleType.Headwaiter:
                        headW = (HeadWaiter)client.role;
                        clientDetails.SubItems.Add(headW.SalaryAmount.ToString());
                        break;
                    case Role.RoleType.Waiter:
                        waiter = (Waiter)client.role;
                        clientDetails.SubItems.Add(waiter.getRate.ToString());
                        clientDetails.SubItems.Add(waiter.getShifts.ToString());
                        break;
                    case Role.RoleType.Runner:
                        runner = (Runner)client.role;
                        clientDetails.SubItems.Add(runner.getRate.ToString());
                        clientDetails.SubItems.Add(runner.getShifts.ToString());
                        break;
                }
                MainListView.Items.Add(clientDetails);
            }
            MainListView.Refresh();
            MainListView.GridLines = true;
        }


        private void MainListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowAll(true, roleValue);
            state = FormStates.View;
            EnableEntries(false);
            if (MainListView.SelectedItems.Count > 0)   // if you selected an item 
            {
                client = clientController.Find(MainListView.SelectedItems[0].Text);  //selected student becoms current student
                                                                                             // Show the details of the selected student in the controls
                PopulateTextBoxes(client);
            }
        }
        #endregion
     */
    public partial class MainUI : Form
    {
        #region Field members
        Dash d;
        int State_of_Form; // 0 = Client, 1 = Room, 2 = Reservation
        public bool listFormClosed;
        private Collection<Client> Clients;
        private Collection<Room> Rooms;
        private Collection<Reservation> Reservations;
        private ClientsController clientsController;
        private RoomController roomController;
        private ReservationController reservationController;

        #endregion

        #region Constructor
        public MainUI(Dash dash, int State, ClientsController c, RoomController r, ReservationController res)
        {
            InitializeComponent();
            d = dash;
            State_of_Form = State;
            

            // Create an instance of ClientsController
            clientsController = new ClientsController();

            LoadClients(); // Load clients from the database when the form is initialized

            clientsController = c;
            roomController = r;
            reservationController = res;

            this.Load += MainListView_Load;
            this.Activated += MainListView_Activated;
            this.FormClosed += MainListView_FormClosed;

            HidePanels();
        }
        #endregion

        private void LoadClients()
        {
            // Retrieve the list of clients from the controller
            Collection<Client> clients = clientsController.AllClients;

            // Clear existing items in the ListView
            MainListView.Items.Clear();

            // Populate the ListView with the retrieved client data
            foreach (Client client in clients)
            {
                ListViewItem item = new ListViewItem(client.getID);
                item.SubItems.Add(client.getName);
                item.SubItems.Add(client.getStreetAddress);
                item.SubItems.Add(client.getArea);
                item.SubItems.Add(client.getTown);
                item.SubItems.Add(client.getPostal_code);
                item.SubItems.Add(client.getBooking.ToString());

                // Tag the ListViewItem with the client object for later reference
                item.Tag = client;

                // Add the ListViewItem to the ListView
                MainListView.Items.Add(item);
            }
        }

        private void HidePanels()
        {
            ClientPanel.Visible = false;
            RoomPanel.Visible = false;
            ReservationPanel.Visible = false;
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            State_of_Form = -1;
            d.Show();
            this.Hide();
        }

        private void MainUI_Load(object sender, EventArgs e)
        {
            HidePanels();
            MainListView.Clear();
            switch (State_of_Form)
            {
                case 0:
                    MainListView.Columns.Insert(0, "ClientID", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(1, "Name", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(2, "Address", 150, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(3, "Area", 100, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(4, "Town", 100, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(5, "Postal Code", 100, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(6, "Reservation", 100, HorizontalAlignment.Left);
                    break;

                case 1:
                    MainListView.Columns.Insert(0, "RoomID", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(1, "Price", 120, HorizontalAlignment.Left);
                    break;

                case 2:
                    MainListView.Columns.Insert(0, "ReservationID", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(1, "Guest", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(2, "Room", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(3, "Total", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(4, "DaysOfStay", 120, HorizontalAlignment.Left);
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (viewRadioGroup.Checked)
            {
                switch(State_of_Form)
                {
                    case 0: //Client
                    ClientPanel.Show();
                    //MainListView

                    break;

                    case 1: //Room
                    RoomPanel.Show();
                    break;

                    case 2: //Reseration
                    ReservationPanel.Show();
                    break;

                }
                
            }

            else if (addRadioGroup.Checked)
            {

            }

            else if (editRadioGroup.Checked)
            {

            }

            else if (deleteRadioGroup.Checked)
            {

            }
        }


        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void RoomSubmit_Click(object sender, EventArgs e)
        {
            switch (State_of_Form)
            {
                case 0:
                    ClientPanel.Visible = true;

                    break;

                case 1:
                    RoomPanel.Visible = true;
                    break;

                case 2:
                    ReservationPanel.Visible = true;
                    break;
            }
        }

        private void ClientSubmit_Click(object sender, EventArgs e)
        {
           /* switch (groupBox1)
            {
                case 0:
                    ClientPanel.Visible = true;

                    break;

                case 1:
                    RoomPanel.Visible = true;
                    break;

                case 2:
                    ReservationPanel.Visible = true;
                    break;
            } */
        }

        private void ReservationSubmit_Click(object sender, EventArgs e)
        {
            switch (State_of_Form)
            {
                case 0:
                    ClientPanel.Visible = true;

                    break;

                case 1:
                    RoomPanel.Visible = true;
                    break;

                case 2:
                    ReservationPanel.Visible = true;
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HidePanels();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HidePanels();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HidePanels();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (State_of_Form)
            {
                case 0:
                    MainListView.Columns.Insert(0, "ClientID", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(1, "Name", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(2, "Address", 150, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(3, "Area", 100, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(4, "Town", 100, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(5, "Postal Code", 100, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(6, "Reservation", 100, HorizontalAlignment.Left);
                    break;

                case 1:
                    MainListView.Columns.Insert(0, "RoomID", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(1, "Price", 120, HorizontalAlignment.Left);
                    break;

                case 2:
                    MainListView.Columns.Insert(0, "ReservationID", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(1, "Guest", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(2, "Room", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(3, "Total", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(4, "DaysOfStay", 120, HorizontalAlignment.Left);
                    break;
            }
            
        }

        private void ReservationPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region Utility Methods
       /* private void PopulateTextBoxes(Employee employee)
        {
            HeadWaiter headW;
            Waiter waiter;
            Runner runner;
            idTextBox.Text = employee.ID;
            empIDTextBox.Text = employee.EmployeeID;
            nameTextBox.Text = employee.Name;
            phoneTextBox.Text = employee.Telephone;

            switch (employee.role.getRoleValue)
            {
                case Role.RoleType.Headwaiter:
                    headW = (HeadWaiter)(employee.role);
                    paymentTextBox.Text = Convert.ToString(headW.SalaryAmount);
                    break;
                case Role.RoleType.Waiter:
                    waiter = (Waiter)(employee.role);
                    paymentTextBox.Text = Convert.ToString(waiter.getRate);
                    shiftsTextBox.Text = Convert.ToString(waiter.getShifts);
                    break;
                case Role.RoleType.Runner:
                    runner = (Runner)(employee.role);
                    paymentTextBox.Text = Convert.ToString(runner.getRate);
                    shiftsTextBox.Text = Convert.ToString(runner.getShifts);
                    break;
            }
        } */

        #endregion


        #region Events
        private void MainListView_FormClosed(object sender, FormClosedEventArgs e)
        {
            listFormClosed = true;

        }
        private void MainListView_Load(object sender, EventArgs e)
        {
            MainListView.View = View.Details;
        }

        private void MainListView_Activated(object sender, EventArgs e)
        {
            
            MainListView.View = View.Details;
            setUpMainListView();

           
            //ShowAll(false, roleValue);
        }


        #endregion

        #region List View

   
   
        public void setUpMainListView()
        {
            
            ListViewItem clientDetails, roomDetails, reservationDetails;
            MainListView.Clear();
            switch (State_of_Form)
            {
                case 0:
                    MainListView.Columns.Insert(0, "ClientID", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(1, "Name", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(2, "Address", 150, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(3, "Area", 100, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(4, "Town", 100, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(5, "Postal Code", 100, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(6, "Reservation", 100, HorizontalAlignment.Left);

                    Clients = null;
                    Clients = clientsController.AllClients;
                    foreach (Client Client in Clients)
                    {
                        clientDetails = new ListViewItem();
                        clientDetails.Text = Client.getID.ToString();
                        clientDetails.SubItems.Add(Client.getName);
                        clientDetails.SubItems.Add(Client.getStreetAddress);
                        clientDetails.SubItems.Add(Client.getArea);
                        clientDetails.SubItems.Add(Client.getTown);
                        clientDetails.SubItems.Add(Client.getPostal_code);
                        clientDetails.SubItems.Add(Client.getBooking.ToString());
                        MainListView.Items.Add(clientDetails);
                    }
                    MainListView.Refresh();
                    MainListView.GridLines = true;
                    break;

                case 1:
                    MainListView.Columns.Insert(0, "RoomID", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(1, "Price", 120, HorizontalAlignment.Left);

                    Rooms = null;
                    Rooms = roomController.AllRooms;
                    foreach (Room Room in Rooms)
                    {
                        roomDetails = new ListViewItem();
                        roomDetails.Text = Room.RoomID.ToString();
                        roomDetails.SubItems.Add(Room.Booked.ToString());

                        MainListView.Items.Add(roomDetails);
                    }
                    MainListView.Refresh();
                    MainListView.GridLines = true;
                    break;

                case 2:
                    MainListView.Columns.Insert(0, "ReservationID", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(1, "Client", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(2, "Room", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(3, "Total", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(4, "DaysOfStay", 120, HorizontalAlignment.Left);

                    Reservations = null;
                    Reservations = reservationController.AllReservations;
                    foreach (Reservation Reservation in Reservations)
                    {
                        reservationDetails = new ListViewItem();
                        reservationDetails.Text = Reservation.ReservationID.ToString();
                        reservationDetails.SubItems.Add(Reservation.Client.ToString());
                        reservationDetails.SubItems.Add(Reservation.Room.ToString());
                        reservationDetails.SubItems.Add(Reservation.Total.ToString());
                        reservationDetails.SubItems.Add(Reservation.Days.ToString());

                        MainListView.Items.Add(reservationDetails);
                    }
                    MainListView.Refresh();
                    MainListView.GridLines = true;

                    break;
            }        
        }
        #endregion
    }


}

/*        #region Events


        #region Utility Methods

       
        private void EnableEntries(bool value)
        {
            if ((state == FormStates.Edit) && value)
            {
                idTextBox.Enabled = !value;
                empIDTextBox.Enabled = !value;
            }
            else
            {
                idTextBox.Enabled = value;
                empIDTextBox.Enabled = value;
            }
            nameTextBox.Enabled = value;
            phoneTextBox.Enabled = value;
            paymentTextBox.Enabled = value;
            shiftsTextBox.Enabled = value;
            if (state == FormStates.Delete)
            {
                cancelButton.Visible = !value;
                submitButton.Visible = !value;
            }
            else
            {
                cancelButton.Visible = value;
                submitButton.Visible = value;
            }
        }
        private void ClearAll()
        {
            idTextBox.Text = "";
            empIDTextBox.Text = "";
            nameTextBox.Text = "";
            phoneTextBox.Text = "";
            paymentTextBox.Text = "";
            shiftsTextBox.Text = "";
        }
        #endregion

        private void PopulateTextBoxes(Employee employee)
        {
            HeadWaiter headW;
            Waiter waiter;
            Runner runner;
            idTextBox.Text = employee.ID;
            empIDTextBox.Text = employee.EmployeeID;
            nameTextBox.Text = employee.Name;
            phoneTextBox.Text = employee.Telephone;

            switch (employee.role.getRoleValue)
            {
                case Role.RoleType.Headwaiter:
                    headW = (HeadWaiter)(employee.role);
                    paymentTextBox.Text = Convert.ToString(headW.SalaryAmount);
                    break;
                case Role.RoleType.Waiter:
                    waiter = (Waiter)(employee.role);
                    paymentTextBox.Text = Convert.ToString(waiter.getRate);
                    shiftsTextBox.Text = Convert.ToString(waiter.getShifts);
                    break;
                case Role.RoleType.Runner:
                    runner = (Runner)(employee.role);
                    paymentTextBox.Text = Convert.ToString(runner.getRate);
                    shiftsTextBox.Text = Convert.ToString(runner.getShifts);
                    break;
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            state = FormStates.Edit;
            EnableEntries(true);
        }

        private void PopulateObject(Role.RoleType roleType)
        {
            HeadWaiter headW;
            Waiter waiter;
            Runner runner;
            employee = new Employee(roleType);
            employee.ID = idTextBox.Text;
            employee.EmployeeID = empIDTextBox.Text;
            employee.Name = nameTextBox.Text;
            employee.Telephone = phoneTextBox.Text;

            switch (employee.role.getRoleValue)
            {
                case Role.RoleType.Headwaiter:
                    headW = (HeadWaiter)(employee.role);
                    headW.SalaryAmount = decimal.Parse(paymentTextBox.Text);
                    break;
                case Role.RoleType.Waiter:
                    waiter = (Waiter)(employee.role);
                    waiter.getRate = decimal.Parse(paymentTextBox.Text);
                    break;
                case Role.RoleType.Runner:
                    runner = (Runner)(employee.role);
                    runner.getRate = decimal.Parse(paymentTextBox.Text);
                    break;
            }
        }


        private void submitButton_Click(object sender, EventArgs e)
        {
            PopulateObject(roleValue);
         
{           if (state == FormStates.Edit)
                {
                    employeeController.DataMaintenance(employee, Data.DB.DBOperation.Edit);
                }
                else if (state == FormStates.Delete)
                {
                    employeeController.DataMaintenance(employee, Data.DB.DBOperation.Delete);
                }
}
            employeeController.FinalizeChanges(employee);
            ClearAll();
            state = FormStates.View;
            ShowAll(false,roleValue);
            setUpMainListView();
    }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            state = FormStates.Delete;
            
        }
    }*/