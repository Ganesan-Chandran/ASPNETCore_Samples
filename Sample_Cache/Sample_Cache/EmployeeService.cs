using System.Collections.Generic;
using Sample_Cache.Entity;

namespace Sample_Cache
{
	public static class EmployeeService
	{
		public static List<Employee> GetEmployeesDeatilsFromDB()
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
