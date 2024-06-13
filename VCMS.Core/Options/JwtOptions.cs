﻿namespace VCMS.Core.Options
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; } 
        public string Audience { get; set; }
        public double DuarationInMinutes { get; set; }
    }
}
