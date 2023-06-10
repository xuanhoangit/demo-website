namespace BookStoreApp.Repositories.Abstract;
using BookStoreApp.Models;
public interface IBookService
{
    
    public bool Add(Book book);
    public bool Update (Book book);
        Book  FindById(int id);
    public bool Delete(int id);
    public IEnumerable<Book> getAll();
}