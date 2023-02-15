using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem
{
    public class Prescription
    {
        public Prescription()
        {
            PrescriptionItems = new HashSet<PrescriptionItem>();
        }
        public DateTime Date { get; set; }
        public virtual Patient Patient { get; set; } = null!;
        public virtual ICollection<PrescriptionItem> PrescriptionItems { get; set; }
    }
}
