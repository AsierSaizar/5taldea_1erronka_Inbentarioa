using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_erronka_1_Stock
{
    internal class Platerak
    {
        public virtual int Id { get; set; }
        public virtual string Izena { get; set; }
        public virtual string Deskribapena { get; set; }
        public virtual string Mota { get; set; }
        public virtual string Platera_mota { get; set; }
        public virtual int Prezioa { get; set; }
        public virtual int Kantidadea { get; set; }
        public virtual Boolean Menu { get; set; }
    }
}
