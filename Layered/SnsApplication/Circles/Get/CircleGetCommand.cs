namespace SnsApplication.Circles.Get
{
    public class CircleGetCommand
    {
        public CircleGetCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
