using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DR
{
    class dolfColor
    {
        public int ID { get; set; }
        public string Color { get; set; }
        [ForeignKey("Product")]
        public int? Product_ID { get; set; }

        public virtual Product Product { get; set; }
    }
}
