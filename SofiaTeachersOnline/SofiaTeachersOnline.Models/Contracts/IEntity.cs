using System;
using System.Collections.Generic;
using System.Text;

namespace SofiaTeachersOnline.Models.Contracts
{
    public interface IEntity
    {
        public DateTime CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
