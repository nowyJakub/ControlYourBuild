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
    public class ConcreteTypeOfWorkService : BaseService<ConcreteTypeOfWork>



    {
        private readonly BaseService<CoreTypeOfWork> _baseCoreService;
        
        public ConcreteTypeOfWorkService(BaseService<CoreTypeOfWork> coreTypeOfWorksService)
        {
            _baseCoreService = coreTypeOfWorksService;
            Initialize();
        }

        void Initialize()
        {
            AddItem(new ConcreteTypeOfWork(0, null, null));
            AddItem(new ConcreteTypeOfWork(1, _baseCoreService.GetItemById(1), "Projekt"));
            AddItem(new ConcreteTypeOfWork(2, _baseCoreService.GetItemById(1), "Mapka od Geodety"));
            AddItem(new ConcreteTypeOfWork(3, _baseCoreService.GetItemById(2), "Lawy"));


        }



        // Tworzymy głowny typ
        // 1. Fundamenty
        //      Tworzymy dodatkowe czynnosi jaki są wykonywane dla głownego typu prac
        //      1.1 Ławy
        //      1.2 Sciany
        // Głównie rozdzieliłem to ze względu na to żeby móc dodawać podczynności dla głównego etapu.
        // Aby pod te czynnosci móc potem dodawać koszty i czas prac, A następnie sumować to dla głownej czyności
        // a także z rozdzieleniem na mniejsze etapy. 
    }
}
