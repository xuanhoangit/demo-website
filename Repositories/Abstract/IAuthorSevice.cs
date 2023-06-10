namespace BookStoreApp.Repositories.Abstract;
using BookStoreApp.Models;
public interface IAuthorService
{
    
    public bool Add(Author author);
    public bool Update (Author author);
        Author  FindById(int id);
    public bool Delete(int id);
    public IEnumerable<Author> getAll();
}