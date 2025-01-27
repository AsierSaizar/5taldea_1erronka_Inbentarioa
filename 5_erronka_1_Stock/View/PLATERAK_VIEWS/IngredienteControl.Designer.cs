namespace _5_erronka_1_Stock.View.PLATERAK_VIEWS
{
    partial class IngredienteControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnRestar;
        private System.Windows.Forms.Button btnSumar;
        private System.Windows.Forms.Label lblCantidad;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnRestar = new System.Windows.Forms.Button();
            this.btnSumar = new System.Windows.Forms.Button();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(10, 10);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(126, 16);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre Ingrediente";
            // 
            // btnRestar
            // 
            this.btnRestar.Location = new System.Drawing.Point(175, 5);
            this.btnRestar.Name = "btnRestar";
            this.btnRestar.Size = new System.Drawing.Size(30, 30);
            this.btnRestar.TabIndex = 1;
            this.btnRestar.Text = "-";
            this.btnRestar.UseVisualStyleBackColor = false; // Desactiva el estilo visual predeterminado
            this.btnRestar.BackColor = System.Drawing.Color.FromArgb(128, 255, 128); // RGB(128, 255, 128)
            this.btnRestar.Click += new System.EventHandler(this.btnRestar_Click);
            // 
            // btnSumar
            // 
            this.btnSumar.Location = new System.Drawing.Point(255, 5);
            this.btnSumar.Name = "btnSumar";
            this.btnSumar.Size = new System.Drawing.Size(30, 30);
            this.btnSumar.TabIndex = 2;
            this.btnSumar.Text = "+";
            this.btnSumar.UseVisualStyleBackColor = false; // Desactiva el estilo visual predeterminado
            this.btnSumar.BackColor = System.Drawing.Color.FromArgb(255, 128, 128); // RGB(255, 128, 128)
            this.btnSumar.Click += new System.EventHandler(this.btnSumar_Click);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(220, 10);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(14, 16);
            this.lblCantidad.TabIndex = 3;
            this.lblCantidad.Text = "0";
            // 
            // IngredienteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White; // Fondo blanco
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.btnSumar);
            this.Controls.Add(this.btnRestar);
            this.Controls.Add(this.lblNombre);
            this.Name = "IngredienteControl";
            this.Size = new System.Drawing.Size(302, 40);
            this.Load += new System.EventHandler(this.IngredienteControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}