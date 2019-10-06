using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DR
{
    class Nha2y
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string clientAddress { get; set; }
        public string PlaceAddress { get; set; }
        public string Phone { get; set; }
        public string nationalId { get; set; }
        public decimal totalPrice { get; set; }
        public string totalPriceText { get; set; }
        public decimal dof3aMokdma { get; set; }
        public string dof3aMokdmaText { get; set; }
        public string tare5t3akod { get; set; }
        public string tare5astlam { get; set; }
        public string modelElmtb5 { get; set; }
        public decimal meterPrice { get; set; }
        public int metersNumber { get; set; }
        public int mfslatNumber { get; set; }
        public int mgaryNumber { get; set; }
        public decimal totalmetermatb5 { get; set; }
        public decimal totalmfslat { get; set; }
        public decimal totalmgary { get; set; }
        public string modelelmfslat { get; set; }
        public decimal mfslatPrice { get; set; }
        public string modelMgary { get; set; }
        public decimal mgaryPrice { get; set; }
        public string da5ly { get; set; }
        public string m2bd { get; set; }
        public decimal totalAccessories { get; set; }
        public string Notes { get; set; }

        //public virtual rf3m2asat Rf3 { get; set; }
        public virtual ICollection<ArkamM2bd> Arkam { get; set; } = new List<ArkamM2bd>();
        public virtual ICollection<Accesories> Accesories { get; set; } = new List<Accesories>();
    }
}
