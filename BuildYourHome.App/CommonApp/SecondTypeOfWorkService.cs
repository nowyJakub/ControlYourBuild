using BuildYourHome.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourHome.App.CommonApp
{
    public class SecondTypeOfWorkService : BaseService<SecondTypeOfWork>
    {
        SecondTypeOfWorkService()
        {
            Initialize();
        }

        void Initialize()
        {
            AddItem(new SecondTypeOfWork(1, "Fundamenty", "Lawy"));
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
