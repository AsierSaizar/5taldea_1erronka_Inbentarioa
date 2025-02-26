﻿using _5_erronka_1_Stock.Kudeatzaileak;
using _5_erronka_1_Stock.View.PLATERAK_VIEWS;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _5_erronka_1_Stock
{
    public partial class Platerak_View : Form
    {
        private ISessionFactory sessionFactory;
        private int idUsuario;
        public Platerak_View(ISessionFactory sessionFactory, int idUsuario)
        {
            InitializeComponent();
            this.sessionFactory = sessionFactory ?? throw new ArgumentNullException(nameof(sessionFactory));
            this.idUsuario = idUsuario;

            CargarDatos();
        }

        protected override void OnLoad(EventArgs e)
        {
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
                    string hql = "FROM Platerak";


                    IQuery query = session.CreateQuery(hql);

                    // Ejecuta la consulta y obtén los resultados como una lista
                    IList<Platerak> platerakList = query.List<Platerak>();

                    // Asigna los datos al DataGridView
                    dataGridView1.DataSource = platerakList;
                    dataGridView1.AutoGenerateColumns = false;

                    // Verifica si la columna existe y ocúltala
                    if (dataGridView1.Columns["PlateraStockak"] != null)
                    {
                        dataGridView1.Columns["PlateraStockak"].Visible = false;
                    }

                    transaction.Commit(); // Confirma la transacción
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void Kontsultak_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Menua m = new Menua(sessionFactory, idUsuario);
            m.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Platerak_View_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Stock_Menu_Btn_Click(object sender, EventArgs e)
        {
            Platerak_Create PC = new Platerak_Create(sessionFactory, idUsuario);
            PC.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                var selectedRow = dataGridView1.SelectedRows[0];

                // Extraer datos de las columnas con manejo de valores null
                var dataToPass_Id = selectedRow.Cells["Id"].Value?.ToString() ?? string.Empty;
                var dataToPass_Izena = selectedRow.Cells["Izena"].Value?.ToString() ?? string.Empty;
                var dataToPass_Deskribapena = selectedRow.Cells["Deskribapena"].Value?.ToString() ?? string.Empty;
                var dataToPass_PlateraMota = selectedRow.Cells["Platera_mota"].Value?.ToString() ?? string.Empty;
                var dataToPass_prezioa = selectedRow.Cells["Prezioa"].Value?.ToString() ?? string.Empty;


                Platerak_Osagaiak PO = new Platerak_Osagaiak(sessionFactory, idUsuario);

                // Pasar datos al formulario Stock_Edit

                PO.selectedId = dataToPass_Id;
                PO.selectedIzena = dataToPass_Izena;
                PO.selectedDeskribapena = dataToPass_Deskribapena;
                PO.selectedPlatera_mota = dataToPass_PlateraMota;
                PO.selectedPrezioa = dataToPass_prezioa;

                PO.Show();
                this.Close();

            }else
            {
                // No hay filas seleccionadas
                MessageBox.Show("No hay ningún registro seleccionado.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];

                // Extraer datos de las columnas con manejo de valores null
                int Id = Convert.ToInt16(selectedRow.Cells["Id"].Value?.ToString() ?? string.Empty);
                var deleted_by = selectedRow.Cells["deleted_by"].Value?.ToString() ?? string.Empty;
                if (deleted_by == "0")
                {
                    DialogResult dr = MessageBox.Show("Produktua ezabatu nahi duzu?",
                      "Konfirmazioa ezabatzeko", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            String result = PlaterakKudeatzailea.Platerak_Ezabatu(sessionFactory, idUsuario, Id);

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
                            String result = PlaterakKudeatzailea.Platerak_Berreskuratu(sessionFactory, idUsuario, Id);

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

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];

                // Extraer datos de las columnas con manejo de valores null
                int idPlatera = Convert.ToInt16(selectedRow.Cells["Id"].Value?.ToString() ?? string.Empty);

                Platerak_Edit SE = new Platerak_Edit(sessionFactory, idUsuario, idPlatera);
                SE.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("No hay ningún registro seleccionado.");
            }
        }
    }
}
