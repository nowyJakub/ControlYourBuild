﻿using BuildYourHome.App.Abstract;
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
    public class CostMenager
    {
        private  IBaseService<Cost> CostService;
        private readonly IBaseService<ConcreteTypeOfWork> _concreteTypeOfWork;
        public CostMenager(IBaseService<Cost> costService,
                           IBaseService<ConcreteTypeOfWork> concreteType)
        {
            CostService = costService;
            _concreteTypeOfWork = concreteType;
        }
        public int AddCost()
        {
            int newId = 0;
            bool exitLoop = false;
            int CostVal=0;
            int AmmountVal=0;
            List<ConcreteTypeOfWork> ListOfConctreteType = _concreteTypeOfWork.GetAllItems();

            ChangeTextColor.PrintTitleOfAction("Dodwanie nowego kosztu");

            while (exitLoop == false)
            {
                ChangeTextColor.PrintInformation("Wybierz typ prac dla którego chcesz dodać koszty:");
                for (int i = 1; i<=ListOfConctreteType.Count; i++)
                {
                    ChangeTextColor.PrintInformation($"{ListOfConctreteType[i].Id}. " +
                        $"{ListOfConctreteType[i].CoreTypeOfWork.GeneralType} " +
                        $"- {ListOfConctreteType[i].DetailOfTypeWork}");
                }
                string UserDecision = Console.ReadLine();
                bool UserSetGoodOption = ChecktToUserSetGoodValue.String_ToInt(UserDecision, 0, ListOfConctreteType.Count);

                if (UserSetGoodOption==true) 
                {
                    int idOfChosenType;
                    int.TryParse(UserDecision, out idOfChosenType);  
                    ConcreteTypeOfWork ChosenConcreteTypeOfWork = _concreteTypeOfWork.GetItemById(idOfChosenType);

                    ChangeTextColor.PrintInformation("Podaj nazwe zakupionego towaru");
                    string MaterialName = Console.ReadLine();

                    bool SecondExitLoop=false;
                    while (SecondExitLoop==false) 
                    {
                        ChangeTextColor.PrintInformation("Podaj koszt, ktory chcesz dodac (używaj przecinka z nie kropki)");
                        string StringCost = Console.ReadLine();
                        bool UserWriteGoodCost = ChecktToUserSetGoodValue.String_ToFloat(StringCost, 0, float.MaxValue);
                        if (UserWriteGoodCost==true) 
                        { 
                        SecondExitLoop = true;
                        Int32.TryParse(StringCost, out CostVal);
                        }
                        else 
                        {
                            ChangeTextColor.PrintError("Wpisana wartość jest nieprawidłowa");
                        }
                    }

                    bool ThirdExitLoop = false;
                    while (ThirdExitLoop==false) 
                    {
                        ChangeTextColor.PrintInformation("Podaj ilosc przedmiotów");
                        string StringAmmount = Console.ReadLine();
                        bool UserWriteGoodAmmount = ChecktToUserSetGoodValue.String_ToInt(StringAmmount, 0, int.MaxValue);
                        if (UserWriteGoodAmmount == true)
                        {
                            ThirdExitLoop = true;
                            Int32.TryParse(StringAmmount, out AmmountVal);
                        }
                        else
                        {
                            ChangeTextColor.PrintError("Wpisana wartość jest nieprawidłowa");
                        }
                    }
                    int lastId = CostService.GetLastId();
                    Cost newCost = new Cost(lastId + 1, ChosenConcreteTypeOfWork, MaterialName, CostVal, AmmountVal);

                    

                    CostService.AddItem(newCost);
                   
                    


                  
                }
            }

            return newId;
        }
    }
}
