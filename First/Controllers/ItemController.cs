using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Data;
using System.Collections.Generic;
using First.Models;

namespace First.Controllers
{
    public class ItemController : Controller
    {
        private AplicationDBContext _db;

        public ItemController(AplicationDBContext context) {
            this._db = context;
        }

        //Returns all items
        public IActionResult Index()
        {
          IEnumerable<Item> items= this._db.Items;
       
            return View(items);
        }

        //Returns the create view
        public IActionResult Create() {

            return View();
        }

        //Post data from view
        [HttpPost]
        public IActionResult Create(Item attributes)
        {
            if (ModelState.IsValid) { 
            this._db.Items.Add(attributes);
            this._db.SaveChanges();
            return RedirectToAction("Index");
            }
            else
            {
                return View(attributes);
            }
        }
    }
}
