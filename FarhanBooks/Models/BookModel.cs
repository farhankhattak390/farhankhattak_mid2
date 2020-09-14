using System;
using System.Data.Entity;

namespace FarhanBooks.Models
{
    public class BookModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime IssueDate { get; set; }
        public string Subject { get; set; }
        public decimal Price { get; set; }
    }

    public class BookDBContext : DbContext
    {
        public DbSet<BookModel> Books { get; set; }
    }
}