namespace EFInfrastructure.Persistence.DataModels
{
    public class UserCircle
    {
        public string UserId { get; set; }
        public UserDataModel User { get; set; }

        public string CircleId { get; set; }
        public CircleDataModel Circle { get; set; }
    }
}
