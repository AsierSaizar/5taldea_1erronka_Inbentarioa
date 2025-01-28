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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using NHibernate.Cfg;
using _5_erronka_1_Stock.Kudeatzaileak;
using System.Transactions;

namespace _5_erronka_1_Stock
{

    public partial class LogIn : Form
    {
        private ISessionFactory sessionFactory;
        private ISession mySession;

        public LogIn()
        {
            InitializeComponent();
            ConfigureNHibernate();
        }
        private void ConfigureNHibernate()
        {
            try
            {
                var configuration = new Configuration();
                configuration.Configure(); // Carga la configuración desde App.config o hibernate.cfg.xml
                sessionFactory = configuration.BuildSessionFactory();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errorea NHibernate konfiguratzean: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            this.Visible = false; // Oculta la ventana mientras carga
            base.OnLoad(e);

            // Realiza las configuraciones necesarias
            this.WindowState = FormWindowState.Maximized; // Asegúrate de que esté maximizado
            this.Visible = true; // Muestra la ventana cuando esté lista
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            


            // Obtener los valores del formulario
            //string email = textBox_email.Text.Trim();
            //string pasahitza = textBox_pasahitza.Text.Trim();
            string email = "a";
            string pasahitza = "a";
            int idUsuario = LangileaKudeatzailea.Login(sessionFactory, email, pasahitza);
            if (idUsuario != 0)
            {
                MessageBox.Show("Inicio de sesión exitoso.");
                Menua m = new Menua(sessionFactory, idUsuario);
                m.Show();
            }else if (idUsuario == -0)
            {
                MessageBox.Show("Errore bat izanda saioa hastean");
            }



        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
