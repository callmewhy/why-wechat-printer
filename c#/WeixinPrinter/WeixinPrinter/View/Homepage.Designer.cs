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
            this.codeLabel = new System.Windows.Forms.Label();
            this.rQRcodePictrueBox = new System.Windows.Forms.PictureBox();
            this.lDetailPictrueBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.rQRcodePictrueBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lDetailPictrueBox)).BeginInit();
            this.SuspendLayout();
            // 
            // codeLabel
            // 
            this.codeLabel.BackColor = System.Drawing.Color.Transparent;
            this.codeLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.codeLabel.ForeColor = System.Drawing.Color.Snow;
            this.codeLabel.Location = new System.Drawing.Point(745, 104);
            this.codeLabel.Margin = new System.Windows.Forms.Padding(0);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(89, 38);
            this.codeLabel.TabIndex = 2;
            this.codeLabel.Text = "2333";
            this.codeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.codeLabel.UseMnemonic = false;
            // 
            // rQRcodePictrueBox
            // 
            this.rQRcodePictrueBox.BackColor = System.Drawing.Color.Transparent;
            this.rQRcodePictrueBox.Image = global::WeixinPrinter.Properties.Resources.qrcode;
            this.rQRcodePictrueBox.Location = new System.Drawing.Point(710, 300);
            this.rQRcodePictrueBox.Name = "rQRcodePictrueBox";
            this.rQRcodePictrueBox.Size = new System.Drawing.Size(150, 150);
            this.rQRcodePictrueBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rQRcodePictrueBox.TabIndex = 6;
            this.rQRcodePictrueBox.TabStop = false;
            this.rQRcodePictrueBox.Click += new System.EventHandler(this.rQRcodePictrueBox_Click);
            // 
            // lDetailPictrueBox
            // 
            this.lDetailPictrueBox.BackColor = System.Drawing.Color.Transparent;
            this.lDetailPictrueBox.Image = ((System.Drawing.Image)(resources.GetObject("lDetailPictrueBox.Image")));
            this.lDetailPictrueBox.Location = new System.Drawing.Point(10, 10);
            this.lDetailPictrueBox.Margin = new System.Windows.Forms.Padding(0);
            this.lDetailPictrueBox.Name = "lDetailPictrueBox";
            this.lDetailPictrueBox.Size = new System.Drawing.Size(671, 443);
            this.lDetailPictrueBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lDetailPictrueBox.TabIndex = 5;
            this.lDetailPictrueBox.TabStop = false;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.lDetailPictrueBox);
            this.Controls.Add(this.rQRcodePictrueBox);
            this.Controls.Add(this.codeLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "微信打印机";
            this.Shown += new System.EventHandler(this.HomeForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.rQRcodePictrueBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lDetailPictrueBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.PictureBox rQRcodePictrueBox;
        private System.Windows.Forms.PictureBox lDetailPictrueBox;
    }
}

