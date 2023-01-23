using System;
using System.Collections.Generic;

namespace PharmacyAPI.EF
{
    public partial class Prescriber
    {
        public Prescriber()
        {
            Prescriptions = new HashSet<Prescription>();
        }

        public int PrescriberId { get; set; }
        public string Name { get; set; } = null!;
        public string TypeOfPrescriber { get; set; } = null!;
        public string PrescriberAddress { get; set; } = null!;
        public bool IsDeleted { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
