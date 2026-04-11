namespace Fluxera.Queries.AspNetCore
{
	using Fluxera.Queries.AspNetCore.ModelBinding;
	using JetBrains.Annotations;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.DependencyInjection;

	/// <summary>
	///		Extensions methods for the <see cref="IServiceCollection"/> type.
	/// </summary>
	[PublicAPI]
	public static class ServiceCollectionExtensions
	{
		///  <summary>
		/// 	Adds ASP.NET Core and Open API support.
		///  </summary>
		///  <param name="services"></param>
		///  <returns></returns>
		public static IServiceCollection AddDataQueriesSwagger(this IServiceCollection services)
		{
			services.PostConfigure<MvcOptions>(options =>
			{
				options.ModelBinderProviders.Insert(0, new DataQueryModelBinderProvider());
			});

			//services.AddTransient<IPostConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>();

			return services;
		}
	}
}
