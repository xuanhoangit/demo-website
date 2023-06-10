using BookStoreApp.Models;
using BookStoreApp.Repositories.Abstract;
namespace BookStoreApp.Repositories.Implementation;
public class GenreService : IGenreService
{   
    public readonly BookContext _btx;
    public GenreService(BookContext btx)
    {
        _btx=btx;
    }
    public bool Add(Genre genre)
    {
       try
       {
        _btx.genres.Add(genre);
        _btx.SaveChanges();
        return true;
       }
       catch (System.Exception)
       {
        
        return false;
       }
    }

       public bool Update(Genre genre)
    {
          try
       {
        _btx.genres.Update(genre);
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

    public Genre FindById(int id)
    {
        
        return _btx.genres.Find(id);
    }

    public IEnumerable<Genre> getAll()
    {
       return _btx.genres.ToList();
    }



    
}