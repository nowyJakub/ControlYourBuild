using BuildYourHome.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourHome.App.CommonApp
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService() 
        {
            Initialize();
        }

        public List<MenuAction> GetMenuActionsByType (string typeMenu)
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

        private void Initialize ()
        { 
            AddItem(new MenuAction(1, "Add new cost", "Main"));
            AddItem(new MenuAction(2, "Show all cost", "Main"));
            AddItem(new MenuAction(3, "Add new schedule of works", "Main"));
            AddItem(new MenuAction(4, "Show schedule of works", "Main"));
            AddItem(new MenuAction(5, "Change Data", "Main"));

            
            AddItem(new MenuAction(1, "Change Data in costs of works", "ChangeData"));
            AddItem(new MenuAction(2, "Change Data in schedule works", "ChangeData"));
        }

    }
}
