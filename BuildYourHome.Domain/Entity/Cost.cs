
using BuildYourHome.Domain.CommonDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourHome.Domain.Entity
{
    public class Cost : GeneralTypeOfWork
    {
        public float TotalCost { get; set; }
        public float DetailCost { get; set; }
        public int DetailCount { get; set; }
        public float Tax { get; set; }

    }
}
