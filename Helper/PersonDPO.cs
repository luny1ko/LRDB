using LR_DB.Model;
using LR_DB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_DB.Helper
{
    public class PersonDPO
    {
        public int Id { get; set; }
        public string Role { get; set; } // Название роли
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public PersonDPO() { }

        public PersonDPO(int id, string role, string firstName, string lastName, DateTime birthday)
        {
            Id = id;
            Role = role;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }

        // Перевод в класс Person (модель БД)
        public Person ToPerson()
        {
            RoleViewModel vmRole = new RoleViewModel();
            int roleId = vmRole.ListRole.FirstOrDefault(r => r.NameRole == Role)?.Id ?? 0;

            return new Person
            {
                Id = Id,
                RoleId = roleId,
                FirstName = FirstName,
                LastName = LastName,
                Birthday = Birthday
            };
        }

        // Перевод из модели Person в DPO
        public static PersonDPO FromPerson(Person person)
        {
            RoleViewModel vmRole = new RoleViewModel();
            string roleName = vmRole.ListRole.FirstOrDefault(r => r.Id == person.RoleId)?.NameRole ?? "";

            return new PersonDPO
            {
                Id = person.Id,
                Role = roleName,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Birthday = person.Birthday
            };
        }
        public PersonDPO ShallowCopy()
        {
            return (PersonDPO)this.MemberwiseClone();
        }

        // Копирование данных из Person в DPO
        public PersonDPO CopyFromPerson(Person person)
        {
            RoleViewModel vmRole = new RoleViewModel();
            string roleName = vmRole.ListRole.FirstOrDefault(r => r.Id == person.RoleId)?.NameRole ?? "";

            return new PersonDPO
            {
                Id = person.Id,
                Role = roleName,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Birthday = person.Birthday
            };
        }
    }
}