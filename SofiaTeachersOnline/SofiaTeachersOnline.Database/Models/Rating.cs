using SofiaTeachersOnline.Database.Models.Abstracts;
using System;

namespace SofiaTeachersOnline.Database.Models
{
    public class Rating : Entity
    {
        public int Id { get; set; }

        public Guid GivenById { get; set; }
        public Student GivenBy { get; set; }
        public Guid GivenToId { get; set; }
        public Teacher GivenTo { get; set; }
    }
}
