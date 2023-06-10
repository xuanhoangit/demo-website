using BookStoreApp.Models;
using BookStoreApp.Repositories.Abstract;
namespace BookStoreApp.Repositories.Implementation;
public class AuthorService : IAuthorService
{   
    public readonly BookContext _btx;
    public AuthorService(BookContext btx)
    {
        _btx=btx;
    }
    public bool Add(Author author)
    {
       try
       {
        _btx.authors.Add(author);
        _btx.SaveChanges();
        return true;
       }
       catch (System.Exception)
       {
        
        return false;
       }
    }

       public bool Update(Author author)
    {
          try
       {
        _btx.authors.Update(author);
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

    public Author FindById(int id)
    {
        
        return _btx.authors.Find(id);
    }

    public IEnumerable<Author> getAll()
    {
       return _btx.authors.ToList();
    }



    
}