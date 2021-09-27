namespace SofiaTeachersOnline.Services.DTOs.Contracts
{
    public interface IIdentifiable<TType>
    {
        public TType Id { get; set; }
    }
}
