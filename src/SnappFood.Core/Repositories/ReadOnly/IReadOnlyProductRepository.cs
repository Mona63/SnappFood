namespace SnappFood.Core
{
    public interface IReadOnlyRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
