using _5_erronka_1_Stock.Kudeatzaileak;
using Antlr.Runtime.Tree;
using NHibernate;
using System;
using System.Linq;
using System.Windows.Forms;

namespace _5_erronka_1_Stock.View.STOCK_VIEWS
{
    public partial class Stock_Edit : Form
    {

        private ISessionFactory sessionFactory;
        private int idUsuario;


        public string selectedId { get; set; }
        public string selectedIzena { get; set; }
        public string selectedMota { get; set; }
        public string selectedEzaugarriak { get; set; }
        public string selectedStockKant { get; set; }
        public string selectedUnitatea { get; set; }
        public string selectedMin { get; set; }
        public string selectedMax { get; set; }

        public Stock_Edit(ISessionFactory sessionFactory, int idUsuario)
        {
            InitializeComponent();
            this.sessionFactory = sessionFactory ?? throw new ArgumentNullException(nameof(sessionFactory));
            this.idUsuario = idUsuario;
        }

        private void Stock_Edit_Load(object sender, EventArgs e)
        {
            // Asignar los valores a controles del formulario
            label1.Text += " (" + selectedId + ")";
            textBox_Id_Storage.Text = selectedId;
            textBox_izena.Text = selectedIzena;
            textBox_Mota.Text = selectedMota;
            textBox_Ezaugarriak.Text = selectedEzaugarriak;
            textBox_Stock_Kant.Text = selectedStockKant;
            textBox_Unitatea.Text = selectedUnitatea;
            textBox_Min.Text = selectedMin;
            textBox_Max.Text = selectedMax;
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
            Stock_View SV = new Stock_View(sessionFactory, idUsuario);
            SV.Show();
            this.Close();
        }

       

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            

            try
            {
                int id = Convert.ToInt16(textBox_Id_Storage.Text);
                String izena = textBox_izena.Text;
                String mota = textBox_Mota.Text;
                String ezaugarriak = textBox_Ezaugarriak.Text;
                int stock_Kant = Convert.ToInt16(textBox_Stock_Kant.Text);
                String unitatea = textBox_Unitatea.Text;
                int min = Convert.ToInt16(textBox_Min.Text);
                int max = Convert.ToInt16(textBox_Max.Text);

                
                String result = Stock_Eraldatu(id, izena, mota, ezaugarriak, stock_Kant, unitatea, min, max);
               
                if (result == "true")
                {
                    MessageBox.Show("Produktua ondo eraldatu da ");
                    Stock_View SV = new Stock_View(sessionFactory, idUsuario);
                    SV.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private String Stock_Eraldatu(int id, string izena, string mota, string ezaugarriak, int stock_Kant, string unitatea, int min, int max)
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
                        MessageBox.Show($"El producto con ID {id} no existe en la base de datos.");
                        return "Error: El producto con el ID especificado no existe.";
                    }



                    // Actualizar solo los campos relevantes
                    if (!string.IsNullOrEmpty(izena)) produktua.Izena = izena;

                    produktua.Mota = mota;
                    produktua.Ezaugarriak = ezaugarriak;
                    if (stock_Kant <= 0 || string.IsNullOrEmpty(unitatea) || min <= 0 || max <= 0)
                    {
                        transaction.Rollback();
                        if (stock_Kant <= 0) return "Stock kantitatea ezinda null edo 0 izan\nEz da eraldatu";
                        if (string.IsNullOrEmpty(unitatea)) return "Unitatea ezinda null izan\nEz da eraldatu";
                        if (min <= 0) return "Minimoa ezinda null edo 0 izan\nEz da eraldatu";
                        if (max <= 0) return "Maximoa ezinda null edo 0 izan\nEz da eraldatu";
                    }

                    produktua.Stock_Kant = stock_Kant;
                    produktua.Unitatea = unitatea;
                    produktua.Min = min;
                    produktua.Max = max;





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
