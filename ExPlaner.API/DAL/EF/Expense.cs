using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExPlaner.API.DAL.EF
{
    public class Expense : IUserDependentEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal NetValue { get; set; }
        public decimal GrossValue { get; set; }
        public DateTime OperationDate { get; set; }
        public Currency Currency { get; set; }
        public DateTime CurrencyDate { get; set; }
        public decimal CurrencyRate { get; set; }
        public OperationType OperationType { get; set; }
        public AppUser User { get; set; }

    }
}