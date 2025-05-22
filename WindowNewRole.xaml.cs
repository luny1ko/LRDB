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

namespace LR_DB
{
    /// <summary>
    /// Логика взаимодействия для WindowNewRole.xaml
    /// </summary>
    public partial class WindowNewRole : Window
    {
        public WindowNewRole()
        {
            InitializeComponent();
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbRole.Text))
            {
                MessageBox.Show("Введите название должности.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DialogResult = true;
        }
        private void OpenEditWindow()
        {
            WindowNewRole wnRole = new WindowNewRole
            {
                Title = "Редактирование должности",
                Owner = this
            };
            wnRole.ShowDialog();
        }
    }
}
