using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using Task3.Common.Model;
using Task3.Repositories;
using Task3.Repositories.Entities;

namespace Task3.Api.Controllers
{
    /// <summary>
    /// Represents the Training Controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingRepository _trainingRepository;
        private readonly IMapper _mapper;
        public TrainingController(ITrainingRepository trainingRepository, IMapper mapper)
        {
            _trainingRepository = trainingRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds the training details.
        /// </summary>
        /// <param name="trainingModel"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult AddTraining(TrainingModel trainingModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (_trainingRepository.AddTraining(_mapper.Map<TrainingEntity>(trainingModel)))
                    return Ok("Data submitted successfully. Date difference is "
                        + Math.Round((trainingModel.EndDate - trainingModel.StartDate).TotalDays));
                else
                    return BadRequest("Request Contains Invalid Data.");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }
    }
}
