using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace MatHra
{
    [DelimitedRecord(",")]
    class Score
    {
        public int HighScore;

        [FieldConverter(ConverterKind.Date, "dd-MM-yyyy")]
        public DateTime Date;

        public Score(int Score, DateTime Date)
        {
            this.HighScore = Score;
            this.Date = Date;
        }

        public Score()
        {

        }

        public void AddScore(int level, int timer)
        {
            int timeBonus = 50 + level;

            if (timer > 5)
            {
                timeBonus = 100 + timer + level;
            }
        }
    }
}
