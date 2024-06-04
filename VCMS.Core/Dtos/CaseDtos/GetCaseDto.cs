namespace VCMS.Core.Dtos.CaseDtos
{
    /// <summary>
    /// data transfer object for retrieving case inforamation. 
    /// </summary>
    public class GetCaseDto : CaseDto
    {
        /// <summary>
        /// Get or set client name.
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// Get or set patient name.
        /// </summary>
        public string SpeciesName { get; set; }

        /// <summary>
        /// Get or set diagnosis name.
        /// </summary>
        public string DiagnosisName { get; set; }

        /// <summary>
        /// Get or set doctor name
        /// </summary>
        public string DoctorName { get; set; }

        /// <summary>
        /// Get or set CaseType.
        /// </summary>
        public string CaseType { get; set; }

        /// <summary>
        /// Get or set Case Status.
        /// </summary>
        public string Status { get; set; }
    }
}
