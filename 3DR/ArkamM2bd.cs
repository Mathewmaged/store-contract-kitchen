using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DR
{
    class ArkamM2bd
    {
        public int ID { get; set; }
        public string Arkam { get; set; }
        [ForeignKey("Nha2")]
        public int Nha2Id { get; set; }

        public virtual Nha2y Nha2 { get; set; }
    }
}
