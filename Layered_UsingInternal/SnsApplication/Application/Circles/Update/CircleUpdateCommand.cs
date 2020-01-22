namespace SnsApplication.Application.Circles.Update
{
    public class CircleUpdateCommand
    {
        public CircleUpdateCommand(string id, string name = null)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; }
        public string Name { get; }
    }
}
