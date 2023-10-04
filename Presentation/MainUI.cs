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
        private Client client;
        private Room room;
        private Reservation reservation;
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
            ClientTextbox.Enabled = false;
            switch (State_of_Form)
            {
                case 0:
                    ClientPanel.Show();
                    MainListView.Columns.Insert(0, "ClientID", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(1, "Name", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(2, "Address", 150, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(3, "Area", 100, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(4, "Town", 100, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(5, "Postal Code", 100, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(6, "Reservation", 100, HorizontalAlignment.Left);
                    break;

                case 1:
                    RoomPanel.Show();
                    MainListView.Columns.Insert(0, "RoomID", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(1, "Price", 120, HorizontalAlignment.Left);
                    break;

                case 2:
                    MessageBox.Show("FUcking poes");
                    ReservationPanel.Show();
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

            if (addRadioGroup.Checked)
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
            ResetLabels();
            RestrictAllLabels();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearClient();
            RestrictAllLabels();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ClearReservation();
            RestrictAllLabels();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClearRoom();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void ReservationPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (State_of_Form)
            {
                case 0:
                    if (MainListView.SelectedItems.Count > 0)
                    {
                        client = clientsController.Find(MainListView.SelectedItems[0].Text);
                        PopulateClient(client);
                    }
                    
                    break;
                case 1:
                    if (MainListView.SelectedItems.Count > 0)
                    {
                        room = roomController.Find(MainListView.SelectedItems[0].Text);
                        PopulateRoom(room);
                    }
                    break;
                case 2:
                    if (MainListView.SelectedItems.Count > 0)
                    {
                        reservation = reservationController.Find(MainListView.SelectedItems[0].Text);
                        PopulateReservation(reservation);
                    }
                    break;
                }
        }

        #region Utility Methods

        private void ClearClient()
        {
            ClientTextbox.Text = "";
            NameTextbox.Text = "";
            AddressTextbox.Text = "";
            AreaTextbox.Text = "";
            TownTextbox.Text = "";
            PostalCodeTextbox.Text = "";
            ReservationTextbox.Text = "";

        }
        private void PopulateClient(Client client)
        {
            ClientTextbox.Text = client.getID;
            NameTextbox.Text = client.getName;
            AddressTextbox.Text = client.getStreetAddress;
            AreaTextbox.Text = client.getArea;
            TownTextbox.Text = client.getTown;
            PostalCodeTextbox.Text = client.getPostal_code;
            ReservationTextbox.Text = client.getBooking.ToString();
            
        }

        private void ClearReservation()
        {
            //...
            ReservationIDTextbox.Text = "";
            GuestTextbox.Text = "";
            RoomTextbox.Text = "";
            TotalTextbox.Text = "";

        }

        private void ClearRoom()
        {
            RoomIDTextbox.Text ="";
            PriceTextbox.Text = "";
        }
        private void PopulateRoom(Room room)
        {
            RoomIDTextbox.Text = room.RoomID;
            PriceTextbox.Text = room.Price.ToString();
        }

        private void PopulateReservation(Reservation reservation)
        {
            ReservationIDTextbox.Text = reservation.ReservationID;
            GuestTextbox.Text = reservation.Client.ToString();
            RoomTextbox.Text = reservation.Room.ToString();
            TotalTextbox.Text = reservation.Total.ToString();
        }
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
                        roomDetails.SubItems.Add(Room.Price.ToString());
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

        private void ClientPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addRadioGroup_CheckedChanged(object sender, EventArgs e)
        {
            switch (State_of_Form)
            {
                case 0:
;                   ClearClient();
                    ClientLabel.Text = "Add a Client:";
                    NameTextbox.Enabled = true;
                    AddressTextbox.Enabled = true;
                    AreaTextbox.Enabled= true;
                    TownTextbox.Enabled = true;
                    PostalCodeTextbox.Enabled = true;
                    ReservationTextbox.Enabled = true;

                    int newCid = 0;
                    newCid = Clients.Count;

                    ClientTextbox.Text = newCid.ToString();
                    break;

                case 1:
                    ClearRoom();
                    RoomLabel.Text = "Add a Room:";
                   // RoomIDTextbox.Enabled = true;
                    PriceTextbox.Enabled = true;

                    int newRid = 0;
                    newRid = Rooms.Count;

                    RoomIDTextbox.Text = newRid.ToString();
                    break;

                case 2:
                    ReservationPanel.Visible = true;
                    ClearReservation();
                    ReservationLabel.Text = "Add a Reservation:";
                   // ReservationIDTextbox.Enabled = true;
                    GuestTextbox.Enabled = true;
                    RoomTextbox.Enabled = true;
                    TotalTextbox.Enabled = true;
                    int newResid = 0;
                    newResid = Reservations.Count;

                    ReservationIDTextbox.Text = newResid.ToString();
                    break;
            }
        }

        private void editRadioGroup_CheckedChanged(object sender, EventArgs e)
        {
            switch (State_of_Form)
            {
                case 0:
                    ClearClient();
                    ClientLabel.Text = "Edit a Client:";
                    ClientTextbox.Enabled = false;
                    NameTextbox.Enabled = true;
                    AddressTextbox.Enabled = true;
                    AreaTextbox.Enabled = true;
                    TownTextbox.Enabled = true;
                    PostalCodeTextbox.Enabled = true;
                    ReservationTextbox.Enabled = true;
                    break;

                case 1:
                    ClearRoom();
                    RoomLabel.Text = "Edit a Room:";
                    RoomIDTextbox.Enabled = false;
                    PriceTextbox.Enabled = true;
                    break;

                case 2:
                    ClearReservation();
                    ReservationLabel.Text = "Edit a Reservation:";
                    ReservationIDTextbox.Enabled = false;
                    GuestTextbox.Enabled = true;
                    RoomTextbox.Enabled = true;
                    TotalTextbox.Enabled = true;
                    break;
            }
        }

        private void deleteRadioGroup_CheckedChanged(object sender, EventArgs e)
        {
            switch (State_of_Form)
            {

                case 0:
                    ClearClient();
                    ClientLabel.Text = "Delete a Client:";
                    RestrictAllLabels();
                    break;

                case 1:
                    ClearRoom();
                    RoomLabel.Text = "Delete a Room:";
                    RestrictAllLabels();
                    break;

                case 2:
                    ReservationPanel.Visible = true;
                    ClearReservation();
                    ReservationLabel.Text = "Delete a Reservation:";
                    RestrictAllLabels();
                    break;
            }
        }

        private void RestrictAllLabels()
        {
            ClientTextbox.Enabled = false;
            NameTextbox.Enabled = false;
            AddressTextbox.Enabled = false;
            AreaTextbox.Enabled = false;
            TownTextbox.Enabled = false;
            PostalCodeTextbox.Enabled = false;
            ReservationTextbox.Enabled = false;

            RoomIDTextbox.Enabled = false;
            PriceTextbox.Enabled = false;

            ReservationIDTextbox.Enabled = false;
            GuestTextbox.Enabled = false;
            RoomTextbox.Enabled = false;
            TotalTextbox.Enabled = false;
        }
        private void ResetLabels()
        {
            switch (State_of_Form)
            {
                case 0:
                    ClearClient();
                    ClientLabel.Text = "Client Details:";
                    break;

                case 1:
                    ClearRoom();
                    RoomLabel.Text = "Room Details:";
                    break;

                case 2:
                    ClearReservation();
                    ReservationLabel.Text = "Reservation Details:";
                    break;
            }
        }
        private void RoomSubmit_Click_1(object sender, EventArgs e)
        {
            ResetLabels();
        }

        private void ClientSubmit_Click_1(object sender, EventArgs e)
        {
            ResetLabels();
        }
    }


}