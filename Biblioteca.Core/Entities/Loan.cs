using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Entities
{
    public class Loan : BaseEntity
    {
        public Loan(int idUser, int idBook, DateTime dataDeLoan)
        {
            IdUser = idUser;
            IdBook = idBook;
            LoanDate = dataDeLoan;
        }
        public int IdUser { get; private set; }
        public User User { get; set; }
        public int IdBook { get; private set; }
        public Book Book { get; set; }
        public DateTime LoanDate { get; private set; }
    }
}
