namespace _20.EFInfrastructure.Persistence.DataModels
{
    public class OwnerCircle
    {
        public string OwnerId { get; set; }
        public UserDataModel Owner { get; set; }

        public string CircleId { get; set; }
        public CircleDataModel Circle { get; set; }
    }
}
