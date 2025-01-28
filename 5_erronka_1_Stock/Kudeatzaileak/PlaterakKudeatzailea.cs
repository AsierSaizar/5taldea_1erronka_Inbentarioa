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
                    // Obtener las instancias de Platerak y Stock
                    var plato = session.Get<Platerak>(platoId);
                    var ingrediente = session.Get<Stock>(ingredienteId);

                    if (plato == null || ingrediente == null)
                    {
                        return "Error: El plato o ingrediente no existe";
                    }

                    // Crear la relación
                    PlateraStock plateraStock = new PlateraStock
                    {
                        Platera = plato,
                        Almazena = ingrediente,
                        Kantitatea = cantidad
                    };

                    session.Save(plateraStock);
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



        internal static Platerak PlateraSortu(ISessionFactory sessionFactory, int idUsuario, string izena, string deskribapena, string mota, string plateraMota, int prezioa, int menu)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    var platera = new Platerak
                    {
                        Izena = izena,
                        Deskribapena = deskribapena,
                        Mota = mota,
                        Platera_mota = plateraMota,
                        Prezioa = prezioa,
                        Menu = menu,
                        created_by = idUsuario,
                        created_at = DateTime.Now.ToString()
                    };

                    session.Save(platera);
                    transaction.Commit();
                    return platera;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return null;
                }
            }
        }

    }
}
