
using NHibernate;
using System;
using System.Linq;
using System.Windows;

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

        internal static string Platerak_Berreskuratu(ISessionFactory sessionFactory, int idUsuario, int id)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    // Recuperar el registro existente por ID
                    var platera = session.Query<Platerak>().FirstOrDefault(f => f.Id == id);
                    if (platera == null)
                    {
                        return "Error: El Plato con el ID especificado no existe.";
                    }

                    platera.deleted_at = "";
                    platera.deleted_by = 0;

                    session.Update(platera);
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

        internal static string Platerak_Ezabatu(ISessionFactory sessionFactory, int idUsuario, int id)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    // Recuperar el registro existente por ID
                    var platera = session.Query<Platerak>().FirstOrDefault(f => f.Id == id);
                    if (platera == null)
                    {
                        return "Error: El Plato con el ID especificado no existe.";
                    }

                    platera.deleted_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    platera.deleted_by = idUsuario;

                    session.Update(platera);
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
