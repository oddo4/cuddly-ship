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

        public Score(int HighScore, DateTime Date)
        {
            this.HighScore = HighScore;
            this.Date = Date;
        }

        public Score()
        {

        }
    }
}
