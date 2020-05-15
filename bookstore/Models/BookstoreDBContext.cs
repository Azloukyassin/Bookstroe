using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Models
{
    public class BookstoreDBContext:DbContext
    {
        public BookstoreDBContext(DbContextOptions<BookstoreDBContext> options) :base(options)
        {
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<formular> Books { get; set; }
    }
}
