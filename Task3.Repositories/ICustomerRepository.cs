using Task3.Repositories.Entities;

namespace Task3.Repositories
{
    /// <summary>
    /// Represents the ICustomerRepository interface.
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Adds the customer to the database
        /// </summary>
        /// <param name="customer">The customer entity.</param>
        /// <returns>The boolean result true or false if customer is inserted.</returns>
        bool AddCustomer(Customer Customer);
    }
}
