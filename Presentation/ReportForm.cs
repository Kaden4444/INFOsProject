using INFOsProject.Business;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ClientsController cCont;
        RoomController rCont;
        ReservationController resCont;
        public ReportForm(Dash D, int State, ClientsController c, RoomController r, ReservationController res)
        {
            d=D;
            StateOfForm = State;
            InitializeComponent();
            cCont = c;
            rCont = r;
            resCont = res;

            Collection<Client> clients = cCont.AllClients;
            Collection<Room> rooms = rCont.AllRooms;
            Collection<Reservation> reservations = resCont.AllReservations;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                richTextBox1.Text = "Room Occupancy Levels For (DATE HERE):\r\nRooms occupied: 0/5\r\nRooms available: 5/5\r\n\r\nReservations using room occupied:\r\nRoom 1 - Kaden\r\netc etc\r\n\r\n";
            }

            if (comboBox1.SelectedIndex == 1)
            {
                string finaltext = "Report showing weekly incomes throughout December - monthly total included:";
                double weektotal = 0;
                double monthlyTotal = 0;

                string week1 = "\r\nWeekly income for week of Dec 1 - Dec 7:\r\n";
                foreach(Reservation res in resCont.AllReservations)
                {
                    if (res.StartDate >= new DateTime(2023, 12, 1) && res.StartDate <= new DateTime(2023, 12, 7))
                    {
                        week1 += "Reservation ID: " + res.ReservationID + " - R" + res.Total + "\r\n";
                        weektotal += res.Total;
                    }
                }
                week1 += "\r\nWeek Total: " + weektotal.ToString() + "\r\n";
                finaltext += week1;
                monthlyTotal += weektotal;
                weektotal = 0;

                string week2 = "\r\nWeekly income for week of Dec 8 - Dec 15:\r\n";
                foreach (Reservation res in resCont.AllReservations)
                {
                    if (res.StartDate >= new DateTime(2023, 12, 8) && res.StartDate <= new DateTime(2023, 12, 15))
                    {
                        week2 += "Reservation ID: " + res.ReservationID + " - R" + res.Total + "\r\n";
                        weektotal += res.Total;
                    }
                }
                week2 += "\r\nWeek Total: " + weektotal.ToString() + "\r\n";
                finaltext += week2 + "\r\n";
                monthlyTotal += weektotal;
                weektotal = 0;

                string week3 = "\r\nWeekly income for week of Dec 16 - Dec 24:\r\n";
                foreach (Reservation res in resCont.AllReservations)
                {
                    if (res.StartDate >= new DateTime(2023, 12, 16) && res.StartDate <= new DateTime(2023, 12, 24))
                    {
                        week3 += "Reservation ID: " + res.ReservationID + " - R" + res.Total + "\r\n";
                        weektotal += res.Total;
                    }
                }
                week3 += "\r\nWeek Total: " + weektotal.ToString() + "\r\n";
                finaltext += week3 + "\r\n";
                monthlyTotal += weektotal;
                weektotal = 0;

                string week4 = "\r\nWeekly income for week of Dec 25 - Dec 31:\r\n";
                foreach (Reservation res in resCont.AllReservations)
                {
                    if (res.StartDate >= new DateTime(2023, 12, 25) && res.StartDate <= new DateTime(2023, 12, 31))
                    {
                        week4 += "Reservation ID: " + res.ReservationID + " - R" + res.Total + "\r\n";
                        weektotal += res.Total;
                    }
                }
                week4 += "\r\nWeek Total: " + weektotal.ToString() + "\r\n";
                finaltext += week4 + "\r\n";
                monthlyTotal += weektotal;
                weektotal = 0;

                richTextBox1.Text = finaltext + "Monthly Total for December: R" + monthlyTotal.ToString();
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
