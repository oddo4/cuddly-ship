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
        List<DirPath> pathsListData = new List<DirPath>();
        DirPath allAppPaths = new DirPath();
        //ObservableCollection<AppPath> PathsColl = new ObservableCollection<AppPath>();
        List<string> exeNames = new List<string>();
        List<AppInfo> appInfoList = new List<AppInfo>();
        FileHelper appInfoFile = new FileHelper();

        public MainWindow()
        {
            InitializeComponent();
            FileHelper fileData = new FileHelper();
            FileSearch fileSearch = new FileSearch();
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
            listViewExePaths.SelectedIndex = -1;
            //labelChooseApp.Content = listViewExePaths.SelectedIndex.ToString();

            buttonLaunch.IsEnabled = false;
        }

        private void listViewExePaths_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttonLaunch.IsEnabled = true;

            /*if (appInfoFile.ReadAppInfo(appInfoList))
            {
                tBoxAppName.Text = appInfoList[listViewExePaths.SelectedIndex].AppName;
                tBoxAppVer.Text = appInfoList[listViewExePaths.SelectedIndex].AppVer;
                tBoxAppAuthor.Text = appInfoList[listViewExePaths.SelectedIndex].AppAuthor;
            }*/
        }
            

        private void buttonLaunch_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(@allAppPaths.AppList[listViewApps.SelectedIndex].ExePaths[listViewExePaths.SelectedIndex]);
        }

        private void buttonShowAppInfo_Click(object sender, RoutedEventArgs e)
        {
            appInfoFile.fileName = allAppPaths.AppList[listViewApps.SelectedIndex].AppDirPath + "\\AppFileInfo.csv";

            if (appInfoFile.ReadAppInfo(appInfoList))
            {
                appInfoList[listViewExePaths.SelectedIndex].DisplayAppInfo(tBoxAppName, tBoxAppVer, tBoxAppAuthor);
            }
            else
            {
                
            }
        }

        private void buttonEditAppInfo_Click(object sender, RoutedEventArgs e)
        {
            EditAppInfo(true);

        }

        private void buttonSaveAppInfo_Click(object sender, RoutedEventArgs e)
        {
            EditAppInfo(false);

            appInfoFile.fileName = allAppPaths.AppList[listViewApps.SelectedIndex].AppDirPath + "\\AppFileInfo.csv";

            AppInfo exeInfo = new AppInfo(tBoxAppName.Text, tBoxAppVer.Text, tBoxAppAuthor.Text);

            if (appInfoFile.ReadAppInfo(appInfoList))
            {
                for (int i = 0; i < allAppPaths.AppList[listViewApps.SelectedIndex].ExeInfo.Count; i++)
                {
                    if (i == listViewExePaths.SelectedIndex)
                    {
                        appInfoList.Add(exeInfo);
                    }
                    else
                    {
                        appInfoList.Add(allAppPaths.AppList[listViewApps.SelectedIndex].ExeInfo[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < allAppPaths.AppList[listViewApps.SelectedIndex].ExeInfo.Count; i++)
                {
                    if (i == listViewExePaths.SelectedIndex)
                    {
                        appInfoList.Add(exeInfo);
                    }
                    else
                    {
                        appInfoList.Add(allAppPaths.AppList[listViewApps.SelectedIndex].ExeInfo[i]);
                    }
                }
            }

            appInfoFile.WriteAppInfo(appInfoList);

        }

        private void EditAppInfo(bool enable)
        {
            if (enable)
            {
                buttonSaveAppInfo.Visibility = Visibility.Visible;
                buttonEditAppInfo.Visibility = Visibility.Hidden;

                tBoxAppName.IsEnabled = true;
                tBoxAppVer.IsEnabled = true;
                tBoxAppAuthor.IsEnabled = true;
            }
            else
            {
                buttonSaveAppInfo.Visibility = Visibility.Hidden;
                buttonEditAppInfo.Visibility = Visibility.Visible;

                tBoxAppName.IsEnabled = false;
                tBoxAppVer.IsEnabled = false;
                tBoxAppAuthor.IsEnabled = false;
            }
        }
    }
}
