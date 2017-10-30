using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MatHra
{
    class Life
    {
        public int Lives = 3;

        public void AddLife(Label labelLives)
        {
            if (Lives < 3)
            {
                Lives++;
            }

            labelLives.Content = new string('♥', Lives);
        }

        public bool LoseLife(Label labelLives)
        {
            Lives--;
            labelLives.Content = new string('♥', Lives);
            if (Lives == 0)
            {
                return true;
            }

            return false;
        }
    }
}
