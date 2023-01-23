using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem
{
    public class Patients
    {
        public string Name { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string Address { get; set; } = null!;
        public string Nhsnumber { get; set; } = null!;
        public string Exemption { get; set; } = null!;
    }
}
