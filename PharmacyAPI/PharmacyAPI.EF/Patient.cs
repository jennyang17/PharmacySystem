﻿using System;
using System.Collections.Generic;

namespace PharmacyAPI.EF
{
    public partial class Patient
    {
        public Patient()
        {
            Prescriptions = new HashSet<Prescription>();
        }

        public int PatientId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string Address { get; set; } = null!;
        public string Nhsnumber { get; set; } = null!;
        public string Exemption { get; set; } = null!;
        public bool IsDeleted { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
