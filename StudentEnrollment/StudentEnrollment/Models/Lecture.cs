using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace StudentEnrollment.Models
{
    public class Lecture
    {
        [BsonElement("Duration")]
        public int Duration { get; set; }
        [BsonElement("NoOfLecWeekly")]
        public int NoOfLecWeekly { get; set; }
        [BsonElement("Theatre")]
        public string Theatre { get; set; }
    }
}
