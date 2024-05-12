using BuildYourHome.App.Abstract;
using BuildYourHome.App.CommonApp;
using BuildYourHome.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourHome.App.Concrete
{
    public class TimeWorkService : BaseService<TimeWork>
    {
        private readonly IBaseService<ConcreteTypeOfWork> _concreteWork;

        public TimeWorkService(IBaseService<ConcreteTypeOfWork> concreteWork)
        {
            _concreteWork = concreteWork;
            Initialize();
        }

        public void Initialize()
        {
            DateTime DataTime1 = new DateTime(2022, 11, 20);
            DateTime DataTime2 = new DateTime(2023, 12, 25);

            AddItem(new TimeWork(0, null, DataTime1, DataTime2));
            AddItem(new TimeWork(1, _concreteWork.GetItemById(1), DataTime1, DataTime2));
        }

    }
}
