using BuildYourHome.App.CommonApp;
using BuildYourHome.Helpers;

Console.WriteLine("ss");
ChangeTextColor changeTextColor = new ChangeTextColor();

MenuActionService menuActionService = new MenuActionService();

var mainMenu = menuActionService.GetMenuActionsByType("Main");

while (true)
{
    for (int i = 0; i < mainMenu.Count; i++)
    {
        changeTextColor.PrintInformation($"{mainMenu[i].Id}. { mainMenu[i].Name}");
    }

    var userDecision = Console.ReadKey();


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