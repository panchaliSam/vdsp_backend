using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.DomainLayer.Models.Entities
{
    public class Staff
    {
        [Key]
        [Column("staff_id")]
        public int StaffId { get; set; }

        [Column("staff_first_name")]
        public string StaffFirstName { get; set; } = string.Empty;

        [Column("staff_last_name")]
        public string StaffLastName { get; set; } = string.Empty;

        [Column("role_id")]
        public int RoleId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }
        
        [Column("team_id")]
        public int TeamId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [ForeignKey(nameof(RoleId))]
        public Role? Role { get; set; }
        
        [ForeignKey((nameof(TeamId)))]
        public Team? Team { get; set; }
    }
}