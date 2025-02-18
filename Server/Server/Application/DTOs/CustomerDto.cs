﻿namespace Server.Application.DTOs
{
    public class CustomerDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        
        public int UserId { get; set; }
    }
}

