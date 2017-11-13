using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace launcher
{
    /// <summary>
    /// Interakční logika pro DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : MetroWindow
    {
        public bool ClickResult = false;
        public List<DirPath> PathsList;

        string projectDirPath;
        int index;
        int Condition;

        public DeleteWindow(string message, int condition, string dirPath = "", List<DirPath> pathsList = null, int i = -1)
        {
            InitializeComponent();
            labelDeleteAlert.Content = message;
            Condition = condition;

            switch (condition)
            {
                case 0:
                    projectDirPath = dirPath;
                    break;
                case 1:
                    PathsList = pathsList;
                    index = i;
                    break;
            }
        }

        private void buttonDeleteAccept_Click(object sender, RoutedEventArgs e)
        {
            switch (Condition)
            {
                case 0:
                    Directory.Delete(projectDirPath, true);
                    break;
                case 1:
                    PathsList.RemoveAt(index);
                    break;
            }
            
            ClickResult = true;
            this.Close();
        }

        private void buttonDeleteDecline_Click(object sender, RoutedEventArgs e)
        {
            ClickResult = false;
            this.Close();
        }
    }
}
