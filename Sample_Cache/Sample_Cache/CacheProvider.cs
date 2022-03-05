using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Sample_Cache.Entity;

namespace Sample_Cache
{
	public class CacheProvider : ICacheProvider
	{
		private static readonly SemaphoreSlim GetUsersSemaphore = new SemaphoreSlim(1, 1);

		private readonly IMemoryCache _cache;

		public CacheProvider(IMemoryCache memoryCache)
		{
			_cache = memoryCache;
		}

		public async Task<IEnumerable<Employee>> GetCachedResponse()
		{
			try
			{
				return await GetCachedResponse(CacheKeys.Employees, GetUsersSemaphore);
			}
			catch
			{
				throw;
			}			
		}

		private async Task<IEnumerable<Employee>> GetCachedResponse(string cacheKey, SemaphoreSlim semaphore)
		{
			bool isAvaiable = _cache.TryGetValue(cacheKey, out List<Employee> employees);

			if (isAvaiable)
				return employees;

			try
			{
				await semaphore.WaitAsync();

				isAvaiable = _cache.TryGetValue(cacheKey, out employees);

				if (isAvaiable)
					return employees;

				employees = EmployeeService.GetEmployeesDeatilsFromDB();

				var cacheEntryOptions = new MemoryCacheEntryOptions
				{
					AbsoluteExpiration = DateTime.Now.AddMinutes(5),
					SlidingExpiration = TimeSpan.FromMinutes(2),
					Size = 1024,
				};

				_cache.Set(cacheKey, employees, cacheEntryOptions);
			}
			catch
			{
				throw;
			}
			finally
			{
				semaphore.Release();
			}

			return employees;
		}
	}
}
