using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<string> testColl = new ObservableCollection<string>();
        List<string> exePathsList = new List<string>();
        string fileName = "";
        string lastPath = "";

        public MainWindow()
        {
            InitializeComponent();
            File fileData = new File();
            DirectoryInfo[] directories;
            DirectoryInfo[] subdir;
            FileInfo[] files;

            fileData.ReadFileData(pathsList);

            foreach (CorePath data in pathsList)
            {
                lastPath = data.PathString;
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

                listViewPaths.ItemsSource = testColl;

            }
        }

        public void findingExe(DirectoryInfo[] directories)
        {
            for (int i = 0; i < directories.Length; i++)
            {
                var fileinfo = new DirectoryInfo(@directories[i].FullName);
                FileInfo[] files = fileinfo.GetFiles();


                var carMake1 = files
                .Where(item => item.Extension == ".exe")
                .Select(item => item);

                foreach (var item in carMake1)
                {
                    if (fileName == System.IO.Path.GetFileNameWithoutExtension(item.Name))
                    {
                        exePathsList.Add(item.FullName);
                    }
                }
            }

            
        }

    }
}
