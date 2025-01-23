using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_erronka_1_Stock
{
    internal class Stock
    {
        public virtual int Id { get; set; }
        public virtual string Izena { get; set; }
        public virtual string Mota { get; set; }
        public virtual string Ezaugarriak { get; set; }
        public virtual int Stock_Kant { get; set; }
        public virtual string Unitatea { get; set; }
        public virtual int Min { get; set; }
        public virtual int Max { get; set; }
    }
}
