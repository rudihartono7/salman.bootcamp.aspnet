using RAS.Bootcamp.Api.Net.Datas.Entities;

namespace RAS.Bootcamp.Api.Net.Datas;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly EMarketDbContext DbContext;
    private readonly IGuidRandom _randomGuid;
    public Repository(EMarketDbContext dbContext, IGuidRandom randomGuid)
    {
        DbContext = dbContext;
        _randomGuid = randomGuid;
    }
    public void Add(T newData)
    {
        DbContext.Add<T>(newData);
        DbContext.SaveChanges();
    }

    public T Get(int id)
    {
        return DbContext.Find<T>(id);
    }

    public Guid GetRandom(){
        return _randomGuid.GetRandomString();
    }

    public IEnumerable<T> GetList()
    {
        return DbContext.Set<T>().ToList();
    }

    public void Remove(int id)
    {
        var data = DbContext.Find<T>(id);
        if(data == null)
        {
            return;
        }

        DbContext.Remove<T>(data);
        DbContext.SaveChanges();
    }

    public void RemoveRange(IEnumerable<T> datas)
    {
        DbContext.RemoveRange(datas);
    }

    public void Update(T data)
    {
        DbContext.Update<T>(data);
        DbContext.SaveChanges();
    }
}
