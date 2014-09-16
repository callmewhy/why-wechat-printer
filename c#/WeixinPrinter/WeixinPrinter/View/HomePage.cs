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

            rPrintCodeLabel.Text = Properties.Settings.Default.print_code;

            //开始监测打印任务
            wxPrinter.startCheckTask();

            CheckForIllegalCrossThreadCalls = false;
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
            rPrintCodeLabel.Text = print_code;
        }


        //---------- 适配 start ----------
        // 切换到全屏显示
        private void switchToNomalScreen()
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
            adjustViews();
        }

        // 切换到正常显示
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
            int leftX = 0;
            int leftY = 0;
            int leftWidth = formHeight * 7 / 5;
            int leftHeight = formHeight;
            lPanel.SetBounds(leftX, leftY, leftWidth, leftHeight);

            // 1.1左侧展示图片，坐标是lPanel的相对坐标
            int leftPicX = padding;
            int leftPicY = padding;
            int leftPicWidth = leftWidth - padding * 2;
            int leftPicHeight = leftHeight - padding * 2;
            lDetailPictrueBox.SetBounds(leftPicX, leftPicY, leftPicWidth, leftPicHeight);


            //----- 右侧适配 -----//
            // 2.右侧Panel
            int rightX = leftWidth;
            int rightY = leftY;
            int rightWidth = formWidth - leftWidth;
            int rightHeight = formHeight;
            rPanel.SetBounds(rightX, rightY, rightWidth, rightHeight);


            // 2.1二维码图片，坐标是rPanel的相对坐标
            int qrPicX = padding;
            int qrPicY = padding;
            int qrPicWidth = rightWidth - padding * 2;
            int qrPicHeight = qrPicWidth;
            rQRcodePictrueBox.SetBounds(qrPicX, qrPicY, qrPicWidth, qrPicHeight);
            
            // 2.2右下角的背景图片，上面是文字的内容，坐标是rPanel的相对坐标
            int introPictureX = padding;
            int introPictureY = qrPicY + qrPicHeight + padding;
            int introPictureWidth = qrPicWidth;
            int introPictureHeight = formHeight - padding - introPictureY;
            rIntroPicture.SetBounds(introPictureX, introPictureY, introPictureWidth, introPictureHeight);

            // 2.3打印码，坐标是rPanel的相对坐标
            int printCodeX = padding;
            int printCodeY = introPictureY + introPictureHeight / 7 + padding;
            int printCodeWidth = qrPicWidth;
            int printCodeHeight = introPictureY / 5;
            rPrintCodeLabel.SetBounds(printCodeX, printCodeY, printCodeWidth, printCodeHeight);

           
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

    }
}
