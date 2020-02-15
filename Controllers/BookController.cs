using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooksManagement.Models;

namespace BooksManagement.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        private static List<Book> books;
        public ActionResult Index()
        {
            if(books == null)
            {
                books = new List<Book>();

                // ajout d'un nouveau book 
                books.Add(new Book
                {
                    Id = 1, 
                    Author = "Tony Robbins",
                    Price=100.99m,
                    Title=" Unlimited Power "
                });

                books.Add(new Book
                {
                    Id = 2,
                    Author = "Tony Robbins",
                    Price = 120.99m,
                    Title = " PNL "
                });

                books.Add(new Book
                {
                    Id = 3,
                    Author = "Tony Robbins",
                    Price = 120.99m,
                    Title = " Awaken the giant within "
                });
            }

            return View(books); // envoyer les books a la vue index
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            Book book = books.Single(s => s.Id == id);
            return View(book);
        }

        // GET: Book/Create , pour afficher le formulair de creation 
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create,  pour enregistrer ce qu'on a rempli dans le formulair de creation 
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                // TODO: Add insert logic here
                books.Add(book);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            // afficher les informations de book id 
            Book book = books.Single(a => a.Id == id);

            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Book book)
        {
            try
            {
                // modifier les informations sur le book :
                Book oldbook = books.Single(a => a.Id == id);
                oldbook.Author = book.Author;
                oldbook.Title = book.Title;
                oldbook.Price = book.Price;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            Book book = books.Single(a => a.Id == id);
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Book book = books.Single(a => a.Id == id);
                books.Remove(book);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
