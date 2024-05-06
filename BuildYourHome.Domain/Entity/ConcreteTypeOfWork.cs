using BuildYourHome.Domain.CommonDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourHome.Domain.Entity
{
    public class ConcreteTypeOfWork : BaseEntity
    {
        public CoreTypeOfWork CoreTypeOfWork { get; set; }
        public string DetailOfTypeWork { get; set; }

        public ConcreteTypeOfWork(int id, CoreTypeOfWork generalTypeOfWork, string detailOfTypeWork)
        {
            Id = id;
            CoreTypeOfWork = generalTypeOfWork;
            DetailOfTypeWork = detailOfTypeWork;
        }
    }
}
