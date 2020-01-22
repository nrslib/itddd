using System.Collections.Generic;
using System.Linq;
using SnsDomain.Models.Circles;

namespace SnsApplication.Circles.Commons
{
    public class CircleData
    {
        public CircleData(Circle source) : this
        (
            source.Id.Value,
            source.Name.Value,
            source.Owner?.Value,
            source.Members.Select(x => x.Value).ToList()
        )
        { }

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