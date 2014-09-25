using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace WeixinPrinter
{
    /// <summary>
    /// 打印纸张大小：A7纸，长105，宽74
    /// </summary>
    class PrintService
    {

        WxPrinter myWxPrinter;
        string printPath = "";

        int MARGIN_LEFT = 0;
        int MARGIN_RIGHT = 0;
        int MARGIN_TOP = 0;
        int MARGIN_BOTTOM = 0;

        public PrintService(WxPrinter wxPrinter)
        {
            myWxPrinter = wxPrinter;
        }

        public void printImage(string imgPath)
        {
            printPath = imgPath;
            PrintDocument printDocument = new PrintDocument();
            printDocument.DocumentName = "WHY微信打印机";//设置完后可在打印对话框及队列中显示（默认显示document）

            PrintController printController = new StandardPrintController();
            printDocument.PrintController = printController;
            printDocument.DefaultPageSettings.PaperSize = new PaperSize("L 88X125mm", 330, 460);
            printDocument.DefaultPageSettings.Margins = new Margins(MARGIN_LEFT, MARGIN_RIGHT, MARGIN_TOP, MARGIN_BOTTOM);
            //打印开始前
            printDocument.BeginPrint += new PrintEventHandler(printDocument_BeginPrint);
            //打印输出（过程）
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            //打印结束
            printDocument.EndPrint += new PrintEventHandler(printDocument_EndPrint);

            try
            {
                printDocument.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void printDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            //也可以把一些打印的参数放在此处设置
            Console.WriteLine("开始打印！");
        }

        public void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Console.WriteLine("打印中！");
            Image img = Image.FromFile(printPath);
            Console.WriteLine("MarginBounds" + e.MarginBounds);
            Console.WriteLine("img" + img.Width + "+++++" + img.Height);


            //在图片中打印的矩形区域
            int oldX = e.MarginBounds.X;
            int oldY = e.MarginBounds.Y;
            int oldWidth = e.MarginBounds.Width;
            int oldHeight = e.MarginBounds.Height;
            int newX = e.MarginBounds.X;
            int newY = e.MarginBounds.Y;
            int newWidth = oldWidth;
            int newHeight = oldHeight;

            //理论的打印高度
            int tempHeight = oldWidth * img.Height / img.Width;

            //如果理论打印高度大于纸张的高度，也就是照片偏窄
            if (tempHeight > oldHeight)
            {
                newHeight = oldHeight;
                newWidth = newHeight * img.Width / img.Height;
                newX = oldX + (oldWidth - newWidth) / 2;
                newY = oldY;
            }

            //如果理论打印高度小于纸张的高度，也就是照片偏宽
            else
            {
                newWidth = oldWidth;
                newHeight = oldWidth * img.Height / img.Width;
                newY = oldY + (oldHeight - newHeight) / 2;
                newX = oldX;
            }


            Console.WriteLine("======================================");
            Console.WriteLine(e.MarginBounds);
            Console.WriteLine(newX + " - " + newY + " - " + newWidth + " - " + newHeight);
            Console.WriteLine("======================================");

            


            //将图像缩放到屏幕中心的位置
            e.Graphics.DrawImage(img, new Rectangle(newX, newY, newWidth, newHeight), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
            
            img.Dispose();

        }

        public void printDocument_EndPrint(object sender, PrintEventArgs e)
        {
            //打印结束后相关操作
            Console.WriteLine("打印结束！");
            myWxPrinter.endPrint();
        }
    }
}
