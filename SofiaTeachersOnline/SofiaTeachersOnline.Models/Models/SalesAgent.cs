using SofiaTeachersOnline.Models.Abstracts;
using System.Collections.Generic;

namespace SofiaTeachersOnline.Models
{
    public class SalesAgent : UserBase
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
