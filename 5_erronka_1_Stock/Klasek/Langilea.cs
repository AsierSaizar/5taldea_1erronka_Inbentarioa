using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_erronka_1_Stock
{
    internal class Langilea
    {
        public virtual int Id { get; set; }
        public virtual string Emaila { get; set; }
        public virtual string Pasahitza { get; set; }
        public virtual int Nivel_permisos { get; set; }
    }
}