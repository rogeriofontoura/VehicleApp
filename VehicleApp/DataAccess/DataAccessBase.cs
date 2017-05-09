using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace VehicleApp.DataAccess
{
    public abstract class DataAccessBase<T>
    {
        public MongoCollection<T> Entity;

        public DataAccessBase(string entityName)
        {
            MongoClient client = new MongoClient(System.Configuration.ConfigurationManager.ConnectionStrings["mongoConnectionString"].ConnectionString);
            var server = client.GetServer();
            var dataBase = server.GetDatabase("vehicles");
            Entity = dataBase.GetCollection<T>(entityName);
        }

        public abstract IEnumerable<T> GetList();
        public abstract T Get(ObjectId id);
        public abstract T Create(T myEntity);
        public abstract T Update(T myEntity);
        public abstract bool Delete(ObjectId id);
    }
}