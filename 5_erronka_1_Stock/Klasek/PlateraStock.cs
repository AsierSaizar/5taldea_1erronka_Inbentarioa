using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_erronka_1_Stock
{
    internal class PlateraStock
    {
        public virtual int Id { get; set; }
        public virtual Platerak Platera { get; set; }
        public virtual Stock Almazena { get; set; }
        public virtual int Kantitatea { get; set; }
    }

}
