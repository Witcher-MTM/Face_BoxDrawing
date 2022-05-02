namespace REcognition18PLUS
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
            this.img_add_btn = new System.Windows.Forms.Button();
            this.clearpicture_btn = new System.Windows.Forms.Button();
            this.WTF = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // img_add_btn
            // 
            this.img_add_btn.Location = new System.Drawing.Point(12, 12);
            this.img_add_btn.Name = "img_add_btn";
            this.img_add_btn.Size = new System.Drawing.Size(75, 83);
            this.img_add_btn.TabIndex = 0;
            this.img_add_btn.Text = "Upload Image";
            this.img_add_btn.UseVisualStyleBackColor = true;
            this.img_add_btn.Click += new System.EventHandler(this.img_add_btn_Click);
            // 
            // clearpicture_btn
            // 
            this.clearpicture_btn.Location = new System.Drawing.Point(12, 173);
            this.clearpicture_btn.Name = "clearpicture_btn";
            this.clearpicture_btn.Size = new System.Drawing.Size(75, 90);
            this.clearpicture_btn.TabIndex = 1;
            this.clearpicture_btn.Text = "Clear";
            this.clearpicture_btn.UseVisualStyleBackColor = true;
            this.clearpicture_btn.Click += new System.EventHandler(this.clearpicture_btn_Click);
            // 
            // WTF
            // 
            this.WTF.Location = new System.Drawing.Point(12, 357);
            this.WTF.Name = "WTF";
            this.WTF.Size = new System.Drawing.Size(75, 81);
            this.WTF.TabIndex = 2;
            this.WTF.Text = "button3";
            this.WTF.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(93, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(695, 435);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.WTF);
            this.Controls.Add(this.clearpicture_btn);
            this.Controls.Add(this.img_add_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button img_add_btn;
        private System.Windows.Forms.Button clearpicture_btn;
        private System.Windows.Forms.Button WTF;
        public System.Windows.Forms.PictureBox pictureBox1;
    }
}

