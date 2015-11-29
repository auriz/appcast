using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCast
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            LoginForm obj1 = new LoginForm();
            obj1.Show();
            this.Close();
        }
    }
}
