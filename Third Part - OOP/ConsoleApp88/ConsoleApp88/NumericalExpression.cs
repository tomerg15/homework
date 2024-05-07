using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp88
{
    class NumericalExpression<T>
    {
        private long value;
        public NumericalExpression(long value)
        {
            this.value = value;
        }

        public long GetValue()
        {
            return value;
        }

        public static int SumLetters(long number)
        {
            NumericalExpression<long> temp = new NumericalExpression<long>(number);
            return((temp.ToString().Replace(" ",string.Empty).Length));
        }

        public static int SumLetters(NumericalExpression<long> number) //7.f: OOP Principle which is used here is: Polymorphism (method overloading)
        {
            return ((number.GetValue().ToString().Replace(" ", string.Empty).Length));
        }

        private static string[] Ones = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        private static string[] Teens = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private static string[] Tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        private static string[] Thousands = { "", "Thousand", "Million", "Billion"};

        public override string ToString()
        {
            long valuetemp = value;
            string words = "";
            if (valuetemp == 0)
                return "Zero";

            for (int i = 0; valuetemp > 0; i++)
            {
                if (valuetemp % 1000 != 0)
                    words = NumberToHundreds(valuetemp % 1000) + Thousands[i] + " " + words;

                valuetemp /= 1000;
            }
            return words;

            static string NumberToHundreds(long valuetemp)
            {
                string words = "";
                if (valuetemp >= 100)
                {
                    words += Ones[valuetemp / 100] + " Hundred ";
                    valuetemp %= 100;
                }

                if (valuetemp >= 10 && valuetemp <= 19)
                {
                    words += Teens[valuetemp % 10] + " ";
                }

                else
                {
                    words += Tens[valuetemp / 10] + " ";
                    words += Ones[valuetemp % 10] + " ";
                }
                return words;
            }
        }
    }
}