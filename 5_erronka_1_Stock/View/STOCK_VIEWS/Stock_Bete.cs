using NHibernate;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5_erronka_1_Stock.View.STOCK_VIEWS
{
    public partial class Stock_Bete : Form
    {

        private ISessionFactory sessionFactory;
        private int idUsuario;
        public Stock_Bete(ISessionFactory sessionFactory, int idUsuario)
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

            // Realiza las configuraciones necesarias
            this.WindowState = FormWindowState.Maximized; // Asegúrate de que esté maximizado
            this.Visible = true; // Muestra la ventana cuando esté lista

            // Asociar el evento CellClick al DataGridView
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void CargarDatos()
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    // Consulta HQL para seleccionar solo columnas específicas
                    string hql = "SELECT s.Id, s.Izena, s.Stock_Kant,s.Unitatea, s.Min, s.Max FROM Stock s WHERE s.Stock_Kant < s.Min";

                    // Crear la consulta
                    IQuery query = session.CreateQuery(hql);

                    // Ejecutar la consulta y obtener los resultados
                    var stockList = query.List<object[]>();

                    // Crear un DataTable para asignar los datos al DataGridView
                    var dataTable = new DataTable();
                    dataTable.Columns.Add("Id", typeof(int));
                    dataTable.Columns.Add("Izena", typeof(String));
                    dataTable.Columns.Add("Stock Kantitatea", typeof(int));
                    dataTable.Columns.Add("Unitatea", typeof(String));
                    dataTable.Columns.Add("Minimoa", typeof(int));
                    dataTable.Columns.Add("Maximoa", typeof(int));

                    // Rellenar el DataTable con los datos de la consulta
                    foreach (var row in stockList)
                    {
                        dataTable.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5]);
                    }

                    // Asignar el DataTable al DataGridView
                    dataGridView1.DataSource = dataTable;

                    transaction.Commit(); // Confirmar la transacción
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Revertir la transacción en caso de error
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica que no sea el encabezado
            {
                // Obtén la fila seleccionada
                var selectedRow = dataGridView1.Rows[e.RowIndex];

                // Llena los TextBox con los datos de la fila seleccionada
                textBox1.Text = selectedRow.Cells["Id"].Value?.ToString() ?? string.Empty;
                textBox_Stock_Kant.Text = selectedRow.Cells["Stock Kantitatea"].Value?.ToString() ?? string.Empty;
                label2.Text = selectedRow.Cells["Minimoa"].Value?.ToString() ?? string.Empty;
                label3.Text = selectedRow.Cells["Maximoa"].Value?.ToString() ?? string.Empty;
            }
        }


        private void Stock_Bete_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stock_View CV = new Stock_View(sessionFactory, idUsuario);
            CV.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                String min = (label2.Text);
                textBox_Stock_Kant.Text = min;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int stockKant = Convert.ToInt16(textBox_Stock_Kant.Text);
                int max = Convert.ToInt16((label3.Text));
                if (stockKant < max)
                {
                    textBox_Stock_Kant.Text = (stockKant + 1).ToString();

                }
            }
                
        }

        private void textBox_Stock_Kant_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int stockKant = Convert.ToInt16(textBox_Stock_Kant.Text);
                int min = Convert.ToInt16((label2.Text));
                if (stockKant>min)
                {
                    textBox_Stock_Kant.Text = (stockKant - 1).ToString();
                }
            }
                
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                String max = (label3.Text);
                textBox_Stock_Kant.Text = max;
            }
        }

        private void button_login_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt16(textBox1.Text);
                int stockKant = Convert.ToInt16(textBox_Stock_Kant.Text);
                int min = Convert.ToInt16((label2.Text));
                int max = Convert.ToInt16((label3.Text));

                if (max >= stockKant && stockKant >= min)
                {
                    String result = StockBete(id, stockKant);
                    if (result == "true")
                    {
                        MessageBox.Show("Ondo eraldatu da");
                        CargarDatos();
                    }
                    else
                    {
                        MessageBox.Show(result);
                    }
                }
                else
                {
                    MessageBox.Show("Minimoa eta maximoaren arteko kantitate bat aukeratu");
                }
            }else
            {
                MessageBox.Show("Aukeratu erregistro bat");
            }
            
        }

        private String StockBete(int id, int stockKant)
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

                    produktua.Stock_Kant = stockKant;

                    produktua.updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    produktua.updated_by = idUsuario;

                    // Guardar los cambios en la sesión
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
    }
}
