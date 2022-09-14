using BonkCrud.Data;
using System.Net;
using BonkCrud.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ActionNameAttribute = Microsoft.AspNetCore.Mvc.ActionNameAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.ObjectPool;
using System.Web.Mvc;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using ValidateAntiForgeryTokenAttribute = Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute;
using BindAttribute = Microsoft.AspNetCore.Mvc.BindAttribute;
using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using NuGet.Protocol;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;

namespace BonkCrud.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    

    public class ItemsController : Controller
    {
        
        private readonly crudContext _context;
        //crudContext localDB = new crudContext();
        public ItemsController(crudContext context)
        {
            _context = context;
        }

        [Route("ItemList")]
        [HttpGet]
        public object ItemList()
        {
            return _context.Items;
        }

        [HttpGet]
        public IEnumerable<Item> Get()
        {
            Console.Write("ItemList has been called");
            var crudContext = _context.Items.Include(i => i.User);
            object toList = crudContext.ToList();
            return (IEnumerable<Item>)Enumerable.ToArray(crudContext.ToList());
        }

        // GET: Items

        [Route("Items")]
        [Route("Items/ItemList")]
        [HttpGet("ItemList")]
        public async Task<IActionResult> Index()
        {
            Console.Write("ItemList has been called");
            var crudContext = _context.Items.Include(i => i.User);
            object toList = await crudContext.ToListAsync();
            //return TableBase(await crudContext.ToListAsync());
            Console.Write("ItemList Done");
            //return (IActionResult)toList;
            return View(await crudContext.ToListAsync());
            
        }

    

        //crudContext localDB = new crudContext();





        // GET: Items/Details/5
        [Route("ItemDetails")]
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            Console.Write("ItemDetails runs");
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
            
        }

        [Route("CreateItem")]
        // GET: Items/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("AddorUpdateItem")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,ItemName,Detail,Quantity,UserId")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", item.UserId);
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", item.UserId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("EditItem")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,ItemName,Detail,Quantity,UserId")] Item item)
        {
            if (id != item.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", item.UserId);
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("DeleteItem")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Items == null)
            {
                return Problem("Entity set 'crudContext.Items'  is null.");
            }
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return (_context.Items?.Any(e => e.ItemId == id)).GetValueOrDefault();
        }
    }
}
