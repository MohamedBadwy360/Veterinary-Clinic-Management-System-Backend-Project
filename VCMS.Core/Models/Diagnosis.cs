namespace VCMS.Core.Models
{
    public class Diagnosis
    {
        public int Id { get; set; }
        public string Name { get; set; }


        [JsonIgnore]
        public virtual List<Case> Cases { get; set; } = new List<Case>();
    }
}
