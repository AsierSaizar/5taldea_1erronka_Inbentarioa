using _5_erronka_1_Stock;
using NHibernate;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_erronka_1_Stock.Kudeatzaileak
{
    internal class PlaterakKudeatzailea
    {

        internal static string GuardarRelacionPlatoIngrediente(ISessionFactory sessionFactory, int platoId, int ingredienteId, int cantidad)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    PlateraStock platera_stock = new PlateraStock
                    {
                        PlateraId = platoId,
                        StockId = ingredienteId,
                        Kantitatea = cantidad

                    };
                    session.Save(platera_stock);
                    transaction.Commit();  

                    return "true";

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return "Error: " + ex.Message;
                }
            }
        }

        internal static int ObtenerIdDelPlatoCreado(ISessionFactory sessionFactory, string izena)
        {
            using (var session = sessionFactory.OpenSession())
            {
                // Buscar el plato por nombre (o cualquier otro campo único)
                var plato = session.Query<Platerak>().FirstOrDefault(p => p.Izena == izena);

                if (plato != null)
                {
                    return plato.Id; // Devolver el ID del plato
                }
                else
                {
                    throw new Exception("Plato no encontrado.");
                }
            }
        }

        internal static string PlateraSortu(ISessionFactory sessionFactory, int idUsuario, string izena, string deskribapena, string mota, string plateraMota, int prezioa, int menu)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    Platerak plateraFinal = new Platerak
                    {
                        Izena = izena,
                        Deskribapena = deskribapena,
                        Mota = mota,
                        Platera_mota = plateraMota,
                        Prezioa = prezioa,
                        Menu = menu,
                        created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        created_by = idUsuario

                    };
                    session.Save(plateraFinal);
                    transaction.Commit();  // Asegúrate de confirmar la transacción
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
