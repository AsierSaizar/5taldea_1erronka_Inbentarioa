namespace _5_erronka_1_Stock
{
    partial class LogIn
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_pasahitza = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_login = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_email
            // 
            this.textBox_email.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_email.Location = new System.Drawing.Point(407, 338);
            this.textBox_email.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(219, 22);
            this.textBox_email.TabIndex = 4;
            this.textBox_email.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(419, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Emaila";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox_pasahitza
            // 
            this.textBox_pasahitza.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_pasahitza.Location = new System.Drawing.Point(407, 393);
            this.textBox_pasahitza.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_pasahitza.Name = "textBox_pasahitza";
            this.textBox_pasahitza.Size = new System.Drawing.Size(219, 22);
            this.textBox_pasahitza.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(419, 374);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Pasahitza";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::_5_erronka_1_Stock.Properties.Resources.saboreame_sin_background__1_;
            this.pictureBox1.Location = new System.Drawing.Point(352, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(335, 290);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // button_login
            // 
            this.button_login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(69)))), ((int)(((byte)(13)))));
            this.button_login.Location = new System.Drawing.Point(407, 437);
            this.button_login.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(220, 41);
            this.button_login.TabIndex = 13;
            this.button_login.Text = "Saioa Hasi";
            this.button_login.UseVisualStyleBackColor = false;
            this.button_login.Click += new System.EventHandler(this.button1_Click);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(1053, 601);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_pasahitza);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_email);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LogIn";
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LogIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_pasahitza;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_login;
    }
}

