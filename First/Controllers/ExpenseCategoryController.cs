using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Data;
using First.Models;

namespace First.Controllers
{
    public class ExpenseCategoryController : Controller
    {
        private readonly AplicationDBContext _db;

        public ExpenseCategoryController(AplicationDBContext context)
        {
            this._db = context;
        }
        public IActionResult Index()
        {
            IEnumerable<ExpenseCategory> expensesCategories = this._db.ExpenseCategories;
            return View(expensesCategories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(ExpenseCategory attributes)
        {
            if (ModelState.IsValid)
            {
                this._db.ExpenseCategories.Add(attributes);
                this._db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(attributes);
            }
        }

        //Get single expense
        [HttpGet]

        public IActionResult Show(int? Id)
        {
            if (Id != null || Id != 0)
            {
                var expenseCategory = this._db.ExpenseCategories.Find(Id);
                if (expenseCategory != null)
                {
                    return View(expenseCategory);
                }
            }
            return NotFound();
        }


        [HttpGet]
        public IActionResult Update(int? Id)
        {

            var expenseCategory = this._db.ExpenseCategories.Find(Id);
            if (expenseCategory == null)
            {
                return NotFound();
            }

            return View(expenseCategory);
        }

        [HttpPost]
        public IActionResult Update(ExpenseCategory attributes)
        {

            this._db.ExpenseCategories.Update(attributes);
            this._db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Post delete
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            //return Ok("ID: "+Id);

            var expenseCategory = this._db.ExpenseCategories.Find(Id);

            if (expenseCategory == null)
            {
                return NotFound();
            }

            return View(expenseCategory);
        }

        [HttpPost]
        public IActionResult DeleteAction(int? Id)
        {
            //return Ok("ID: "+Id);

            var expenseCategory = this._db.ExpenseCategories.Find(Id);

            if (expenseCategory == null)
            {
                return NotFound();
            }

            this._db.Remove(expenseCategory);
            this._db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
