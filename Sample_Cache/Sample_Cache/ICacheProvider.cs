using System.Collections.Generic;
using System.Threading.Tasks;
using Sample_Cache.Entity;

namespace Sample_Cache
{
	public interface ICacheProvider
	{
		Task<IEnumerable<Employee>> GetCachedResponse();
	}
}
