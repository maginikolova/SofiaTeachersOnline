using SofiaTeachersOnline.Database.Models.Abstracts;
using System;

namespace SofiaTeachersOnline.Database.Models
{
    public class Message : Entity
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public Guid SenderId { get; set; }
        public AppUser Sender { get; set; }

        public Guid ReceiverId { get; set; }
        public AppUser Receiver { get; set; }
    }
}
