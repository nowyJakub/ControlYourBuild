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

TimeWorkService TimeWorkServ = new TimeWorkService(concreteTypeOfWorksService);
TimeWorkMenager timeWorkMenager = new TimeWorkMenager (TimeWorkServ, concreteTypeOfWorksService, concreteTypeOfWorksManager);

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
            int idNewCost = costMenager.AddCost();
            break;
        case '2':
            costMenager.PrintListAllCost();
            break;
        case '3':
            costMenager.PrintListWhithWholeCostForBuildStage();
            break;
        case '4':
            int IdNewTimeWork = timeWorkMenager.AddTimeWork();
            break;
        case '5':
            timeWorkMenager.PrintListOfTimeWork();
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





