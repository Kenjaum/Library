using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Entities
{
    public class Loan : BaseEntity
    {
        public int IdUser { get; set; }
        public User User { get; set; }
        public int IdBook { get; set; }
        public Book Book { get; set; }
        public DateTime LoanDate { get; set; }
    }
}
