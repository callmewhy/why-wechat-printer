using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;

namespace WeixinPrinter
{
    /// <summary>
    /// 不断监测服务器，获取最新打印任务
    /// </summary>
    class ImageTool
    {
        //持有的HomeForm的引用
        WxPrinter myWxPrinter;

        //监测图片加载的worker
        private BackgroundWorker checkImageWorker;

        //监测图片的间隔，单位为毫秒
        private int check_time = 500;

        //构造方法，持有HomeForm的引用
        public ImageTool(WxPrinter wxPrinter)
        {
            myWxPrinter = wxPrinter;
            checkImageWorker = new System.ComponentModel.BackgroundWorker();
            checkImageWorker.DoWork += new DoWorkEventHandler(checkImageWorker_DoWork);
        }

        //---------- wx_printer api ----------
        //开始监测服务器
        public void startCheckTask()
        {
            checkImageWorker.RunWorkerAsync(); 
        }

        //---------- 私有方法 ----------
        void checkImageWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                //如果打印机的状态为可打印
                if (!myWxPrinter.isPrinting)
                {
                    try
                    {
                        // 获取需要打印的照片的地址
                        string taskUrl = getTaskUrl();
                        logLog("taskUrl = " + taskUrl);

                        //如果监测到了新的任务，通知控制器
                        if (taskUrl != "")
                        {
                            myWxPrinter.rcvdNewImage(taskUrl);
                        }
                    }
                    catch (Exception ex)
                    {
                        logLog("get image url but --error-- "+ex);
                    }
                }
                //休息一段时间继续监测
                Thread.Sleep(check_time);
            }
        }

        //获取需要打印的照片的URL
        private string getTaskUrl()
        {
            string newTaskUrl = HttpTool.sendPost(WxPrinter.GET_TASK_IMAGE_URL, "print_code=" + Properties.Settings.Default.print_code);
            return newTaskUrl;
        }



        //---------- 一些静态方法 ----------

        // 下载文件到指定的路径
        public static void DownloadFile(string URL, string filename)
        {
            try
            {
                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                long totalBytes = myrp.ContentLength;
                System.IO.Stream st = myrp.GetResponseStream();
                System.IO.Stream so = new System.IO.FileStream(filename, System.IO.FileMode.Create);
                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    System.Windows.Forms.Application.DoEvents();
                    so.Write(by, 0, osize);
                    osize = st.Read(by, 0, (int)by.Length);
                }
                so.Close();
                st.Close();
            }
            catch (Exception ex)
            {
                logLog(ex.ToString());
            }
        }


        //---------- 测试函数 ----------
        public static void logLog(String logStr)
        {
            Console.WriteLine("\n-----"+DateTime.Now+"-----\n" + logStr + "\n-----WHY-----\n");
        }


    
    }
}
