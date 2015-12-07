using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCast
{
    public partial class fileUpload : Form
    {
        public fileUpload()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.AddExtension = true;
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    File.Copy(fileName, "D:\\Desktop\\TempServer\\Uploads\\" + Path.GetFileName(fileName));
                    

                    FtpWebRequest newRequest = (FtpWebRequest)WebRequest.Create("ftp://appcast-backend.cloudapp.net"+"/testingUpload.png");
                    newRequest.Method = WebRequestMethods.Ftp.UploadFile;
                    //newRequest.UsePassive = false;

                    newRequest.Credentials = new NetworkCredential("appcast","@ppcastPW1");

                    Stream ftpStream = newRequest.GetRequestStream();
                    FileStream file = File.OpenRead("D:\\Desktop\\TempServer\\Uploads\\" + Path.GetFileName(fileName));

                    int length = 1024;
                    byte[] buffer = new byte[length];
                    int bytesRead = 0;

                    do
                    {
                        bytesRead = file.Read(buffer, 0, length);
                        ftpStream.Write(buffer, 0, bytesRead);
                    }
                    while(bytesRead !=0);

                    file.Close();
                    ftpStream.Close();

                    lblMsg.Text += Path.GetFileName(fileName) + " has been successfully uploaded.\n";
                    button1.Visible = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient request = new WebClient();
            request.Credentials = new NetworkCredential("appcast", "@ppcastPW1");

            byte[] filedata = request.DownloadData("ftp://appcast-backend.cloudapp.net" + "/testingUpload.png");

            FileStream file = File.Create("D:\\Desktop\\Downloads\\testDownload.png");
            file.Write(filedata, 0, filedata.Length);
            file.Close();
            MessageBox.Show("Download Complete.");
 
 /*           FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://appcast-backend.cloudapp.net" + "/testingUpload.png");
            request.KeepAlive = true;
            request.UsePassive = false;
            request.UseBinary = true;

            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential("appcast", "@ppcastPW1");

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            using (StreamWriter destination = new StreamWriter("D:\\Desktop\\Downloads\\testDownload.png"))
            {
                destination.Write(reader.ReadToEnd());
                destination.Flush();
            } 
 */
        }
    }
}
