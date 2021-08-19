using SofiaTeachersOnline.Database.Models.Abstracts;
using SofiaTeachersOnline.Database.Models.Contracts;
using System;

namespace SofiaTeachersOnline.Database.Models
{
    public class Notebook : Entity, IModifiable
    {
        public string Notes { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        //public Dictionary<string, Dictionary<string, string>> Notes { get; set; }

        public DateTime? ModifiedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid? ModifiedByUserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public AppUser ModifiedByUser { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
