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
    public partial class Platerak_Create : Form
    {
        private ISessionFactory sessionFactory;
        private int idUsuario;
        public Platerak_Create(ISessionFactory sessionFactory, int idUsuario)
        {
            InitializeComponent();
            this.sessionFactory = sessionFactory ?? throw new ArgumentNullException(nameof(sessionFactory));
            this.idUsuario = idUsuario;
        }

        protected override void OnLoad(EventArgs e)
        {
            CargarDatos();
            this.Visible = false; // Oculta la ventana mientras carga
            base.OnLoad(e);


            // Realiza las configuraciones necesarias
            this.WindowState = FormWindowState.Maximized; // Asegúrate de que esté maximizado
            this.Visible = true; // Muestra la ventana cuando esté lista
        }

        private void CargarDatos()
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    // Consulta HQL para obtener todos los registros de la tabla 'almazena'
                    string hql = "FROM Stock";


                    IQuery query = session.CreateQuery(hql);

                    // Ejecuta la consulta y obtén los resultados como una lista
                    IList<Stock> stockList = query.List<Stock>();

                    // Asigna los datos al DataGridView
                    dataGridView1.DataSource = stockList;

                    transaction.Commit(); // Confirma la transacción
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Revierte la transacción en caso de error
                    //MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void Platerak_Create_Load(object sender, EventArgs e)
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
