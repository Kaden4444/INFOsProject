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
    public partial class Dash : Form
    {
        public Dash()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainUI ClientUI = new MainUI(this, 0);
            ClientUI.Show();
            this.Hide();
        }

        private void Dash_Load(object sender, EventArgs e)
        {
            ActiveControl = null;
            timer1.Start();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainUI ReservationsUI = new MainUI(this, 1);
            ReservationsUI.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainUI RoomsUI = new MainUI(this, 2);
            RoomsUI.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelDateTime.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss ");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MainUI ReservationsUI = new MainUI(this, 2);
            ReservationsUI.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Message");
            Console.WriteLine("Hide!");
            MainUI RoomsUI = new MainUI(this, 1);
            RoomsUI.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MainUI ClientUI = new MainUI(this, 0);
            ClientUI.Show();
            this.Hide();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
