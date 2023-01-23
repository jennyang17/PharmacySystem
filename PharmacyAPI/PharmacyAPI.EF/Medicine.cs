using System;
using System.Collections.Generic;


namespace PharmacyAPI.EF
{
    public partial class Medicine
    {
        public Medicine()
        {
            PrescriptionItems = new HashSet<PrescriptionItem>();
        }

        public int MedicineId { get; set; }
        public string Name { get; set; } = null!;
        public string Strength { get; set; } = null!;
        public string Formulation { get; set; } = null!;
        public bool IsDeleted { get; set; }

        public virtual ICollection<PrescriptionItem> PrescriptionItems { get; set; }
    }
}
