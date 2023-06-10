using BookStoreApp.Models;
using BookStoreApp.Repositories.Abstract;
namespace BookStoreApp.Repositories.Implementation;
public class BookService : IBookService
{   
    public readonly BookContext _btx;
    public BookService(BookContext btx)
    {
        _btx=btx;
    }
    public bool Add(Book book)
    {
       try
       {
        _btx.books.Add(book);
        _btx.SaveChanges();
        return true;
       }
       catch (System.Exception)
       {
        
        return false;
       }
    }

       public bool Update(Book book)
    {
          try
       {
        _btx.books.Update(book);
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

    public Book FindById(int id)
    {
        
        return _btx.books.Find(id);
    }

    public IEnumerable<Book> getAll()
    { 
      var result=(from book in _btx.books 
      join author in _btx.authors on book.AuthorId equals author.Id 
      join genre in _btx.genres on book.GenreID equals genre.Id
      join publisher in _btx.publishers on book.PublisherID equals publisher.Id
      select new Book{
         Id=book.Id,
         Title=book.Title,
         Isbn=book.Isbn,
         GenreID=book.GenreID,
         AuthorId=book.AuthorId,
         PublisherID=book.PublisherID,
         GenreName=genre.Name,
         AuthorName=author.AuthorName,
         PublisherName=publisher.PublisherName
      }
      ).ToList();
       return result;
    }


    
}