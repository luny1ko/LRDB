using LR_DB.View;
using LR_DB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LR_DB.Helper;

namespace LR_DB.ViewModel
{
    public class PersonViewModel
    {
        public ObservableCollection<Person> ListPerson { get; set; } =
            new ObservableCollection<Person>();

        public PersonViewModel()
        {
            ListPerson = DataService.LoadPersons();
        }

        public int MaxId()
        {
            int max = 0;
            foreach (var r in this.ListPerson)
            {
                if (max < r.Id)
                {
                    max = r.Id;
                };
            }
            return max;
        }

        // ⬇️ Вот сюда вставляешь метод FindPerson
        public Person FindPerson(int id)
        {
            return ListPerson.FirstOrDefault(p => p.Id == id);
        }
    }
}
