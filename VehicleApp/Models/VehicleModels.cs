using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleApp.Models
{
    public class VehicleModel
    {
        public ObjectId id { get; set; }
        public string plate { get; set; }
        public string vehicles_document { get; set; }
        public string owner_name { get; set; }
        public string owner_document { get; set; }
        public bool blocked { get; set; }
        public List<string> images { get; set; }
    }
}