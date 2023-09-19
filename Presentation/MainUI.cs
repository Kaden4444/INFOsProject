using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
