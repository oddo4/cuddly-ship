using Microsoft.Win32;
using System;
using System.IO;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System.Xml.Serialization;

namespace formaty.Pages
{
    /// <summary>
    /// Interakční logika pro MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        OpenFileDialog fDialog;
        SaveFileDialog sDialog;
        FilesSave fSave;
        List<Vehicle> vehicleList;
        List<string> nameList;
        string ext = "";

        public MainPage()
        {
            InitializeComponent();

            
        }

        private void buttonImportFile_Click(object sender, RoutedEventArgs e)
        {
            fDialog = new OpenFileDialog();
            fDialog.ShowDialog();

            vehicleList = new List<Vehicle>();
            fSave = new FilesSave(fDialog.FileName);

            ext = Path.GetExtension(fDialog.SafeFileName);

            switch (ext)
            {
                case ".csv":
                    fSave.ReadCSVFile(vehicleList);
                    break;
                case ".json":
                    fSave.ReadJSFile(vehicleList);
                    break;
                case ".xml":
                    fSave.ReadXMLFile(vehicleList);

                    XmlSerializer xmlDoc = new XmlSerializer(vehicleList.GetType());
                    vehicleList = (List<Vehicle>)xmlDoc.Deserialize(new StreamReader(fDialog.FileName));

                    break;
            }

            nameList = new List<string>();

            foreach (Vehicle data in vehicleList)
            {
                nameList.Add(data.Name);
            }

            listViewFileData.ItemsSource = nameList;
        }

        private void buttonExportCSVFile_Click(object sender, RoutedEventArgs e)
        {
            sDialog = new SaveFileDialog();
            sDialog.ShowDialog();

            fSave = new FilesSave(sDialog.FileName);
            fSave.WriteCSVFile(vehicleList);
        }

        private void buttonExportJSFile_Click(object sender, RoutedEventArgs e)
        {
            sDialog = new SaveFileDialog();
            sDialog.ShowDialog();

            fSave = new FilesSave(sDialog.FileName);
            fSave.WriteJSFile(vehicleList);
        }

        private void buttonExportXMLFile_Click(object sender, RoutedEventArgs e)
        {
            sDialog = new SaveFileDialog();
            sDialog.ShowDialog();

            fSave = new FilesSave(sDialog.FileName);
            fSave.WriteXMLFile(vehicleList);
        }

        
    }
}
