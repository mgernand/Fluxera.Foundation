namespace Fluxera.MongoDB.DbContext.UnitTests.Serialization
{
	using System;
	using FluentAssertions;
	using Fluxera.MongoDB.DbContext.Serialization.Serializers;
	using global::MongoDB.Bson;
	using global::MongoDB.Bson.IO;
	using global::MongoDB.Bson.Serialization;
	using NUnit.Framework;

	[TestFixture]
	public class DateOnlyTests
	{
		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			BsonSerializer.RegisterSerializer(new CustomDateOnlySerializer());
		}

		private class TestClass
		{
			public DateOnly Property { get; set; }
		}

		[Test]
		public void ShouldDeserialize()
		{
			string json = @"{""property"" : ""2022-04-01""}";
			TestClass result = BsonSerializer.Deserialize<TestClass>(json);

			result.Should().NotBeNull();
			result.Property.Should().Be(new DateOnly(2022, 4, 1));
		}

		[Test]
		public void ShouldSerialize()
		{
			TestClass obj = new TestClass
			{
				Property = new DateOnly(2022, 4, 1),
			};

			string json = obj.ToJson(new JsonWriterSettings
			{
				Indent = true
			});

			Console.WriteLine(json);
			json.Should().Contain(@"""2022-04-01""");
		}
	}
}
