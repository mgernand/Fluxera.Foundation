namespace Fluxera.StronglyTypedId.SystemTextJson
{
	using System.Text.Json;
	using Fluxera.Guards;
	using JetBrains.Annotations;

	/// <summary>
	///     Extension methods for the <see cref="JsonSerializerOptions" /> type.
	/// </summary>
	[PublicAPI]
	public static class JsonSerializerOptionsExtensions
	{
		/// <summary>
		///     Configures the serializer to use the <see cref="StronglyTypedIdConverter{TStronglyTypedId,TValue}" />.
		/// </summary>
		/// <param name="options"></param>
		public static void UseStronglyTypedId(this JsonSerializerOptions options)
		{
			Guard.Against.Null(options);

			options.Converters.Add(new StronglyTypedIdJsonConverterFactory());
		}
	}
}
