namespace Fluxera.MongoDB.DbContext.Serialization
{
	using System;
	using Fluxera.MongoDB.DbContext.Serialization.Serializers;
	using global::MongoDB.Bson.Serialization;
	using global::MongoDB.Bson.Serialization.Serializers;

	/// <inheritdoc />
	internal sealed class DateOnlySerializationProvider : IBsonSerializationProvider
	{
		private static readonly CustomDateOnlySerializer Serializer = new CustomDateOnlySerializer();
		private static readonly NullableSerializer<DateOnly> NullableSerializer = new NullableSerializer<DateOnly>(Serializer);

		/// <inheritdoc />
		public IBsonSerializer GetSerializer(Type type)
		{
			if(type == typeof(DateOnly))
			{
				return Serializer;
			}

			if(type == typeof(DateOnly?))
			{
				return NullableSerializer;
			}

			// Fall back to MongoDB defaults.
			return null;
		}
	}
}
