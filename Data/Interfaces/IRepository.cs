namespace Data.Interfaces;

public interface IRepository<T>
{
    Task<List<T>> GetAll();
    Task<T> Get(int id);
    Task<bool> Create(T entity);
    Task<bool> Update(T entity);
    Task<bool> Delete(T entity);
}