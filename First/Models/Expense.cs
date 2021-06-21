using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}
