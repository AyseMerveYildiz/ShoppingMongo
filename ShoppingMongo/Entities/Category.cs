﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ShoppingMongo.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }
    }
}
