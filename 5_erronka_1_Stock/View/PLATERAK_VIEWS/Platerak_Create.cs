using _5_erronka_1_Stock.Kudeatzaileak;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Common;
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
                    string hql = "FROM Stock Where deleted_by = 0";


                    IQuery query = session.CreateQuery(hql);
                    // Ejecuta la consulta y obtén los resultados como una lista
                    IList<Stock> ingredientes = query.List<Stock>();

                    foreach (var ingrediente in ingredientes)
                    {
                        var control = new IngredienteControl
                        {
                            IngredienteId = ingrediente.Id,
                            Nombre = ingrediente.Izena,
                            Cantidad = 0
                        };
                        control.Margin = new Padding(10); // Añade un margen de 10 píxeles alrededor de cada control
                        flowLayoutPanel1.Controls.Add(control);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
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

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Stock_Sortu_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                String izena = textBox_izena.Text;
                String deskribapena = textBox_Deskribapena.Text;
                String mota = textBox_Mota.Text;
                String plateraMota = comboBox1.Text;
                int prezioa = Convert.ToInt16(textBox_Prezioa.Text);

                int menu = Convert.ToInt16(textBoxMin.Text);
                if (menu == 0 || menu == 1)
                {
                    var nuevoPlato = PlaterakKudeatzailea.PlateraSortu(sessionFactory, idUsuario, izena, deskribapena, mota, plateraMota, prezioa, menu);
                    if (nuevoPlato != null)
                    {
                        int platoId = nuevoPlato.Id;

                        using (var session = sessionFactory.OpenSession())
                        using (var transaction = session.BeginTransaction())
                        {
                            try
                            {
                                // Recorrer los controles de ingredientes en el FlowLayoutPanel
                                foreach (var control in flowLayoutPanel1.Controls.OfType<IngredienteControl>())
                                {
                                    if (control.Cantidad > 0)
                                    {
                                        int ingredienteId = control.IngredienteId;
                                        int cantidad = control.Cantidad;

                                        string result = PlaterakKudeatzailea.GuardarRelacionPlatoIngrediente(sessionFactory, platoId, ingredienteId, cantidad);

                                        if (result != "true")
                                        {
                                            MessageBox.Show(result);
                                            break;
                                        }
                                    }
                                }

                                MessageBox.Show("Platera ondo sortu da ");
                                Platerak_View PV = new Platerak_View(sessionFactory, idUsuario);
                                PV.Show();
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error: " + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Errorea platera sortzean.");
                    }
                }
                else
                {
                    MessageBox.Show("Menu atalean 1 edo 0 sartu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void textBoxPlateraMota_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
