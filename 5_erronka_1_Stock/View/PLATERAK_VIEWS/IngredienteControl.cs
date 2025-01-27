using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5_erronka_1_Stock.View.PLATERAK_VIEWS
{
    public partial class IngredienteControl : UserControl
    {
        // Propiedades
        public int IngredienteId { get; set; } // Para identificar el ingrediente
        public string Nombre
        {
            get { return lblNombre.Text; }
            set { lblNombre.Text = value; }
        }
        public int Cantidad { get; set; } = 0; // Cantidad seleccionada

        public IngredienteControl()
        {
            InitializeComponent();
        }

        // Evento para el botón de restar
        private void btnRestar_Click(object sender, EventArgs e)
        {
            if (Cantidad > 0)
            {
                Cantidad--;
                lblCantidad.Text = Cantidad.ToString();
            }
        }

        // Evento para el botón de sumar
        private void btnSumar_Click(object sender, EventArgs e)
        {
            Cantidad++;
            lblCantidad.Text = Cantidad.ToString();
        }

        private void IngredienteControl_Load(object sender, EventArgs e)
        {

        }
    }
}