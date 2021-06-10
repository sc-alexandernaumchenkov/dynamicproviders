using System.Collections.Generic;

namespace DynamicProviders
{
    public interface IOptionsStorage<out TMiddlewareOptions>
    {
        IEnumerable<TMiddlewareOptions> GetOptions();
    }
}
