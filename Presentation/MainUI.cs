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
using System.Xml.Linq;

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
           // this.FormClosed += MainListView_FormClosed;
        }
        #endregion

        #region Important / initial 
        private void MainUI_Load(object sender, EventArgs e)
        {
            HidePanels();
            MainListView.Clear();
            RestrictAllLabels();
            //getLatestID();
            switch (State_of_Form)
            {
                case 0:

                    break;

                case 1:
                    RoomPanel.Show();
                    MainListView.Columns.Insert(0, "RoomID", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(1, "Price", 120, HorizontalAlignment.Left);
                    break;

                case 2:
                    ReservationPanel.Show();
                    MainListView.Columns.Insert(0, "ReservationID", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(1, "Client", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(2, "Room", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(3, "Total", 120, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(4, "DaysOfStay", 120, HorizontalAlignment.Left);
                    break;
            }
            //getLatestID();
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
            dateTimePicker1.Enabled = true;
        }

        private void EnableRoom()
        {
            RoomIDTextbox.Enabled = false;
            PriceTextbox.Enabled = true;
        }

        private void EnableReservation()
        {
            ReservationIDTextbox.Enabled = false;
            GuestTextbox.Enabled = true;
            RoomTextbox.Enabled = true;
            TotalTextbox.Enabled = true;
            DaystextBox.Enabled = true;
        }

        private void RestrictAllLabels()
        {
            ClientTextbox.Enabled = false;
            NameTextbox.Enabled = false;
            AddressTextbox.Enabled = false;
            AreaTextbox.Enabled = false;
            TownTextbox.Enabled = false;
            PostalCodeTextbox.Enabled = false;
            dateTimePicker1.Enabled = false;

            RoomIDTextbox.Enabled = false;
            PriceTextbox.Enabled = false;

            ReservationIDTextbox.Enabled = false;
            GuestTextbox.Enabled = false;
            DaystextBox.Enabled = false;
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
                item.SubItems.Add(client.getBooking.ToString());

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
                client.getBooking = DateTime.Parse(dateTimePicker1.Text);
            }
            catch { MessageBox.Show("Something went wrong populating client, please ensure all fields are filled."); }
            return client;
        }

        private void ClientSubmit_Click_1(object sender, EventArgs e)
        {
            if (addRadioGroup.Checked)
            {
                if (ValidateClientFields())
                {
                    client = PopulateClientObject();
                    clientsController.DataMaintenance(client, DB.DBOperation.Add);
                    clientsController.FinalizeChanges(client);
                    setUpMainListView();
                }
                else
                {
                    MessageBox.Show("Invalid client. Please check highlighted field(s).");
                }


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

        }

        private void ClientSubmit_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Room methods
        private void RoomSubmit_Click_1(object sender, EventArgs e)
        {
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
        #endregion

        #region Reservation methods
        private void ReservationSubmit_Click(object sender, EventArgs e)
        {
          

            if (addRadioGroup.Checked)
            {
                if (ValidateReservationFields())
                {
                    reservation = PopulateReservationObject();
                    reservationController.DataMaintenance(reservation, DB.DBOperation.Add);
                    reservationController.FinalizeChanges(reservation);
                    setUpMainListView();
                }
                else
                {
                    MessageBox.Show("Invalid Reservation. Please check highlighted field(s).");
                }
                

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
            getLatestID();
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
            ClearClient();
            UnselectedRadioButtons();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ClearReservation();
            UnselectedRadioButtons();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClearRoom();
            UnselectedRadioButtons();
        }

        private void addRadioGroup_CheckedChanged(object sender, EventArgs e)
        {
            getLatestID();
            switch (State_of_Form)
            {
                case 0:
                    ; ClearClient();
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
                    dateTimePicker1.Enabled = true;
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
        #endregion

        #region Utility Methods
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
            reservation.Room = RoomTextbox.Text ;
            reservation.Total = Double.Parse(TotalTextbox.Text);
            reservation.Days =int.Parse(DaystextBox.Text);


             }
            catch { MessageBox.Show("Something went wrong"); }
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
            dateTimePicker1.Text = "";

            //  reset the background colors to the default 
            NameTextbox.BackColor = System.Drawing.SystemColors.Window;
            AddressTextbox.BackColor = System.Drawing.SystemColors.Window;
            AreaTextbox.BackColor = System.Drawing.SystemColors.Window;
            TownTextbox.BackColor = System.Drawing.SystemColors.Window;
            PostalCodeTextbox.BackColor = System.Drawing.SystemColors.Window;
            dateTimePicker1.BackColor = System.Drawing.SystemColors.Window;

        }
        private void PopulateClientTB(Client client)
        {
            ClientTextbox.Text = client.getID;
            NameTextbox.Text = client.getName;
            AddressTextbox.Text = client.getStreetAddress;
            AreaTextbox.Text = client.getArea;
            TownTextbox.Text = client.getTown;
            PostalCodeTextbox.Text = client.getPostal_code;
            try
            {
                dateTimePicker1.Text = client.getBooking.ToString();
            }
            catch { }
            dateTimePicker1.Text = dateTimePicker1.MinDate.ToString();
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
            RoomTextbox.Text = "";
            DaystextBox.Text = "";
            TotalTextbox.Text = "";

            //  reset the background colors to the default 
            ReservationIDTextbox.BackColor = System.Drawing.SystemColors.Window;
            GuestTextbox.BackColor = System.Drawing.SystemColors.Window;
            RoomTextbox.BackColor = System.Drawing.SystemColors.Window;
            DaystextBox.BackColor = System.Drawing.SystemColors.Window;
            TotalTextbox.BackColor = System.Drawing.SystemColors.Window;
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
            RoomTextbox.Text = reservation.Room.ToString();
            TotalTextbox.Text = reservation.Total.ToString();
            DaystextBox.Text = reservation.Days.ToString();
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
                    MainListView.Columns.Insert(0, "ClientID", 30, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(1, "Name", 100, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(2, "Address", 150, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(3, "Area", 50, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(4, "Town", 50, HorizontalAlignment.Left);
                    MainListView.Columns.Insert(5, "Postal Code", 60, HorizontalAlignment.Left);
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
                    MainListView.Columns.Insert(4, "DaysOfStay", 120, HorizontalAlignment.Left);

                    Reservations = null;
                    Reservations = reservationController.AllReservations;
                    foreach (Reservation Reservation in Reservations)
                    {
                        reservationDetails = new ListViewItem();
                        reservationDetails.Text = Reservation.ReservationID;
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

        #region Validation


        private bool ValidateClientFields()
        {
            bool valid = true;
            // You can reset the background color to its default by setting it to 'SystemColors.Window'
            // textBox1.BackColor = System.Drawing.SystemColors.Window;

            if (string.IsNullOrEmpty(NameTextbox.Text) || (!(NameTextbox.Text).All(char.IsLetter)) || (!(NameTextbox.Text).All(char.IsWhiteSpace)))
            {
                MessageBox.Show("Please enter a valid Name.");
                NameTextbox.BackColor = System.Drawing.Color.Red;
                valid = false;
            }


            if (string.IsNullOrEmpty(AddressTextbox.Text) || (!(AddressTextbox.Text).All(char.IsLetterOrDigit)) || (!(AddressTextbox.Text).All(char.IsWhiteSpace)))
            {
                MessageBox.Show("Please enter a valid address.");
                AddressTextbox.BackColor = System.Drawing.Color.Red;
                valid = false;
            }

            if (string.IsNullOrEmpty(AreaTextbox.Text) || (!(AreaTextbox.Text).All(char.IsLetterOrDigit)) || (!(AreaTextbox.Text).All(char.IsWhiteSpace)))
            {
                MessageBox.Show("Please enter a valid area.");
                AreaTextbox.BackColor = System.Drawing.Color.Red;
                valid = false;
            }

            if (string.IsNullOrEmpty(TownTextbox.Text) || (!(TownTextbox.Text).All(char.IsLetter)) || (!(TownTextbox.Text).All(char.IsWhiteSpace)))
            {
                MessageBox.Show("Please enter a valid town.");
                TownTextbox.BackColor = System.Drawing.Color.Red;
                valid = false;
            }

            if (string.IsNullOrEmpty(PostalCodeTextbox.Text) || (!(PostalCodeTextbox.Text).All(char.IsDigit)))
            {
                MessageBox.Show("Please enter a valid postal code.");
                PostalCodeTextbox.BackColor = System.Drawing.Color.Red;
                valid = false;
            }

            DateTime selectedDate = dateTimePicker1.Value;

            DateTime startDate = new DateTime(2023, 12, 1);
            DateTime endDate = new DateTime(2023, 12, 31);

            if (!(selectedDate >= startDate && selectedDate <= endDate))
            {
                MessageBox.Show("Please select a date between December 1, 2023, and December 31, 2023.");
                dateTimePicker1.BackColor = System.Drawing.Color.Red;
                valid = false;
            }
           

            return valid; // All fields are valid
        }


        private bool ValidateReservationFields()
        {
            bool valid = true;
            // You can reset the background color to its default by setting it to 'SystemColors.Window'
            // textBox1.BackColor = System.Drawing.SystemColors.Window;

            if (string.IsNullOrEmpty(GuestTextbox.Text) || (!(GuestTextbox.Text).All(char.IsDigit)))
            {
                MessageBox.Show("Please enter a valid Guest.");
                GuestTextbox.BackColor = System.Drawing.Color.Red;
                valid = false;
            }


            if (string.IsNullOrEmpty(DaystextBox.Text) || (!(DaystextBox.Text).All(char.IsDigit)))
            {
                MessageBox.Show("Please enter a valid number of days of stay.");
                DaystextBox.BackColor = System.Drawing.Color.Red;
                valid = false;
            }

            int room = int.Parse(RoomTextbox.Text);

            if (string.IsNullOrEmpty(RoomTextbox.Text) || (!(RoomTextbox.Text).All(char.IsDigit)) || (!(room>=1 && room <=5)))
            {
                MessageBox.Show("Please enter a valid Room.");
                RoomTextbox.BackColor = System.Drawing.Color.Red;
                valid = false;
            }

            return valid; // All fields are valid
        }


        #endregion

        #region Unimplemented/Random
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

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

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ClientPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label9_Click(object sender, EventArgs e)
        {

        }

        #endregion


    }
}