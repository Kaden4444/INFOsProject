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
    public partial class MainUI : Form
    {
        Dash d;
        int State_of_Form; // 0 = Client, 1 = Room, 2 = Reservation
        
        public MainUI(Dash dash, int State)
        {
            InitializeComponent();
            d = dash;
            State_of_Form = State;
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

            switch (State_of_Form)
            {
                case 0:

                break;

                case 1:
                    
                break;
                
                case 2:

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
                    ListView.Columns.Insert(0, "ClientID", 120, HorizontalAlignment.Left);
                    ListView.Columns.Insert(1, "Name", 120, HorizontalAlignment.Left);
                    ListView.Columns.Insert(2, "Address", 150, HorizontalAlignment.Left);
                    ListView.Columns.Insert(3, "Area", 100, HorizontalAlignment.Left);
                    ListView.Columns.Insert(3, "Town", 100, HorizontalAlignment.Left);
                    ListView.Columns.Insert(3, "Postal Code", 100, HorizontalAlignment.Left);
                    ListView.Columns.Insert(3, "Reservation", 100, HorizontalAlignment.Left);
                    break;

                case 1:
                    ListView.Columns.Insert(0, "RoomID", 120, HorizontalAlignment.Left);
                    ListView.Columns.Insert(0, "Price", 120, HorizontalAlignment.Left);
                    break;

                case 2:
                    ListView.Columns.Insert(0, "ReservationID", 120, HorizontalAlignment.Left);
                    ListView.Columns.Insert(0, "Guest", 120, HorizontalAlignment.Left);
                    ListView.Columns.Insert(0, "Room", 120, HorizontalAlignment.Left);
                    ListView.Columns.Insert(0, "Total", 120, HorizontalAlignment.Left);
                    break;
            }
            
        }
    }
}
