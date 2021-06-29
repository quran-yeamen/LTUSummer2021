using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Homework2.Models
{
    public class Product
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public double Price { get; set; }

        public double WholesalePrice { get; set; }
    }
}