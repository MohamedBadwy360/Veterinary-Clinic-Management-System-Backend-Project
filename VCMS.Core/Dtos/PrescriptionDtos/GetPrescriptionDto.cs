namespace VCMS.Core.Dtos.PrescriptionDtos
{
    /// <summary>
    /// Retrival data transfer object for prescription
    /// </summary>
    public class GetPrescriptionDto : PrescriptionDto
    {
        /// <summary>
        /// Get list of prescribed medications dtos
        /// </summary>
        public List<GetPrescribedMedDto> PrescribedMedcations { get; set; }
    }
}
