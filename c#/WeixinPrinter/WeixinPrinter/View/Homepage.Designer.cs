namespace WeixinPrinter
{
    partial class HomeForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.lDetailPictrueBox = new System.Windows.Forms.PictureBox();
            this.rPanel = new System.Windows.Forms.Panel();
            this.rPrintCodeLabel = new System.Windows.Forms.Label();
            this.rQRcodePictrueBox = new System.Windows.Forms.PictureBox();
            this.rIntroPicture = new System.Windows.Forms.PictureBox();
            this.lPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.lDetailPictrueBox)).BeginInit();
            this.rPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rQRcodePictrueBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rIntroPicture)).BeginInit();
            this.lPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lDetailPictrueBox
            // 
            this.lDetailPictrueBox.Image = ((System.Drawing.Image)(resources.GetObject("lDetailPictrueBox.Image")));
            this.lDetailPictrueBox.Location = new System.Drawing.Point(55, 52);
            this.lDetailPictrueBox.Margin = new System.Windows.Forms.Padding(0);
            this.lDetailPictrueBox.Name = "lDetailPictrueBox";
            this.lDetailPictrueBox.Size = new System.Drawing.Size(583, 343);
            this.lDetailPictrueBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lDetailPictrueBox.TabIndex = 0;
            this.lDetailPictrueBox.TabStop = false;
            // 
            // rPanel
            // 
            this.rPanel.BackColor = System.Drawing.Color.Transparent;
            this.rPanel.Controls.Add(this.rPrintCodeLabel);
            this.rPanel.Controls.Add(this.rQRcodePictrueBox);
            this.rPanel.Controls.Add(this.rIntroPicture);
            this.rPanel.Location = new System.Drawing.Point(716, 0);
            this.rPanel.Margin = new System.Windows.Forms.Padding(0);
            this.rPanel.Name = "rPanel";
            this.rPanel.Size = new System.Drawing.Size(168, 450);
            this.rPanel.TabIndex = 2;
            // 
            // rPrintCodeLabel
            // 
            this.rPrintCodeLabel.BackColor = System.Drawing.Color.Transparent;
            this.rPrintCodeLabel.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rPrintCodeLabel.Location = new System.Drawing.Point(15, 225);
            this.rPrintCodeLabel.Margin = new System.Windows.Forms.Padding(0);
            this.rPrintCodeLabel.Name = "rPrintCodeLabel";
            this.rPrintCodeLabel.Size = new System.Drawing.Size(150, 30);
            this.rPrintCodeLabel.TabIndex = 2;
            this.rPrintCodeLabel.Text = "2333";
            this.rPrintCodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rPrintCodeLabel.UseMnemonic = false;
            // 
            // rQRcodePictrueBox
            // 
            this.rQRcodePictrueBox.Location = new System.Drawing.Point(20, 10);
            this.rQRcodePictrueBox.Margin = new System.Windows.Forms.Padding(0);
            this.rQRcodePictrueBox.Name = "rQRcodePictrueBox";
            this.rQRcodePictrueBox.Size = new System.Drawing.Size(130, 130);
            this.rQRcodePictrueBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rQRcodePictrueBox.TabIndex = 0;
            this.rQRcodePictrueBox.TabStop = false;
            // 
            // rIntroPicture
            // 
            this.rIntroPicture.Image = ((System.Drawing.Image)(resources.GetObject("rIntroPicture.Image")));
            this.rIntroPicture.Location = new System.Drawing.Point(20, 150);
            this.rIntroPicture.Name = "rIntroPicture";
            this.rIntroPicture.Size = new System.Drawing.Size(130, 284);
            this.rIntroPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rIntroPicture.TabIndex = 3;
            this.rIntroPicture.TabStop = false;
            // 
            // lPanel
            // 
            this.lPanel.Controls.Add(this.lDetailPictrueBox);
            this.lPanel.Location = new System.Drawing.Point(-1, 0);
            this.lPanel.Name = "lPanel";
            this.lPanel.Size = new System.Drawing.Size(714, 465);
            this.lPanel.TabIndex = 3;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WeixinPrinter.Properties.Resources.retina_wood;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.lPanel);
            this.Controls.Add(this.rPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "微信打印机";
            this.Shown += new System.EventHandler(this.HomeForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.lDetailPictrueBox)).EndInit();
            this.rPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rQRcodePictrueBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rIntroPicture)).EndInit();
            this.lPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox lDetailPictrueBox;
        private System.Windows.Forms.Panel rPanel;
        private System.Windows.Forms.PictureBox rQRcodePictrueBox;
        private System.Windows.Forms.Label rPrintCodeLabel;
        private System.Windows.Forms.Panel lPanel;
        private System.Windows.Forms.PictureBox rIntroPicture;
    }
}

