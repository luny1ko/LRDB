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

        public static void SaveRoles(ObservableCollection<Genre> roles)
        {
            File.WriteAllText(RolePath, JsonSerializer.Serialize(roles));
        }

        public static ObservableCollection<Genre> LoadRoles()
        {
            if (!File.Exists(RolePath)) return new ObservableCollection<Genre>();
            return JsonSerializer.Deserialize<ObservableCollection<Genre>>(File.ReadAllText(RolePath));
        }

        public static void SavePersons(ObservableCollection<Book> persons)
        {
            File.WriteAllText(PersonPath, JsonSerializer.Serialize(persons));
        }

        public static ObservableCollection<Book> LoadPersons()
        {
            if (!File.Exists(PersonPath)) return new ObservableCollection<Book>();
            return JsonSerializer.Deserialize<ObservableCollection<Book>>(File.ReadAllText(PersonPath));
        }
        public static void SavePersonsToFile(ObservableCollection<Book> persons, string path)
        {
            File.WriteAllText(path, JsonSerializer.Serialize(persons));
        }

        public static ObservableCollection<Book> LoadPersonsFromFile(string path)
        {
            if (!File.Exists(path)) return new ObservableCollection<Book>();
            return JsonSerializer.Deserialize<ObservableCollection<Book>>(File.ReadAllText(path));
        }
        public static void SaveRolesToFile(ObservableCollection<Genre> roles, string path)
        {
            File.WriteAllText(path, JsonSerializer.Serialize(roles));
        }

        public static ObservableCollection<Genre> LoadRolesFromFile(string path)
        {
            if (!File.Exists(path)) return new ObservableCollection<Genre>();
            return JsonSerializer.Deserialize<ObservableCollection<Genre>>(File.ReadAllText(path));
        }

    }
}
