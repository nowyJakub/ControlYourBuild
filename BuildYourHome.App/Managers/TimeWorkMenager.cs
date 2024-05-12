using BuildYourHome.App.Abstract;
using BuildYourHome.App.Concrete;
using BuildYourHome.App.Helpers;
using BuildYourHome.Domain.Entity;
using BuildYourHome.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BuildYourHome.App.Managers
{
    public class TimeWorkMenager
    {
        private IBaseService<TimeWork> TimeWorkService;
        private readonly IBaseService<ConcreteTypeOfWork> _concreteTypeOfWorkService;
        private readonly ConcreteTypeOfWorkManager _concreteTypeOfWorkManager;
        public TimeWorkMenager(IBaseService<TimeWork> baseService, IBaseService<ConcreteTypeOfWork> concreteWork,
                                ConcreteTypeOfWorkManager concreteTypeOfWorkManager) 
        {
            TimeWorkService = baseService;
            _concreteTypeOfWorkService = concreteWork;
            _concreteTypeOfWorkManager = concreteTypeOfWorkManager;
        }

        public int AddTimeWork ()
        {
            int NewID = 0;
            int NumberOfWork = 0;
            DateTime StartWorkTime = new DateTime (1999, 01, 01);
            DateTime EndWorkTime = new DateTime(1999, 01, 01); ;

            Console.Clear();
            bool ExitLoop1 = false;
            while (ExitLoop1 ==false) 
            {
                ChangeTextColor.PrintTitleOfAction("Dodawanie czasu trawania prac");
                ChangeTextColor.PrintInformation("Wpisz numer z listy dla którego chcesz dodac czas trwania prac: ");
                _concreteTypeOfWorkManager.PrintListAllWorks();
                string StringNumberOfConcreteWork = Console.ReadLine();
                bool UserSetGoodNumberOfWork = ChecktToUserSetGoodValue.String_ToInt(StringNumberOfConcreteWork, 0, 
                                                                        _concreteTypeOfWorkService.BaseElementList.Count);
                if (UserSetGoodNumberOfWork==true) 
                {
                    Int32.TryParse(StringNumberOfConcreteWork, out NumberOfWork);
                    ExitLoop1 = true;
                }
                else
                {
                    ChangeTextColor.PrintError("Wpisano zla wartosc");
                }

            }

            bool ExitLoop2 = false;
            while (ExitLoop2 ==false)
            {
                ChangeTextColor.PrintInformation("Proszę podać datę rozpoczecia w formacie DD / MM / RRRR:");
                string StringStartWorkData = Console.ReadLine();
                bool userSetGoodStartTime = ChecktToUserSetGoodValue.String_ToDateTime(StringStartWorkData, "dd/MM/yyyy");
                if (userSetGoodStartTime == true) 
                {
                    DateTime.TryParseExact(StringStartWorkData, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture,
                                            System.Globalization.DateTimeStyles.None, out StartWorkTime);

                    ExitLoop2 = true;
                }
                else
                {
                    ChangeTextColor.PrintError("Podany format jest nie prawidłowy");
                }
            }

            bool ExitLoop3 = false;
            
            while (ExitLoop3 == false)
            {
                ChangeTextColor.PrintInformation("Proszę podać datę zakonczenia w formacie DD / MM / RRRR:");
                string StringEndWorkData = Console.ReadLine();
                bool userSetGoodEndTime = ChecktToUserSetGoodValue.String_ToDateTime(StringEndWorkData, "dd/MM/yyyy");
                if (userSetGoodEndTime == true)
                {
                    DateTime.TryParseExact(StringEndWorkData, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture,
                                            System.Globalization.DateTimeStyles.None, out EndWorkTime);

                    ExitLoop3 = true;
                }
                else
                {
                    ChangeTextColor.PrintError("Podany format jest nie prawidłowy");
                }
            }

            int LastId = TimeWorkService.GetLastId();
            TimeWork newTimeWork = new TimeWork(LastId+1, _concreteTypeOfWorkService.GetItemById(NumberOfWork), StartWorkTime, EndWorkTime);
            TimeWorkService.AddItem(newTimeWork);

            ChangeTextColor.PrintInformation("Udało się dodać date prac dla wybranego etapu");
            NewID = TimeWorkService.GetLastId();

            return NewID;
        }

        public void PrintListOfTimeWork()
        {
            List<TimeWork> TimeWorkList = TimeWorkService.GetAllItems();
            for (int i = 1; i < TimeWorkList.Count; i++) 
            {
                ChangeTextColor.PrintInformation($"{TimeWorkList[i].Id}. {TimeWorkList[i].SecondTypeOfWork.DetailOfTypeWork} " +
                                                 $"{TimeWorkList[i].StartWork.ToString("dd.MM.yyyy")} - " +
                                                 $"{TimeWorkList[i].EndWork.ToString("dd.MM.yyyy")} " +
                                                 $"czas trwania : {TimeWorkList[i].TotalMonths.ToString()} miesiecy i " +
                                                 $"{TimeWorkList[i].RemainingDays.ToString()} dni ");
            }
        }
    }
}
