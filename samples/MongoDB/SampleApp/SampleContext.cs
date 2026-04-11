namespace SampleApp
{
	using Fluxera.MongoDB.DbContext;
	using JetBrains.Annotations;
	using MongoDB.Driver;

	[PublicAPI]
	public sealed class SampleContext : MongoDbContext
	{
		public SampleContext(MongoDbContextOptions options)
			: base(options)
		{
		}

		public IMongoCollection<User> Users { get; set; }

		public IMongoCollection<Tenant> Tenants { get; set; }

		/// <inheritdoc />
		protected override void OnConfiguring(MongoDbContextOptionsBuilder builder)
		{
			if(!builder.IsConfigured)
			{
				builder
					.UseDatabase("mongodb://localhost:27017", "test")
					.EnableTelemetry()
					.CaptureCommandText();
			}
		}
	}
}
