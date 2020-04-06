using System;
using System.ComponentModel.DataAnnotations;

namespace Task3.Common.Model
{
    /// <summary>
    /// Represents the CustomerModel DTO.
    /// </summary>
    public class CustomerModel
    {
        /// <summary>
        /// Gets or sets the CustomerName.
        /// </summary>
        [Required]
        public string Name { get; set; }
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
