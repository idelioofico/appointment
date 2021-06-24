using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Data;
using First.Models;
using First.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace First.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly AplicationDBContext _db;

        public ExpenseController(AplicationDBContext context) {
            _db = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Expense> expenses = _db.Expenses;
           
            foreach (var expense in expenses.ToList()) {

                expense.ExpenseCategory = _db.ExpenseCategories.FirstOrDefault(u => u.Id == expense.ExpenseCategoryId);
            }

            return View(expenses);
        }

        public IActionResult Create()
        {

            ExpenseVM expenseVM = new()
            {
                Expense = new Expense(),
                CategoryDropDown = _db.ExpenseCategories.Select(i => new SelectListItem {
                    Text=i.Description,
                    Value=i.Id.ToString()
                })
            };
         
            return View(expenseVM);
        }

        [HttpPost]
     
        public IActionResult Create(ExpenseVM expenseVM)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(expenseVM.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else {
                return View(expenseVM.Expense);
            }
        }

        //Get single expense
        [HttpGet]

        public IActionResult Show(int? Id)
        {
            if (Id != null || Id != 0) {
                var expense = _db.Expenses.Find(Id);
                if (expense != null)
                {
                    return View(expense);
                }
            }
            return NotFound();
        }


        [HttpGet]
        public IActionResult Update(int? Id) {


            ExpenseVM expenseVM = new()
            {
                Expense = _db.Expenses.Find(Id),
                CategoryDropDown = _db.ExpenseCategories.Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.Description,
                })
            };

            if (expenseVM == null) {
                return NotFound();
            }

            return View(expenseVM);
        }

        [HttpPost]
        public IActionResult Update(ExpenseVM expenseVM)
        {

            _db.Expenses.Update(expenseVM.Expense);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Post delete
        [HttpGet]
        public IActionResult Delete(int? Id)
        {

            ExpenseVM expenseVM = new()
            {
                Expense = _db.Expenses.Find(Id),
                CategoryDropDown = _db.ExpenseCategories.Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.Description
                })
            };

           

            if (expenseVM == null) {
                return NotFound();
            }

        
            return View(expenseVM);
        }

        [HttpPost]
        public IActionResult DeleteAction(int? Id)
        {
            //return Ok("ID: "+Id);

            var expense = _db.Expenses.Find(Id);

            if (expense == null)
            {
                return NotFound();
            }

            _db.Remove(expense);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
