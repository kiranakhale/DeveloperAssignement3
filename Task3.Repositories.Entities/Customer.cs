using System;

namespace Task3.Repositories.Entities
{
    /// <summary>
    /// Represents the Customer Entity Class
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets or sets the CustomerId.
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Gets or sets the CustomerName.
        /// </summary>
        public string CustomerName { get; set; }
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
