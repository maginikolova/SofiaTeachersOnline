using SofiaTeachersOnline.Models.Abstracts;
using System;

namespace SofiaTeachersOnline.Models.Contracts
{
    public interface IModifiable
    {
        public DateTime? ModifiedOn { get; set; }
        public AppUser ModifiedByUser { get; set; }
    }
}
