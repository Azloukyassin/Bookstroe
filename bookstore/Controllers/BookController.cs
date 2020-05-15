using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using bookstore.Models;
using bookstore.Models.Repositories;
using bookstore.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace bookstore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookstoreRepoository<formular> bookrepository;
        private readonly IBookstoreRepoository<Author> authorrepository;
        private readonly IHostEnvironment hosting;

        public BookController(IBookstoreRepoository<formular> bookrepository , IBookstoreRepoository<Author> authorrepository, IHostEnvironment hosting )
        {
            
            this.bookrepository = bookrepository;
            this.authorrepository = authorrepository;
            this.hosting = hosting;
        }
        // GET: Book
        public ActionResult Index()
        {
            var book = bookrepository.liste(); 
            return View(book);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            var book = bookrepository.Find(id);
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View(GetAllAuthors());
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAuthorViewModel model )
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string Filename = string.Empty; 
                    if(model.File != null)
                    {
                        string upload = Path.Combine(hosting.ContentRootPath, "uploads");
                        Filename = model.File.FileName;
                        string fullpath = Path.Combine(upload, Filename);
                        model.File.CopyTo(new FileStream(fullpath,FileMode.Create)); 
                    }
                    if (model.AuthorId == -1)
                    {
                        ViewBag.Message = "Bitte Checken Sie Ihr Eingabe nach";
                       
                        return View(GetAllAuthors());
                    }
                    formular book = new formular
                    {
                        ID = model.BookId,
                        Title = model.Title,
                        Description = model.Description,
                        Author = authorrepository.Find(model.AuthorId),
                        ImageUrl=Filename 
                    };
                    bookrepository.Add(book);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
          
            else {
                ModelState.AddModelError("","Bitte prüfen Sie Ihr Eingabe nach !") ;
                return View(GetAllAuthors()); }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            var book = bookrepository.Find(id);
            var authorID = book.Author == null ? book.Author.ID = 0 : book.Author.ID; 
            var viewModell = new BookAuthorViewModel
            {
                BookId = book.ID,
                Title = book.Title,
                Description = book.Description,
                AuthorId = authorID,
                Authors = authorrepository.liste().ToList()
            };
            return View(viewModell);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookAuthorViewModel model )
        {
            try
            {
                formular book = new formular
                {
                    Title = model.Title,
                    Description = model.Description,
                    Author = authorrepository.Find(model.AuthorId),
                };
                bookrepository.Update(model.BookId,book);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            var book = bookrepository.Find(id);
            
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmeDelete(int id)
        {
            try
            {
                bookrepository.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        List<Author> FillSelectList()
        {
            var author = authorrepository.liste().ToList();
            author.Insert(0, new Author { ID = -1, FullName = "--- Bitte Geben Sie ein Author ein----" });
            return author; 
        }
        BookAuthorViewModel GetAllAuthors()
        {
            var vmodel = new BookAuthorViewModel
            {
                Authors = FillSelectList()

            };
            return vmodel;
        }
        public ActionResult Serach(string term)
        {
            var result = bookrepository.Serach(term);
            return View("Index",result); 
        }

    }
}