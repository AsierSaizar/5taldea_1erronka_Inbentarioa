using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_erronka_1_Stock.Kudeatzaileak
{
    internal class LangileaKudeatzailea
    {
        internal static int Login(ISessionFactory sessionFactory, string email, string pasahitza)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    // Crear la consulta HQL para buscar al usuario
                    string hql = "FROM Langilea WHERE Emaila = :email AND Pasahitza = :pasahitza AND Nivel_permisos = 0";
                    IQuery query = session.CreateQuery(hql);
                    query.SetParameter("email", email);
                    query.SetParameter("pasahitza", pasahitza);

                    // Ejecutar la consulta y obtener el resultado
                    var user = query.UniqueResult<Langilea>();
                    int idUsuario = user.Id;
                    if (user != null)
                    {
                        // Usuario encontrado
                        return idUsuario;
                        
                    }
                    else
                    {
                        // Usuario no encontrado
                        return 0;
                    }

                    
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return -0;
                }
            }
        }
    }
}
