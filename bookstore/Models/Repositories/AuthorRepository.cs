using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Models.Repositories
{
    public class AuthorRepository : IBookstoreRepoository<Author>
    {
        IList<Author> authors;
        public AuthorRepository()
        {
            authors = new List<Author>()
            {
                new Author { ID=1, FullName="Azlouk"} ,
                new Author { ID=2, FullName="Azlouk Yasine "} ,
                new Author { ID=3, FullName="Yasine "} ,
            };
        }
        public void Add(Author entity)
        {
            authors.Add(entity); 
        }

        public void Delete(int id)
        {
            var author = Find(id);
            authors.Remove(author); 
        }

        public Author Find(int id)
        {
            var author = authors.SingleOrDefault(b => b.ID == id);
            return author; 
        }

       

        public IList<Author> liste()
        {
            return authors; 
        }

        public List<Author> Serach(string term)
        {
            return authors.Where(a=>a.FullName.Contains(term)).ToList();
        }

        public void Update(int id, Author newauthor)
        {
            var author = Find(id);
            author.ID = newauthor.ID;
            author.FullName = newauthor.FullName; 
        }
    }
}
