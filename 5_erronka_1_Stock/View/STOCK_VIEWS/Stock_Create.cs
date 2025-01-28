
using _5_erronka_1_Stock.Kudeatzaileak;
using NHibernate;
using System;
using System.Windows.Forms;

namespace _5_erronka_1_Stock.View.STOCK_VIEWS
{
    public partial class Stock_Create : Form
    {
        private ISessionFactory sessionFactory;
        private int idUsuario;

        public Stock_Create(ISessionFactory sessionFactory, int idUsuario)
        {
            InitializeComponent();
            this.sessionFactory = sessionFactory ?? throw new ArgumentNullException(nameof(sessionFactory));
            this.idUsuario = idUsuario;
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

                String result = StockKudeatzailea.Stock_Sortu(sessionFactory, idUsuario, izena, mota, ezaugarriak, stock_Kant, unitatea, min, max);
                if (result == "true")
                {
                    MessageBox.Show("Produktua ondo sortu da ");

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

        

        private void Stock_Create_Load(object sender, EventArgs e)
        {

        }
    }
}
