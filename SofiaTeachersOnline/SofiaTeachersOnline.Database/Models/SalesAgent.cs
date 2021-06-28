using System.Collections.Generic;

namespace SofiaTeachersOnline.Database.Models
{
    public class SalesAgent : AppUser
    {
        public int NumberOfSales { get; set; }
        public ICollection<GeneratedLink> GeneratedLinks { get; set; }
    }

    public class GeneratedLink
    {
        public int Id { get; set; }
        public string Url { get; set; }
    }
}
