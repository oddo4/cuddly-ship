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

namespace launcher.Pages
{
    /// <summary>
    /// Interakční logika pro EditPage.xaml
    /// </summary>
    public partial class AppPage : Page
    {
        List<AppInfo> appInfoList = new List<AppInfo>();
        FileHelper appInfoFile = new FileHelper();
        int index = 0;

        public AppPage(int exeCtr, int i, string appInfoPath, string appName)
        {
            InitializeComponent();
            index = i;
            appInfoFile.fileName = appInfoPath + "\\AppFileInfo.csv";

            if (appInfoFile.ReadAppInfo(appInfoList) == false)
            {
                CreateAppInfoList(exeCtr, index, appName);
            }

            ShowInfo(index);
        }

        private void CreateAppInfoList(int maxCtr, int index, string appName)
        {
            appInfoList = new List<AppInfo>();

            for (int i = 0; i < maxCtr; i++)
            {
                AppInfo appInfo = new AppInfo();
                appInfo.AppName = appName;

                appInfoList.Add(appInfo);
            }
        }

        private void EditAppInfoList(int maxCtr, int index, string appName, string appVer, string appAuthor)
        {
            for (int i = 0; i < maxCtr; i++)
            {
                AppInfo appInfo = new AppInfo(appName, appVer, appAuthor);

                if (i == index)
                {
                    appInfoList[i] = appInfo;
                }
            }
        }

        private void ShowInfo(int index)
        {
            tboxAppName.Text = appInfoList[index].AppName;
            tboxAppVer.Text = appInfoList[index].AppVer;
            tboxAppAuthor.Text = appInfoList[index].AppAuthor;
        }

        private void buttonReturn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void buttonSaveAppInfo_Click(object sender, RoutedEventArgs e)
        {
            EditAppInfoList(appInfoList.Count, index, tboxAppName.Text, tboxAppVer.Text, tboxAppAuthor.Text);

            if (appInfoFile.WriteAppInfo(appInfoList))
            {

            }
            else
            {

            }
        }
    }
}
