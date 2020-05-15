using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Models.Repositories
{
    public class BookDBRepository : IBookstoreRepoository<formular>
    {
        BookstoreDBContext db; 
        public BookDBRepository(BookstoreDBContext _db)
        {
            db = _db; 
        }
        public void Add(formular entity)
        {
            db.Books.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
        }

        public formular Find(int id)
        {
            var book = db.Books.Include(a => a.Author).SingleOrDefault(b => b.ID == id);
            return book;
        }



        public IList<formular> liste()
        {
            return db.Books.Include(a=> a.Author).ToList();
        }

        public void Update(formular entity)
        {

        }

        public void Update(int id, formular newbook)
        {
            db.Update(newbook);
            db.SaveChanges();
        }
        public List<formular> Serach (string term )
        {
            var result = db.Books.Include(a => a.Author)
                .Where(b => b.Title.Contains(term)
                            || b.Description.Contains(term)
                            || b.Author.FullName.Contains(term));
            return result.ToList();
        }
    }
    
    
}
