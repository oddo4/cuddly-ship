using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPF1
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Person> persons = new ObservableCollection<Person>();

        public MainWindow()
        {
            InitializeComponent();
            ListViewPersons.ItemsSource = persons;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //labelOutputText.Content = "";

            if (textBoxFirstName.Text != "")
            {
                persons.Add(new Person(textBoxFirstName.Text, textBoxLastName.Text));
                textBoxFirstName.Text = "";
                labelOutputText.Content = "Úspěšně přidáno.";
            }
            else
            {
                labelOutputText.Content = "Zadejte jméno!";
            }
            

            
        }
    }
}
