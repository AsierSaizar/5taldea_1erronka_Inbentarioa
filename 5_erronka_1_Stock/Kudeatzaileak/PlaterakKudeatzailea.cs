
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

        internal static void PlateraEraldatu(ISessionFactory sessionFactory, int idUsuario, int idPlatera, string izena, string deskribapena, string mota, string plateraMota, int prezioa, int menu)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    // Obtener el registro existente con el idPlatera
                    var platera = session.Get<Platerak>(idPlatera);

                    // Verificar si el registro existe
                    if (platera != null)
                    {
                        // Actualizar los campos del registro
                        platera.Izena = izena;
                        platera.Deskribapena = deskribapena;
                        platera.Mota = mota;
                        platera.Platera_mota = plateraMota;
                        platera.Prezioa = prezioa;
                        platera.Menu = menu;
                        platera.updated_by = idUsuario;
                        platera.updated_at = DateTime.Now.ToString();

                        // Guardar los cambios en la base de datos
                        session.Update(platera);
                        transaction.Commit();
                    }
                    else
                    {
                        // Si el registro no se encuentra, puedes manejar el error o lanzar una excepción
                        throw new Exception("Platera no encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    // En caso de error, realizar un rollback
                    transaction.Rollback();
                    // Aquí puedes manejar el error, por ejemplo, loguear el mensaje
                    Console.WriteLine(ex.Message);
                }
            }
        }

        internal static void PlaterarenErlazioakEzabatu(ISessionFactory sessionFactory, int idPlatera)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    // Obtener todos los registros de PlateraStock que estén relacionados con el idPlatera
                    var plateraStocks = session.Query<PlateraStock>()
                                               .Where(ps => ps.Platera.Id == idPlatera)
                                               .ToList();

                    // Eliminar todos los registros encontrados
                    foreach (var plateraStock in plateraStocks)
                    {
                        session.Delete(plateraStock);
                    }

                    // Confirmar la transacción
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // En caso de error, realizar rollback
                    transaction.Rollback();
                    // Manejar el error, por ejemplo, loguearlo
                    Console.WriteLine(ex.Message);
                }
            }
        }


    }
}
