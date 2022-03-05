using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore_Swagger_UI.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore_Swagger_UI.Controller
{
	[Route("[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		/// <summary>
		/// Gets the list of all Employees.
		/// </summary>
		/// <returns>The list of Employees.</returns>
		/// <response code="200">Returns the items</response>
		[HttpGet]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IEnumerable<Employee> Get()
		{
			return GetEmployeesDeatils();
		}

		[HttpGet("{id}")]
		[Produces("application/json")]
		public Employee Get(int id)
		{
			return GetEmployeesDeatils().Find(e => e.Id == id);
		}

		/// <summary>
		/// Creates an Employee.
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// 
		///     POST api/Employee
		///     {        
		///       "firstName": "Test",
		///       "lastName": "Name",
		///       "emailId": "Test.Name@gmail.com"        
		///     }
		/// </remarks>
		/// <param name="employee"></param>
		/// <response code="201">Returns the newly created item</response>
		/// <response code="400">If the item is null</response>
		[HttpPost]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public Employee Post([FromBody] Employee employee)
		{
			// Write logic to insert employee data
			return new Employee()
			{
				Id = 4,
				FirstName = employee.FirstName,
				LastName = employee.LastName,
				EmailId = employee.EmailId
			};
		}

		private List<Employee> GetEmployeesDeatils()
		{
			return new List<Employee>()
			{
				new Employee()
				{
					Id = 1,
					FirstName= "Test",
					LastName = "Name",
					EmailId ="Test.Name@gmail.com"
				},
				new Employee()
				{
					Id = 2,
					FirstName= "Test",
					LastName = "Name1",
					EmailId ="Test.Name1@gmail.com"
				}
			};
		}
	}
}
