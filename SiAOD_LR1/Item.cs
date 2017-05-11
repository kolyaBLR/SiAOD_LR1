using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAOD_LR1
{
    class Item
    {
        public int number { get; set; }
        public int power { get; set; }
        public Item Next { get; set; }
        public Item Back { get; set; }

        public Item() { }

        public Item(int number, int power)
        {
            this.number = number;
            this.power = power;
        }
    }
}