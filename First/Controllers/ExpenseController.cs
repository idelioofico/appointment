using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Data;
using First.Models;

namespace First.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly AplicationDBContext _db;
        public ExpenseController(AplicationDBContext context) {
            this._db = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Expense> expenses = this._db.Expenses;
            return View(expenses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense attributes)
        {
            if (ModelState.IsValid)
            {
                this._db.Expenses.Add(attributes);
                this._db.SaveChanges();
                return RedirectToAction("Index");
            }
            else {
                return View(attributes);
            }
        }

        //Post delete
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? Id)
        {
            var expense=this._db.Expenses.Find(Id);
            if (expense == null) {
                return NotFound();
            }

            this._db.Remove(expense);
            this._db.SaveChanges();
            return RedirectToAction('Index');
        }
    }
}
