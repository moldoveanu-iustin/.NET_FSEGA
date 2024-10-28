namespace Moldoveanu_Iustin_Lab2.Models
{
    public class ViewModels
    {
        public class PublisherIndexData
        {

            public IEnumerable<Publisher> Publishers { get; set; }
            public IEnumerable<Book> Books { get; set; }

        }
    }
}
