namespace SiVine
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.CamImageBox = new Emgu.CV.UI.ImageBox();
            this.btn_stream = new System.Windows.Forms.Button();
            this.btn_takePicture = new System.Windows.Forms.Button();
            this.btn_recognized = new System.Windows.Forms.Button();
            this.imageCapturate = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.CamImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCapturate)).BeginInit();
            this.SuspendLayout();
            // 
            // CamImageBox
            // 
            this.CamImageBox.Location = new System.Drawing.Point(27, 26);
            this.CamImageBox.Name = "CamImageBox";
            this.CamImageBox.Size = new System.Drawing.Size(535, 473);
            this.CamImageBox.TabIndex = 2;
            this.CamImageBox.TabStop = false;
            // 
            // btn_stream
            // 
            this.btn_stream.Location = new System.Drawing.Point(27, 505);
            this.btn_stream.Name = "btn_stream";
            this.btn_stream.Size = new System.Drawing.Size(199, 23);
            this.btn_stream.TabIndex = 3;
            this.btn_stream.Text = "Start video stream";
            this.btn_stream.UseVisualStyleBackColor = true;
            this.btn_stream.Click += new System.EventHandler(this.btn_stream_Click);
            // 
            // btn_takePicture
            // 
            this.btn_takePicture.Location = new System.Drawing.Point(232, 505);
            this.btn_takePicture.Name = "btn_takePicture";
            this.btn_takePicture.Size = new System.Drawing.Size(106, 23);
            this.btn_takePicture.TabIndex = 4;
            this.btn_takePicture.Text = "Tomar foto";
            this.btn_takePicture.UseVisualStyleBackColor = true;
            this.btn_takePicture.Click += new System.EventHandler(this.btn_takePicture_Click);
            // 
            // btn_recognized
            // 
            this.btn_recognized.Location = new System.Drawing.Point(344, 505);
            this.btn_recognized.Name = "btn_recognized";
            this.btn_recognized.Size = new System.Drawing.Size(106, 23);
            this.btn_recognized.TabIndex = 5;
            this.btn_recognized.Text = "Reconocer rostro";
            this.btn_recognized.UseVisualStyleBackColor = true;
            // 
            // imageCapturate
            // 
            this.imageCapturate.Location = new System.Drawing.Point(665, 26);
            this.imageCapturate.Name = "imageCapturate";
            this.imageCapturate.Size = new System.Drawing.Size(511, 473);
            this.imageCapturate.TabIndex = 2;
            this.imageCapturate.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 540);
            this.Controls.Add(this.imageCapturate);
            this.Controls.Add(this.btn_recognized);
            this.Controls.Add(this.btn_takePicture);
            this.Controls.Add(this.btn_stream);
            this.Controls.Add(this.CamImageBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CamImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCapturate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox CamImageBox;
        private System.Windows.Forms.Button btn_stream;
        private System.Windows.Forms.Button btn_takePicture;
        private System.Windows.Forms.Button btn_recognized;
        private Emgu.CV.UI.ImageBox imageCapturate;
    }
}

