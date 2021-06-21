using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace First.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public int Borrower { get; set; }
    }
}
