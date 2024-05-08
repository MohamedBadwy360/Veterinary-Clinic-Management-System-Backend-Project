﻿namespace VCMS.Core.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }


        public virtual List<Patient> Patients { get; set; } = new List<Patient>();
    }
}