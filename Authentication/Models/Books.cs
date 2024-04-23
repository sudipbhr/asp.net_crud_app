namespace Authentication.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; } // Foreign key to Author
        public virtual Author Author { get; set; } // Navigation property

    }

    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }

        // Navigation property representing the list of books written by this author
        public virtual ICollection<Book> Books { get; set; }
    }

}
