using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calculator
{
    class Formula
    {
        string formula { get; set; }
        List <Number> numbers { get; set; }

        public Formula(string formula)
        {
            this.formula = formula;
            this.numbers = new List <Number>(0);
            this.numbers = Separation(formula);
        }

        private List <Number> Separation (string formula)
        {
            string stringNumbers = string.Empty;
            List<Number> tmp = new List <Number>(0);
            formula = formula.Replace('.', ',');
            for (int j = 0; j < formula.Length; j++)
            {
                if (j == 0 && formula[j] == '-')
                {
                    stringNumbers += '-';
                }
                else if (formula[j] == '-' && (formula[j - 1] == '+' || formula[j - 1] == '*' || formula[j - 1] == '/' || formula[j - 1] == '(' || formula[j - 1] == '^'))
                {
                    stringNumbers += '-';
                }
                else if (formula[j] == '-' || formula[j] == '+')
                {
                    tmp.Add(new Number (Convert.ToDouble(stringNumbers), Convert.ToChar(formula[j])));
                    stringNumbers = string.Empty;
                }
                else if (formula[j] == '*' || formula[j] == '/')
                {
                    tmp.Add(new Number(Convert.ToDouble(stringNumbers), Convert.ToChar(formula[j])));
                    stringNumbers = string.Empty;
                }
                else if (formula[j] == '0' || formula[j] == '1' || formula[j] == '2' || formula[j] == '3' || formula[j] == '4' || formula[j] == '5' || formula[j] == '6'
                    || formula[j] == '7' || formula[j] == '8' || formula[j] == '9' || formula[j] == '.' || formula[j] == ',')
                {
                    stringNumbers += formula[j];
                }
                if (formula[j] == '=' && j == formula.Length-1)
                {
                    tmp.Add(new Number(Convert.ToDouble(stringNumbers), '='));
                }
            }
            return tmp;
        }

        public double Calculation ()
        {
            //this.Print();
            List<Number> tmp = new List<Number>(0);
            tmp = this.numbers;
            double itog = 0;
            while (tmp.Count() != 1)
            {
                if (tmp.Exists(x => x.Symbols == '*') || tmp.Exists(x => x.Symbols == '/'))
                        {
                    if (tmp.Exists(x => x.Symbols == '*'))
                    {
                        itog = tmp[tmp.FindIndex(x => x.Symbols.Equals('*'))].Numbers * tmp[tmp.FindIndex(x => x.Symbols.Equals('*')) + 1].Numbers;
                        tmp[tmp.FindIndex(x => x.Symbols.Equals('*')) + 1].Numbers = itog;
                        tmp.RemoveAt(tmp.FindIndex(x => x.Symbols.Equals('*')));
                    }
                    else 
                    {
                        itog = tmp[tmp.FindIndex(x => x.Symbols.Equals('/'))].Numbers / tmp[tmp.FindIndex(x => x.Symbols.Equals('/')) + 1].Numbers;
                        tmp[tmp.FindIndex(x => x.Symbols.Equals('/')) + 1].Numbers = itog;
                        tmp.RemoveAt(tmp.FindIndex(x => x.Symbols.Equals('/')));
                    }
                }
                else
                {
                    if (tmp[0].Symbols == '+')
                    {
                        itog = tmp[tmp.FindIndex(x => x.Symbols.Equals('+'))].Numbers + tmp[tmp.FindIndex(x => x.Symbols.Equals('+')) + 1].Numbers;
                        tmp[tmp.FindIndex(x => x.Symbols.Equals('+')) + 1].Numbers = itog;
                        tmp.RemoveAt(tmp.FindIndex(x => x.Symbols.Equals('+')));
                    }
                    else if (tmp[0].Symbols == '-')
                    {
                        itog = tmp[tmp.FindIndex(x => x.Symbols.Equals('-'))].Numbers - tmp[tmp.FindIndex(x => x.Symbols.Equals('-')) + 1].Numbers;
                        tmp[tmp.FindIndex(x => x.Symbols.Equals('-')) + 1].Numbers = itog;
                        tmp.RemoveAt(tmp.FindIndex(x => x.Symbols.Equals('-')));
                    }
                }
            }
            return itog;
        }

        public void Print ()
        {
            foreach (Number item in this.numbers)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
        }
    }
}
