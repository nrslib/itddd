using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFInfrastructure.Persistence.DataModels
{
    [Table("Users")]
    public class UserDataModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Range(0, 1)]
        public int Type { get; set; }

        public IList<CircleDataModel> OwnedCircles { get; set; }

        public IList<UserCircle> MemberOf { get; set; } = null;
    }
}
