using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DR
{
    class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("categories")]
        public int? Categories_ID { get; set; }

        public virtual Category categories { get; set; }
        public virtual ICollection<dolfColor> DolfColors { get; set; } = new List<dolfColor>();
    }
}
