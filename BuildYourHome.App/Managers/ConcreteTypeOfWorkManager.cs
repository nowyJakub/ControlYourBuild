using BuildYourHome.App.Abstract;
using BuildYourHome.App.CommonApp;
using BuildYourHome.App.Concrete;
using BuildYourHome.App.Helpers;
using BuildYourHome.Domain.Entity;
using BuildYourHome.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourHome.App.Managers
{
    public class ConcreteTypeOfWorkManager
    {
        private IBaseService<ConcreteTypeOfWork> ConcreteTypeService;
        private readonly IBaseService<CoreTypeOfWork> _coreTypeOfWorksService;



        public ConcreteTypeOfWorkManager(IBaseService<ConcreteTypeOfWork> concreteTypeService, 
                                        IBaseService<CoreTypeOfWork> coreTypeOfWorksService) 
        {
            ConcreteTypeService = concreteTypeService;
            _coreTypeOfWorksService = coreTypeOfWorksService;
        }
        

        public void PrintListAllWorks()
        {
            var ListOfConcreteWork = ConcreteTypeService.GetAllItems();

            Console.Clear();
            ChangeTextColor.PrintTitleOfAction("Lista glownych i dodatkowych etapów prac:");
            for (int i = 1; i < ListOfConcreteWork.Count; i++) 
            {
                ChangeTextColor.PrintInformation($"{ListOfConcreteWork[i].Id}. " +
                    $"{ListOfConcreteWork[i].CoreTypeOfWork.GeneralType} - " +
                    $"{ListOfConcreteWork[i].DetailOfTypeWork};");
            }
            Console.WriteLine();
        }


        public int AddConcreteTypeWork()
        {

            List<CoreTypeOfWork> ListCoreWorks = _coreTypeOfWorksService.GetAllItems();
            int NewId = 0;
            bool exitLoop = false;
            Console.Clear() ;
            while (exitLoop == false)  
            {
                ChangeTextColor.PrintTitleOfAction("Wpisz numer dla którego glownego typu prac chcesz dodać szczegolowe prace");
                for (int i = 1; i < ListCoreWorks.Count; i++)
                {
                    ChangeTextColor.PrintInformation($"{ListCoreWorks[i].Id}. {ListCoreWorks[i].GeneralType}");
                }

                var newCoreTypeString = Console.ReadLine();
                bool userUseGoogKey = ChecktToUserSetGoodValue.String_ToInt(newCoreTypeString, 0, ListCoreWorks.Count);
                
                if (userUseGoogKey == true)
                {
                    exitLoop = true;
                    Int32.TryParse(newCoreTypeString, out int newCoreTypeInt);
                    Console.WriteLine();
                    ChangeTextColor.PrintInformation($"Wpisz nazwe dla nowego typu prac dodatowych dla głownego etapu");
                    string NewAdditionalWork = Console.ReadLine();
                    int lastId = _coreTypeOfWorksService.GetLastId();
                    CoreTypeOfWork ChosenCoreTypeOfWork = _coreTypeOfWorksService.GetItemById(newCoreTypeInt);

                    ConcreteTypeOfWork newConcreteTypeOfWork = new ConcreteTypeOfWork(lastId + 1, ChosenCoreTypeOfWork, NewAdditionalWork);
                    ConcreteTypeService.AddItem(newConcreteTypeOfWork);
                }
                else
                {
                    ChangeTextColor.PrintError("Użytkownik wybrał pozycję, której nie ma na liscie");
                }
            }

            NewId = ConcreteTypeService.GetLastId();
            return NewId;
        }

        public int DeleteConcreteTypeOfWork()
        {
            int deletedId = 0;
            bool UserDecition = false;
            int LenghtOfList = ConcreteTypeService.BaseElementList.Count;


            while (UserDecition == false)
            {
                Console.Clear();
                ChangeTextColor.PrintTitleOfAction("Usuwanie glownego typu prac");
                PrintListAllWorks();
                ChangeTextColor.PrintInformation("Wpisz numer pozycji, ktora chcesz usunac");
                string PositionToDeleteCoreType = Console.ReadLine();
                UserDecition = ChecktToUserSetGoodValue.String_ToInt(PositionToDeleteCoreType, 0, LenghtOfList);

                if (UserDecition == false)
                {
                    ChangeTextColor.PrintError("Wybrana pozycja jest niedostepna");
                }
                else
                {
                    Int32.TryParse(PositionToDeleteCoreType, out deletedId);
                    UserDecition = true;
                    ConcreteTypeOfWork concreteTypeOfWorkToDelete = ConcreteTypeService.GetItemById(deletedId);
                    ConcreteTypeService.RemoveItem(concreteTypeOfWorkToDelete);
                    ChangeTextColor.PrintInformation("Pozycja zostala usunieta z Listy");
                    ChangeTextColor.PrintInformation($" {concreteTypeOfWorkToDelete.Id}. " +
                        $"{concreteTypeOfWorkToDelete.CoreTypeOfWork.GeneralType}" +
                        $"- {concreteTypeOfWorkToDelete.DetailOfTypeWork}");
                    ConcreteTypeService.DecreaseId(deletedId);
                }
            }



            return deletedId;
        }
    }
}
