using SofiaTeachersOnline.Models.Contracts;
using System;

namespace SofiaTeachersOnline.Models
{
    public class Rating : IEntity
    {
        public int Id { get; set; }
        public Guid GivenById { get; set; }
        public Student GivenBy { get; set; }
        public Guid GivenToId { get; set; }
        public Teacher GivenTo { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
