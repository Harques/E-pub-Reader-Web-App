namespace SoftwareEngineering.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public int BookProviderId { get; set; }
        public bool IsAdultOnly { get; set; }
        public int GenreId1 { get; set; }
        public int GenreId2 { get; set; }
        public int GenreId3 { get; set; }
    }
}
