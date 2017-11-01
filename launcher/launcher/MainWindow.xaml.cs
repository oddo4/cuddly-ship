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
        List<DirPath> pathsList = new List<DirPath>();
        //ObservableCollection<AppPath> PathsColl = new ObservableCollection<AppPath>();
        List<string> exeNames = new List<string>();
        List<AppInfo> appInfoList = new List<AppInfo>();
        FileHelper appInfoFile = new FileHelper();
        string exeName = "";

        public MainWindow()
        {
            InitializeComponent();
            FileHelper fileData = new FileHelper();
            DirectoryInfo[] directories;
            FileInfo[] files;

            fileData.ReadFileData(pathsList);

            for (int i = 0; i < pathsList.Count; i++)
            {
                var dirinfo = new DirectoryInfo(@pathsList[i].AppPathString);
                directories = dirinfo.GetDirectories();
                files = dirinfo.GetFiles("*.sln",SearchOption.AllDirectories);

                foreach (var item in files)
                {
                    exeName = System.IO.Path.GetFileNameWithoutExtension(item.Name); 

                    appInfoFile.fileName = @pathsList[i].AppPathString + "\\AppInfoFile.csv";

                }

                findingExe(directories, i);

            }

            listViewExes.ItemsSource = exeNames;
        }

        public void findingExe(DirectoryInfo[] directories, int j)
        {
            for (int i = 0; i < directories.Length; i++)
            {
                var fileinfo = new DirectoryInfo(@directories[i].FullName);
                FileInfo[] files = fileinfo.GetFiles("*.exe",SearchOption.AllDirectories);

                if (files.Length > 0)
                {

                    AppPath appPath = new AppPath(exeName);

                    foreach (var item in files)
                    {
                        if (exeName == System.IO.Path.GetFileNameWithoutExtension(item.Name))
                        {
                            pathsList[j].AddPath(item.FullName);
                        }
                    }

                    pathsList[j].AddAppList(appPath);

                    exeNames.Add(appPath.Name);
                }
            }
        }

        private void listViewExes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listViewPaths.ItemsSource = pathsList[listViewExes.SelectedIndex].ExePaths;
            labelChooseApp.Content = listViewExes.SelectedIndex.ToString();

            buttonLaunch.IsEnabled = false;
        }

        private void listViewPaths_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttonLaunch.IsEnabled = true;
            labelAppInfo.Content = listViewPaths.SelectedIndex.ToString();

            if (appInfoFile.ReadAppInfo(appInfoList))
            {
                tBoxAppName.Text = appInfoList[listViewPaths.SelectedIndex].AppName;
                tBoxAppVer.Text = appInfoList[listViewPaths.SelectedIndex].AppVer;
                tBoxAppAuthor.Text = appInfoList[listViewPaths.SelectedIndex].AppAuthor;
            }
        }
            

        private void buttonLaunch_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(@pathsList[listViewExes.SelectedIndex].ExePaths[listViewPaths.SelectedIndex]);
        }

        private void buttonEditAppInfo_Click(object sender, RoutedEventArgs e)
        {
            buttonEditAppInfo.Visibility = Visibility.Hidden;
            buttonSaveAppInfo.Visibility = Visibility.Visible;

            tBoxAppName.IsEnabled = true;
            tBoxAppVer.IsEnabled = true;
            tBoxAppAuthor.IsEnabled = true;

        }

        private void buttonSaveAppInfo_Click(object sender, RoutedEventArgs e)
        {
            buttonSaveAppInfo.Visibility = Visibility.Hidden;
            buttonEditAppInfo.Visibility = Visibility.Visible;

            tBoxAppName.IsEnabled = false;
            tBoxAppVer.IsEnabled = false;
            tBoxAppAuthor.IsEnabled = false;

            if (appInfoFile.ReadAppInfo(appInfoList) == false)
            {
                for (int i = 0; i < pathsList[listViewExes.SelectedIndex].AppList.Count; i++)
                {
                    appInfoList.Add(pathsList[listViewPaths.SelectedIndex].AppList[i].Info);
                } 
            }
            else
            {
                pathsList[listViewPaths.SelectedIndex].AppList[listViewExes.SelectedIndex].Info = new AppInfo(tBoxAppName.Text, tBoxAppVer.Text, tBoxAppAuthor.Text);

                for (int i = 0; i < pathsList[listViewExes.SelectedIndex].AppList.Count + 1; i++)
                {
                    appInfoList[i] = pathsList[listViewExes.SelectedIndex].AppList[i].Info;
                }
            }

            appInfoFile.fileName = pathsList[listViewExes.SelectedIndex].AppPathString + "\\AppFileInfo.csv";

            appInfoFile.WriteAppInfo(appInfoList);

        }
    }
}
