
using BuildYourHome.Domain.CommonDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourHome.Domain.Entity
{
    public class MenuAction : BaseEntity
    {
        public string Name { get; set; }
        public string TypeMenu { get; set; }
        public MenuAction(int id, string name, string typeMenu)
        {
            Id = id;
            Name = name;
            TypeMenu = typeMenu;
        }
    }
}
