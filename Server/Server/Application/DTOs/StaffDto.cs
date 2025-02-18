namespace Server.Application.DTOs
{
    public class StaffDto
    {
        public string StaffFirstName { get; set; } = string.Empty;
        public string StaffLastName { get; set; } = string.Empty;
        
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int TeamId { get; set; }
    }
}

