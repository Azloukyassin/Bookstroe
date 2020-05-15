using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using bookstore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bookstore.ViewModels
{
    public class BookAuthorViewModel
    {
        
        public int BookId { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(5)]
        public string Title { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(5)]
        public string Description { get; set; }

        public int AuthorId { get; set; }
       
        public List<Author> Authors { get; set; }
        public IFormFile File { get; set; } 
    }
}
