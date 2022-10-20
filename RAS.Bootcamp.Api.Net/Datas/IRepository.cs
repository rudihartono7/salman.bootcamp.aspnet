namespace RAS.Bootcamp.Api.Net.Datas;

public interface IRepository<T> where T: class {
    T Get(int id);
    Guid GetRandom();
    IEnumerable<T> GetList();
    void Add(T newData);
    void Update(T data);
    void Remove(int id);
    void RemoveRange(IEnumerable<T> datas);
}
