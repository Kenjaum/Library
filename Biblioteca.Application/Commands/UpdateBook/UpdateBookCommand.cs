using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest<Unit>
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int PublicationYear { get; private set; }
    }
}
