namespace Backend_Development_Assignment_3.Services
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task Put(int id, T entity);
        Task Post(T entity);
        Task Delete(T entity);
        bool Exists(int id);
    }
}
