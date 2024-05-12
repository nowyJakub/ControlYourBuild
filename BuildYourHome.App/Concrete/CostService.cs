using BuildYourHome.App.Abstract;
using BuildYourHome.App.CommonApp;
using BuildYourHome.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourHome.App.Concrete
{
    public class CostService: BaseService<Cost>
    {
        //private BaseService<Cost> Service;

        //private ConcreteTypeOfWorkService ConcreteTypeOfWorksService { get; }

        private readonly IBaseService<ConcreteTypeOfWork> _ConcreteService;

        public CostService(IBaseService<ConcreteTypeOfWork> iService)
        {
            _ConcreteService = iService;
            Initialize();
        }
        //public CostService(ConcreteTypeOfWorkService concreteTypeOfWorksService)
        //{
        //    ConcreteTypeOfWorksService = concreteTypeOfWorksService;
        //    Initialize();
        //}

        //public CostService(BaseService<Cost> service)
        //{
        //    Service = service;
        //    Initialize();
        //}
        private void Initialize ()
        {
            AddItem(new Cost(0,null,null,0,0));
            AddItem(new Cost(1, _ConcreteService.GetItemById(1), "Zakup projektu", 2800, 1)); 
            AddItem(new Cost(2, _ConcreteService.GetItemById(1), "Adaptacja", 3000, 1)); 
            AddItem(new Cost(3, _ConcreteService.GetItemById(4), "Beton na słupy", 800, 1)); 
            AddItem(new Cost(4, _ConcreteService.GetItemById(4), "Bloczki betonowe", 3.45f, 1400));
            AddItem(new Cost(5, _ConcreteService.GetItemById(1), "no", 10, 1));
        }

        public List<Cost> GetListOfConcreteType()
        {
            List<Cost> list = new List<Cost>();

            for (int i=0; i<_ConcreteService.BaseElementList.Count; i++)
            {
                list.Add(new Cost(i, _ConcreteService.GetItemById(i),null,0,0));
            }

            return list;
        }

        
        
    }
}
