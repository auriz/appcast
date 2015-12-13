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
using AppCast.Data;

namespace AppCast
{
    public partial class Meeting : MetroForm
    {
        public Meeting()
        {
            InitializeComponent();
        }

        private void Meeting_Load(object sender, EventArgs e)
        {
            listBox2.DataSource = new MeetingController().getRoom("admin");
            listBox1.DataSource = new MeetingController().getUsers("admin");
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string roomUsers = "";
            foreach (string s in listBox1.SelectedItems)
            {
                roomUsers += "," + s;
            }
            roomUsers = roomUsers.Substring(1);
            if (new MeetingController().createRoom("admin", tbRoomTitle.Text, roomUsers))
            {
                PopupForm success = new PopupForm(this);
                success.Show();
                this.Enabled = false;
                reset();
            }
            else
            {
                
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            VideoConf conf = new VideoConf();
            conf.Show();
            this.Enabled = false;
        }

        private void reset()
        {
            tbRoomTitle.Text = "";
            listBox1.Refresh();
        }
    }
}
