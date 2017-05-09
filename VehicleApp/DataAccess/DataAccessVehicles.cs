using MongoDB.Bson;
using MongoDB.Driver.Builders;
using System.Collections.Generic;
using System.Linq;
using VehicleApp.Models;

namespace VehicleApp.DataAccess
{
    public class DataAccessVehicles : DataAccessBase<VehicleModel>
    {
        public DataAccessVehicles() : base("vehicle") { }

        public override VehicleModel Get(ObjectId id)
        {
            return Entity.FindOne(Query<VehicleModel>.EQ(e => e.id, id));
        }

        public override IEnumerable<VehicleModel> GetList()
        {
            return Entity.FindAll().ToList();
        }

        public override VehicleModel Create(VehicleModel myEntity)
        {
            Entity.Insert(myEntity);
            return myEntity;
        }

        public override VehicleModel Update(VehicleModel myEntity)
        {
            Entity.Save(myEntity);
            return myEntity;
        }

        public override bool Delete(ObjectId id)
        {
            var obj = Get(id);
            if (obj != null && obj.id != ObjectId.Empty)
            {
                Entity.Remove(Query<VehicleModel>.EQ(e => e.id, id));
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}