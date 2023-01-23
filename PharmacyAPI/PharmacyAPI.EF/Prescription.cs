using System;
using System.Collections.Generic;

namespace PharmacyAPI.EF
{
    public partial class Prescription
    {
        public Prescription()
        {
            PrescriptionItems = new HashSet<PrescriptionItem>();
        }

        public int PrescriptionId { get; set; }
        public int PatientId { get; set; }
        public int PrescriberId { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Patient Patient { get; set; } = null!;
        public virtual Prescriber Prescriber { get; set; } = null!;
        public virtual ICollection<PrescriptionItem> PrescriptionItems { get; set; }
    }
}
