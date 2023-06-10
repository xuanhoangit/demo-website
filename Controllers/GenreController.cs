using Microsoft.EntityFrameworkCore;
using BookStoreApp.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using BookStoreApp.Models;

namespace BookStoreApp.Controllers
{
    public class GenreController : Controller
    {   private readonly IGenreService _service;
        public GenreController( IGenreService service){
            _service=service;
        }
        

        public IActionResult Add()
        {   
            return View();
        }
        [HttpPost]
        public IActionResult Add(Genre genre){
            if(!ModelState.IsValid){
                return View(genre);
            }
            var result=_service.Add(genre);
            if(result){
                TempData["msg"]="Added succesfully";
                return RedirectToAction("Add"/*Hoặc that bằng nameof(Add)*/);
            }
            TempData["msg"]="Error has occured on sever side";
            return View();
        }


        public IActionResult Update( int id)
        {   
            var genre=_service.FindById(id);
            return View(genre);
        }
        [HttpPost]
        public IActionResult Update(Genre genre){
            if(!ModelState.IsValid){
                return View(genre);
            }
            var result=_service.Update(genre);
           
            if(result){
                TempData["msg"]="Update succesfully";
                
                return RedirectToAction("GetAll"/*Hoặc that bằng nameof(Add)*/);
            }
            TempData["msg"]="Error has occured on sever side";
            return View();
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