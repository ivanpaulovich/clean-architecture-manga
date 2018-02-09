//namespace Acerola.UI.Controllers
//{
//    using Acerola.Application.Queries;
//    using Acerola.Application.DTO;
//    using Acerola.Domain.Customers;
//    using Microsoft.AspNetCore.Mvc;
//    using System;
//    using System.Collections.Generic;
//    using System.Threading.Tasks;
//    using Acerola.Application.Boundary;
//    using Acerola.Application.UseCases;

//    [Route("api/[controller]")]
//    public class CustomersController : Controller
//    {
//        private readonly ICustomersQueries customersQueries;
//        private readonly IBoundary register;

//        public CustomersController(ICustomersQueries customersQueries,
//            IBoundary register)
//        {
//            if (customersQueries == null)
//                throw new ArgumentNullException(nameof(customersQueries));

//            if (register == null)
//                throw new ArgumentNullException(nameof(register));

//            this.customersQueries = customersQueries;
//            this.register = register;
//        }

//        /// <summary>
//        /// Register a new Customer
//        /// </summary>
//        [HttpPost]
//        public async Task<IActionResult> Post([FromBody]Interactor command)
//        {
//            Customer customer = await register.Handle(command);

//            CustomerData result = new CustomerData
//            {
//                CustomerId = customer.Id,
//                Name = customer.Name.Text,
//                Personnummer = customer.PIN.Text
//            };

//            return CreatedAtRoute("GetCustomer", new { id = result.CustomerId }, result);
//        }

//        /// <summary>
//        /// Get a Customer details 
//        /// </summary>
//        [HttpGet("{id}", Name = "GetCustomer")]
//        public async Task<IActionResult> GetCustomer(Guid id)
//        {
//            CustomerData customer = await customersQueries.GetCustomer(id);

//            return Ok(customer);
//        }

//        /// <summary>
//        /// List all customers
//        /// </summary>
//        [HttpGet]
//        public async Task<IActionResult> Get()
//        {
//            IEnumerable<CustomerData> customers = await customersQueries.GetAll();

//            return Ok(customers);
//        }
//    }
//}
