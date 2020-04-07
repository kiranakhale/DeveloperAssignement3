using System;
using System.ComponentModel.DataAnnotations;

namespace Task3.Repositories.Entities
{
    /// <summary>
    /// Represents the Training Entity Class
    /// </summary>
    public class TrainingEntity
    {
        [Key]
        /// <summary>
        /// Gets or sets the TrainingId.
        /// </summary>
        public int TrainingId { get; set; }
        /// <summary>
        /// Gets or sets the TrainingName.
        /// </summary>
        public string TrainingName { get; set; }
        /// <summary>
        /// Gets or sets the StartDate.
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Gets or sets the EndDate.
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
