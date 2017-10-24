using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using FileHelpers;
using System.Collections.ObjectModel;

namespace MatHra
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random rnd = new Random();
        int level = 1;
        int mathOperator;
        int answer;
        int answersCount;
        int answerRnd;
        int number1;
        int number2;
        int i = 5;
        int lives = 3;
        int score = 0;
        ObservableCollection<int> loadhighscores = new ObservableCollection<int>();
        List<Score> scoresList = new List<Score>();

        public MainWindow()
        {
            InitializeComponent();
            labelLevelStatus.Content = "Úroveň " + level;
            highScoreLoad(loadhighscores, scoresList);
            randomExample();
            labelTimer.Content = i.ToString();

            DispatcherTimer t = new DispatcherTimer();
            t.Interval = new TimeSpan(0, 0, 1);
            t.Tick += (sender, args) => { timer(t,i); };

            t.Start();
        }

        private void buttonAnswer1_Click(object sender, RoutedEventArgs e)
        {
            checkAnswer((int)buttonAnswer1.Content);
            labelTimer.Content = i.ToString();
            randomExample();
        }

        private void buttonAnswer2_Click(object sender, RoutedEventArgs e)
        {
            checkAnswer((int) buttonAnswer2.Content);
            labelTimer.Content = i.ToString();
            randomExample();
        }

        private void randomExample()
        {
            mathOperator = rnd.Next(1, 5);
            number1 = rnd.Next(1, 11)*level;
            number2 = rnd.Next(1, 11)*level;
            answerRnd = rnd.Next(0, 2);


            switch (mathOperator)
            {
                case 1: // +
                    labelMathExample.Content = number1 + " + " + number2;
                    answer = number1 + number2;
                    break;
                case 2: // -
                    labelMathExample.Content = number1 + " - " + number2;
                    answer = number1 - number2;
                    break;
                case 3: // *
                    labelMathExample.Content = number1 + " * " + number2;
                    answer = number1 * number2;
                    break;
                /*case 4: // /
                    labelMathExample.Content = number1 + " / " + number2;
                    answer = number1 / number2;
                    break;*/
            }

            switch (answerRnd)
            {
                case 0:
                    buttonAnswer1.Content = answer;
                    buttonAnswer2.Content = answer + rnd.Next(1, 10);
                    break;
                case 1:
                    buttonAnswer1.Content = answer + rnd.Next(1, 10);
                    buttonAnswer2.Content = answer;
                    break;
            }

        }

        private void progressStatus()
        {
            progressLevelStatus.Value += 10 / level;

            if ((int) progressLevelStatus.Value == 100)
            {
                progressLevelStatus.Value = 0;
                level++;
                if (lives < 3)
                {
                    lives++;
                    labelLives.Content = new string('♥', lives);
                }
                labelLevelStatus.Content = "Úroveň " + level;      
            }
        }

        private void checkAnswer(int buttonAnswer)
        {
            if (buttonAnswer == answer)
            {
                labelAlert.Content = "Správně!";
                answersCount++;
                score += 100;
                labelScore.Content = score;
                progressStatus();
                i = 5;
            }
            else
            {
                labelAlert.Content = "Špatně!";
                loseLife();
            }
        }

        private void timer(DispatcherTimer t, int c)
        {
            if (lives == 0)
            {
                t.Stop();
            }
            else
            {
                i--;
                labelTimer.Content = i.ToString();

                if (i == 0)
                {
                    labelAlert.Content = "Time out!";
                    i = 5;
                    loseLife();
                    labelTimer.Content = i.ToString();
                    randomExample();
                }
            }
        }

        public void loseLife()
        {
            lives--;
            labelLives.Content = new string('♥', lives);
            if (lives == 0)
            {
                i = 0;
                gameOver();
            }
            else
            {
                i = 5;
            }
        }

        private void addLife()
        {
            lives++;
            labelLives.Content = new string('♥', lives);
        }

        private void highScoreLoad(ObservableCollection<int> loadhighscores, List<Score> highscoresList)
        {
            var engine = new FileHelperEngine<Score>();

            var result = engine.ReadFile("MatHraFile.csv");

            foreach (Score highscore in highscoresList)
            {
                highscore.Add(new Score(highscore.HighScore, highscore.Date));
                loadhighscores.Add(highscore.HighScore);
            }

            listViewHighScores.ItemsSource = loadhighscores;

        }

        public void highScoreSave()
        {
            var engine = new FileHelperEngine<Score>();
            Score test = new Score();

            test.HighScore = score;
            test.Date = DateTime.Now;

            List<Score> result = new List<Score>();
            result.Add(test);

            engine.WriteFile("MatHraFile.csv", result);
        }

        public void gameOver()
        {

        }
    }
}
