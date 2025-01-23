using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _5_erronka_1_Stock.Kudeatzaileak
{
    internal class Stock_Kudeatzailea
    {
        /*
        internal static Boolean Stock_Sortu(string izena, string mota, string ezaugarriak, int stock_Kant, string unitatea, int min, int max, ISession mySession, ISessionFactory mySessionFactory)
        {
            
            using (var transaction = mySessionFactory.BeginTransaction())
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
                        Max = max
                    };
                    mySession.Save(produktua);
                    transaction.Commit();  // Asegúrate de confirmar la transacción
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();  // Si hay un error, revierte la transacción
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }   
        */
    }
}
