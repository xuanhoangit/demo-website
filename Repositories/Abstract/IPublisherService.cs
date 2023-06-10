namespace BookStoreApp.Repositories.Abstract;
using BookStoreApp.Models;
public interface IPublisherService
{
    
    public bool Add(Publisher publisher);
    public bool Update (Publisher publisher);
        Publisher  FindById(int id);
    public bool Delete(int id);
    public IEnumerable<Publisher> getAll();
}