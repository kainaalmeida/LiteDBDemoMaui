using LiteDB;

namespace LiteDBDemo.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        LiteDatabase _db;
        public GenericRepository()
        {
            _db = new LiteDatabase(GetPath());
        }

        public void Add(T entity)
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            collection.Insert(entity);
        }

        public IEnumerable<T> GetAll()
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            return collection.Query().ToEnumerable();
        }

        public string GetPath()
        {
            var path = FileSystem.Current.AppDataDirectory;

            return Path.Combine(path, "litedbdemo.db");
        }
    }
}
