using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.DomainLayer.Models.Entities
{
    public class Role
    {
        [Key][Column("role_id")] public int RoleId { get; set; }
        
        [Column("role_name")] public string RoleName { get; set; }
    }
}

