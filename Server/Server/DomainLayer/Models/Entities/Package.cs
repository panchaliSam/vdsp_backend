using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.DomainLayer.Models.Entities
{
    public class Package
    {
        [Key][Column("package_id")] public int PackageId { get; set; }
        [Column("package_name")] public string PackageName { get; set; }
        [Column("package_price")] public double PackagePrice { get; set; }
        [Column("no_of_photos")] public int NoOfPhotos { get; set; }
    }
}

