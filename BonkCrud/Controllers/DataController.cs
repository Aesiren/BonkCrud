using Microsoft.AspNetCore.Http;
using System.Data.SqlTypes;
using Microsoft.AspNetCore.Mvc;
using BonkCrud.Models;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace BonkCrud.Controllers
{
    [Route("Api/components")]
    public class DataController : Controller
    {
        DataAccess objItem = new DataAccess();
        [Route("AddorUpdateItem")]
        [HttpPost]
        public object AddorUpdateItem(Item st)
        {
            try
            {
                if(st.ItemID == 0)
                {
                    Item NItem = new Item();
                    NItem.ItemName = st.ItemName;
                    NItem.Detail = st.Detail;
                    NItem.Quantity = st.Quantity;
                    NItem.UserID = st.UserID;
                    objItem.AddItem(NItem);
                }
            }
        }
    }
}



/*public class DataController : Controller
{

    DataAccess objitem = new DataAccess();

    // GET all items
    [HttpGet]
    [Route("api/Items/Index")]
    public IEnumerable<Item> Index()
    {
        return objitem.GetAllItems();
    }

    //get details for specific item
    [HttpPost]
    [Route("api/Items/Details/{id}")]
    public Item Details(int id)
    {
        return objitem.GetItemData(id);
    }

    // Add new item
    [HttpGet]
    [Route("api/Items/Create")]
    public int Create(Item item)
    {
        return objitem.AddItem(item);
    }

    // update item detail
    [HttpPost]
    [Route("api/Items/Edit")]
    public int Edit(Item item)
    {
        try
        {
            return objitem.UpdateItem(item);
        }
        catch
        {
            throw;
        }
    }

    // Delete item
    [HttpDelete]
    [Route("api/Item/Delete/{id}")]
    public int Delete(int id)
    {
        return objitem.DeleteItem(id);
    }


}*/