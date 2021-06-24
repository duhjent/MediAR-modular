namespace MediAR.Modules.Membership.Domain.Users.Events
{
    public class NewUserCreatedEvent
    {
        public NewUserCreatedEvent(string id)
        {
            Id = id;
        }
        
        public string Id { get; }
    }
}