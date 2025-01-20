using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models.Entities
{
    public class Customer
    {
        [Key] [Column("cus_id")] public int CusId { get; set; }

        [Column("cus_first_name")] public string? FirstName { get; set; } = string.Empty;

        [Column("cus_last_name")] public string LastName { get; set; } = string.Empty;

        [Column("phone")] public string Phone { get; set; } = string.Empty;
        [Column("email")] public string Email { get; set; } = string.Empty;

        [Column("user_id")] public int UserId { get; set; }

        [ForeignKey("UserId")] public User User { get; set; } = new User();
    }
}