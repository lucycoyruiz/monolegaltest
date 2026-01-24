using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Monolegal.Domain.Entities
{
    public class Invoice
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("clientId")]
        public string ClientId { get; set; } = string.Empty;

        [BsonElement("number")]
        public string Number { get; set; } = string.Empty;

        [BsonElement("amount")]
        public decimal Amount { get; set; }

        [BsonElement("status")]
        public string Status { get; set; } = string.Empty;
    }
}
