using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Week2Homework.DataModel;
using Week2Homework.DBOperations;
using Week2Homework.Uow;

namespace Week2Homework.Controllers
{
    [ApiController]
    [Route("[controller]/s/[action]")]
    public class CustomerController : ControllerBase
    {

        private readonly ILogger<CustomerController> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CustomerController(ILogger<CustomerController> _logger, IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            logger = _logger;
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        [HttpGet]
        public List<CustomerDTO> GetCustomer()
        {
            var list = unitOfWork.CustomerRepository.GetAll().ToList();
            var result = mapper.Map<List<Customer>, List<CustomerDTO>>(list);
            return result;

        }

        [HttpGet("{id}")]
        public CustomerDTO GetById(long id)
        {
            var customer = unitOfWork.CustomerRepository.GetById(id);
            var result = mapper.Map<Customer, CustomerDTO>(customer);
            return result;
        }

        [HttpPost]
        public ActionResult<CustomerDTO> AddCustomer([FromBody] CustomerDTO newCustomer)
        {
            if (newCustomer == null)
            {
                return NoContent();
            }
            Customer customer = mapper.Map<CustomerDTO, Customer>(newCustomer);
            unitOfWork.CustomerRepository.Insert(customer);

            unitOfWork.Save();
            return Ok(newCustomer);
        }

        [HttpPut("{id}")]
        public ActionResult<CustomerDTO> UpdateCustomer([FromBody] Customer updatedCustomer)
        {
            if (updatedCustomer == null)
            {
                return NoContent();
            }
            var customer = unitOfWork.CustomerRepository.GetById(updatedCustomer.Id);
            if (customer == null)
            {
                return NotFound();
            }

            customer.FirstName = updatedCustomer.FirstName;
            customer.LastName = updatedCustomer.LastName;
            customer.PhoneNumber = updatedCustomer.PhoneNumber;
            customer.Gender = updatedCustomer.Gender;
            customer.Age = updatedCustomer.Age;

            unitOfWork.CustomerRepository.Update(customer);

            unitOfWork.Save();
            var map = mapper.Map<Customer,CustomerDTO>(customer); ;
            return Ok(map);        
        }

        [HttpDelete("{id}")]
        public ActionResult<Customer> DeleteCustomer(long id)
        {
            
            var customer = unitOfWork.CustomerRepository.GetById(id);

            if (customer is null)
            {
                return BadRequest();
            }

            unitOfWork.CustomerRepository.Delete(customer.Id);
            unitOfWork.Save();
            return Ok();
        }


    }
}
