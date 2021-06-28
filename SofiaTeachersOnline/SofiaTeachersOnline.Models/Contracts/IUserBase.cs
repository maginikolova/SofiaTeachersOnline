using System;

namespace SofiaTeachersOnline.Models.Contracts
{
    public interface IUserBase
    {
        public Guid Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime LastOnline { get; set; }
        public string ProfilePic { get; set; }
        //public List<Message> MessaesSent { get; set; }
        //public List<IMessage> MessagesReceived { get; set; }
    }
}
