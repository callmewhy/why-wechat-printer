namespace WeixinPrinter
{
    partial class SettingPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.changeQRBtn = new System.Windows.Forms.Button();
            this.QRPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.QRPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // changeQRBtn
            // 
            this.changeQRBtn.Location = new System.Drawing.Point(246, 125);
            this.changeQRBtn.Name = "changeQRBtn";
            this.changeQRBtn.Size = new System.Drawing.Size(135, 45);
            this.changeQRBtn.TabIndex = 0;
            this.changeQRBtn.Text = "修改二维码的图片";
            this.changeQRBtn.UseVisualStyleBackColor = true;
            // 
            // QRPictureBox
            // 
            this.QRPictureBox.Location = new System.Drawing.Point(32, 34);
            this.QRPictureBox.Name = "QRPictureBox";
            this.QRPictureBox.Size = new System.Drawing.Size(148, 136);
            this.QRPictureBox.TabIndex = 1;
            this.QRPictureBox.TabStop = false;
            // 
            // SettingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 506);
            this.Controls.Add(this.QRPictureBox);
            this.Controls.Add(this.changeQRBtn);
            this.Name = "SettingPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            ((System.ComponentModel.ISupportInitialize)(this.QRPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button changeQRBtn;
        private System.Windows.Forms.PictureBox QRPictureBox;
    }
}