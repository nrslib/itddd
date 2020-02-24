namespace _20.SnsApplication.Circles.Update
{
    public class CircleUpdateCommand
    {
        public CircleUpdateCommand(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; }
        public string Name { get; }
    }
}
