namespace Fluxera.StronglyTypedId.LiteDB.UnitTests
{
	using System;
	using System.Linq;
	using System.Threading.Tasks;
	using FluentAssertions;
	using Fluxera.LiteDB.Queryable;
	using Fluxera.StronglyTypedId.LiteDB;
	using Fluxera.StronglyTypedId.LiteDB.UnitTests.Model;
	using global::LiteDB;
	using global::LiteDB.Async;
	using NUnit.Framework;

	[TestFixture]
	public class QueryTests
	{
		private LiteDatabaseAsync database;
		private ILiteCollectionAsync<Person> collection;

		[OneTimeSetUp]
		public async Task SetUp()
		{
			BsonMapper.Global.Entity<Person>().Id(x => x.Id);
			BsonMapper.Global.UseStronglyTypedId();

			this.database = new LiteDatabaseAsync($"{Guid.NewGuid():N}.db");
			this.collection = this.database.GetCollection<Person>();

			Person person = new Person
			{
				Id = PersonId.Create("fcd5f4f9753a4284a2d0f500b9b23cf8"),
				Name = "Tester"
			};

			await this.collection.InsertAsync(person);
		}

		[OneTimeTearDown]
		public void TearDown()
		{
			this.database?.Dispose();
		}

		[Test]
		public async Task ShouldFindByStronglyTypedID()
		{
			Person linqFilterResult = await this.collection
				.AsQueryable()
				.Where(x => x.Id == PersonId.Create("fcd5f4f9753a4284a2d0f500b9b23cf8"))
				.FirstOrDefaultAsync();
			linqFilterResult.Should().NotBeNull();
		}

		[Test]
		public async Task ShouldFindByValue()
		{
			Person linqFilterResult = await this.collection
				.AsQueryable()
				.Where(x => x.Id == "fcd5f4f9753a4284a2d0f500b9b23cf8")
				.FirstOrDefaultAsync();

			linqFilterResult.Should().NotBeNull();
		}
	}
}
