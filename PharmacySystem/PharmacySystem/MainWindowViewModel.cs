using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            Name = "TestName";
        }
        public string Name { get; set; }
    }
}
