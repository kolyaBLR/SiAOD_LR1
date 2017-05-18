using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAOD_LR1
{
    public class Item
    {
        public int Number { get; set; }
        public int Power { get; set; }
        public Item Next { get; set; }
        public Item Back { get; set; }
    }
}