namespace AppCast
{
    partial class Meeting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbAdd = new System.Windows.Forms.ListBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.lbUsers = new System.Windows.Forms.ListBox();
            this.tbRoomTitle = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.appUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appCastDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appCastDataSet = new AppCast.AppCastDataSet();
            this.roomBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appUserTableAdapter = new AppCast.AppCastDataSetTableAdapters.AppUserTableAdapter();
            this.roomTableAdapter = new AppCast.AppCastDataSetTableAdapters.RoomTableAdapter();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appUserBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appCastDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appCastDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Location = new System.Drawing.Point(23, 74);
            this.metroTabControl1.Name = "metroTabControl1";
            //this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(554, 303);
            this.metroTabControl1.TabIndex = 0;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.listBox2);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(546, 264);
            this.metroTabPage1.TabIndex = 1;
            this.metroTabPage1.Text = "View";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            // 
            // listBox2
            // 
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 29;
            this.listBox2.Location = new System.Drawing.Point(0, 14);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(316, 203);
            this.listBox2.Sorted = true;
            this.listBox2.TabIndex = 7;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.button2);
            this.metroTabPage2.Controls.Add(this.button1);
            this.metroTabPage2.Controls.Add(this.lbAdd);
            this.metroTabPage2.Controls.Add(this.metroButton1);
            this.metroTabPage2.Controls.Add(this.lbUsers);
            this.metroTabPage2.Controls.Add(this.tbRoomTitle);
            this.metroTabPage2.Controls.Add(this.metroLabel2);
            this.metroTabPage2.Controls.Add(this.metroLabel1);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(546, 264);
            this.metroTabPage2.TabIndex = 2;
            this.metroTabPage2.Text = "Create Room";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(267, 112);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(36, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "<<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(267, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = ">>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbAdd
            // 
            this.lbAdd.FormattingEnabled = true;
            this.lbAdd.Location = new System.Drawing.Point(309, 58);
            this.lbAdd.Name = "lbAdd";
            this.lbAdd.Size = new System.Drawing.Size(170, 108);
            this.lbAdd.Sorted = true;
            this.lbAdd.TabIndex = 8;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(103, 186);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.TabIndex = 7;
            this.metroButton1.Text = "Create";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // lbUsers
            // 
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.Location = new System.Drawing.Point(103, 58);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(158, 108);
            this.lbUsers.Sorted = true;
            this.lbUsers.TabIndex = 6;
            // 
            // tbRoomTitle
            // 
            this.tbRoomTitle.Location = new System.Drawing.Point(103, 16);
            this.tbRoomTitle.Name = "tbRoomTitle";
            this.tbRoomTitle.Size = new System.Drawing.Size(316, 23);
            this.tbRoomTitle.TabIndex = 4;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(21, 58);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(77, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Invite Users:";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(21, 16);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(76, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Room Title:";
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.metroButton3);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(546, 264);
            this.metroTabPage3.TabIndex = 3;
            this.metroTabPage3.Text = "Video Conference";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(25, 17);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(75, 23);
            this.metroButton3.TabIndex = 2;
            this.metroButton3.Text = "Start";
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // appUserBindingSource
            // 
            this.appUserBindingSource.DataMember = "AppUser";
            this.appUserBindingSource.DataSource = this.appCastDataSetBindingSource;
            // 
            // appCastDataSetBindingSource
            // 
            this.appCastDataSetBindingSource.DataSource = this.appCastDataSet;
            this.appCastDataSetBindingSource.Position = 0;
            // 
            // appCastDataSet
            // 
            this.appCastDataSet.DataSetName = "AppCastDataSet";
            this.appCastDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // roomBindingSource
            // 
            this.roomBindingSource.DataMember = "Room";
            this.roomBindingSource.DataSource = this.appCastDataSetBindingSource;
            // 
            // appUserTableAdapter
            // 
            this.appUserTableAdapter.ClearBeforeFill = true;
            // 
            // roomTableAdapter
            // 
            this.roomTableAdapter.ClearBeforeFill = true;
            // 
            // Meeting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "Meeting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Meeting";
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.metroTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.appUserBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appCastDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appCastDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private System.Windows.Forms.BindingSource appCastDataSetBindingSource;
        private AppCastDataSet appCastDataSet;
        private System.Windows.Forms.BindingSource appUserBindingSource;
        private AppCastDataSetTableAdapters.AppUserTableAdapter appUserTableAdapter;
        private System.Windows.Forms.BindingSource roomBindingSource;
        private AppCastDataSetTableAdapters.RoomTableAdapter roomTableAdapter;
        private MetroFramework.Controls.MetroTextBox tbRoomTitle;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.ListBox lbUsers;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroButton metroButton3;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lbAdd;
    }
}