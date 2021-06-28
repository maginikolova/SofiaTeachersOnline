using SofiaTeachersOnline.Models.Abstracts;
using SofiaTeachersOnline.Models.Contracts;
using System;

namespace SofiaTeachersOnline.Models
{
    public class Message : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime When { get; set; } = DateTime.UtcNow;

        public Guid SenderId { get; set; }
        public AppUser Sender { get; set; }

        public Guid ReceiverId { get; set; }
        public AppUser Receiver { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
