using VCMS.Core.Enums;

namespace VCMS.Core.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public int ClientId { get; set; }

        [JsonIgnore]
        public virtual Client Client { get; set; }
        public int SpeciesId { get; set; }

        [JsonIgnore]
        public virtual Species Species { get; set; }
        public int Count { get; set; }

        /// <summary>
        /// Represents Patient's Sex. 0 for Female and 1 for Male. 
        /// </summary>
        public ESex Sex { get; set; }
        public string Age { get; set; }


        [JsonIgnore]
        public virtual List<Case> Cases { get; set; } = new List<Case>(); 
    }
}
