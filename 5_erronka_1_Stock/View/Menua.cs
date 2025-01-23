using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5_erronka_1_Stock
{
    public partial class Menua : Form
    {
        public Menua()
        {
            InitializeComponent();

        }
        protected override void OnLoad(EventArgs e)
        {
            this.Visible = false; // Oculta la ventana mientras carga
            base.OnLoad(e);

            // Realiza las configuraciones necesarias
            this.WindowState = FormWindowState.Maximized; // Asegúrate de que esté maximizado
            this.Visible = true; // Muestra la ventana cuando esté lista
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stock_View s = new Stock_View();
            s.Show();
            this.Close();
        }

        private void Platerak_Menu_Btn_Click(object sender, EventArgs e)
        {
            Platerak_View p = new Platerak_View();
            p.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void Menua_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
