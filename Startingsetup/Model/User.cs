using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class User
    {
      

        //basic user
        public string FirstName
        {
            get; set;
        }
        public int UserId
        {
            get; set;
        }
        public string LastName
        {
            get; set;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string FullName { get; set; }
        public List<ExpenseHeader> RequestExpenseHeaders
        {
            get;
            set;
        }
       public List<ExpenseHeader> ApproverExpenseHeaders { get; set; }

    }
}
