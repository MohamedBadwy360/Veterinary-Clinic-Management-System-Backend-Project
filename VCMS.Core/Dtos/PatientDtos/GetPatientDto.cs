namespace VCMS.Core.Dtos.PatientDtos
{
    /// <summary>
    /// Data transfer object for getting a patient.
    /// </summary>
    public class GetPatientDto : PatientDto
    {
        /// <summary>
        /// Gets or sets the name of the client.
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// Gets or sets the name of the species.
        /// </summary>
        public string SpeciesName { get; set; }
    }
}
