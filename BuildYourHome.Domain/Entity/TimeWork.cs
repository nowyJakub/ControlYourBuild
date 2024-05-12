
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
        public ConcreteTypeOfWork SecondTypeOfWork { get; set; }
        public DateTime StartWork { get; set; }
        public DateTime EndWork { get; set; }
        public TimeSpan DuringWorkingTime { get; set; }
        public int TotalMonths { get; set; }
        public int RemainingDays { get; set; }
        

        public TimeWork (int id, ConcreteTypeOfWork secondType, DateTime startWork, DateTime endWork)
        {
            Id = id;
            SecondTypeOfWork = secondType;
            StartWork = startWork;
            EndWork = endWork;
            DuringWorkingTime = EndWork - StartWork;

            
            TotalMonths = ((EndWork.Year - StartWork.Year) * 12) + EndWork.Month - StartWork.Month;
            RemainingDays = (int)DuringWorkingTime.TotalDays - TotalMonths * 
                                DateTime.DaysInMonth(StartWork.Year, StartWork.Month);

        }


    }
}
