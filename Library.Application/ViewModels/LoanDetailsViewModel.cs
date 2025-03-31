using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.ViewModels
{
    public class LoanDetailsViewModel
    {
        public LoanDetailsViewModel(int id, int idUser, int idBook, DateTime loanDate)
        {
            Id = id;
            IdUser = idUser;
            IdBook = idBook;
            LoanDate = loanDate;
        }

        public int Id { get; private set; }
        public int IdUser { get; private set; }
        public int IdBook { get; private set; }
        public DateTime LoanDate { get; private set; }
    }

}
