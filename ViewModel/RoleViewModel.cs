using LR_DB.Model;
using LR_DB.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using LR_DB.Helper;
namespace LR_DB.ViewModel
{
    public class RoleViewModel : INotifyPropertyChanged
    {
        private Role selectedRole;
        public Role SelectedRole
        {
            get => selectedRole;
            set
            {
                selectedRole = value;
                OnPropertyChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public ObservableCollection<Role> ListRole { get; set; }

        public ICommand EditRole { get; }
        public ICommand AddRole { get; }

        public RoleViewModel()
        {
            ListRole = DataService.LoadRoles();
            EditRole = new RelayCommand(ExecuteEditRole, CanExecuteEditRole);
            AddRole = new RelayCommand(ExecuteAddRole);
        }

        private void ExecuteEditRole(object parameter)
        {
            if (SelectedRole == null) return;

            Role temp = SelectedRole.ShallowCopy();
            var window = new WindowNewRole
            {
                Title = "Редактирование должности",
                Owner = Application.Current.MainWindow,
                DataContext = temp
            };

            if (window.ShowDialog() == true)
            {
                SelectedRole.NameRole = temp.NameRole;
                DataService.SaveRoles(ListRole);
                OnPropertyChanged(nameof(ListRole));
            }
        }

        private void ExecuteAddRole(object parameter)
        {
            var newRole = new Role
            {
                Id = MaxId() + 1,
                NameRole = "Новая должность"
            };

            var window = new WindowNewRole
            {
                Title = "Новая должность",
                Owner = Application.Current.MainWindow,
                DataContext = newRole
            };

            if (window.ShowDialog() == true)
            {
                ListRole.Add(newRole);
                DataService.SaveRoles(ListRole);
                OnPropertyChanged(nameof(ListRole));
            }
        }

        private bool CanExecuteEditRole(object parameter)
        {
            return SelectedRole != null;
        }

        public int MaxId()
        {
            if (ListRole.Count == 0)
                return 0;

            return ListRole.Max(r => r.Id);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}