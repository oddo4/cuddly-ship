using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF1
{
    class Person
    {
        private string name = String.Empty;
        private string surname = String.Empty;

        public Person(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }

        public override string ToString()
        {
            return name;
        }

    }
}
