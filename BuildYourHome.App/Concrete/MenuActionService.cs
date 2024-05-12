using BuildYourHome.App.CommonApp;
using BuildYourHome.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourHome.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService()
        {
            Initialize();
        }

        public List<MenuAction> GetMenuActionsByType(string typeMenu)
        {
            var ListOfConcreteTypeMenuAction = new List<MenuAction>();
            foreach (MenuAction typeMenuActionElement in BaseElementList)
            {
                if (typeMenu == typeMenuActionElement.TypeMenu)
                {
                    ListOfConcreteTypeMenuAction.Add(typeMenuActionElement);
                }
            }
            return ListOfConcreteTypeMenuAction;
        }

        private void Initialize()
        {
            AddItem(new MenuAction(1, "Dodaj koszt dla danego etapu", "Main"));
            AddItem(new MenuAction(2, "Wyswietl koszty", "Main"));
            AddItem(new MenuAction(3, "Wyswietl sumaryczne koszty dla etapu", "Main"));
            AddItem(new MenuAction(4, "Dodaj nowy terminy prac dla etapow", "Main"));
            AddItem(new MenuAction(5, "Wyswietl czasy trwania prac", "Main"));
            AddItem(new MenuAction(6, "Zmiana danych", "Main"));
            AddItem(new MenuAction(7, "Konfiguracja etapów", "Main"));


            AddItem(new MenuAction(1, "Change Data in costs of works", "ChangeData"));
            AddItem(new MenuAction(2, "Change Data in schedule works", "ChangeData"));

            AddItem(new MenuAction(1, "Dodaj glowny etap budowy", "Configuration"));
            AddItem(new MenuAction(2, "Dodaj dodatkowe prace dla glownego etapu", "Configuration"));
            AddItem(new MenuAction(3, "Wyswietl liste glownych etapow budowy", "Configuration"));
            AddItem(new MenuAction(4, "Wyswietl glowne etapy budowy z dodatkowymi pracami", "Configuration"));
            AddItem(new MenuAction(5, "Usun pozycje z etapow budowy", "Configuration"));
            AddItem(new MenuAction(6, "Usun pozycje z dodatkowych prac dla glownego etapu", "Configuration"));
            AddItem(new MenuAction(7, "Powrot do glownego menu", "Configuration"));


        }

    }
}
