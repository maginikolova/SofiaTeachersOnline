using SofiaTeachersOnline.Database.Models.Abstracts;
using System;

namespace SofiaTeachersOnline.Database.Models
{
    public class Notebook : Entity
    {
        public string Notes { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        //public Dictionary<string, Dictionary<string, string>> Notes { get; set; }
    }
}
