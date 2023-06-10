namespace BookStoreApp.Repositories.Abstract;
using BookStoreApp.Models;
public interface IGenreService
{
    
    public bool Add(Genre genre);
    public bool Update (Genre genre);
        Genre  FindById(int id);
    public bool Delete(int id);
    public IEnumerable<Genre> getAll();
}