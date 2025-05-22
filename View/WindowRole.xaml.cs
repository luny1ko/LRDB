using LR_DB.Model;
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
using LR_DB.ViewModel;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using LR_DB.Helper;
using System.Data;
using LR_DB.View;


namespace LR_DB.View
{
    /// <summary>
    /// Логика взаимодействия для WindowRole.xaml
    /// </summary>
    public partial class WindowRole : Window
    {
        private PersonViewModel vmPerson;
        private RoleViewModel vmRole;  // добавлено поле vmRole
        private List<Role> roles;
        private ObservableCollection<PersonDPO> personsDPO;

        public WindowRole()
        {
            InitializeComponent();

            vmPerson = new PersonViewModel();
            vmRole = new RoleViewModel();  // инициализация поля
            roles = vmRole.ListRole.ToList();

            lvRole.ItemsSource = vmRole.ListRole;

            personsDPO = new ObservableCollection<PersonDPO>();
            foreach (var person in vmPerson.ListPerson)
            {
                personsDPO.Add(PersonDPO.FromPerson(person));
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewRole wnRole = new WindowNewRole
            {
                Title = "Новая должность",
                Owner = this
            };

            Role newRole = new Role();  // создаём новую роль (модель)
            wnRole.DataContext = newRole;

            if (wnRole.ShowDialog() == true)
            {
                vmRole.ListRole.Add(newRole); // добавляем в коллекцию ролей
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewRole wnRole = new WindowNewRole
            {
                Title = "Редактирование должности",
                Owner = this
            };
            Role role = lvRole.SelectedItem as Role;
            if (role != null)
            {
                Role tempRole = role.ShallowCopy();
                wnRole.DataContext = tempRole;
                if (wnRole.ShowDialog() == true)
                {
                    // сохранение данных 
                    role.NameRole = tempRole.NameRole;
                    lvRole.ItemsSource = null;
                    lvRole.ItemsSource = vmRole.ListRole;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать должность для редактированния",

                 "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            {
                Role role = (Role)lvRole.SelectedItem;
                if (role != null)
                {
                    MessageBoxResult result = MessageBox.Show("Удалить данные по должности: " +

                    role.NameRole, "Предупреждение", MessageBoxButton.OKCancel,
                    MessageBoxImage.Warning);
                    if (result == MessageBoxResult.OK)
                    {
                        vmRole.ListRole.Remove(role);
                    }
                }
                else
                {
                    MessageBox.Show("Необходимо выбрать должность для удаления",
                     "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

        }
    }
}
