using FluentAssertions;
using Xunit;

namespace SpeakOps.Data.IntegrationTests
{
	public class WhenQueryingMeetupsTests : IClassFixture<PostgresFixture>
	{
		private readonly PostgresFixture _postgresFixture;

		public WhenQueryingMeetupsTests(PostgresFixture postgresFixture)
		{
			_postgresFixture = postgresFixture;
		}

		[Fact]
		public void ThenSomething()
		{
			_postgresFixture.Something();
			true.Should().Be(true);
		}
	}
}