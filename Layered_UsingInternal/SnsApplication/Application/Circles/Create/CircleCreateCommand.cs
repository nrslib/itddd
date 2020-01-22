namespace SnsApplication.Application.Circles.Create
{
    public class CircleCreateCommand
    {
        public CircleCreateCommand(string name, string ownerId)
        {
            Name = name;
            OwnerId = ownerId;
        }

        public string Name { get; }
        public string OwnerId { get; }
    }
}
