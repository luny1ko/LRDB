using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using LR_DB.Model;

namespace LR_DB.Helper
{
    public static class DataService
    {
        private static readonly string RolePath = "roles.json";
        private static readonly string PersonPath = "persons.json";

        public static void SaveRoles(ObservableCollection<Role> roles)
        {
            File.WriteAllText(RolePath, JsonSerializer.Serialize(roles));
        }

        public static ObservableCollection<Role> LoadRoles()
        {
            if (!File.Exists(RolePath)) return new ObservableCollection<Role>();
            return JsonSerializer.Deserialize<ObservableCollection<Role>>(File.ReadAllText(RolePath));
        }

        public static void SavePersons(ObservableCollection<Person> persons)
        {
            File.WriteAllText(PersonPath, JsonSerializer.Serialize(persons));
        }

        public static ObservableCollection<Person> LoadPersons()
        {
            if (!File.Exists(PersonPath)) return new ObservableCollection<Person>();
            return JsonSerializer.Deserialize<ObservableCollection<Person>>(File.ReadAllText(PersonPath));
        }
    }
}
