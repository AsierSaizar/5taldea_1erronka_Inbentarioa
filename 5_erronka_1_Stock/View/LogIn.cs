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
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    // Crear la consulta HQL para buscar al usuario
                    string hql = "FROM Langilea WHERE Emaila = :email AND Pasahitza = :pasahitza AND Nivel_permisos = 0";
                    IQuery query = session.CreateQuery(hql);
                    query.SetParameter("email", email);
                    query.SetParameter("pasahitza", pasahitza);

                    // Ejecutar la consulta y obtener el resultado
                    var user = query.UniqueResult<Langilea>();
                    int idUsuario= user.Id;
                    if (user != null)
                    {
                        // Usuario encontrado
                        MessageBox.Show("Inicio de sesión exitoso.");
                        Menua m = new Menua(sessionFactory, idUsuario);
                        m.Show();

                    }
                    else
                    {
                        // Usuario no encontrado
                        MessageBox.Show("Correo electrónico o contraseña incorrectos.");
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }



        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
