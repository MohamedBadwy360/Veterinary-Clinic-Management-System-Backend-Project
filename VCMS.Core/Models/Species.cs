namespace VCMS.Core.Models
{
    public class Species
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public virtual List<Patient> Patients { get; set; } = new List<Patient>();
    }
}
