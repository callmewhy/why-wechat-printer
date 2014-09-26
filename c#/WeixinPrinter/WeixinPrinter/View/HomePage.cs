using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;


namespace WeixinPrinter
{

    public partial class HomeForm : Form
    {
        // 微信打印机类，负责：打印图片，重置打印码
        WxPrinter wxPrinter;

        public HomeForm()
        {
            InitializeComponent();

            //设置二维码
            setQrCodeImage();

            // 初始化微信打印机
            string uuid = Properties.Settings.Default.uid;
            if (uuid == null || uuid == "")
            {
                uuid = Guid.NewGuid().ToString();
                Properties.Settings.Default.uid = uuid;
                Properties.Settings.Default.Save();
            }

            wxPrinter = new WxPrinter(this,uuid);

            codeLabel.Text = Properties.Settings.Default.print_code;

            //开始监测打印任务
            wxPrinter.startCheckTask();

            CheckForIllegalCrossThreadCalls = false;

            switchToFullScreen();
        }


        //---------- wx_printer api ----------
        //设置左上角的显示的图片
        public void setShowImage(string imgUrl)
        {
            lDetailPictrueBox.ImageLocation = imgUrl;
        }

        //---------- 私有方法 ----------
        // 加载二维码，如果Settings里面没有设置二维码图片的路径，则将资源库中的默认微信二维码加载出来
        private void setQrCodeImage()
        {
            if (Properties.Settings.Default.qrcode_location == "")
            {
                rQRcodePictrueBox.Image = Properties.Resources.qrcode;
            }
            else
            {
                rQRcodePictrueBox.ImageLocation = Properties.Settings.Default.qrcode_location;
            }
        }

        //重置打印码
        public void resetPrintCode()
        {

            wxPrinter.resetPrintCode();
            string print_code = Properties.Settings.Default.print_code;
            //显示打印码
            codeLabel.Text = print_code;
        }


        //---------- 适配 start ----------
        // 切换到正常显示
        private void switchToNomalScreen()
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
            adjustViews();
        }

        // 切换到全屏显示
        private void switchToFullScreen()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            adjustViews();
        }

        // 根据当前窗口自动调整控件位置和大小
        private void adjustViews()
        {
            // 屏幕的宽度和高度
            int formWidth = this.Size.Width;
            int formHeight = this.Size.Height;
            //内部控件距离panel边缘的padding
            int padding = 10;

            //----- 左侧适配 -----//
            // 1.左侧图片展示
            int leftX = padding;
            int leftY = padding;
            int leftWidth = formWidth * 1500 / 1920 - padding * 2;
            int leftHeight = formHeight - padding * 2;
            lDetailPictrueBox.SetBounds(leftX, leftY, leftWidth, leftHeight);

            //----- 右侧适配 -----//
            // 2.1二维码图片，坐标是rPanel的相对坐标
            int qrPicX = formWidth * 1550 / 1920;
            int qrPicY = formHeight * 724 / 1080;
            int qrPicWidth = formWidth * 324 / 1920;
            int qrPicHeight = formHeight * 324 / 1080;
            rQRcodePictrueBox.SetBounds(qrPicX, qrPicY, qrPicWidth, qrPicHeight);
            
            // 2.3打印码，坐标是rPanel的相对坐标
            int printCodeX = formWidth * 1530 / 1920;
            int printCodeY = formHeight * 258 / 1080;
            int printCodeWidth = formWidth * 360 / 1920;
            int printCodeHeight = formHeight * 70 / 1080;
            codeLabel.SetBounds(printCodeX, printCodeY, printCodeWidth, printCodeHeight);
            Font font = new Font("微软雅黑", printCodeHeight / 2);
            codeLabel.Font = font;
        }

        //---------- 监听 start ----------
        // 监听键盘按键
        protected override bool ProcessDialogKey(Keys keyData)
        {
            // 如果按下的是F1，则全屏切换，并自适应控件大小
            if (keyData == Keys.F1)
            {
                // 如果目前是全屏显示，则切换到正常显示
                if (this.WindowState == FormWindowState.Maximized)
                {
                    switchToNomalScreen();
                }
                // 如果目前是正常显示，则切换到全屏显示
                else if (this.WindowState == FormWindowState.Normal)
                {
                    switchToFullScreen();
                }
            }

            return false;
        }

        private void HomeForm_Shown(object sender, EventArgs e)
        {
            adjustViews();
        }

        private void rQRcodePictrueBox_Click(object sender, EventArgs e)
        {
            string filePath; //文件路径  
            string fileName; //文件名称  
            string fileExtension;//文件后缀名  
            string[] strExtension = new string[] { ".gif", ".jpg", ".jpeg", ".png" };
            OpenFileDialog openFileDialog1 = new OpenFileDialog();//实例化一个对象  


            //InitialDirectory 默认打开文件夹的位置  
            openFileDialog1.InitialDirectory = "d:\\";
            //Filter 允许打开文件的格式  显示在Dialg中的Files of Type  
            openFileDialog1.Filter = "All files (*.*)|*.*";
            //显示在Dialg中的Files of Type的选择  
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "请选择二维码图片地址";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //文件路径 和文件名字  
                filePath = openFileDialog1.FileName;
                fileName = Path.GetFileName(filePath);
                // 获取文件后缀  
                fileExtension = Path.GetExtension(filePath);

                if (!strExtension.Contains(fileExtension.ToLower()))//验证读取文件的格式，设置为只能读取以下几种格式的图片  
                {
                    MessageBox.Show("仅打开.gif, .jpeg, .jpg, .png格式的图片！");
                }
                else
                {
                    Properties.Settings.Default.qrcode_location = filePath;
                    Properties.Settings.Default.Save();
                    setQrCodeImage();
                }
            }  
        }

    }
}
