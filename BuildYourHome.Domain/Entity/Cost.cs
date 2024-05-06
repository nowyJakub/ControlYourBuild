
using BuildYourHome.Domain.CommonDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourHome.Domain.Entity
{
    public class Cost : BaseEntity
    {
        public ConcreteTypeOfWork SecondTypeOfWork { get; set; }
        public string Materil {  get; set; }
        public float TotalCost { get; set; }
        public float DetailCost { get; set; }
        public int DetailCount { get; set; }


        public Cost(int id, ConcreteTypeOfWork secondType, string material, float detailCost, int detailCount) 
        {
            Id = id;
            SecondTypeOfWork = secondType;
            Materil = material;
            DetailCost = detailCost;
            DetailCount = detailCount;
            TotalCost = DetailCost* DetailCount;

        }
       

    }
}
