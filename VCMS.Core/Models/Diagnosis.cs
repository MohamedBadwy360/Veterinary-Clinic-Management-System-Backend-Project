namespace VCMS.Core.Models
{
    /// <summary>
    /// Represents a diagnosis that can be assigned to a case.
    /// </summary>
    public class Diagnosis
    {
        /// <summary>
        /// Gets or sets the unique identifier for the diagnosis.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the diagnosis.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets list of cases that have this diagnosis.
        /// </summary>
        public virtual List<Case> Cases { get; set; } = new List<Case>();
    }
}
