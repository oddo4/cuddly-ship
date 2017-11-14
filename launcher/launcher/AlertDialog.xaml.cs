﻿using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace launcher
{
    /// <summary>
    /// Interakční logika pro AlertDialog.xaml
    /// </summary>
    public partial class AlertDialog : MetroWindow
    {
        public AlertDialog(string message)
        {
            InitializeComponent();
            labelAlertDialog.Content = message;
        }

        private void buttonAlertAccept_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}