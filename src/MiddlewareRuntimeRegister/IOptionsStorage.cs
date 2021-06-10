using System.Collections.Generic;

namespace MiddlewareRuntimeRegister
{
    public interface IOptionsStorage<out TMiddlewareOptions>
    {
        IEnumerable<TMiddlewareOptions> GetOptions();
    }
}
