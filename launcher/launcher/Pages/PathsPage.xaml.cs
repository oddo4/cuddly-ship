using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace launcher.Pages
{
    /// <summary>
    /// Interakční logika pro PathsPage.xaml
    /// </summary>
    public partial class PathsPage : Page
    {
        FolderBrowserDialog fBrowser = new FolderBrowserDialog();
        List<DirPath> pathsListData;
        List<string> pathsList;

        public PathsPage(List<DirPath> paths)
        {
            InitializeComponent();
            pathsListData = paths;

            UpdatePaths(pathsListData);

           /* DirPath test = new DirPath();
            test.DirPathString = "C:\\Users\\Filip\\Desktop\\School\\VAH\\git_old\\";

            pathsListData.Add(test);*/

        }

        private void buttonReturn_Click(object sender, RoutedEventArgs e)
        {
            FileHelper fileData = new FileHelper();

            fileData.WriteFileData(pathsListData);

            this.NavigationService.GoBack();
        }

        private void buttonAddPath_Click(object sender, RoutedEventArgs e)
        {
            fBrowser.ShowDialog();
            if (fBrowser.SelectedPath != "")
            {
                DirPath dirPath = new DirPath(fBrowser.SelectedPath + "\\");

                pathsListData.Add(dirPath);

                AlertDialog alertDialog = new AlertDialog("Úspěšně přidáno.");
                alertDialog.ShowDialog();

                UpdatePaths(pathsListData);
            }
        }

        private void buttonDeletePath_Click(object sender, RoutedEventArgs e)
        {
            DeleteWindow deleteWindow = new DeleteWindow("Vážně si přejete odebrat cestu?" ,1 ,"" ,pathsListData ,listViewDirPaths.SelectedIndex);
            deleteWindow.ShowDialog();

            if (deleteWindow.ClickResult)
            {
                AlertDialog alertDialog = new AlertDialog("Úspěšně smazáno.");
                alertDialog.ShowDialog();

                pathsListData = deleteWindow.PathsList;

                UpdatePaths(pathsListData);
            }
        }

        private void buttonSavePaths_Click(object sender, RoutedEventArgs e)
        {
            FileHelper fileData = new FileHelper();

            fileData.WriteFileData(pathsListData);

            AlertDialog alertDialog = new AlertDialog("Úspěšně uloženo.");
            alertDialog.ShowDialog();
        }

        private void UpdatePaths(List<DirPath> pathsListData)
        {
            pathsList = new List<string>();

            foreach (DirPath path in pathsListData)
            {
                pathsList.Add(path.DirPathString);
            }

            listViewDirPaths.ItemsSource = pathsList;
        }
    }
}
