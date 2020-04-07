using Task3.Repositories.Entities;

namespace Task3.Repositories
{
    /// <summary>
    /// Represents the Training Repository Class.
    /// </summary>
    public class TrainingRepository : ITrainingRepository
    {
        private readonly Task3DbContext _task3DbContext;
        public TrainingRepository(Task3DbContext task3DbContext)
        {
            _task3DbContext = task3DbContext;
        }

        /// <summary>
        /// Adds the training to the database
        /// </summary>
        /// <param name="trainingEntity">The training entity.</param>
        /// <returns>The boolean result true or false if training is inserted.</returns>
        public bool AddTraining(TrainingEntity trainingEntity)
        {
            _task3DbContext.Add(trainingEntity);
            return (_task3DbContext.SaveChanges() > 0) ? true : false;
        }
    }
}
