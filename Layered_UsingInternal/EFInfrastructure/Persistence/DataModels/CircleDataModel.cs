using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EFInfrastructure.Persistence.DataModels
{
    [Table("Circles")]
    public class CircleDataModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        
        public string OwnerId { get; set; }
        public UserDataModel Owner { get; set; }

        public IList<UserCircle> CircleMembers { get; set; } = new List<UserCircle>();
    }
}
