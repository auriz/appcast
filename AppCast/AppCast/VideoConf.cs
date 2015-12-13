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
using System.IO;
using System.ServiceModel;
using AppCast.VideoServiceReference;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace AppCast
{
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class VideoConf : MetroForm, IVideoConferenceServiceCallback
    {
        VideoServiceReference.VideoConferenceServiceClient video;
        bool webcam = false;
        public VideoConf()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            video = new VideoServiceReference.VideoConferenceServiceClient(new InstanceContext(this), "NetTcpBinding_IVideoConferenceService");
            video.Subscribe();
            video.PublishText(Environment.UserName + " Has Join The Room");
        }

        #region WebCam API
        const short WM_CAP = 1024;
        const int WM_CAP_DRIVER_CONNECT = WM_CAP + 10;
        const int WM_CAP_DRIVER_DISCONNECT = WM_CAP + 11;
        const int WM_CAP_EDIT_COPY = WM_CAP + 30;
        const int WM_CAP_SET_PREVIEW = WM_CAP + 50;
        const int WM_CAP_SET_PREVIEWRATE = WM_CAP + 52;
        const int WM_CAP_SET_SCALE = WM_CAP + 53;
        const int WS_CHILD = 1073741824;
        const int WS_VISIBLE = 268435456;
        const short SWP_NOMOVE = 2;
        const short SWP_NOSIZE = 1;
        const short SWP_NOZORDER = 4;
        const short HWND_BOTTOM = 1;
        int iDevice = 0;
        int hHwnd;
        [System.Runtime.InteropServices.DllImport("user32", EntryPoint = "SendMessageA")]
        static extern int SendMessage(int hwnd, int wMsg, int wParam, [MarshalAs(UnmanagedType.AsAny)] 
			object lParam);
        [System.Runtime.InteropServices.DllImport("user32", EntryPoint = "SetWindowPos")]
        static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);
        [System.Runtime.InteropServices.DllImport("user32")]
        static extern bool DestroyWindow(int hndw);
        [System.Runtime.InteropServices.DllImport("avicap32.dll")]
        static extern int capCreateCaptureWindowA(string lpszWindowName, int dwStyle, int x, int y, int nWidth, short nHeight, int hWndParent, int nID);
        [System.Runtime.InteropServices.DllImport("avicap32.dll")]
        static extern bool capGetDriverDescriptionA(short wDriver, string lpszName, int cbName, string lpszVer, int cbVer);
        private void OpenPreviewWindow()
        {
            int iHeight = pictureBox1.Height;
            int iWidth = pictureBox1.Width;
            // 
            //  Open Preview window in picturebox
            // 
            hHwnd = capCreateCaptureWindowA(iDevice.ToString(), (WS_VISIBLE | WS_CHILD), 0, 0, pictureBox1.Image.Width, (short)pictureBox1.Image.Height, pictureBox1.Handle.ToInt32(), 0);
            // 
            //  Connect to device
            // 
            if (SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) == 1)
            {
                // 
                // Set the preview scale
                // 
                SendMessage(hHwnd, WM_CAP_SET_SCALE, 1, 0);
                // 
                // Set the preview rate in milliseconds
                // 
                SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0);
                // 
                // Start previewing the image from the camera
                // 
                SendMessage(hHwnd, WM_CAP_SET_PREVIEW, 1, 0);
                // 
                //  Resize window to fit in picturebox
                // 
                SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, iWidth, iHeight, (SWP_NOMOVE | SWP_NOZORDER));

                webcam = true;
            }
            else
            {
                // 
                //  Error connecting to device close window
                //  
                DestroyWindow(hHwnd);
            }
        }
        private void ClosePreviewWindow()
        {
            // 
            //  Disconnect from device
            // 
            SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0);
            // 
            //  close window
            // 
            DestroyWindow(hHwnd);
        }
        #endregion

        public void OnVideoSend(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            pictureBox2.Image = Image.FromStream(ms);
        }
        public void OnTextSend(string data)
        {
            listBox1.Items.Add(data);
            if (listBox1.Items.Count > 1)
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }
        public void OnVoiceSend(byte[] data)
        {
            // Play the voice
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FramesTimer.Enabled = true;
            button1.Enabled = false;
            button4.Enabled = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            FramesTimer.Enabled = false;
            button4.Enabled = false;
            button1.Enabled = true;
        }
        void SendWebCamFrame()
        {
            MemoryStream ms = new MemoryStream();

            IDataObject data;
            Image bmap;

            //  Copy image to clipboard
            SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0);

            //  Get image from clipboard and convert it to a bitmap
            data = Clipboard.GetDataObject();

            if (data.GetDataPresent(typeof(System.Drawing.Bitmap)))
            {
                bmap = ((Image)(data.GetData(typeof(System.Drawing.Bitmap))));
                bmap.Save(ms, ImageFormat.Jpeg);
            }

            pictureBox1.Image.Save(ms, ImageFormat.Jpeg);

            byte[] buffer = ms.GetBuffer();

            video.PublishVideo(buffer);
        }

        void Publish_Text(string MSG)
        {
            string FullMSG = Environment.UserName + ">> " + MSG;
            video.PublishText(FullMSG);
            textBox1.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Publish_Text(textBox1.Text);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Publish_Text(textBox1.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            iDevice = 0;
            OpenPreviewWindow();
            button3.Enabled = false;
            button1.Enabled = true;
            button5.Enabled = true;
        }

        private void FramesTimer_Tick(object sender, EventArgs e)
        {
            SendWebCamFrame();
        }
    }
}
