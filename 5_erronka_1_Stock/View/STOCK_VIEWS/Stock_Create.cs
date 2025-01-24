using _5_erronka_1_Stock.Kudeatzaileak;
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

namespace _5_erronka_1_Stock.View.STOCK_VIEWS
{
    public partial class Stock_Create : Form
    {
        private ISessionFactory sessionFactory;
        public Stock_Create(ISessionFactory sessionFactory)
        {
            InitializeComponent();
            this.sessionFactory = sessionFactory ?? throw new ArgumentNullException(nameof(sessionFactory));
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

            Stock_View SV = new Stock_View(sessionFactory);
            SV.Show(); 
            this.Close();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Button_login_Click(object sender, EventArgs e)
        {
            
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            

            try
            {
                String izena = textBox_izena.Text;
                String mota = textBox_Mota.Text;
                String ezaugarriak = textBox_Ezaugarriak.Text;
                int stock_Kant = Convert.ToInt16(textBoxStockKant.Text);
                String unitatea = textBox_Unitatea.Text;
                int min = Convert.ToInt16(textBoxMin.Text);
                int max = Convert.ToInt16(textBoxMax.Text);

                String result = Stock_Sortu(izena, mota, ezaugarriak, stock_Kant, unitatea, min, max);
                if (result == "true")
                {
                    MessageBox.Show("Produktua ondo sortu da ");

                    Stock_View SV = new Stock_View(sessionFactory);
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

        private String Stock_Sortu(string izena, string mota, string ezaugarriak, int stock_Kant, string unitatea, int min, int max)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    Stock produktua = new Stock
                    {
                        Izena = izena,
                        Mota = mota,
                        Ezaugarriak = ezaugarriak,
                        Stock_Kant = stock_Kant,
                        Unitatea = unitatea,
                        Min = min,
                        Max = max,
                        created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        created_by = 2

                    };
                    session.Save(produktua);
                    transaction.Commit();  // Asegúrate de confirmar la transacción
                    return "true";


                }
                catch (Exception ex)
                {
                    transaction.Rollback();  // Si hay un error, revierte la transacción
                    MessageBox.Show("Error: " + ex.Message);

                    return "Error: " + ex.Message;
                }
            }
        }

        private void Stock_Create_Load(object sender, EventArgs e)
        {

        }
    }
}
