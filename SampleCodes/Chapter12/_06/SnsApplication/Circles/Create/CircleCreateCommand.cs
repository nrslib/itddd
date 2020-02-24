namespace _06.SnsApplication.Circles.Create
{
    public class CircleCreateCommand
    {
        public CircleCreateCommand(string userId, string name)
        {
            UserId = userId;
            Name = name;
        }
        public string UserId { get; }
        public string Name { get; }
    }
}
