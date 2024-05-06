using BuildYourHome.App.Concrete;
using BuildYourHome.App.Managers;
using BuildYourHome.Helpers;



MenuActionService menuActionService = new MenuActionService();

CoreTypeOfWorksService coreTypeOfWorksService = new CoreTypeOfWorksService();
CoreTypeOfWorksManager coreTypeOfWorksManager = new CoreTypeOfWorksManager(coreTypeOfWorksService);

ConcreteTypeOfWorkService concreteTypeOfWorksService = new ConcreteTypeOfWorkService(coreTypeOfWorksService);
ConcreteTypeOfWorkManager concreteTypeOfWorksManager = new ConcreteTypeOfWorkManager(concreteTypeOfWorksService, coreTypeOfWorksService);

CostService costService = new CostService(concreteTypeOfWorksService);
CostMenager costMenager = new CostMenager(costService, concreteTypeOfWorksService);

var mainMenu = menuActionService.GetMenuActionsByType("Main");
var configurationMenu = menuActionService.GetMenuActionsByType("Configuration");

while (true)
{
    ChangeTextColor.PrintTitleOfAction($" Witaj w aplikacji do zarzadzania budowa ---");

    for (int i = 0; i < mainMenu.Count; i++)
    {
        ChangeTextColor.PrintInformation($"{mainMenu[i].Id}. { mainMenu[i].Name}");
    }

    var userDecision = Console.ReadKey();
    Console.Clear();
    switch (userDecision.KeyChar)
    {
        case '1':
            
            break;
        case '2':
            //
            break;
        case '3':
            //
            break;
        case '4':
            //
            break;
        case '5':
            //
            break;
        case '6':

            bool exitConfigurationMenu = false;
            ChangeTextColor.PrintTitleOfAction("Konfiguracja");
            while (exitConfigurationMenu == false)
            {
                 for (int i = 0; i < configurationMenu.Count; i++)
                 {
                    ChangeTextColor.PrintInformation($"{configurationMenu[i].Id}. {configurationMenu[i].Name}");
                 }
                var ConfigurationUserDecision = Console.ReadKey();

                switch (ConfigurationUserDecision.KeyChar) 
                { 
                case '1':
                        int NewIdCoreTypeWork = coreTypeOfWorksManager.AddCoreTypeOfWork();
                        break ;
                    case '2':
                        int NewIdConcreteTypeWork = concreteTypeOfWorksManager.AddConcreteTypeWork();
                        break ;
                    case '3':
                        coreTypeOfWorksManager.PrintAllTypeOfWork();
                        break;
                    case '4':
                        concreteTypeOfWorksManager.PrintListAllWorks();
                        break;
                    case '5':
                        coreTypeOfWorksManager.DeleteCoreTypeOfWork();
                        break;
                    case '6':
                        concreteTypeOfWorksManager.DeleteConcreteTypeOfWork();
                        break;
                    case '7':
                        exitConfigurationMenu = true;
                        Console.Clear();
                        break;
                }

            }
           
            break;
        default:
            ChangeTextColor.PrintError("Wybrales zla opcje");
            break;
    }



}





// Menu Action
// 1. Aktualne koszty budowy
//    1.1 Koszt całkowity + opis
//    1.2  - Mozliwosc wejscia w szczegóły gdzie : 
//            - Ilosc za sztuke, ilosc sztuk, etap prac, material / robocizna. Wartosc podatku
// 2. Plany prac 
//      2.1 Przyszle prace co i kiedy
//      2.2 Zeszłe z dokładnymi terminami i ile trwały do nastepnego etapu do aktualnego czasu
// 3. Zmiana danych
//      3.1 Kosztow 
//      3.2 Planu prac