using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace launcher
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<CorePath> pathsList = new List<CorePath>();
        ObservableCollection<AppPath> PathsColl = new ObservableCollection<AppPath>();
        List<string> exeNames = new List<string>();
        string fileName = "";

        public MainWindow()
        {
            InitializeComponent();
            File fileData = new File();
            DirectoryInfo[] directories;
            FileInfo[] files;

            fileData.ReadFileData(pathsList);

            foreach (CorePath data in pathsList)
            {
                var dirinfo = new DirectoryInfo(@data.PathString);
                directories = dirinfo.GetDirectories();
                files = dirinfo.GetFiles();

                var carMake = files
                .Where(item => item.Extension == ".sln")
                .Select(item => item);

                foreach (var item in carMake)
                {
                    fileName = System.IO.Path.GetFileNameWithoutExtension(item.Name);
                }

                findingExe(directories);

            }

            foreach (AppPath data in PathsColl)
            {
                exeNames.Add(data.Name);
            }

            listViewExes.ItemsSource = exeNames;
        }

        public void findingExe(DirectoryInfo[] directories)
        {
            for (int i = 0; i < directories.Length; i++)
            {
                var fileinfo = new DirectoryInfo(@directories[i].FullName);
                FileInfo[] files = fileinfo.GetFiles("*.exe",SearchOption.AllDirectories);

                if (files.Length > 0)
                {
                    var carMake1 = files
                .Where(item => item.Extension == ".exe")
                .Select(item => item);

                    AppPath appPath = new AppPath(fileName);

                    foreach (var item in carMake1)
                    {
                        if (fileName == System.IO.Path.GetFileNameWithoutExtension(item.Name))
                        {
                            appPath.AddPath(item.FullName);
                        }
                    }

                    PathsColl.Add(appPath);
                }
            }
        }

        private void listViewExes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listViewPaths.ItemsSource = PathsColl[listViewExes.SelectedIndex].ExePaths;
        }

        private void listViewPaths_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttonLaunch.IsEnabled = true;
        }

        private void buttonLaunch_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(@PathsColl[listViewExes.SelectedIndex].ExePaths[listViewPaths.SelectedIndex]);
        }
    }
}
