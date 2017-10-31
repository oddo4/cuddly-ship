using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;
using System.Collections.ObjectModel;

namespace MatHra
{
    class FileHelper
    {
        private string fileName = "MatHraFile.csv";

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public FileHelper()
        {

        }

        public FileHelper(string FileName)
        {
            this.fileName = FileName;
        }

        public bool ReadFileData(ObservableCollection<int> loadhighscores, List<Score> highscoresList)
        {
            var engine = new FileHelperEngine<Score>();

            try
            {
                var data = engine.ReadFile(fileName);

                if (data.Any())
                {
                    foreach (Score highscore in data)
                    {
                        highscoresList.Add(highscore);
                        loadhighscores.Add(highscore.HighScore);
                    }

                    return true;
                }
                
            }
            catch
            {
                
            }

            return false;
        }

        public bool WriteFileData(List<Score> highscoresList)
        {
            var engine = new FileHelperEngine<Score>();

            try
            {
                engine.WriteFile(fileName, highscoresList);
                return true;
            }
            catch
            {

            }  

            return false;
        }
    }
}
