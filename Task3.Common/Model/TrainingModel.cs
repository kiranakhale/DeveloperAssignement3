using System;
using System.ComponentModel.DataAnnotations;

namespace Task3.Common.Model
{
    /// <summary>
    /// Represents the TrainingModel DTO.
    /// </summary>
    public class TrainingModel
    {
        /// <summary>
        /// Gets or sets the TrainingName.
        /// </summary>
        [Required]
        public string TrainingName { get; set; }
        /// <summary>
        /// Gets or sets the StartDate.
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Gets or sets the EndDate.
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }
    }
}
