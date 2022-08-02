using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Number
    {
        public double Numbers { get; set; }
        public char Symbols { get; set; }

        public Number (double num=0.0, char symbols = '=')
        {
            Numbers = num;
            Symbols = symbols;
        }

        public override string ToString ()
        {
            return $"Value: {this.Numbers} Symbol: {this.Symbols}";
        }
    }
}
