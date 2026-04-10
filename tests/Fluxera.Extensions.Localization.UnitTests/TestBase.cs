namespace Fluxera.Extensions.Localization.UnitTests
{
	using System;
	using Microsoft.Extensions.DependencyInjection;

	public class TestBase
    {
        protected static IServiceProvider BuildServiceProvider(Action<IServiceCollection> configure)
        {
            IServiceCollection services = new ServiceCollection();
			services.AddLogging();

            configure(services);

            return services.BuildServiceProvider();
        }
    }
}
