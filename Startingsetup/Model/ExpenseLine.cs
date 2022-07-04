using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
namespace Model
{
    [Table("ExpenseDetails")]
    public class ExpenseLine
    {
        public int ExpenseLineId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        [Column("UnitPrice", TypeName = "decimal(16,2)")]
        public decimal UniCost { get; set; }
        [Column(TypeName = "decimal(16,2")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal ToatalCost { get; set; }
        [NotMapped]
        public string Secret { get; set; }
        public int ExpenseHeaderId {get;set;}

    }
}
