using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INFOsProject.Presentation;

namespace INFOsProject
{
    public partial class LoginForm : Form
    {
        LoginForm loginForm;
        public LoginForm()
        {
            InitializeComponent();
            loginForm = this;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // Make sure details are right
            Console.WriteLine("I am working");
            Dash Dash  = new Dash();
           
            Dash.Show();
            this.Hide();
            Console.WriteLine("I am done");
        }
    }
}
