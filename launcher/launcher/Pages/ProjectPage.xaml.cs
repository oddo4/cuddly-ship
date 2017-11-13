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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace launcher.Pages
{
    /// <summary>
    /// Interakční logika pro ProjectPage.xaml
    /// </summary>
    public partial class ProjectPage : Page
    {
        FolderBrowserDialog fBrowser = new FolderBrowserDialog();
        AppPath App = new AppPath();

        public ProjectPage(AppPath appPath)
        {
            InitializeComponent();
            App = appPath;
            labelCurrentPathValue.Content = App.AppDirPath.Remove(App.AppDirPath.Length - (App.Name.Length + 1));
        }

        private void buttonReturn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void buttonCopyProject_Click(object sender, RoutedEventArgs e)
        {
            fBrowser.ShowDialog();
            if (fBrowser.SelectedPath != "")
            {
                CopyProject(App.AppDirPath, fBrowser.SelectedPath + "\\" + App.Name);
                App.AppDirPath = fBrowser.SelectedPath + "\\" + App.Name;


                labelCurrentPathValue.Content = fBrowser.SelectedPath;
            }
        }

        private void buttonDeleteProject_Click(object sender, RoutedEventArgs e)
        {
            DeleteWindow deleteWindow = new DeleteWindow("Vážně si přejete smazat projekt?" ,0 ,App.AppDirPath);
            deleteWindow.ShowDialog();

            if (deleteWindow.ClickResult)
            {
                this.NavigationService.GoBack();
                AlertDialog alertDialog = new AlertDialog("Úspěšně smazáno.");
                alertDialog.ShowDialog();
            }

        }

        private void CopyProject(string SourcePath, string DestinationPath)
        {
            foreach (string dirPath in Directory.GetDirectories(SourcePath, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));

            foreach (string newPath in Directory.GetFiles(SourcePath, "*.*", SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);
        }

    }
}
