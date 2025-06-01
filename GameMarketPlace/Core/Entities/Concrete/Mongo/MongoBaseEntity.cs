using Core.Entities.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete.Mongo
{
    public class MongoBaseEntity<TKey> : IEntity<TKey>
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public TKey Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime EditDate { get; set; } = DateTime.Now;
    }
}
