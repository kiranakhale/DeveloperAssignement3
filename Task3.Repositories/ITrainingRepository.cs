using Task3.Repositories.Entities;

namespace Task3.Repositories
{
    /// <summary>
    /// Represents the ITrainingRepository interface.
    /// </summary>
    public interface ITrainingRepository
    {
        /// <summary>
        /// Adds the training to the database
        /// </summary>
        /// <param name="trainingEntity">The training entity.</param>
        /// <returns>The boolean result true or false if training is inserted.</returns>
        bool AddTraining(TrainingEntity trainingEntity);
    }
}
