using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Exceptions
{
    public class BookAlreadyExistsException : Exception
    {
        public BookAlreadyExistsException() : base ("O livro já existe na base de dados")
        {
            
        }
    }
}
