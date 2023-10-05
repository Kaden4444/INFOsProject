using INFOsProject.Business;
using INFOsProject.Properties;
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
        #region Data fields
        private ClientsController cCont;
        private RoomController rCont;
        private ReservationController resCont;
        #endregion

        #region Constructor
        public Dash()
        {
            InitializeComponent();
            cCont = new ClientsController();
            rCont = new RoomController();
            resCont = new ReservationController();
        }
        #endregion

        #region Events
        private void Dash_Load(object sender, EventArgs e)
        {
            ActiveControl = null;
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelDateTime.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss ");
        }


        #endregion

        #region ButtonClicks
        private void button1_Click(object sender, EventArgs e)
        {
            MainUI ClientUI = new MainUI(this, 0, cCont, rCont, resCont);
            ClientUI.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainUI ReservationsUI = new MainUI(this, 1, cCont, rCont, resCont);
            ReservationsUI.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainUI RoomsUI = new MainUI(this, 2, cCont, rCont, resCont);
            RoomsUI.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }



        private void button3_Click_1(object sender, EventArgs e)
        {
            MainUI ReservationsUI = new MainUI(this, 2, cCont, rCont, resCont);
            ReservationsUI.Show();
            this.Hide();
        }

        

        private void button2_Click_1(object sender, EventArgs e)
        {

            MainUI RoomsUI = new MainUI(this, 1, cCont, rCont, resCont);
            RoomsUI.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MainUI ClientUI = new MainUI(this, 0, cCont, rCont, resCont);
            ClientUI.Show();
            this.Hide();
        }
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Unimplemented / Random
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

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

        #endregion
    }
}
