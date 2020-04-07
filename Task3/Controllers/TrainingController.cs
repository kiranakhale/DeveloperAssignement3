using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using Task3.Common.Model;
using Task3.Repositories;
using Task3.Repositories.Entities;

namespace Task3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingRepository _customer;
        private readonly IMapper _mapper;
        public TrainingController(ITrainingRepository customer,IMapper mapper)
        {
            _customer = customer;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        public IActionResult AddTraining(TrainingModel customerModel)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState.Values);

                if (_customer.AddTraining(_mapper.Map<TrainingEntity>(customerModel)))
                    return Ok("Data submitted successfully. Date difference is " 
                        + Math.Round((customerModel.EndDate - customerModel.StartDate).TotalDays));
                else
                    return BadRequest("Request Contains Invalid Data.");
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
           
        }
    }
}