using BuildYourHome.Domain.CommonDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourHome.Domain.Entity
{
    public class CoreTypeOfWork : BaseEntity
    {
        public string? GeneralType { get; set; }

        public CoreTypeOfWork(int id, string type)
        {
            Id = id;
            GeneralType = type;
        }
    }
}
