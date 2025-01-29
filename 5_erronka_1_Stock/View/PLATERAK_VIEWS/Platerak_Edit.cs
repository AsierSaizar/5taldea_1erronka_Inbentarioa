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

namespace _5_erronka_1_Stock.View.PLATERAK_VIEWS
{
    public partial class Platerak_Edit : Form
    {
        private ISessionFactory sessionFactory;
        private int idUsuario;
        private int idPlatera;
        public Platerak_Edit(ISessionFactory sessionFactory, int idUsuario, int idPlatera)
        {
            InitializeComponent();
            this.sessionFactory = sessionFactory ?? throw new ArgumentNullException(nameof(sessionFactory));
            this.idUsuario = idUsuario;
            this.idPlatera = idPlatera;
        }
        protected override void OnLoad(EventArgs e)
        {
            CargarDatos();
            CargarDatosForm();
            this.Visible = false; // Oculta la ventana mientras carga
            base.OnLoad(e);


            // Realiza las configuraciones necesarias
            this.WindowState = FormWindowState.Maximized; // Asegúrate de que esté maximizado
            this.Visible = true; // Muestra la ventana cuando esté lista
        }

        private void Platerak_Edit_Load(object sender, EventArgs e)
        {
            label1.Text += " (" + idPlatera + ")";
        }

        private void CargarDatosForm()
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var platerak = session.Get<Platerak>(idPlatera);

                if (platerak != null)
                {
                    // Guardar los datos en variables
                    textBox_izena.Text = platerak.Izena;
                    textBox_Deskribapena.Text = platerak.Deskribapena;
                    textBox_Mota.Text = platerak.Mota;
                    comboBox1.SelectedItem = platerak.Platera_mota;
                    textBox_Prezioa.Text = platerak.Prezioa.ToString();
                    comboBox2.SelectedItem = platerak.Menu.ToString();

                }
                else
                {
                    Console.WriteLine("Registro no encontrado.");
                }

                transaction.Commit();
            }
        }



        private void CargarDatos()
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    // Obtener todos los ingredientes activos
                    string hqlIngredientes = "FROM Stock Where deleted_by = 0";
                    IQuery queryIngredientes = session.CreateQuery(hqlIngredientes);
                    IList<Stock> ingredientes = queryIngredientes.List<Stock>();

                    // Obtener las relaciones PlateraStock para el plato específico
                    string hqlPlateraStock = "FROM PlateraStock WHERE Platera.Id = :platoId";
                    IQuery queryPlateraStock = session.CreateQuery(hqlPlateraStock)
                                                       .SetParameter("platoId", idPlatera);
                    IList<PlateraStock> plateraStocks = queryPlateraStock.List<PlateraStock>();


                    // Crear un diccionario para buscar cantidades rápidamente
                    var ingredienteCantidadDict = plateraStocks.ToDictionary(
                        ps => ps.Almazena.Id,
                        ps => ps.Kantitatea
                    );

                    // Iterar sobre todos los ingredientes y cargar controles
                    foreach (var ingrediente in ingredientes)
                    {
                        var control = new IngredienteControl
                        {
                            IngredienteId = ingrediente.Id,
                            Nombre = ingrediente.Izena,
                            Cantidad = ingredienteCantidadDict.ContainsKey(ingrediente.Id)
                                ? ingredienteCantidadDict[ingrediente.Id]
                                : 0
                        };
                        control.Margin = new Padding(10); // Añade un margen de 10 píxeles
                        flowLayoutPanel1.Controls.Add(control);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Platerak_View PV = new Platerak_View(sessionFactory, idUsuario);
            PV.Show();
            this.Close();
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

                int menu = Convert.ToInt16(comboBox2.Text);
                
                PlaterakKudeatzailea.PlateraEraldatu(sessionFactory, idUsuario, idPlatera, izena, deskribapena, mota, plateraMota, prezioa, menu);
                PlaterakKudeatzailea.PlaterarenErlazioakEzabatu(sessionFactory, idPlatera);

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

                                string result = PlaterakKudeatzailea.GuardarRelacionPlatoIngrediente(sessionFactory, idPlatera, ingredienteId, cantidad);

                                if (result != "true")
                                {
                                    MessageBox.Show(result);
                                    break;
                                }
                            }
                        }

                        MessageBox.Show("Platera ondo eraldatu da ");
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
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
