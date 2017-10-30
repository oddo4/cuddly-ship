using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatHra
{
    class Example
    {
        public int Number1;
        public int Number2;
        public string ExampleString;
        public int MathOperator;
        public int Answer;
        public int ExampleCount = 1;

        public Example()
        {

        }

        public Example(int number1, int number2, int mathOperator, int exampleCount)
        {
            this.Number1 = number1;
            this.Number2 = number2;
            this.MathOperator = mathOperator;
            this.ExampleCount = exampleCount;
        }

        public void CreateExample()
        {
            switch (MathOperator)
            {
                case 1: // +
                    ExampleString = Number1 + " + " + Number2;
                    Answer = Number1 + Number2;
                    break;
                case 2: // -
                    ExampleString = Number1 + " - " + Number2;
                    Answer = Number1 - Number2;
                    break;
                case 3: // *
                    ExampleString = Number1 + " * " + Number2;
                    Answer = Number1 * Number2;
                    break;
            }
        }

    }
}
