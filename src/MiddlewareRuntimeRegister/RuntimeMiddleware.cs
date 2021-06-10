using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Owin.Builder;
using Owin;

namespace MiddlewareRuntimeRegister
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class RuntimeMiddleware<TMiddleware, TMiddlewareOptions>
    {
        private readonly AppFunc _next;
        private readonly IAppBuilder _appBuilder;
        private readonly IOptionsStorage<TMiddlewareOptions> _optionsStorage;
        private AppFunc _subPipeline;

        public RuntimeMiddleware(AppFunc next, IAppBuilder appBuilder, IOptionsStorage<TMiddlewareOptions> optionsStorage)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _appBuilder = appBuilder ?? throw new ArgumentNullException(nameof(appBuilder));
            _optionsStorage = optionsStorage ?? throw new ArgumentNullException(nameof(optionsStorage));
        }

        public Task Invoke(IDictionary<string, object> environment)
        {
            var builder = _appBuilder.New();

            InjectMiddleware(builder);

            builder.Use(new Func<AppFunc, AppFunc>(_ => _next));
            _subPipeline = builder.Build();

            return _subPipeline != null ? _subPipeline(environment) : _next(environment);
        }

        private void InjectMiddleware(IAppBuilder app)
        {
            foreach (var options in _optionsStorage.GetOptions())
            {
                app.Use(typeof(TMiddleware), (object)app, (object)options);

            }
        }
    }
}