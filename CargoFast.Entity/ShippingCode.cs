using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CargoFast.Entity;
public class ShippingCode : BaseEntity
{
    public string Shipping { get; set; }   
   
    [BsonRepresentation(BsonType.ObjectId)]
    public string SenderId { get; set; }
        
    
    [BsonRepresentation(BsonType.ObjectId)]
    public string ReceiverId { get; set; }

    public int PackageCount { get; set; }
    public int PackageWeight { get; set; }
    public ShippingEnum ShippingEnum { get; set; }
}