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
        public int AnswersCount;

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

        public int AddScore(int level, int timer, int comboStreak, int multiplier)
        {
            int timeBonus;
            int minLimit = 5;
            int maxLimit = 7;
            
            if (comboStreak > 5)
            {
                minLimit = 2;
                maxLimit = 4;
            }
            else if (comboStreak > 10)
            {
                minLimit = 1;
                maxLimit = 2;
            }


            if (timer > minLimit)
            {
                timeBonus = (100 * multiplier) + (level * timer);
                comboStreak++;
            }
            else if (timer > maxLimit)
            {
                timeBonus = (120 * multiplier) + (level * timer);
                comboStreak++;
            }
            else
            {
                timeBonus = 20 + level;
            }

            HighScore += 100 + timeBonus;

            return comboStreak;
        }

        public List<Score> HighScoreSave(Score recentScore, List<Score> scoresList)
        {
            List<Score> result = new List<Score>();
            bool addedScore = false;

            for (int i = 0; i < 10; i++)
            {
                if (scoresList[i].HighScore < recentScore.HighScore && addedScore == false)
                {
                    result.Add(recentScore);
                    addedScore = true;
                }
                else if (addedScore == true)
                {
                    result.Add(scoresList[i - 1]);
                }
                else
                {
                    result.Add(scoresList[i]);
                }
            }

            return result;
        }
    }
}
