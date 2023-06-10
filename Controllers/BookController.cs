// using Microsoft.EntityFrameworkCore;
using BookStoreApp.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using BookStoreApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
// using System.Web.WebPages.Html;

namespace BookStoreApp.Controllers
{
    public class BookController : Controller
    {   
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IGenreService _genreService;
        private readonly IPublisherService _publisherService;
        public BookController( IBookService bookService,IAuthorService authorService,IGenreService genreService,IPublisherService publisherService){
            _bookService=bookService;
            _authorService=authorService;
            _genreService=genreService;
            _publisherService=publisherService; 
        }
        

        public IActionResult Add()
        {   
            var book=new Book();

            book.authorList=_authorService.getAll().Select(
            a=>new SelectListItem{
            Text=a.AuthorName,Value=a.Id.ToString()
            }).ToList();

             book.genreList=_genreService.getAll().Select(
            a=>new SelectListItem{
            Text=a.Name,Value=a.Id.ToString()
            }).ToList();

             book.publisherList=_publisherService.getAll().Select(
            a=>new SelectListItem{
            Text=a.PublisherName,Value=a.Id.ToString()
            }).ToList();
            return View(book);
        }
        [HttpPost]
        public IActionResult Add(Book book){

             book.authorList=_authorService.getAll().Select(
            a=>new SelectListItem{
            Text=a.AuthorName,Value=a.Id.ToString()
            }).ToList();

             book.genreList=_genreService.getAll().Select(
            a=>new SelectListItem{
            Text=a.Name,Value=a.Id.ToString()
            }).ToList();

             book.publisherList=_publisherService.getAll().Select(
            a=>new SelectListItem{
            Text=a.PublisherName,Value=a.Id.ToString()
            }).ToList();
           
            


            if(!ModelState.IsValid){
                return View(book);
            }
            var result=_bookService.Add(book);
            if(result){
                TempData["msg"]="Added succesfully";
                return RedirectToAction("Add"/*Hoặc that bằng nameof(Add)*/);
            }
            TempData["msg"]="Error has occured on sever side";
            return View();
        }


        public IActionResult Update( int id)
        {   
            var book=_bookService.FindById(id);
            book.authorList =_authorService.getAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id == book.AuthorId }).ToList();

            // book.authorList=_authorService.getAll().Select(
            // a=>new SelectListItem{
            // Text=a.AuthorName,Value=a.Id.ToString(),Selected=a.Id==book.AuthorId
            // }).ToList();

             book.genreList=_genreService.getAll().Select(
            a=>new SelectListItem{
            Text=a.Name,Value=a.Id.ToString(),Selected=a.Id==book.GenreID
            }).ToList();

             book.publisherList=_publisherService.getAll().Select(
            a=>new SelectListItem{
            Text=a.PublisherName,Value=a.Id.ToString(),Selected=a.Id==book.PublisherID
            }).ToList();

            return View(book);
        }
        [HttpPost]
        public IActionResult Update(Book book){

            book.authorList=_authorService.getAll().Select(
            a=>new SelectListItem{
            Text=a.AuthorName,Value=a.Id.ToString(),Selected=a.Id==book.AuthorId
            }).ToList();

             book.genreList=_genreService.getAll().Select(
            a=>new SelectListItem{
            Text=a.Name,Value=a.Id.ToString(),Selected=a.Id==book.GenreID
            }).ToList();

             book.publisherList=_publisherService.getAll().Select(
            a=>new SelectListItem{
            Text=a.PublisherName,Value=a.Id.ToString(),Selected=a.Id==book.PublisherID
            }).ToList();
            


            if(!ModelState.IsValid){
                return View(book);
            }
            var result=_bookService.Update(book);
           
            if(result){
                TempData["msg"]="Update succesfully";
                
                return RedirectToAction("GetAll"/*Hoặc that bằng nameof(Add)*/);
            }
            TempData["msg"]="Error has occured on sever side";
            return View();
        }

        
        public IActionResult Delete(int id){
            var result=_bookService.Delete(id);
            
                return RedirectToAction("GetAll"/*Hoặc that bằng nameof(Add)*/);
        }

        public IActionResult GetAll(){
            var result=_bookService.getAll();
            return View(result);
        }
    }
}