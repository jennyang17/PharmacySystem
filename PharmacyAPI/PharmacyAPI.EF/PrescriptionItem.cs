using System;
using System.Collections.Generic;

namespace PharmacyAPI.EF
{
    public partial class PrescriptionItem
    {
        public int PrescriptionItemId { get; set; }
        public int PrescriptionId { get; set; }
        public int MedicineId { get; set; }
        public string Dosage { get; set; } = null!;
        public int Quantity { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Medicine Medicine { get; set; } = null!;
        public virtual Prescription Prescription { get; set; } = null!;
    }
}
