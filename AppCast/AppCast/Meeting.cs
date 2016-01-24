using System;
using System.Collections;
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
using AppCast.Model;

namespace AppCast
{
    public partial class Meeting : MetroForm
    {
        string userid;
        List<AppUser> uList = new List<AppUser>();
        List<AppUser> aList = new List<AppUser>();
        List<Room> myRooms = new List<Room>();
        public Meeting(string userid)
        {
            InitializeComponent();
            this.userid = userid;
            populateRoom(this.userid);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string roomUsers = "";
            foreach (AppUser s in aList)
            {
                roomUsers += "," + s.userID;
            }
            roomUsers = roomUsers.Substring(1);
            if (new MeetingController().createRoom(userid, tbRoomTitle.Text, roomUsers))
            {
                PopupForm success = new PopupForm(this);
                success.Show();
                this.Enabled = false;
                populateRoom(userid);
                reset();
            }
            else
            {
                
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            //VideoConf conf = new VideoConf();
            //conf.Show();

            ChatRoom chat = new ChatRoom(userid, 1);
            chat.Show();
        }

        private void reset()
        {
            tbRoomTitle.Text = "";
                      
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            //lbAdd.Items.Add(lbUsers.SelectedItems);
            //lbUsers.Items.Remove(lbUsers.SelectedItems);
            aList.Add((AppUser)lbUsers.SelectedItem);
            uList.Remove((AppUser)lbUsers.SelectedItem);
            lbAdd.DataSource = null;
            lbAdd.DataSource = aList;
            lbAdd.ValueMember = "userid";
            lbAdd.DisplayMember = "name";
            lbUsers.DataSource = null;
            lbUsers.DataSource = uList;
            lbUsers.ValueMember = "userid";
            lbUsers.DisplayMember = "name";

            lbAdd.SetSelected(aList.Count - 1, true);
            if (uList.Count != 0)
                lbUsers.SetSelected(uList.Count - 1, true);

            if (uList.Count == 0)
                button1.Enabled = false;
            if (aList.Count != 0)
                button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //lbUsers.Items.Add(lbAdd.SelectedItems);
            //lbAdd.Items.Remove(lbAdd.SelectedItems);
            uList.Add((AppUser)lbAdd.SelectedItem);
            aList.Remove((AppUser)lbAdd.SelectedItem);
            lbAdd.DataSource = null;
            lbAdd.DataSource = aList;
            lbAdd.ValueMember = "userid";
            lbAdd.DisplayMember = "name";
            lbUsers.DataSource = null;
            lbUsers.DataSource = uList;
            lbUsers.ValueMember = "userid";
            lbUsers.DisplayMember = "name";

            lbUsers.SetSelected(uList.Count - 1, true);
            if (aList.Count != 0)
                lbAdd.SetSelected(aList.Count - 1, true);

            if (aList.Count == 0)
                button2.Enabled = false;
            if (uList.Count != 0)
                button1.Enabled = true;
        }
        private void listBox2_DoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox2.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                //ManageRoom manageRoom = new ManageRoom(Convert.ToInt32(listBox2.SelectedValue), ((Room)listBox2.SelectedItem).roomTitle);
                //manageRoom.Show();
                ChatRoom chat = new ChatRoom(userid, Convert.ToInt32(((Room)listBox2.SelectedItem).roomID));
                chat.Text = ((Room)listBox2.SelectedItem).roomTitle;
                chat.Show();
            }
        }

        public void populateRoom(string userid)
        {
            myRooms = new MeetingController().getRoom(userid);
            List<string> rList = new List<string>();
            foreach (Room r in myRooms)
            {
                rList.Add(r.roomTitle);
            }
            listBox2.DataSource = myRooms;
            listBox2.DisplayMember = "roomTitle";
            listBox2.ValueMember = "roomID";
            listBox2.MouseDoubleClick += new MouseEventHandler(listBox2_DoubleClick);
            
            uList = new MeetingController().getUsers(userid);
            lbUsers.DataSource = uList;
            lbUsers.ValueMember = "userid";
            lbUsers.DisplayMember = "name";
        }
    }
}
