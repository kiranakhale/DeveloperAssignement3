using Task3.Repositories.Entities;

namespace Task3.Repositories
{
    /// <summary>
    /// Represents the Customer Repository Class.
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Task3DbContext _task3DbContext;
        public CustomerRepository(Task3DbContext task3DbContext)
        {
            _task3DbContext = task3DbContext;
        }

        /// <summary>
        /// Adds the customer to the database
        /// </summary>
        /// <param name="customer">The customer entity.</param>
        /// <returns>The boolean result true or false if customer is inserted.</returns>
        public bool AddCustomer(Customer customer)
        {
            _task3DbContext.Add(customer);
            return (_task3DbContext.SaveChanges() > 0) ? true : false;
        }
    }
}
