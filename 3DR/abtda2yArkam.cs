using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DR
{
    class abtda2yArkam
    {
        public int ID { get; set; }
        public string Arkam { get; set; }
        [ForeignKey("Abtda2Y")]
        public int Abtda2YId { get; set; }

        public virtual abtda2y Abtda2Y { get; set; }
    }
}
