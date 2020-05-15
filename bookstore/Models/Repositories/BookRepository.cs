using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Models.Repositories
{
    public class BookRepository : IBookstoreRepoository<formular>
    {
        List<formular> books;
        public BookRepository()
        {
            books = new List<formular>()
            {
                new formular
                {
                    ID=1 , Title="c# Programming" , Description="Einfach Programming" , Author =new Author() 
                } ,
                 new formular
                {
                    ID=2 , Title="Java" , Description="Einfach Programming" ,Author =new Author()
                } ,
                  new formular
                {
                    ID=3 , Title="Python" , Description="Einfach Programming",Author =new Author()
                } ,
            };
        }
        public void Add(formular entity)
        {
            entity.ID = books.Max(b => b.ID) + 1; 
            books.Add(entity); 
        }

        public void Delete(int id)
        {
            var book = Find(id);
            books.Remove(book); 
        }

        public formular Find(int id)
        {
            var book = books.SingleOrDefault(b => b.ID == id);
            return book;
        }

        public IList<formular> liste()
        {
            return books; 
        }

        public List<formular> Serach(string term)
        {
            return books.Where(a => a.Title.Contains(term)).ToList();
        }

        public void Update(formular entity)
        {
            
        }

        public void Update(int id, formular newbook)
        {
            var book =Find(id);
            book.Title = newbook.Title;
            book.Description = newbook.Description;
            book.Author = newbook.Author; 
        }
    }
}
