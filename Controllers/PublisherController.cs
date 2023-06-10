using Microsoft.EntityFrameworkCore;
using BookStoreApp.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using BookStoreApp.Models;

namespace BookStoreApp.Controllers
{
    public class PublisherController : Controller
    {   private readonly IPublisherService _service;
        public PublisherController( IPublisherService service){
            _service=service;
        }
        

        public IActionResult Add()
        {   
            return View();
        }
        [HttpPost]
        public IActionResult Add(Publisher publisher){
            if(!ModelState.IsValid){
                return View(publisher);
            }
            var result=_service.Add(publisher);
            if(result){
                TempData["msg"]="Added succesfully";
                return RedirectToAction("Add"/*Hoặc that bằng nameof(Add)*/);
            }
            TempData["msg"]="Error has occured on sever side";
            return View();
        }


        public IActionResult Update( int id)
        {   
            var publisher=_service.FindById(id);
            return View(publisher);
        }
        [HttpPost]
        public IActionResult Update(Publisher publisher){
            if(!ModelState.IsValid){
                return View(publisher);
            }
           
            _service.Update(publisher);
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