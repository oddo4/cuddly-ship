using System;
using System.Collections.Generic;
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

namespace launcher.Pages
{
    /// <summary>
    /// Interakční logika pro MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        List<DirPath> pathsListData = new List<DirPath>();
        DirPath allAppPaths = new DirPath();
        List<string> exeNames = new List<string>();

        public MainPage()
        {
            InitializeComponent();
            FileHelper fileData = new FileHelper();
            DirectoryInfo[] directories;

            fileData.ReadFileData(pathsListData);

            for (int i = 0; i < pathsListData.Count; i++)
            {
                var dirinfo = new DirectoryInfo(@pathsListData[i].DirPathString);
                directories = dirinfo.GetDirectories();

                foreach (var dir in directories)
                {
                    findingExe(dir.FullName, 0, "*.sln", SearchOption.TopDirectoryOnly);
                }

            }

            for (int j = 0; j < allAppPaths.AppList.Count; j++)
            {
                findingExe(allAppPaths.AppList[j].AppDirPath, j, "*.exe", SearchOption.AllDirectories);
            }

            listViewApps.ItemsSource = exeNames;
        }

        public void findingExe(string SearchPath, int j, string pattern, SearchOption searchOption)
        {
            var fileinfo = new DirectoryInfo(@SearchPath);
            FileInfo[] files = fileinfo.GetFiles(pattern, searchOption);

            if (files.Length > 0)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    switch (pattern)
                    {
                        case "*.sln":
                            AppPath appPath = new AppPath(System.IO.Path.GetFileNameWithoutExtension(files[i].Name), SearchPath);
                            appPath.AddSlnPath(files[i].FullName);

                            allAppPaths.AddAppList(appPath);

                            exeNames.Add(appPath.Name);

                            break;
                        case "*.exe":
                            if (allAppPaths.AppList[j].Name == System.IO.Path.GetFileNameWithoutExtension(files[i].Name))
                            {
                                allAppPaths.AppList[j].AddExePath(files[i].FullName);
                            }

                            break;
                    }
                }
            }
        }

        private void listViewApps_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listViewExePaths.ItemsSource = allAppPaths.AppList[listViewApps.SelectedIndex].ExePaths;
            buttonAboutProject.IsEnabled = true;

            ButtonAppEnabled(false);
        }

        private void listViewExePaths_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonAppEnabled(true);
        }

        private void buttonEditPaths_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PathsPage(pathsListData));
        }

        private void buttonAboutProject_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ProjectPage(allAppPaths.AppList[listViewApps.SelectedIndex]));
        }

        private void buttonAboutApp_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AppPage(allAppPaths.AppList[listViewExePaths.SelectedIndex].ExePaths.Count, listViewExePaths.SelectedIndex, allAppPaths.AppList[listViewApps.SelectedIndex].AppDirPath, allAppPaths.AppList[listViewApps.SelectedIndex].Name));
        }

        private void buttonLaunch_Click(object sender, RoutedEventArgs e)
        {
            ProgramStart(allAppPaths.AppList[listViewApps.SelectedIndex].ExePaths[listViewExePaths.SelectedIndex]);
        }

        private void ProgramStart(string programPath)
        {
            Process.Start(@programPath);
        }

        private void ButtonAppEnabled(bool enable)
        {
            if (enable)
            {
                buttonAboutApp.IsEnabled = true;
                buttonLaunch.IsEnabled = true;

            }
            else
            {
                buttonAboutApp.IsEnabled = false;
                buttonLaunch.IsEnabled = false;
            }
        }
    }
}
