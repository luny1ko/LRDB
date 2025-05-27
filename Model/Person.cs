using LR_DB.Helper;
using LR_DB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_DB.Model
{
    public class Person
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public Person CopyFromPersonDPO(PersonDpo personDPO)
        {
            RoleViewModel vmRole = new RoleViewModel();
            int roleId = vmRole.ListRole.FirstOrDefault(r => r.NameRole == personDPO.Role)?.Id ?? 0;

            this.Id = personDPO.Id;
            this.RoleId = roleId;
            this.FirstName = personDPO.FirstName;
            this.LastName = personDPO.LastName;
            this.Birthday = personDPO.Birthday;

            return this;
        }
    }
}


