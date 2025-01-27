using NHibernate;
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
    public partial class Platerak_Osagaiak : Form
    {
        private ISessionFactory sessionFactory;
        private int idUsuario;



        public string selectedId { get; set; }
        public string selectedIzena { get; set; }
        public string selectedDeskribapena { get; set; }
        public string selectedPlatera_mota { get; set; }
        public string selectedPrezioa { get; set; }


        public Platerak_Osagaiak(ISessionFactory sessionFactory, int idUsuario)
        {
            InitializeComponent();
            this.sessionFactory = sessionFactory ?? throw new ArgumentNullException(nameof(sessionFactory));
            this.idUsuario = idUsuario;
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Visible = false; // Oculta la ventana mientras carga
            base.OnLoad(e);
            CargarDatos();
            CargarTextBox();

            // Realiza las configuraciones necesarias
            this.WindowState = FormWindowState.Maximized; // Asegúrate de que esté maximizado
            this.Visible = true; // Muestra la ventana cuando esté lista
        }
        private void CargarTextBox()
        {
            // Asignar los valores a controles del formulario
            label1.Text += " (" + selectedId + ")";
            textBox_Id_Storage.Text = selectedId;
            textBox_izena.Text = selectedIzena;
            textBox_Deskribapena.Text = selectedDeskribapena;
            textBox_Platera_mota.Text = selectedPlatera_mota;
            textBox_prezioa.Text = selectedPrezioa;
        }

        private void CargarDatos()
        {
            
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Platerak_Osagaiak_Load_1(object sender, EventArgs e)
        {

        }

        private void textBox_Ezaugarriak_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Platerak_View PV = new Platerak_View(sessionFactory, idUsuario);
            PV.Show();
            this.Close();
        }
    }
}
