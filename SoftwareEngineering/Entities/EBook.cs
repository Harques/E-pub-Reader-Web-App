namespace SoftwareEngineering.Entities
{

    public class EBook
    {
        public int Id { get; set; }
        public byte[] PDFFile { get; set; }
        public BookGenre bookGenre1 { get; set; }
        public BookGenre bookGenre2 { get; set; }
        public BookGenre bookGenre3 { get; set; }
    }

    public enum BookGenre
    {
        Classics,
        Comic Book,
        Detective and Mystery,
        Fantasy,
        Horror,
        Romance,
        Science Fiction,
        Biographies and Autobiographies,
        Cookbooks,
        Essays,
        History,
        Poetry
    }
}
