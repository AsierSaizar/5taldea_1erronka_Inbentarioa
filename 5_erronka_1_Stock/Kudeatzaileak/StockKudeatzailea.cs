using NHibernate;
using System;
using System.Linq;

namespace _5_erronka_1_Stock.Kudeatzaileak
{
    internal class StockKudeatzailea
    {
        internal static string StockBete(ISessionFactory sessionFactory, int idUsuario, int id, int stockKant)
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
                        return "Error: El producto con el ID especificado no existe.";
                    }

                    produktua.Stock_Kant = stockKant;

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

        internal static string Stock_Berreskuratu(ISessionFactory sessionFactory, int idUsuario, int id)
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
                        return "Error: El producto con el ID especificado no existe.";
                    }

                    produktua.deleted_at = "";
                    produktua.deleted_by = 0;

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

        internal static string Stock_Eraldatu(ISessionFactory sessionFactory, int idUsuario, int id, string izena, string mota, string ezaugarriak, int stock_Kant, string unitatea, int min, int max)
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

        internal static string Stock_Ezabatu(ISessionFactory sessionFactory, int idUsuario, int id)
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
                        return "Error: El producto con el ID especificado no existe.";
                    }

                    produktua.deleted_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    produktua.deleted_by = idUsuario;

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

        internal static string Stock_Sortu(ISessionFactory sessionFactory, int idUsuario, string izena, string mota, string ezaugarriak, int stock_Kant, string unitatea, int min, int max)
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
                        created_by = idUsuario

                    };
                    session.Save(produktua);
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
