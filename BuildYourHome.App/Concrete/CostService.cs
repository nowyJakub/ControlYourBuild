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
            AddItem(new Cost(1, _ConcreteService.GetItemById(1), "Projekt", 1000, 1)); ;
        }
        
    }
}
