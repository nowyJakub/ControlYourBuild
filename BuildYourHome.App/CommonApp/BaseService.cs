//using BuildYourHome.Domain.CommonEntity;
using BuildYourHome.App.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourHome.Domain.CommonDomain;


namespace BuildYourHome.App.CommonApp
{
    public class BaseService<Element> : IBaseService<Element> where Element : BaseEntity
    {
        public List<Element> BaseElementList { get; set; }

        public BaseService() 
        {
        BaseElementList = new List<Element>();
        }

        public void AddItem(Element BaseItem)
        {
            BaseElementList.Add(BaseItem);
        }

        public void RemoveItem(Element BaseItem)
        {
            BaseElementList.Remove(BaseItem);
        }

        public int UpdaterItem(Element BaseItem)
        {
            var entity = BaseElementList.FirstOrDefault(p=> p.Id == BaseItem.Id);
            if (entity != null)
            {
                entity = BaseItem;
            }
            return entity.Id;
        }
        public List<Element> GetAllItems()
        {
            return BaseElementList;
        }
    }
}
