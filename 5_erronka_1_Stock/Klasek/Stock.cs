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
        public virtual string created_at { get; set; }
        public virtual int created_by { get; set; }
        public virtual string updated_at { get; set; }
        public virtual int updated_by { get; set; }
        public virtual string deleted_at { get; set; }
        public virtual int deleted_by { get; set; }

        public virtual IList<PlateraStock> PlateraStockak { get; set; } = new List<PlateraStock>();

        

    }

}
