using LR_DB.Model;
using LR_DB.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LR_DB.Helper
{
    /// <summary>
    /// Класс отображения данных по сотруднику.
    /// </summary>
    public class PersonDpo : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string _roleName;
        public string Role { get; set; }

        public string RoleName
        {
            get => _roleName;
            set => SetProperty(ref _roleName, value);
        }

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        private DateTime _birthday;
        public DateTime Birthday
        {
            get => _birthday;
            set => SetProperty(ref _birthday, value);
        }

        public PersonDpo() { }

        public PersonDpo(int id, string roleName, string firstName, string lastName, DateTime birthday)
        {
            Id = id;
            RoleName = roleName;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }

        public PersonDpo ShallowCopy() => (PersonDpo)MemberwiseClone();

        /// <summary>
        /// Копирует данные из Person в текущий объект PersonDpo
        /// </summary>
        public PersonDpo CopyFromPerson(Person person)
        {
            RoleViewModel vmRole = new RoleViewModel();
            string role = vmRole.ListRole.FirstOrDefault(r => r.Id == person.RoleId)?.NameRole ?? string.Empty;
            if (!string.IsNullOrEmpty(role))
            {
                this.Id = person.Id;
                this.Role = role;
                this.FirstName = person.FirstName;
                this.LastName = person.LastName;
                this.Birthday = person.Birthday;
            }
            return this;
        }

        public static PersonDpo FromPerson(Person person, RoleViewModel roleViewModel)
        {
            var role = roleViewModel.ListRole
                .FirstOrDefault(r => r.Id == person.RoleId)?.NameRole;

            return role == null ? null : new PersonDpo
            {
                Id = person.Id,
                RoleName = role,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Birthday = person.Birthday
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (Equals(storage, value)) return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}