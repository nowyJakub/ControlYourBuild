using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourHome.App.Abstract;
using BuildYourHome.App.CommonApp;
using BuildYourHome.App.Helpers;
using BuildYourHome.Domain.Entity;
using BuildYourHome.Helpers;
//using BuildYourHome.Helpers;

namespace BuildYourHome.App.Managers
{
    public class CoreTypeOfWorksManager
    {
        
        
        private IBaseService<CoreTypeOfWork> CoreTypeService;
        public CoreTypeOfWorksManager(IBaseService<CoreTypeOfWork> coreTypeService) 
        {
            CoreTypeService = coreTypeService;
        }

        public void PrintAllTypeOfWork()
        {
            var ListOfAllType = CoreTypeService.GetAllItems();
            ChangeTextColor.PrintTitleOfAction("Lista glownych etapów budowy:");
            for (int i = 1; i < ListOfAllType.Count; i++) 
            {
                ChangeTextColor.PrintInformation($"{ListOfAllType[i].Id}. {ListOfAllType[i].GeneralType}.");
            }
            Console.WriteLine();
        }
        public int AddCoreTypeOfWork()
        {
            int newId = 0;
            Console.WriteLine("Wpisz nazwe nowego glownego typu prac:");
            string NewCoreType = Console.ReadLine();
            int lastId = CoreTypeService.GetLastId();
            CoreTypeOfWork newCoreTypeOfWork = new CoreTypeOfWork(lastId+1, NewCoreType); 
            CoreTypeService.AddItem(newCoreTypeOfWork);
            newId = CoreTypeService.GetLastId();

            return newId;
        }

        public int DeleteCoreTypeOfWork()
        {
            int deletedId = 0;
            bool UserDecition = false;
            int LenghtOfList = CoreTypeService.BaseElementList.Count;

            while(UserDecition==false)
            {
                Console.Clear();
                ChangeTextColor.PrintTitleOfAction("Usuwanie glownego typu prac");
                PrintAllTypeOfWork();
                ChangeTextColor.PrintInformation("Wpisz numer pozycji, ktora chcesz usunac");
                string PositionToDeleteCoreType = Console.ReadLine();
                UserDecition = ChecktToUserSetGoodValue.String_ToInt(PositionToDeleteCoreType, 0, LenghtOfList);

                if (UserDecition==false) 
                {
                    ChangeTextColor.PrintError("Wybrana pozycja jest niedostepna");
                }
                else
                {
                    Int32.TryParse(PositionToDeleteCoreType, out deletedId);
                    UserDecition=true;
                    CoreTypeOfWork coreTypeOfWorkToDelete = CoreTypeService.GetItemById(deletedId);
                    CoreTypeService.RemoveItem(coreTypeOfWorkToDelete);
                    ChangeTextColor.PrintInformation("Pozycja zostala usunieta z Listy");
                    ChangeTextColor.PrintInformation($" {coreTypeOfWorkToDelete.Id}. {coreTypeOfWorkToDelete.GeneralType}");
                    CoreTypeService.DecreaseId(deletedId );
                }
            }
            
             

            return deletedId;
        }

    }
}
