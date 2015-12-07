using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace AppCast
{
    public partial class PopupForm : MetroForm
    {
        public MetroForm form;
        public PopupForm(MetroForm pForm)
        {
            InitializeComponent();
            form = pForm;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            form.Enabled = true;
            this.Dispose();
        }
    }
}
