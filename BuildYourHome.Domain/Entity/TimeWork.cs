
using BuildYourHome.Domain.CommonDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourHome.Domain.Entity
{
    public class TimeWork : BaseEntity
    {
        ConcreteTypeOfWork SecondTypeOfWork { get; set; }
        public DateTime StartWork { get; set; }
        public DateTime EndWork { get; set; }
        public DateTime DuringWorkingTime { get; set; }

        public TimeWork (int id, ConcreteTypeOfWork secondType, DateTime startWork, DateTime endWork)
        {
            Id = id;
            SecondTypeOfWork = secondType;
            StartWork = startWork;
            EndWork = endWork;

        }


    }
}
