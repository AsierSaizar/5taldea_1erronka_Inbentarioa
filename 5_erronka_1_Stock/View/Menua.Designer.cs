namespace _5_erronka_1_Stock
{
    partial class Menua
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
            this.Stock_Menu_Btn = new System.Windows.Forms.Button();
            this.Platerak_Menu_Btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Stock_Menu_Btn
            // 
            this.Stock_Menu_Btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Stock_Menu_Btn.AutoSize = true;
            this.Stock_Menu_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(71)))));
            this.Stock_Menu_Btn.Font = new System.Drawing.Font("Malgun Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stock_Menu_Btn.Location = new System.Drawing.Point(311, 100);
            this.Stock_Menu_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Stock_Menu_Btn.Name = "Stock_Menu_Btn";
            this.Stock_Menu_Btn.Size = new System.Drawing.Size(476, 197);
            this.Stock_Menu_Btn.TabIndex = 1;
            this.Stock_Menu_Btn.Text = "Stock";
            this.Stock_Menu_Btn.UseVisualStyleBackColor = false;
            this.Stock_Menu_Btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Platerak_Menu_Btn
            // 
            this.Platerak_Menu_Btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Platerak_Menu_Btn.AutoSize = true;
            this.Platerak_Menu_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(71)))));
            this.Platerak_Menu_Btn.Font = new System.Drawing.Font("Malgun Gothic", 48F);
            this.Platerak_Menu_Btn.Location = new System.Drawing.Point(311, 336);
            this.Platerak_Menu_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Platerak_Menu_Btn.Name = "Platerak_Menu_Btn";
            this.Platerak_Menu_Btn.Size = new System.Drawing.Size(476, 197);
            this.Platerak_Menu_Btn.TabIndex = 1;
            this.Platerak_Menu_Btn.Text = "Platerak";
            this.Platerak_Menu_Btn.UseVisualStyleBackColor = false;
            this.Platerak_Menu_Btn.Click += new System.EventHandler(this.Platerak_Menu_Btn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(69)))), ((int)(((byte)(13)))));
            this.button1.Location = new System.Drawing.Point(16, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 39);
            this.button1.TabIndex = 2;
            this.button1.Text = "<--Atzera";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Menua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(1091, 607);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Platerak_Menu_Btn);
            this.Controls.Add(this.Stock_Menu_Btn);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Menua";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Menua_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Stock_Menu_Btn;
        private System.Windows.Forms.Button Platerak_Menu_Btn;
        private System.Windows.Forms.Button button1;
    }
}