using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.DomainLayer.Models.Entities
{
    public class User
    {
        [Key][Column("user_id")] public int UserId { get; set; }

        [Column("email")] public string Email { get; set; } = string.Empty;

        [Column("user_token")] public string UserToken { get; set; } = string.Empty;
    }
}