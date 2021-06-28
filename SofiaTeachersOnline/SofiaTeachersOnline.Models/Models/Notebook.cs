using SofiaTeachersOnline.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SofiaTeachersOnline.Models
{
    public class Notebook : IEntity
    {
        public int Id { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        //public Dictionary<string, Dictionary<string, string>> Notes { get; set; }
        public string Notes { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
