using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VCMS.Core.Dtos.SpeciesDtos
{
    /// <summary>
    /// Data transfer object for species
    /// </summary>
    public class SpeciesDto
    {
        /// <summary>
        /// Name of species
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(50, ErrorMessage = "Name can't be longer than 50 characters.")]
        public string Name { get; set; }

        /// <summary>
        /// Equals method override for SpeciesDto class.
        /// </summary>
        /// <param name="obj">
        /// The object to compare with the current object.
        /// </param>
        /// <returns>
        /// True if the specified object is equal to the current object; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is SpeciesDto response &&
                Name == response.Name;
        }

        /// <summary>
        /// GetHashCode method override for Response class.
        /// </summary>
        /// <returns>
        /// Hash code for the current object.
        /// </returns>
        public override int GetHashCode()
        {
            return Name.Length + HashCode.Combine(Name);
        }
    }
}
