using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.DomainLayer.Models.Entities
{
    public class Team
    {
        [Key][Column("team_id")] public int TeamId { get; set; }
        [Column("team_name")] public string TeamName { get; set; }
    }
}

