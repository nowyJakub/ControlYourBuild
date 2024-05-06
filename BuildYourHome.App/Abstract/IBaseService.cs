using BuildYourHome.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BuildYourHome.App.Abstract
{
    public interface IBaseService<Element>
    {
       public List<Element> BaseElementList { get; set; }
        int GetLastId();
       public Element GetItemById(int id);

       public List<Element> GetAllItems();
       public void AddItem(Element BaseItem);
       public void RemoveItem(Element BaseItem);
       public int UpdaterItem(Element BaseItem);
        public void DecreaseId ( int HowMuch);
 
    }
}
