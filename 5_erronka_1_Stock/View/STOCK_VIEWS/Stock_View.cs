using _5_erronka_1_Stock.View.STOCK_VIEWS;
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

namespace _5_erronka_1_Stock
{
    public partial class Stock_View : Form
    {

        public Stock_View()
        {
            InitializeComponent();
            Kontsultak_Load();

        }

        protected override void OnLoad(EventArgs e)
        {
            this.Visible = false; // Oculta la ventana mientras carga
            base.OnLoad(e);

            // Realiza las configuraciones necesarias
            this.WindowState = FormWindowState.Maximized; // Asegúrate de que esté maximizado
            this.Visible = true; // Muestra la ventana cuando esté lista
        }   
        private NHibernate.Cfg.Configuration myConfiguration;
        private ISessionFactory mySessionFactory;
        private ISession mySession;

        private void Kontsultak_Load()
        {
            // Configuración de NHibernate para conectarse a la base de datos
            myConfiguration = new NHibernate.Cfg.Configuration();
            myConfiguration.Configure(); // Carga la configuración desde app.config
            mySessionFactory = myConfiguration.BuildSessionFactory();
            mySession = mySessionFactory.OpenSession();

            // Cargar los datos al abrir la pestaña
            CargarDatos();
        }

        private void CargarDatos()
        {
            using (var transaction = mySession.BeginTransaction())
            {
                try
                {
                    // Consulta HQL para obtener todos los registros de la tabla 'almazena'
                    string hql = "FROM Stock";
                    

                    IQuery query = mySession.CreateQuery(hql);

                    // Ejecuta la consulta y obtén los resultados como una lista
                    IList<Stock> stockList = query.List<Stock>();

                    // Asigna los datos al DataGridView
                    dataGridView1.DataSource = stockList;

                    transaction.Commit(); // Confirma la transacción
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Revierte la transacción en caso de error
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        

        private void Stock_Load(object sender, EventArgs e)
        {



        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Menua m = new Menua();
            m.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void Stock_Menu_Btn_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Stock_Create SC = new Stock_Create();
            SC.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Stock_Edit SE = new Stock_Edit();
            SE.Show();
        }
    }
}
