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
    public partial class ReportForm : Form
    {
        int StateOfForm;
        Dash d;
        public ReportForm(Dash D, int State)
        {
            d=D;
            StateOfForm = State;
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                richTextBox1.Text = "Room Occupancy Levels For (DATE HERE):\r\nRooms occupied: 0/5\r\nRooms available: 5/5\r\n\r\nReservations using room occupied:\r\nRoom 1 - Kaden\r\netc etc\r\n\r\n";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                richTextBox1.Text = "Weekly income for week of (Start date - Start date = 7):\r\nTOTAL\r\n\r\nComing from:\r\nReservation 0 - R200\r\nReservation 2 - R1000\r\n";
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StateOfForm = -1;
            d.Show();
            this.Hide();
        }
    }
}
