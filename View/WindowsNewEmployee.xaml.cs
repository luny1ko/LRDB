﻿using System;
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


namespace LR_DB.View
{
    /// <summary>
    /// Логика взаимодействия для WindowsNewEmployee.xaml
    /// </summary>
    public partial class WindowsNewEmployee : Window
    {
        public WindowsNewEmployee()
        {
            InitializeComponent();
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

    }
}
