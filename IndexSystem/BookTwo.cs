using CsvHelper.Configuration;

namespace IndexSystem
{
    public record BookTwo : Book
    {
        public string Hash { get; set; }
    }

    public class BookTwoMap : ClassMap<BookTwo>
    {
        public BookTwoMap()
        {
            Map(m => m.Hash).Name("ID");
            Map(m => m.Name).Name("Name");
            Map(m => m.Title).Name("Title");
            Map(m => m.Place).Name("Place publication");
            Map(m => m.Publisher).Name("Publisher");
            Map(m => m.Date).Name("Date of publication");
        }
    }
}
