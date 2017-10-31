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
using System.Diagnostics;

namespace MatHra
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random rnd = new Random();
        int level = 1;
        int i = 10;
        int comboStreak = 0;
        int multiplier = 1;
        ObservableCollection<int> loadhighscores = new ObservableCollection<int>();
        List<Score> scoresList = new List<Score>();
        Score currentScore = new Score();
        FileHelper fileData = new FileHelper();
        Example example = new Example();
        Life lives = new Life();

        public MainWindow()
        {
            InitializeComponent();

            readFile();

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
        
        private void readFile()
        {
            if (fileData.ReadFileData(loadhighscores, scoresList))
            {
                listViewHighScores.ItemsSource = loadhighscores;
            }
            else
            {
                Score noscore = new Score(0, DateTime.MinValue);
                scoresList.AddRange(Enumerable.Repeat(noscore, 10));
                fileData.WriteFileData(scoresList);

                fileData.ReadFileData(loadhighscores, scoresList);

                listViewHighScores.ItemsSource = loadhighscores;
            }
        }

        private void randomExample()
        {
            int mathOperator = rnd.Next(1, 4);
            int number1 = rnd.Next(1, 11)*level;
            int number2 = rnd.Next(1, 11)*level;
            int answerRnd = rnd.Next(0, 10);

            example = new Example(number1, number2, mathOperator, example.ExampleCount);
            example.CreateExample();

            labelMathExampleCount.Content = "Příklad č. " + example.ExampleCount;
            labelAnswersCount.Content = currentScore.AnswersCount;
            labelMathExample.Content = example.ExampleString;

            switch (answerRnd % 2)
            {
                case 0:
                    buttonAnswer1.Content = example.Answer;
                    buttonAnswer2.Content = example.Answer + rnd.Next(1, 10);
                    break;
                case 1:
                    buttonAnswer1.Content = example.Answer + rnd.Next(1, 10);
                    buttonAnswer2.Content = example.Answer;
                    break;
            }

        }

        private void progressStatus()
        {
            progressLevelStatus.Value += 20 / level;

            if ((int) progressLevelStatus.Value == 100)
            {
                progressLevelStatus.Value = 0;
                level++;
                if (lives.Lives < 3)
                {
                    lives.AddLife(labelLives);
                }
                labelLevelStatus.Content = "Úroveň " + level;      
            }
        }

        private void checkAnswer(int buttonAnswer)
        {
            if (buttonAnswer == example.Answer)
            {
                labelAlert.Content = "Správně!";
                currentScore.AnswersCount++;
                comboStreak = currentScore.AddScore(level, i, comboStreak, multiplier);
                progressStatus();
                labelScore.Content = currentScore.HighScore;
                resetTimer();
            }
            else
            {
                labelAlert.Content = "Špatně!";
                comboStreak = 0;
                if (lives.LoseLife(labelLives))
                {
                    i = 0;
                    gameOver();
                }
            }

            example.ExampleCount++;
        }

        private void timer(DispatcherTimer t, int c)
        {
            if (lives.Lives == 0)
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
                    comboStreak = 0;
                    resetTimer();
                    if (lives.LoseLife(labelLives))
                    {
                        i = 0;
                        gameOver();
                    }
                    labelTimer.Content = i.ToString();
                    randomExample();
                }
            }
        }

        private void resetTimer()
        {
            if (comboStreak > 30)
            {
                i = 5;
                multiplier = 4;
            }
            else if (comboStreak > 5)
            {
                i = 5;
                multiplier = 2;
            }
            else
            {
                i = 10;
                multiplier = 1;
            }
        }

        public void gameOver()
        {
            buttonAnswer1.IsEnabled = false;
            buttonAnswer2.IsEnabled = false;

            currentScore.Date = DateTime.Now;
            
            List<Score> updatedScoreList = currentScore.HighScoreSave(currentScore, scoresList);

            listViewHighScores.ItemsSource = null;

            fileData.WriteFileData(updatedScoreList);

            readFile();
        }
    }
}
