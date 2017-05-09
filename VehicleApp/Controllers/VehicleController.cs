using System.Collections.Generic;
using System.Web.Http;
using VehicleApp.Models;

namespace VehicleApp.Controllers
{
    public class VehicleController : ApiController
    {
        DataAccess.DataAccessVehicles dataVehicles = new DataAccess.DataAccessVehicles();

        // GET api/vehicle
        public IEnumerable<VehicleModel> Get()
        {
            return dataVehicles.GetList();
        }

        // GET api/vehicle/5
        public VehicleModel Get(string id)
        {
            return dataVehicles.Get(new MongoDB.Bson.ObjectId(id));
        }

        // POST api/vehicle
        public VehicleModel Post(VehicleModel value)
        {
            value = dataVehicles.Create(value);
            return value;
        }

        // PUT api/vehicle/5
        public VehicleModel Put(string id, VehicleModel value)
        {
            value.id = new MongoDB.Bson.ObjectId(id);
            value = dataVehicles.Update(value);
            return value;
        }

        // DELETE api/vehicle/5
        public void Delete(string id)
        {
            dataVehicles.Delete(new MongoDB.Bson.ObjectId(id));
        }
    }
}