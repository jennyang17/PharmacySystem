using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem
{
    public class PrescriptionItem
    {
        public string Dosage { get; set; } = null!;
        public int Quantity { get; set; }
        public virtual Medicine Medicine { get; set; } = null!;
        public virtual Prescription Prescription { get; set; } = null!;
    }
}
