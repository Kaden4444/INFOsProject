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

        
        public MainUI(Dash dash, selection)
        {
            InitializeComponent();
            d = dash;
            this.selection
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            d.Show();
            this.Hide();
        }

        private void ClientsUI_Load(object sender, EventArgs e)
        {

        }
    }
}
