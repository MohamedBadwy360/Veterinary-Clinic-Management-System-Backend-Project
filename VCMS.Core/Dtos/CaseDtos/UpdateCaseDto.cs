using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCMS.Core.Dtos.CaseDtos
{
    public class UpdateCaseDto
    {
        /// <summary>
        /// Get or set case's notes.
        /// </summary>
        [Required(ErrorMessage = "Notes is required.")]
        [MaxLength(1000, ErrorMessage = "Notes cant't be longer than 1000 character.")]
        public string Notes { get; set; }
    }
}
