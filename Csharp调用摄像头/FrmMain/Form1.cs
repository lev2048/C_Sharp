using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;

namespace FrmMain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //声明变量
        public FilterInfoCollection USE_Webcams = null;
        public VideoCaptureDevice cam = null;

        private void btn_Start_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_Start.Text == "开始")
                {
                    ///--  
                    btn_Start.Text = "停止";
                    ///---启动摄像头  
                    cam.Start();
                }
                else
                {
                    ///--设置按钮提示字样  
                    btn_Start.Text = "开始";
                    ///--停止摄像头捕获图像  
                    cam.Stop();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ///---实例化对象  
                USE_Webcams = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                ///---摄像头数量大于0  
                if (USE_Webcams.Count > 0)
                {
                    ///---禁用按钮  
                    btn_Start.Enabled = true;
                    ///---实例化对象  
                    cam = new VideoCaptureDevice(USE_Webcams[0].MonikerString);
                    ///---绑定事件  
                    cam.NewFrame += new NewFrameEventHandler(Cam_NewFrame);
                }
                else
                {
                    ///--没有摄像头  
                    btn_Start.Enabled = false;
                    ///---提示没有摄像头  
                    MessageBox.Show("没有摄像头外设");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Cam_NewFrame(object obj, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
            ///---throw new NotImplementedException();  
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (cam != null)
                {
                    ///---关闭摄像头  
                    if (cam.IsRunning)
                    {
                        cam.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
   
}
