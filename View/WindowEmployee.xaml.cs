using LR_DB.Helper;
using LR_DB.Model;
using LR_DB.ViewModel;
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
using System.Windows.Shapes;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Win32;

namespace LR_DB.View
{
    /// <summary>
    /// Логика взаимодействия для WindowEmployee.xaml
    /// </summary>
    public partial class WindowEmployee : Window
    {
        private PersonViewModel vmPerson;
        private RoleViewModel vmRole;
        private ObservableCollection<PersonDpo> personsDPO;
        private List<Role> roles;

        public WindowEmployee()
        {
            InitializeComponent();
            vmPerson = new PersonViewModel();
            vmRole = new RoleViewModel();
            roles = vmRole.ListRole.ToList();
            personsDPO = new ObservableCollection<PersonDpo>();

            foreach (var person in vmPerson.ListPerson)
            {
                PersonDpo p = new PersonDpo();
                p = p.CopyFromPerson(person);
                personsDPO.Add(p);
            }

            lvEmployee.ItemsSource = personsDPO;
            
            this.Closed += (s, e) =>
            {
                DataService.SavePersons(vmPerson.ListPerson);
                DataService.SaveRoles(vmRole.ListRole);
            };
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowsNewEmployee wnEmployee = new WindowsNewEmployee
            {
                Title = "Новый сотрудник",
                Owner = this
            };

            int maxIdPerson = vmPerson.MaxId() + 1;
            PersonDpo per = new PersonDpo { Id = maxIdPerson, Birthday = DateTime.Now };

            wnEmployee.DataContext = per;
            wnEmployee.CbRole.ItemsSource = roles;

            if (wnEmployee.ShowDialog() == true)
            {
                Role r = (Role)wnEmployee.CbRole.SelectedValue;
                per.Role = r.NameRole;
                personsDPO.Add(per);
                Person p = new Person();
                p = p.CopyFromPersonDPO(per);
                vmPerson.ListPerson.Add(p);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowsNewEmployee wnEmployee = new WindowsNewEmployee
            {
                Title = "Редактирование данных",
                Owner = this
            };

            PersonDpo perDPO = (PersonDpo)lvEmployee.SelectedValue;
            if (perDPO != null)
            {
                PersonDpo tempPerDPO = perDPO.ShallowCopy();
                wnEmployee.DataContext = tempPerDPO;
                wnEmployee.CbRole.ItemsSource = roles;
                wnEmployee.CbRole.Text = tempPerDPO.Role;

                if (wnEmployee.ShowDialog() == true)
                {
                    Role r = (Role)wnEmployee.CbRole.SelectedValue;
                    perDPO.Role = r.NameRole;
                    perDPO.FirstName = tempPerDPO.FirstName;
                    perDPO.LastName = tempPerDPO.LastName;
                    perDPO.Birthday = tempPerDPO.Birthday;
                    lvEmployee.ItemsSource = null;
                    lvEmployee.ItemsSource = personsDPO;

                    FindPerson finder = new FindPerson(perDPO.Id);
                    Person p = vmPerson.ListPerson.FirstOrDefault(person => finder.PersonPredicate(person));

                    p = p.CopyFromPersonDPO(perDPO);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать сотрудника для редактирования", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            PersonDpo person = (PersonDpo)lvEmployee.SelectedItem;
            if (person != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по сотруднику: \n" + person.LastName + " " + person.FirstName, "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    personsDPO.Remove(person);
                    Person per = new Person();
                    per = per.CopyFromPersonDPO(person);
                    vmPerson.ListPerson.Remove(per);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать данные по сотруднику для удаления", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            this.Closed += (s, e) =>
            {
                DataService.SavePersons(vmPerson.ListPerson);
                DataService.SaveRoles(vmRole.ListRole);
            };

        }
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON файлы (*.json)|*.json",
                Title = "Выберите файл с сотрудниками"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                var loadedPersons = DataService.LoadPersonsFromFile(openFileDialog.FileName);
                personsDPO.Clear();

                foreach (var person in loadedPersons)
                {
                    PersonDpo dpo = new PersonDpo().CopyFromPerson(person);
                    personsDPO.Add(dpo);
                }

                vmPerson.ListPerson = loadedPersons;
                lvEmployee.ItemsSource = null;
                lvEmployee.ItemsSource = personsDPO;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON файлы (*.json)|*.json",
                Title = "Сохранить сотрудников в файл"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                DataService.SavePersonsToFile(vmPerson.ListPerson, saveFileDialog.FileName);
            }
        }
    }
}