﻿namespace RiskAnalysis.Application
{
    public class ServiceUserDto
    {
        public Guid Id { get; set; }
        public Guid PartnerId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
