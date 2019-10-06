using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DR
{
    class Accesories
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("Nha2")]
        public int Nha2Id { get; set; }

        public virtual Nha2y Nha2 { get; set; }

    }
}
