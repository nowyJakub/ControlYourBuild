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


        public int GetLastId()
        {
            int lastId = 0;
            if (BaseElementList.Any())
            {
                lastId = BaseElementList.OrderBy(x => x.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }
            return lastId;
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

        public Element GetItemById(int id)
        {
            Element entity = BaseElementList.FirstOrDefault(p =>p.Id == id);
            return entity;
        }

        public int GetLenghtOfList()
        {
            int lenghtOfList = BaseElementList.Count;
            return lenghtOfList;

        }

        public void DecreaseId( int PositionToStartDec)
        {
            //BaseElementList
            for (int i = PositionToStartDec; i < BaseElementList.Count; i++)
            {
                BaseElementList[i].Id = BaseElementList[i].Id - 1;
            }
        }
    }
}
