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
            ClientsUI ClientForm = new ClientsUI(this);

            ClientForm.Show();
            this.Hide();
        }

        private void Dash_Load(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
