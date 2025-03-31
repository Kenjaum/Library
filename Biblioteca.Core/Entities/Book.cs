using System.Globalization;

namespace Library.Core.Entities
{
    public class Book : BaseEntity
    {
        protected Book() { }
        public Book(string titulo, string autor, string isbn, int anoDePublicacao)
        {
            Title = titulo;
            Author = autor;
            ISBN = isbn;
            PublicationYear = anoDePublicacao;
        }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int PublicationYear { get; private set; }
        public IEnumerable<Loan> Loans { get; set; }
    }
}
