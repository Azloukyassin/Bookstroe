using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Models.Repositories
{
    public class AuthorDBRepository : IBookstoreRepoository<Author>
    {
        BookstoreDBContext db; 
        public AuthorDBRepository(BookstoreDBContext _db)
        {
            db = _db; 
        }
        public void Add(Author entity)
        {
            db.Authors.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var author = Find(id);
            db.Authors.Remove(author);
            db.SaveChanges();
        }

        public Author Find(int id)
        {
            var author = db.Authors.SingleOrDefault(b => b.ID == id);
            return author;
        }



        public IList<Author> liste()
        {
            return db.Authors.ToList();
        }

        public List<Author> Serach(string term)
        {
            return db.Authors.Where(a => a.FullName.Contains(term)).ToList();
        }

        public void Update(int id, Author newauthor)
        {
            db.Update(newauthor);
            db.SaveChanges();
    }
    
    }
}
