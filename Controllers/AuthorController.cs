using Microsoft.EntityFrameworkCore;
using BookStoreApp.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using BookStoreApp.Models;

namespace BookStoreApp.Controllers
{
    public class AuthorController : Controller
    {   private readonly IAuthorService _service;
        public AuthorController( IAuthorService service){
            _service=service;
        }
        

        public IActionResult Add()
        {   
            return View();
        }
        [HttpPost]
        public IActionResult Add(Author author){
            if(!ModelState.IsValid){
                return View(author);
            }
            var result=_service.Add(author);
            if(result){
                TempData["msg"]="Added succesfully";
                return RedirectToAction("Add"/*Hoặc that bằng nameof(Add)*/);
            }
            TempData["msg"]="Error has occured on sever side";
            return View();
        }


        public IActionResult Update( int id)
        {   
            var author=_service.FindById(id);
            return View(author);
        }
        [HttpPost]
        public IActionResult Update(Author author){
            if(!ModelState.IsValid){
                return View(author);
            }
           
            _service.Update(author);
            return RedirectToAction("GetAll"/*Hoặc that bằng nameof(Add)*/);  
        }

        
        public IActionResult Delete(int id){
            var result=_service.Delete(id);
            
                return RedirectToAction("GetAll"/*Hoặc that bằng nameof(Add)*/);
        }

        public IActionResult GetAll(){
            var result=_service.getAll();
            return View(result);
        }
    }
}