using System.Collections.Generic;

namespace SnsApplicationPort.Circles.Commons
{
    public class CircleData
    {
        public CircleData(string id, string name, string ownerId, List<string> memberIds)
        {
            Id = id;
            Name = name;
            OwnerId = ownerId;
            MemberIds = memberIds;
        }

        public string Id { get; }
        public string Name { get; }
        public string OwnerId { get; }
        public List<string> MemberIds { get; }
    }
}