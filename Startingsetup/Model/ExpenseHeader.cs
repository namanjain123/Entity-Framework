using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class ExpenseHeader
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100,ErrorMessage ="{0} can not be more then 100")]
        public string Description { get; set; }
         
        public DateTime? ExpenseDate { get; set; }//become nullable
        public decimal UsdExchangeRate { get; set; }
        [ForeignKey("Requester")]
        public int RequesterID { get; set; }
        [InverseProperty("RequestExpenseHeaders")]
        public User Requester { get; set; }
        [ForeignKey("Approver")]//easy to read and make the action of link explicit
        public int ApproverId { get; set; }
       [InverseProperty("ApproverExpenseHeaders")]
        //relation to the user function and its connection
        public User Approver { get; set; }
        public List<ExpenseLine> ExpenseLines { get; set; }
    }
}
