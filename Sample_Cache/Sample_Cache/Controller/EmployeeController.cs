using System;
using Microsoft.AspNetCore.Mvc;

namespace Sample_Cache.Controller
{
	[Route("api/[controller]")]
	public class EmployeeController : ControllerBase
	{
		private ICacheProvider _cacheProvider;

		public EmployeeController(ICacheProvider cacheProvider)
		{
			_cacheProvider = cacheProvider;
		}

		[Route("getAllEmployee")]
		public IActionResult GetAllEmployee()
		{
			try
			{
				var employees = _cacheProvider.GetCachedResponse().Result;

				return Ok(employees);
			}
			catch(Exception ex)
			{
				return new ContentResult()
				{
					StatusCode = 500,
					Content = "{ \n error : " + ex.Message + "}",
					ContentType = "application/json"
				};
			}
		}
	}
}
