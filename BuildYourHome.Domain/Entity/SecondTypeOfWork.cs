using BuildYourHome.Domain.CommonDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourHome.Domain.Entity
{
    public class SecondTypeOfWork : BaseEntity
    {
        public GeneralTypeOfWork GeneralTypeOfWork;
        public string DetailOfTypeWork;

        public SecondTypeOfWork(GeneralTypeOfWork generalTypeOfWork, string detailOfTypeWork)
        {
            GeneralTypeOfWork = generalTypeOfWork;
            DetailOfTypeWork = detailOfTypeWork;
        }
    }
}
