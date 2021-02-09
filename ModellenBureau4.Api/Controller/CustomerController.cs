using Microsoft.AspNetCore.Mvc;
using ModellenBureau4.Api.Models;
using ModellenBureau4.Shared;

namespace ModellenBureau4.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            return Ok(_customerRepository.GetAllCustomers());
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            return Ok(_customerRepository.GetCustomerById(id));
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest();

            if (customer.FirstName == string.Empty || customer.LastName == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCustomer = _customerRepository.AddCustomer(customer);

            return Created("customer", createdCustomer);
        }

        [HttpPut]
        public IActionResult UpdateCustomer([FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest();

            if (customer.FirstName == string.Empty || customer.LastName == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerToUpdate = _customerRepository.GetCustomerById(customer.Id);

            if (customerToUpdate == null)
                return NotFound();

            _customerRepository.UpdateCustomer(customer);

            return NoContent(); //success
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            if (id == 0)
                return BadRequest();

            var customerToDelete = _customerRepository.GetCustomerById(id);
            if (customerToDelete == null)
                return NotFound();

            _customerRepository.DeleteCustomer(id);

            return NoContent();//success
        }
    }
}
