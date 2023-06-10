using BookStoreApp.Models;
using BookStoreApp.Repositories.Abstract;
namespace BookStoreApp.Repositories.Implementation;
public class PublisherService : IPublisherService
{   
    public readonly BookContext _btx;
    public PublisherService(BookContext btx)
    {
        _btx=btx;
    }
    public bool Add(Publisher publisher)
    {
       try
       {
        _btx.publishers.Add(publisher);
        _btx.SaveChanges();
        return true;
       }
       catch (System.Exception)
       {
        
        return false;
       }
    }

       public bool Update(Publisher publisher)
    {
          try
       {
        _btx.publishers.Update(publisher);
        _btx.SaveChanges();
        return true;
       }
       catch (System.Exception)
       {
        
        return false;
       }
    }

    public bool Delete(int id)
    {
       try
       {
         var exist=FindById(id);
        if(exist==null){
           return false;
        }
         _btx.Remove(exist);
         _btx.SaveChanges();
            return true;
       }
       catch (System.Exception)
       {
        
         return false;
       }
    }

    public Publisher FindById(int id)
    {
        
        return _btx.publishers.Find(id);
    }

    public IEnumerable<Publisher> getAll()
    {
       return _btx.publishers.ToList();
    }



    
}