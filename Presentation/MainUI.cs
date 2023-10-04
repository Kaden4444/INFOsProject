using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace INFOsProject.Presentation
{

    /*
        #region Events
        private void EmployeeListingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            listFormClosed = true;//4.4 Set the Boolean value of listFormClosed to true in the FormClosed event of the form(first create a FormClosed event for the form).

        }
        private void EmployeeListingForm_Load(object sender, EventArgs e)
        {
            employeeListView.View = View.Details;
        }

        private void EmployeeListingForm_Activated(object sender, EventArgs e)
        {
            // 4.3.1 Set the view of the employeeListView to Details view
            employeeListView.View = View.Details;

            // 4.3.2 Call the setUpEmployeeListView method
            setUpEmployeeListView();

            // 4.3.3 Call the ShowAll method to reset the controls
            ShowAll(false, roleValue);
        }
        #endregion

        #region List View
        public void setUpEmployeeListView()
        {
            ListViewItem employeeDetails;   //Declare variables
            HeadWaiter headW;
            Waiter waiter;
            Runner runner;
            //Clear current List View Control
            employeeListView.Clear();
            //Set Up Columns of List View
            employeeListView.Columns.Insert(0, "ID", 120, HorizontalAlignment.Left);
            employeeListView.Columns.Insert(1, "EMPID", 120, HorizontalAlignment.Left);
            employeeListView.Columns.Insert(2, "Name", 150, HorizontalAlignment.Left);
            employeeListView.Columns.Insert(3, "Phone", 100, HorizontalAlignment.Left);
            //TO DO  … do this for the other generic elements
            employees = null;                      //employees collection will be filled by role
            switch (roleValue)                     //  Check which role to add specific headings
            {
                case Role.RoleType.NoRole:
                    // TO DO Get all the employees from the EmployeeController object 
                    // (use the property) and assign to a local employees collection reference
                    employees = employeeController.AllEmployees;
                    listLabel.Text = "Listing of all employees";
                    employeeListView.Columns.Insert(4, "Payment", 100, HorizontalAlignment.Center);
                    break;
                case Role.RoleType.Headwaiter:
                    //Add a FindByRole method to the EmployeeController 
                    employees = employeeController.FindByRole(employeeController.AllEmployees, Role.RoleType.Headwaiter);
                    listLabel.Text = "Listing of all Headwaiters";
                    //Set Up Columns of List View
                    employeeListView.Columns.Insert(4, "Salary", 100, HorizontalAlignment.Center);
                    break;
                //do for the others
                case Role.RoleType.Waiter:
                    //Add a FindByRole method to the EmployeeController 
                    employees = employeeController.FindByRole(employeeController.AllEmployees, Role.RoleType.Waiter);
                    listLabel.Text = "Listing of all Waiters";
                    //Set Up Columns of List View
                    employeeListView.Columns.Insert(4, "Rate", 100, HorizontalAlignment.Center);
                    employeeListView.Columns.Insert(4, "Number of Shifts", 100, HorizontalAlignment.Center);
                    break;
                case Role.RoleType.Runner:
                    //Add a FindByRole method to the EmployeeController 
                    employees = employeeController.FindByRole(employeeController.AllEmployees, Role.RoleType.Runner);
                    listLabel.Text = "Listing of all Runners";
                    //Set Up Columns of List View
                    employeeListView.Columns.Insert(4, "Rate", 100, HorizontalAlignment.Center);
                    employeeListView.Columns.Insert(4, "Number of Shifts", 100, HorizontalAlignment.Center);
                    break;

            }
            //Add employee details to each ListView item 
            foreach (Employee employee in employees)
            {
                employeeDetails = new ListViewItem();
                employeeDetails.Text = employee.ID.ToString();
                // Do the same for EmpID, Name and Phone
                employeeDetails.SubItems.Add(employee.EmployeeID);
                employeeDetails.SubItems.Add(employee.Name);
                employeeDetails.SubItems.Add(employee.Telephone);

                switch (employee.role.getRoleValue)
                {
                    case Role.RoleType.Headwaiter:
                        headW = (HeadWaiter)employee.role;
                        employeeDetails.SubItems.Add(headW.SalaryAmount.ToString());
                        break;
                    case Role.RoleType.Waiter:
                        waiter = (Waiter)employee.role;
                        employeeDetails.SubItems.Add(waiter.getRate.ToString());
                        employeeDetails.SubItems.Add(waiter.getShifts.ToString());
                        break;
                    case Role.RoleType.Runner:
                        runner = (Runner)employee.role;
                        employeeDetails.SubItems.Add(runner.getRate.ToString());
                        employeeDetails.SubItems.Add(runner.getShifts.ToString());
                        break;
                }
                employeeListView.Items.Add(employeeDetails);
            }
            employeeListView.Refresh();
            employeeListView.GridLines = true;
        }


        private void employeeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowAll(true, roleValue);
            state = FormStates.View;
            EnableEntries(false);
            if (employeeListView.SelectedItems.Count > 0)   // if you selected an item 
            {
                employee = employeeController.Find(employeeListView.SelectedItems[0].Text);  //selected student becoms current student
                                                                                             // Show the details of the selected student in the controls
                PopulateTextBoxes(employee);
            }
        }
        #endregion
     */
    public partial class MainUI : Form
    {
        Dash d;
        int State_of_Form; // 0 = Client, 1 = Room, 2 = Reservation
        
        public MainUI(Dash dash, int State)
        {
            InitializeComponent();
            d = dash;
            State_of_Form = State;

            HidePanels();
            listView2.Clear();
            Console.Write("Hi!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            switch (State_of_Form)
            {
                case 0:
                    listView2.Columns.Insert(0, "ClientID", 120, HorizontalAlignment.Left);
                    listView2.Columns.Insert(1, "Name", 120, HorizontalAlignment.Left);
                    listView2.Columns.Insert(2, "Address", 150, HorizontalAlignment.Left);
                    listView2.Columns.Insert(3, "Area", 100, HorizontalAlignment.Left);
                    listView2.Columns.Insert(4, "Town", 100, HorizontalAlignment.Left);
                    listView2.Columns.Insert(5, "Postal Code", 100, HorizontalAlignment.Left);
                    listView2.Columns.Insert(6, "Reservation", 100, HorizontalAlignment.Left);
                    break;

                case 1:
                    listView2.Columns.Insert(0, "RoomID", 120, HorizontalAlignment.Left);
                    listView2.Columns.Insert(1, "Price", 120, HorizontalAlignment.Left);
                    break;

                case 2:
                    listView2.Columns.Insert(0, "ReservationID", 120, HorizontalAlignment.Left);
                    listView2.Columns.Insert(1, "Guest", 120, HorizontalAlignment.Left);
                    listView2.Columns.Insert(2, "Room", 120, HorizontalAlignment.Left);
                    listView2.Columns.Insert(3, "Total", 120, HorizontalAlignment.Left);
                    listView2.Columns.Insert(4, "DaysOfStay", 120, HorizontalAlignment.Left);
                    break;
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
            listView2.Clear();
            Console.Write("Hi!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            switch (State_of_Form)
            {
                case 0:
                    listView2.Columns.Insert(0, "ClientID", 120, HorizontalAlignment.Left);
                    listView2.Columns.Insert(1, "Name", 120, HorizontalAlignment.Left);
                    listView2.Columns.Insert(2, "Address", 150, HorizontalAlignment.Left);
                    listView2.Columns.Insert(3, "Area", 100, HorizontalAlignment.Left);
                    listView2.Columns.Insert(4, "Town", 100, HorizontalAlignment.Left);
                    listView2.Columns.Insert(5, "Postal Code", 100, HorizontalAlignment.Left);
                    listView2.Columns.Insert(6, "Reservation", 100, HorizontalAlignment.Left);
                    break;

                case 1:
                    listView2.Columns.Insert(0, "RoomID", 120, HorizontalAlignment.Left);
                    listView2.Columns.Insert(1, "Price", 120, HorizontalAlignment.Left);
                    break;

                case 2:
                    listView2.Columns.Insert(0, "ReservationID", 120, HorizontalAlignment.Left);
                    listView2.Columns.Insert(1, "Guest", 120, HorizontalAlignment.Left);
                    listView2.Columns.Insert(2, "Room", 120, HorizontalAlignment.Left);
                    listView2.Columns.Insert(3, "Total", 120, HorizontalAlignment.Left);
                    listView2.Columns.Insert(4, "DaysOfStay", 120, HorizontalAlignment.Left);
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
                ClientPanel.Show();
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
                    listView2.Columns.Insert(0, "ClientID", 120, HorizontalAlignment.Left);
                    listView2.Columns.Insert(1, "Name", 120, HorizontalAlignment.Left);
                    listView2.Columns.Insert(2, "Address", 150, HorizontalAlignment.Left);
                    listView2.Columns.Insert(3, "Area", 100, HorizontalAlignment.Left);
                    listView2.Columns.Insert(4, "Town", 100, HorizontalAlignment.Left);
                    listView2.Columns.Insert(5, "Postal Code", 100, HorizontalAlignment.Left);
                    listView2.Columns.Insert(6, "Reservation", 100, HorizontalAlignment.Left);
                    break;

                case 1:
                    listView2.Columns.Insert(0, "RoomID", 120, HorizontalAlignment.Left);
                    listView2.Columns.Insert(1, "Price", 120, HorizontalAlignment.Left);
                    break;

                case 2:
                    listView2.Columns.Insert(0, "ReservationID", 120, HorizontalAlignment.Left);
                    listView2.Columns.Insert(1, "Guest", 120, HorizontalAlignment.Left);
                    listView2.Columns.Insert(2, "Room", 120, HorizontalAlignment.Left);
                    listView2.Columns.Insert(3, "Total", 120, HorizontalAlignment.Left);
                    listView2.Columns.Insert(4, "DaysOfStay", 120, HorizontalAlignment.Left);
                    break;
            }
            
        }

        private void ReservationPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
