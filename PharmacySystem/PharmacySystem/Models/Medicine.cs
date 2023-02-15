using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem
{
    public class Medicine
    {
        public Medicine()
        {
            PrescriptionItems = new HashSet<PrescriptionItem>();
        }

        public string Name { get; set; } = null!;
        public string Strength { get; set; } = null!;
        public string Formulation { get; set; } = null!;

        public virtual ICollection<PrescriptionItem> PrescriptionItems { get; set; }
    }
}
