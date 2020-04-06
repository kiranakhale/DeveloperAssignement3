using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Net;
using Task3.Common.Model;
using Task3.Controllers;
using Task3.Mapper;
using Task3.Repositories;
using Task3.Repositories.Entities;

namespace Task3.TestProject
{
    [TestClass]
    public class TrainingControllerTest
    {
        private readonly CustomerController _trainingController;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public TrainingControllerTest()
        {
            _customerRepository = Substitute.For<ICustomerRepository>();
            _mapper = new TaskMapper().Mapper;
            _trainingController = new CustomerController(_customerRepository, _mapper);
        }

        [TestMethod]
        public void CreateReturnSuccess()
        {
            //Arrange
            var startDate = DateTime.Now;
            var endDate = DateTime.Now.AddDays(1);
            _customerRepository.AddCustomer(Arg.Any<Customer>()).Returns(true);
            //Act
            var response = _trainingController.create(new CustomerModel() { EndDate = endDate, Name = "test", StartDate = startDate });
            var okResult = response as OkObjectResult;
            //Verify
            Assert.IsNotNull(okResult);
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual("Data submitted successfully. Date difference is " + Math.Round((endDate - startDate).TotalDays), okResult.Value);

        }

        [TestMethod]
        public void CreateReturnBadRequest()
        {
            var response = _trainingController.create(null);
            var badResult = response as BadRequestObjectResult;
            //Verify
            Assert.IsNotNull(badResult);
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badResult.StatusCode);
        }

        [TestMethod]
        public void CreateReturnBadRequestWhenRecordNotInsertedToDB()
        {
            _customerRepository.AddCustomer(Arg.Any<Customer>()).Returns(false);
            var response = _trainingController.create(new CustomerModel { EndDate = DateTime.Now, Name = "Name", StartDate = DateTime.Now });
            var badResult = response as BadRequestObjectResult;
            //Verify
            Assert.IsNotNull(badResult);
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badResult.StatusCode);
        }

        [TestMethod]
        public void CreateReturnBadRequestWhenNameIsNotValid()
        {
            var response = _trainingController.create(new CustomerModel { EndDate = DateTime.Now, StartDate = DateTime.Now });
            var badResult = response as BadRequestObjectResult;
            //Verify
            Assert.IsNotNull(badResult);
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badResult.StatusCode);
        }

        [TestMethod]
        public void CreateReturnInternalServerErrorWhenExceptionRaised()
        {
            _customerRepository.AddCustomer(Arg.Any<Customer>()).Throws(new Exception());
            var response = _trainingController.create(new CustomerModel { EndDate = DateTime.Now, StartDate = DateTime.Now });

            var result = response as StatusCodeResult;
            //Verify
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, result.StatusCode);
        }
    }
}
