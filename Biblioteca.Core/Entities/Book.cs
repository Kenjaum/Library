using System.Globalization;

namespace Library.Core.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }
        public IEnumerable<Loan> Loans { get; set; }
    }
}
