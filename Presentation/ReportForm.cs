using INFOsProject.Business;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
                // Get the selected month and year
                int selectedMonth = new DateTime(2023, 12, 1).Month; 
                int selectedYear = new DateTime(2023, 12, 1).Year; 

                // Calculate the number of days in the selected month
                int daysInMonth = DateTime.DaysInMonth(selectedYear, selectedMonth);

                // Initialize an array to store daily occupancy counts
                int[] dailyOccupancy = new int[daysInMonth];

                // Initialize the occupancy report texts
                string occupancyReport = $"Occupancy Report for {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(selectedMonth)} {selectedYear}:\r\n";
                string max = "Fully booked days: \r\n";
                string min = "Days with no bookings: \r\n";
                // Iterate through each day of the selected month
                for (int day = 1; day <= daysInMonth; day++)
                {
                    // Calculate the date for the current day
                    DateTime currentDate = new DateTime(selectedYear, selectedMonth, day);

                    // Count the number of reservations for the current day
                    int reservationsForDay = resCont.AllReservations.Count(res =>
                        res.StartDate.Date <= currentDate.Date && res.EndDate.Date >= currentDate.Date
                    );

                    // Update the daily occupancy count
                    dailyOccupancy[day - 1] = reservationsForDay;
                   

                    // Add the daily occupancy to the report
                    if (reservationsForDay > 0)
                    {
                        if (reservationsForDay == 1)
                        {
                            occupancyReport += $"{currentDate:dd-MMM-yyyy}: {reservationsForDay} reservation\r\n";
                        }
                        else
                        {
                            occupancyReport += $"{currentDate:dd-MMM-yyyy}: {reservationsForDay} reservations\r\n";
                        }
                       
                    }
                    if(reservationsForDay == 5)
                    {
                        max += $"{currentDate:dd-MMM-yyyy} \r\n";
                    }
                    if (reservationsForDay == 0)
                    {
                        min += $"{currentDate:dd-MMM-yyyy} \r\n";
                    }

                }

                // Display the occupancy report 
                richTextBox1.Text = occupancyReport+"\r\n"+max+"\r\n"+min;

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

        private void ReportForm_Load(object sender, EventArgs e)
        {

        }
    }
}
// richTextBox1.Text = "Room Occupancy Levels For (DATE HERE):\r\nRooms occupied: 0/5\r\nRooms available: 5/5\r\n\r\nReservations using room occupied:\r\nRoom 1 - Kaden\r\netc etc\r\n\r\n";