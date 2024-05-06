using BuildYourHome.App.CommonApp;
using BuildYourHome.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourHome.App.Concrete
{
    public class CoreTypeOfWorksService : BaseService<CoreTypeOfWork>
    {
        public CoreTypeOfWorksService()
        {
            Initialize();
        }

        public List<T> GetAllItems<T>()
        {
            throw new NotImplementedException();
        }

        private void Initialize()
        {
            AddItem(new CoreTypeOfWork(0, null));
            AddItem(new CoreTypeOfWork(1, "Dokumenty"));
            AddItem(new CoreTypeOfWork(2, "Fundament"));
            AddItem(new CoreTypeOfWork(3, "Sciany"));
            AddItem(new CoreTypeOfWork(4, "Dach"));
        }


        //Menu
        // Utworz nowe typy, etapy
        // Dodaj aktywnosci
        // Wpisz szczegoly i potem pyta czy cchcrsz dodac koszty lub czas rozpoczecia lub to i to


        // Tworzymy głowny typ
        // Gdy to mamy mozemy dodawac pod czynnosci. I wtedy jezeli chcemy to mozemy dodac czas trwania albo koszty

        // W kosztach to beda
        // emki
        // zaprawa
        // projekt

        // tutaj mozemy dodac podpoziomy
        // 1. Przygotowanie do budoyw
        //  1.1 Elektryka
        //      1.1.1 Kabel

        // Planowanie czasu
        // Ile czekalismy na projekt
        // Ile na pozowlenie
        // ile robilismy fundamenty


    }
}
