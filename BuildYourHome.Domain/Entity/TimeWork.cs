
using BuildYourHome.Domain.CommonDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourHome.Domain.Entity
{
    public class TimeWork : GeneralTypeOfWork
    {
        public DateTime StartWork { get; set; }
        public DateTime EndWork { get; set; }
        public DateTime DuringWorkingTime { get; set; }


    }
}
