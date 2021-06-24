using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace First.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
       
        [Required]
        [Range(1,double.MaxValue,ErrorMessage ="The amount must be grather than or equal to zero")]
        public double Amount { get; set; }

        [DisplayName("Expense Category")]
        public int ExpenseCategoryId { get; set; }

        [ForeignKey("ExpenseCategoryId")]
        public virtual ExpenseCategory ExpenseCategory { get; set; }
    }
}
