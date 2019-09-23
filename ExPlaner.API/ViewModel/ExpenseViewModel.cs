using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ExPlaner.API.DAL.EF;

namespace ExPlaner.API.ViewModel
{
    public class ExpenseViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal? NetValue { get; set; }
        [Required]
        public decimal? GrossValue { get; set; }
        public DateTime? OperationDate { get; set; }
        public string Currency { get; set; }
        public DateTime? CurrencyDate { get; set; }
        public decimal? CurrencyRate { get; set; }
        public OperationType? OperationType { get; set; }
    }
}
