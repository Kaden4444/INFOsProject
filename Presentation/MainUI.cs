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
using System.Threading;
using System.Data.SqlClient;

namespace INFOsProject.Presentation
{

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
        bool CreditDetailsValid = false;
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
            setUpMainListView();
        }
        #endregion

        #region Important / initial 
        private void MainUI_Load(object sender, EventArgs e)
        {
            ActiveControl = null;
            timer1.Start();
            CreditPanel.Visible = false;
            HidePanels();
            switch (State_of_Form)
            {
                case 0:
                    ClientPanel.Show();
                    break;
                case 1:
                    RoomPanel.Show();
                    break;
                case 2:
                    ReservationPanel.Show();
                    break;
            }
            MainListView.Clear();
            RestrictAllLabels();

        }

        private void MainListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (State_of_Form)
            {

                case 0:
                    if (MainListView.SelectedItems.Count > 0)
                    {
                        client = clientsController.Find(MainListView.SelectedItems[0].Text);
                        PopulateClientTB(client);
                    }

                    break;
                case 1:
                    if (MainListView.SelectedItems.Count > 0)
                    {
                        room = roomController.Find(MainListView.SelectedItems[0].Text);
                        PopulateRoomTB(room);
                    }
                    break;
                case 2:
                    if (MainListView.SelectedItems.Count > 0)
                    {
                        reservation = reservationController.Find(MainListView.SelectedItems[0].Text);
                        PopulateReservationTB(reservation);
                    }
                    break;
            }
        }
        #endregion

        #region Textbox Methods
        private void EnableClient()
        {
            ClientTextbox.Enabled = false;
            NameTextbox.Enabled = true;
            AddressTextbox.Enabled = true;
            AreaTextbox.Enabled = true;
            TownTextbox.Enabled = true;
            PostalCodeTextbox.Enabled = true;
            startDate.Enabled = true;
        }

        private void EnableRoom()
        {
            RoomIDTextbox.Enabled = false;
            PriceTextbox.Enabled = true;
        }

        private void EnableReservation()
        {
            ReservationIDTextbox.Enabled = false;
            startDate.Enabled = true;   
            endDate.Enabled = true;
            GuestTextbox.Enabled = true;
            //RoomcomboBox.populate
            TotalTextbox.Enabled = false;
        }

        private void RestrictAllLabels()
        {
            ClientTextbox.Enabled = false;
            NameTextbox.Enabled = false;
            AddressTextbox.Enabled = false;
            AreaTextbox.Enabled = false;
            TownTextbox.Enabled = false;
            PostalCodeTextbox.Enabled = false;
            startDate.Enabled = false;

            RoomIDTextbox.Enabled = false;
            PriceTextbox.Enabled = false;

            ReservationIDTextbox.Enabled = false;
            GuestTextbox.Enabled = false;
            //DaystextBox.Enabled = false;
            //RoomTextbox.Enabled = false;
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
        #endregion

        #region Panel Methods
        private void HidePanels()
        {
            ClientPanel.Visible = false;
            RoomPanel.Visible = false;
            ReservationPanel.Visible = false;
        }


        #endregion

        #region Client Methods
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


                // Tag the ListViewItem with the client object for later reference
                item.Tag = client;

                // Add the ListViewItem to the ListView
                MainListView.Items.Add(item);
            }
        }

        private Client PopulateClientObject()
        {
            try
            {
                client = new Client();
                client.getID = ClientTextbox.Text;
                client.getName = NameTextbox.Text;
                client.getStreetAddress = AddressTextbox.Text;
                client.getArea = AreaTextbox.Text;
                client.getTown = TownTextbox.Text;
                client.getPostal_code = PostalCodeTextbox.Text;
                
            }
            catch { MessageBox.Show("Something went wrong populating client, please ensure all fields are filled."); }
            return client;
        }

        private void ClientSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateClientFields())
            {
                if (addRadioGroup.Checked)
                {
                        client = PopulateClientObject();
                        clientsController.DataMaintenance(client, DB.DBOperation.Add);
                        clientsController.FinalizeChanges(client);
                        setUpMainListView();
                }

                else if (editRadioGroup.Checked)
                {
                        client = PopulateClientObject();
                        clientsController.DataMaintenance(client, DB.DBOperation.Edit);
                        clientsController.FinalizeChanges(client);
                        setUpMainListView();
                }
                else if (deleteRadioGroup.Checked)
                {
                    client = PopulateClientObject();
                    clientsController.DataMaintenance(client, DB.DBOperation.Delete);
                    clientsController.FinalizeChanges(client);
                    setUpMainListView();
                }
                ClearRoom();
                ResetLabels();
                getLatestID();
                resetTextboxColours();
            }
            else
            {
                MessageBox.Show("Invalid credentials entered");
            }


        }

        #endregion

        #region Room methods
        private void RoomSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateRoomFields()) { 
            if (addRadioGroup.Checked)
            {
                room = PopulateRoomObject();
                roomController.DataMaintenance(room, DB.DBOperation.Add);
                roomController.FinalizeChanges(room);
                setUpMainListView();
            }
            else if (editRadioGroup.Checked)
            {
                room = PopulateRoomObject();
                roomController.DataMaintenance(room, DB.DBOperation.Edit);
                roomController.FinalizeChanges(room);
                setUpMainListView();
            }
            else if (deleteRadioGroup.Checked)
            {
                room = PopulateRoomObject();
                roomController.DataMaintenance(room, DB.DBOperation.Delete);
                roomController.FinalizeChanges(room);
                setUpMainListView();
            }
                ClearRoom();
                ResetLabels();
                getLatestID();
                resetTextboxColours();
            }
            else
            {
                MessageBox.Show("Invalid credentials entered");
            }

        }

        private Room PopulateRoomObject()
        {
            try
            {
                room = new Room();
                room.RoomID = RoomIDTextbox.Text;
                double temp = Double.Parse(PriceTextbox.Text);
                room.Price = temp;
            }
            catch { MessageBox.Show("Something went wrong"); }
            return room;
        }

        #endregion

        #region Credit methods
        private void button2_Click(object sender, EventArgs e)
        {

            if (ValidateCreditFields()) {
                MessageBox.Show("Credit card details valid - reservation made.");
                CreditDetailsValid = true;
                CreditPanel.Visible = false;
                ClearCreditPanel();
                resetTextboxColours();
            }
            else
            {
                MessageBox.Show("Invalid card details.");
            }
        }

        private void ClearCreditPanel() 
        {
            CardHolderTextbox.Clear();
            CreditNumTextbox.Clear();
            ExpiryTextbox.Clear();
            CVVTextbox.Clear();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ClearCreditPanel();
        }

        #endregion

        #region Reservation methods
        private void ReservationSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateReservationFields())
            {
                CreditDetailsValid = false;
                if (addRadioGroup.Checked)
                {

                    CreditPanel.Visible = true;
                    CreditPanel.Focus();
                    reservation = PopulateReservationObject();
                    reservationController.DataMaintenance(reservation, DB.DBOperation.Add);
                    reservationController.FinalizeChanges(reservation);
                    setUpMainListView();
                }
                else if (editRadioGroup.Checked)
                {
                    reservation = PopulateReservationObject();
                    reservationController.DataMaintenance(reservation, DB.DBOperation.Edit);
                    reservationController.FinalizeChanges(reservation);
                    setUpMainListView();
                }
                else if (deleteRadioGroup.Checked)
                {
                    reservation = PopulateReservationObject();
                    reservationController.DataMaintenance(reservation, DB.DBOperation.Delete);
                    reservationController.FinalizeChanges(reservation);
                    setUpMainListView();
                }
            ClearRoom();
            ResetLabels();
            getLatestID();
            resetTextboxColours();
            }
            else
            {
                MessageBox.Show("Invalid credentials entered");
            }
            
        }
        #endregion

        #region General Button Methods

        private void button1_Click(object sender, EventArgs e)
        {
            State_of_Form = -1;
            d.Show();
            this.Hide();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {

            if (addRadioGroup.Checked)
            {
                getLatestID();
            }

            else if (editRadioGroup.Checked)
            {

            }

            else if (deleteRadioGroup.Checked)
            {

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ClearRoom();
            UnselectedRadioButtons();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ClearClient();
            UnselectedRadioButtons();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClearReservation();
            UnselectedRadioButtons();
        }

        private void addRadioGroup_CheckedChanged(object sender, EventArgs e)
        {  
            getLatestID();
            switch (State_of_Form)
            {
                case 0:
                    ClearClient();
                    ClientLabel.Text = "Add a Client:";
                    getLatestID();
                    EnableClient();
                    break;

                case 1:
                    ClearRoom();
                    RoomLabel.Text = "Add a Room:";
                    getLatestID();
                    EnableRoom();
                    break;

                case 2:
                    ClearReservation();
                    ReservationLabel.Text = "Add a Reservation:";
                    getLatestID();
                    EnableReservation();
                    
                    break;
            }
        }

        private void editRadioGroup_CheckedChanged(object sender, EventArgs e)
        {
            switch (State_of_Form)
            {
                case 0:
                    //ClearClient();
                    ClientLabel.Text = "Edit a Client:";
                    ClientTextbox.Enabled = false;
                    NameTextbox.Enabled = true;
                    AddressTextbox.Enabled = true;
                    AreaTextbox.Enabled = true;
                    TownTextbox.Enabled = true;
                    PostalCodeTextbox.Enabled = true;
                    startDate.Enabled = true;
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
                    //RoomTextbox.Enabled = true;
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
        #endregion

        #region Utility Methods

        private decimal CalculateTotal(DateTime CheckIn)
        {
            decimal price = 0;
            DateTime lowSeason = new DateTime(2023, 12, 1);
            DateTime midSeason = new DateTime(2023, 12, 8);
            DateTime highSeason = new DateTime(2023, 12, 16);

            if (CheckIn.Date < midSeason.Date)
            {
                price = 550;
            }
            else if ((CheckIn.Date >= midSeason.Date) && (CheckIn.Date < highSeason.Date))
            {
                price = 750;
            }
            else if ((CheckIn.Date >= highSeason.Date) && (CheckIn.Date <= new DateTime(2023, 12, 31)))
            {
                price = 995;
            }

            return price;
        }
        private void getLatestID()
        {
            switch (State_of_Form)
            {
                case 0:
                    int newCid = 0;
                    newCid = Clients.Count;
                    ClientTextbox.Text = newCid.ToString();
                    break;

                case 1:
                    int newRid = 0;
                    newRid = Rooms.Count;

                    RoomIDTextbox.Text = newRid.ToString();
                    break;

                case 2:
                    int newResid = 0;
                    newResid = Reservations.Count;

                    ReservationIDTextbox.Text = newResid.ToString();
                    break;
            }
        }

        private Reservation PopulateReservationObject()
        {
           try
          {
            reservation = new Reservation();
            reservation.ReservationID = ReservationIDTextbox.Text;
            reservation.Client = GuestTextbox.Text;
            reservation.Room = RoomcomboBox.SelectedItem.ToString();
            reservation.StartDate = startDate.Value;
            reservation.EndDate = endDate.Value;
            }
            catch { MessageBox.Show("Something went wrong with reservation object population"); }
            return reservation;
        }
        private void ClearClient()
        {
            ClientTextbox.Text = "";
            NameTextbox.Text = "";
            AddressTextbox.Text = "";
            AreaTextbox.Text = "";
            TownTextbox.Text = "";
            PostalCodeTextbox.Text = "";
            


            NameTextbox.BackColor = System.Drawing.SystemColors.Window;
            AddressTextbox.BackColor = System.Drawing.SystemColors.Window;
            AreaTextbox.BackColor = System.Drawing.SystemColors.Window;
            TownTextbox.BackColor = System.Drawing.SystemColors.Window;
            PostalCodeTextbox.BackColor = System.Drawing.SystemColors.Window;
            
        }
        private void PopulateClientTB(Client client)
        {
            ClientTextbox.Text = client.getID;
            NameTextbox.Text = client.getName;
            AddressTextbox.Text = client.getStreetAddress;
            AreaTextbox.Text = client.getArea;
            TownTextbox.Text = client.getTown;
            PostalCodeTextbox.Text = client.getPostal_code;
        }

        private void UnselectedRadioButtons()
        {
            addRadioGroup.Checked = false;
            editRadioGroup.Checked = false;
            deleteRadioGroup.Checked = false;
        }
        private void ClearReservation()
        {
            ReservationIDTextbox.Text = "";
            GuestTextbox.Text = "";
           // RoomTextbox.Text = "";
           // DaystextBox.Text = "";
            TotalTextbox.Text = "";
            startDate.Text = "";
            endDate.Text = "";

            ReservationIDTextbox.BackColor = System.Drawing.SystemColors.Window;
            GuestTextbox.BackColor = System.Drawing.SystemColors.Window;
            TotalTextbox.BackColor = System.Drawing.SystemColors.Window;
            startDate.BackColor = System.Drawing.SystemColors.Window;
            endDate.BackColor = System.Drawing.SystemColors.Window;
        }

        private void ClearRoom()
        {
            RoomIDTextbox.Text ="";
            PriceTextbox.Text = "";
        }
        private void PopulateRoomTB(Room room)
        {
            RoomIDTextbox.Text = room.RoomID;
            PriceTextbox.Text = room.Price.ToString();
        }

        private void PopulateReservationTB(Reservation reservation)
        {
            ReservationIDTextbox.Text = reservation.ReservationID;
            GuestTextbox.Text = reservation.Client.ToString();
           // RoomTextbox.Text = reservation.Room.ToString();
            TotalTextbox.Text = reservation.Total.ToString();
          //  DaystextBox.Text = reservation.Days.ToString();
        }
        #endregion

        #region Events
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss ");
        }

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
                    ClientPanel.Show();
                    MainListView.Columns.Insert(0, "ClientID", 50, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(1, "Name", 90, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(2, "Address", 140, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(3, "Area", 70, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(4, "Town", 50, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(5, "Postal Code", 70, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(6, "Reservation", 200, HorizontalAlignment.Left);

                    Clients = null;
                    Clients = clientsController.AllClients;
                    foreach (Client Client in Clients)
                    {
                        clientDetails = new ListViewItem();
                        clientDetails.Text = Client.getID;
                        clientDetails.SubItems.Add(Client.getName);
                        clientDetails.SubItems.Add(Client.getStreetAddress);
                        clientDetails.SubItems.Add(Client.getArea);
                        clientDetails.SubItems.Add(Client.getTown);
                        clientDetails.SubItems.Add(Client.getPostal_code);
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
                        roomDetails.Text = Room.RoomID;
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
                    MainListView.Columns.Insert(4, "StartDate", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(5, "EndDate", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(6, "DepositPaid", 120, HorizontalAlignment.Left);

                    Reservations = null;
                    Reservations = reservationController.AllReservations;
                    foreach (Reservation Reservation in Reservations)
                    {
                        reservationDetails = new ListViewItem();
                        reservationDetails.Text = Reservation.ReservationID;
                        reservationDetails.SubItems.Add(Reservation.Client.ToString());
                        reservationDetails.SubItems.Add(Reservation.Room.ToString());
                        reservationDetails.SubItems.Add(Reservation.Total.ToString());
                        reservationDetails.SubItems.Add(Reservation.StartDate.ToString());
                        reservationDetails.SubItems.Add(Reservation.EndDate.ToString());
                        reservationDetails.SubItems.Add(Reservation.Deposit.ToString());

                        MainListView.Items.Add(reservationDetails);
                    }
                    MainListView.Refresh();
                    MainListView.GridLines = true;

                    break;
            }        
        }
        #endregion

        #region Validation
        private void resetTextboxColours()
        {
            CardHolderTextbox.BackColor = System.Drawing.Color.White;
            CreditNumTextbox.BackColor = System.Drawing.Color.White;
            CVVTextbox.BackColor = System.Drawing.Color.White;
            NameTextbox.BackColor = System.Drawing.Color.White;
            AddressTextbox.BackColor = System.Drawing.Color.White;
            AreaTextbox.BackColor = System.Drawing.Color.White;
            TownTextbox.BackColor = System.Drawing.Color.White;
            PostalCodeTextbox.BackColor = System.Drawing.Color.White;
            GuestTextbox.BackColor = System.Drawing.Color.White;
            startDate.BackColor = System.Drawing.Color.White;
            endDate.BackColor = System.Drawing.Color.White;
            PriceTextbox.BackColor = System.Drawing.Color.White;

        }
        private bool ValidateCreditFields()
        {
            bool valid = true;
            if (string.IsNullOrEmpty(CardHolderTextbox.Text) || (!(CardHolderTextbox.Text).All(char.IsLetter)) || ((CardHolderTextbox.Text).All(char.IsWhiteSpace)))
            {
                MessageBox.Show("Please enter a valid Name.");
                CardHolderTextbox.BackColor = System.Drawing.Color.Red;
                valid = false;
            }

            if (string.IsNullOrEmpty(CreditNumTextbox.Text) || (!(CreditNumTextbox.Text).All(char.IsDigit)) || (!(CreditNumTextbox.Text.Length==16)) || ((CardHolderTextbox.Text).All(char.IsWhiteSpace)))
            {
                MessageBox.Show("Please enter a valid card number.");
                CreditNumTextbox.BackColor = System.Drawing.Color.Red;
                valid = false;
            }

            if (string.IsNullOrEmpty(CVVTextbox.Text) || (!(CVVTextbox.Text).All(char.IsDigit)) || (!(CVVTextbox.Text.Length == 3)) || ((CardHolderTextbox.Text).All(char.IsWhiteSpace)))
            {
                MessageBox.Show("Please enter a valid card verification value.");
                CVVTextbox.BackColor = System.Drawing.Color.Red;
                valid = false;
            }
            // Validate date
            return valid;
        }

        private bool ValidateClientFields()
        {
            bool valid = true;
            // You can reset the background color to its default by setting it to 'SystemColors.Window'
            // textBox1.BackColor = System.Drawing.SystemColors.Window;

            if (string.IsNullOrEmpty(NameTextbox.Text) || (!(NameTextbox.Text).All(char.IsLetter)) || ((NameTextbox.Text).All(char.IsWhiteSpace)))
            {
               // MessageBox.Show("Please enter a valid Name.");
                NameTextbox.BackColor = System.Drawing.Color.Red;
                valid = false;
            }


            if (string.IsNullOrEmpty(AddressTextbox.Text) || ((AddressTextbox.Text).All(char.IsWhiteSpace)))
            {
                //MessageBox.Show("Please enter a valid address.");
                AddressTextbox.BackColor = System.Drawing.Color.Red;
                valid = false;
            }

            if (string.IsNullOrEmpty(AreaTextbox.Text) || (!(AreaTextbox.Text).All(char.IsLetterOrDigit)) || ((AreaTextbox.Text).All(char.IsWhiteSpace)))
            {
               // MessageBox.Show("Please enter a valid area.");
                AreaTextbox.BackColor = System.Drawing.Color.Red;
                valid = false;
            }

            if (string.IsNullOrEmpty(TownTextbox.Text) || (!(TownTextbox.Text).All(char.IsLetter)) || ((TownTextbox.Text).All(char.IsWhiteSpace)))
            {
               // MessageBox.Show("Please enter a valid town.");
                TownTextbox.BackColor = System.Drawing.Color.Red;
                valid = false;
            }

            if (string.IsNullOrEmpty(PostalCodeTextbox.Text) || (!(PostalCodeTextbox.Text).All(char.IsDigit)) || ((TownTextbox.Text).All(char.IsWhiteSpace)))
            {
                //MessageBox.Show("Please enter a valid postal code.");
                PostalCodeTextbox.BackColor = System.Drawing.Color.Red;
                valid = false;
            }

          

            return valid; // All fields are valid
        }


        private bool ValidateReservationFields()
        {
            bool valid = true;
            // You can reset the background color to its default by setting it to 'SystemColors.Window'
            // textBox1.BackColor = System.Drawing.SystemColors.Window;

               
                try { clientsController.Find(GuestTextbox.Text); }
                catch 
                {
                GuestTextbox.BackColor = System.Drawing.Color.Red;
                MessageBox.Show("Please enter a valid Client.");
                valid = false;
            }
                


            DateTime startD = this.startDate.Value;

            DateTime minDate = new DateTime(2023, 12, 1);
            DateTime maxDate = new DateTime(2023, 12, 31);

            if (!(startD >= minDate && startD <= maxDate))
            {
                MessageBox.Show("Please select a starting date between December 1, 2023, and December 31, 2023.");
                this.startDate.BackColor = System.Drawing.Color.Red;
                valid = false;
            }

            DateTime endD = this.endDate.Value;

            if (!(endD >= minDate && endD <= maxDate))
            {
                MessageBox.Show("Please select a ending date between December 1, 2023, and December 31, 2023.");
                this.endDate.BackColor = System.Drawing.Color.Red;
                valid = false;
            }

            if (!(endD > startD))
            {
                MessageBox.Show("Check in date cannot be after check out date");
                this.startDate.BackColor = System.Drawing.Color.Red;
                this.endDate.BackColor = System.Drawing.Color.Red;
                valid = false;
            }



            return valid; // All fields are valid
        }

        private bool ValidateRoomFields()
        {
            bool valid = true;
            if (string.IsNullOrEmpty(PriceTextbox.Text) || (!(PriceTextbox.Text).All(char.IsDigit)) || ((PriceTextbox.Text).All(char.IsWhiteSpace)))
            {
                this.PriceTextbox.BackColor = System.Drawing.Color.Red; 
                valid = false;
            }
            return valid;
        }

        #endregion

        #region Unimplemented/Random



        private void button6_Click(object sender, EventArgs e)
        {
            CreditPanel.Visible = false;
            ClearCreditPanel();

        }

        #endregion


        private void linkLabelLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       private void button8_Click(object sender, EventArgs e)
        {
            try
           {
                int input = int.Parse(SearchtextBox.Text);
                ListViewItem clientDetails, roomDetails, reservationDetails;
                MainListView.Clear();
                switch (State_of_Form)
                {
                    case 0:
                        ClientPanel.Show();
                        MainListView.Columns.Insert(0, "ClientID", 50, HorizontalAlignment.Left);
                        MainListView.Columns.Insert(1, "Name", 90, HorizontalAlignment.Left);
                        MainListView.Columns.Insert(2, "Address", 140, HorizontalAlignment.Left);
                        MainListView.Columns.Insert(3, "Area", 70, HorizontalAlignment.Left);
                        MainListView.Columns.Insert(4, "Town", 50, HorizontalAlignment.Left);
                        MainListView.Columns.Insert(5, "Postal Code", 70, HorizontalAlignment.Left);
                        MainListView.Columns.Insert(6, "Reservation", 200, HorizontalAlignment.Left);

                        Clients = null;
                        Clients = clientsController.AllClients;
                        try
                        {
                            Client Client = Clients[input];
                            clientDetails = new ListViewItem();
                            clientDetails.Text = Client.getID;
                            clientDetails.SubItems.Add(Client.getName);
                            clientDetails.SubItems.Add(Client.getStreetAddress);
                            clientDetails.SubItems.Add(Client.getArea);
                            clientDetails.SubItems.Add(Client.getTown);
                            clientDetails.SubItems.Add(Client.getPostal_code);
                            MainListView.Items.Add(clientDetails);
                        }
                        catch { MessageBox.Show("Not found"); }
                        MainListView.Refresh();
                        MainListView.GridLines = true;
                        break;

                    case 1:
                        MainListView.Columns.Insert(0, "RoomID", 120, HorizontalAlignment.Left);
                        MainListView.Columns.Insert(1, "Price", 120, HorizontalAlignment.Left);

                        Rooms = null;
                        Rooms = roomController.AllRooms;

                        try
                        {
                            Room Room = Rooms[input];
                            roomDetails = new ListViewItem();
                            roomDetails.Text = Room.RoomID;
                            roomDetails.SubItems.Add(Room.Price.ToString());
                            MainListView.Items.Add(roomDetails);
                        }
                        catch { MessageBox.Show("Not found"); }
                        MainListView.Refresh();
                        MainListView.GridLines = true;
                        break;

                    case 2:
                        MainListView.Columns.Insert(0, "ReservationID", 120, HorizontalAlignment.Left);
                        MainListView.Columns.Insert(1, "Client", 120, HorizontalAlignment.Left);
                        MainListView.Columns.Insert(2, "Room", 120, HorizontalAlignment.Left);
                        MainListView.Columns.Insert(3, "Total", 120, HorizontalAlignment.Left);
                        MainListView.Columns.Insert(4, "StartDate", 120, HorizontalAlignment.Left);
                        MainListView.Columns.Insert(5, "EndDate", 120, HorizontalAlignment.Left);
                        MainListView.Columns.Insert(6, "DepositPaid", 120, HorizontalAlignment.Left);

                        Reservations = null;
                        Reservations = reservationController.AllReservations;
                        try
                        {
                            Reservation Reservation = Reservations[input];
                            reservationDetails = new ListViewItem();
                            reservationDetails.Text = Reservation.ReservationID;
                            reservationDetails.SubItems.Add(Reservation.Client.ToString());
                            reservationDetails.SubItems.Add(Reservation.Room.ToString());
                            reservationDetails.SubItems.Add(Reservation.Total.ToString());
                            reservationDetails.SubItems.Add(Reservation.StartDate.ToString());
                            reservationDetails.SubItems.Add(Reservation.EndDate.ToString());
                            reservationDetails.SubItems.Add(Reservation.Deposit.ToString());

                            MainListView.Items.Add(reservationDetails);
                        }
                        catch { MessageBox.Show("Not found"); }

                        MainListView.Refresh();
                        MainListView.GridLines = true;

                        break;
                }
            }
            catch { MessageBox.Show("Invalid Search"); }
        }
        

      

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            setUpMainListView();
        }
    }
}