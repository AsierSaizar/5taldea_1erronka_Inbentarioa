using _5_erronka_1_Stock.View.STOCK_VIEWS;
using NHibernate;
using NHibernate.Mapping;
using Org.BouncyCastle.Asn1.Cms;
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
        private ISessionFactory sessionFactory;
        private int idUsuario;

        public Stock_View(ISessionFactory sessionFactory, int idUsuario)
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
        

       

        public void CargarDatos()
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
                    // Verifica si la columna existe y ocúltala
                    if (dataGridView1.Columns["PlateraStockak"] != null)
                    {
                        dataGridView1.Columns["PlateraStockak"].Visible = false;
                    }


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
            Menua m = new Menua(sessionFactory, idUsuario);
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
            Stock_Create SC = new Stock_Create(sessionFactory, idUsuario);
            SC.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];

                // Extraer datos de las columnas con manejo de valores null
                string dataToPass_Id = selectedRow.Cells[0].Value?.ToString() ?? string.Empty;
                var dataToPass_Izena = selectedRow.Cells[1].Value?.ToString() ?? string.Empty;
                var dataToPass_Mota = selectedRow.Cells[2].Value?.ToString() ?? string.Empty;
                var dataToPass_Ezaugarriak = selectedRow.Cells[3].Value?.ToString() ?? string.Empty;
                var dataToPass_StockKant = selectedRow.Cells[4].Value?.ToString() ?? string.Empty;
                var dataToPass_Unitatea = selectedRow.Cells[5].Value?.ToString() ?? string.Empty;
                var dataToPass_Min = selectedRow.Cells[6].Value?.ToString() ?? string.Empty;
                var dataToPass_Max = selectedRow.Cells[7].Value?.ToString() ?? string.Empty;

                Stock_Edit SE = new Stock_Edit(sessionFactory, idUsuario);

                // Pasar datos al formulario Stock_Edit
                
                SE.selectedId = dataToPass_Id;
                SE.selectedIzena = dataToPass_Izena;
                SE.selectedMota = dataToPass_Mota;
                SE.selectedEzaugarriak = dataToPass_Ezaugarriak;
                SE.selectedStockKant = dataToPass_StockKant;
                SE.selectedUnitatea = dataToPass_Unitatea;
                SE.selectedMin = dataToPass_Min;
                SE.selectedMax = dataToPass_Max;

                SE.Show();
                this.Close();
            }
            else
            {
                // No hay filas seleccionadas
                MessageBox.Show("No hay ningún registro seleccionado.");
            }

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];

                // Extraer datos de las columnas con manejo de valores null
                int Id = Convert.ToInt16(selectedRow.Cells["Id"].Value?.ToString() ?? string.Empty);
                var deleted_at = selectedRow.Cells[12].Value?.ToString() ?? string.Empty;
                if (deleted_at=="")
                {
                    DialogResult dr = MessageBox.Show("Produktua ezabatu nahi duzu?",
                      "Konfirmazioa ezabatzeko", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            String result = Stock_Ezabatu(Id);

                            if (result == "true")
                            {
                                MessageBox.Show("Produktua ondo ezabatu da ");
                                CargarDatos();
                            }
                            else
                            {
                                MessageBox.Show(result);
                            }
                            break;
                        case DialogResult.No:

                            break;
                    }
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Produktua ezabatuta dago iada\nProduktua berreskuratu nahi duzu?",
                      "Konfirmazioa berreskuratzeko", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            String result = Stock_Berreskuratu(Id);

                            if (result == "true")
                            {
                                MessageBox.Show("Produktua ondo berreskuratu da ");
                                CargarDatos();
                            }
                            else
                            {
                                MessageBox.Show(result);
                            }
                            break;
                        case DialogResult.No:

                            break;
                    }
                }


            }
            else
            {
                // No hay filas seleccionadas
                MessageBox.Show("No hay ningún registro seleccionado.");
            }
        }

        private string Stock_Berreskuratu(int id)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    // Recuperar el registro existente por ID
                    var produktua = session.Query<Stock>().FirstOrDefault(f => f.Id == id);
                    if (produktua == null)
                    {
                        return "Error: El producto con el ID especificado no existe.";
                    }

                    produktua.deleted_at = "";
                    produktua.deleted_by = 0;

                    session.Update(produktua);
                    transaction.Commit();  // Confirmar la transacción

                    return "true";

                }
                catch (Exception ex)
                {
                    transaction.Rollback();  // Si hay un error, revierte la transacción

                    return "Error: " + ex.Message;
                }
            }
        }

        private string Stock_Ezabatu(int id)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    // Recuperar el registro existente por ID
                    var produktua = session.Query<Stock>().FirstOrDefault(f => f.Id == id);
                    if (produktua == null)
                    {
                        return "Error: El producto con el ID especificado no existe.";
                    }

                    produktua.deleted_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    produktua.deleted_by = idUsuario;

                    session.Update(produktua);
                    transaction.Commit();  // Confirmar la transacción

                    return "true";

                }
                catch (Exception ex)
                {
                    transaction.Rollback();  // Si hay un error, revierte la transacción

                    return "Error: " + ex.Message;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Stock_Bete SB = new Stock_Bete(sessionFactory, idUsuario);
            SB.Show();
            this.Close();
        }
    }
}
