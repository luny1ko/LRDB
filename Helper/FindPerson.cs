using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LR_DB.Model;

namespace LR_DB.Helper
{
    public class FindPerson
    {
        private int id;

        public FindPerson(int id)
        {
            this.id = id;
        }

        public bool PersonPredicate(Person person)
        {
            return person.Id == id;
        }
    }
}
