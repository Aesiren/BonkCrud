using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BonkCrud.Models;

namespace BonkCrud.Controllers
{
    public class DataController : Controller
    {

        DataAccess objitem = new DataAccess();

        // GET: DataController
        [HttpGet]
        [Route("api/Items/Index")]
        public IEnumerable<Item> Index()
        {
            return objitem.GetAllItems();
        }

        [HttpPost]
        [Route("api/Items/Details/{id}")]
        // GET: DataController/Details/5
        public Item Details(int id)
        {
            return objitem.GetItemData(id);
        }

        // GET: DataController/Create
        [HttpGet]
        [Route("api/Items/Create")]
        public int Create(Item item)
        {
            return objitem.AddItem(item);
        }

        // PUT: DataController/Edit
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

        // GET: DataController/Edit/5
        [HttpDelete]
        [Route("api/Item/Delete/{id}")]
        public int Delete(int id)
        {
            return objitem.DeleteItem(id);
        }

       
    }
}
