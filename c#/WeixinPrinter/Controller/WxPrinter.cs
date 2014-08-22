using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeixinPrinter
{
    /// <summary>
    /// 控制器，微信打印机的封装类，处理逻辑，例如HTTP访问，打印照片等等
    /// </summary>
    class WxPrinter
    {
        public static string API_URL = "http://wxprinter.sinaapp.com/pcapi/";
        public static string RESET_PRINTER_CODE_URL = API_URL + "?action=reset_code";
        public static string GET_TASK_IMAGE_URL = API_URL + "?action=get_task";

        public bool isPrinting = false; //目前打印机的状态，是否在打印
        HomeForm myHomeForm;            //主页面
        ImageTool myImageTool;          //图片加载的工具包
        PrintService myPrintServer;       //打印用的工具包

        // WxPrinter的构造方法
        public WxPrinter(HomeForm homeForm)
        {
            myHomeForm = homeForm;
            myPrintServer = new PrintService(this);
            myImageTool = new ImageTool(this);
        }

        //---------- print_server api ----------
        //打印事件结束了
        public void endPrint()
        {
            isPrinting = false;
        }

        //---------- image_tool api ----------
        //监测到了新的照片的处理
        public void rcvdNewImage(string imgUrl)
        {
            isPrinting = true;

            //定义下载的文件名称和路径
            string filePath = System.Windows.Forms.Application.UserAppDataPath+"/down_image.why";
            //1.下载
            ImageTool.DownloadFile(imgUrl,filePath);

            //2.展示
            setShowImage(filePath);

            //3.打印
            myPrintServer.printImage(filePath);
            //4.事后

        }

        //设置主页面的展示图片
        private void setShowImage(string imgUrl)
        {
            myHomeForm.setShowImage(imgUrl);
        }


        //---------- homepage api ----------
        //开始监测打印任务
        public void startCheckTask()
        {
            myImageTool.startCheckTask();//开始监测待打印的照片
        }

        //重置打印码，将原来的print_code设为未用，并选择新的print_code设为已用
        public void resetPrintCode()
        {
            string old_code = getPrintCode();
            string new_code = HttpTool.sendPost(RESET_PRINTER_CODE_URL, "print_code=" + old_code);
            setPrintCode(new_code);
        }
        //获取setting中的print_code
        public string getPrintCode()
        {
            return Properties.Settings.Default.print_code;
        }
        //设置setting中的print_code
        private void setPrintCode(string print_code)
        {
            Properties.Settings.Default.print_code = print_code;
            logLog("print_code=" + print_code);
            Properties.Settings.Default.Save();
        }


        //---------- 测试函数 ----------
        private static void logLog(String logStr)
        {
            Console.WriteLine("-----WHY-----" + logStr);
        }

    }
}
