using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Json;
using Newtonsoft.Json.Linq;
using SpeakOps.Api.AcceptanceTests.Helpers;
using Xunit;

//https://github.com/dotnet/cli/issues/7901
//http://xunit.github.io/docs/getting-started-dotnet-core
//https://docs.microsoft.com/en-us/aspnet/core/testing/integration-testing
namespace SpeakOps.Api.AcceptanceTests
{
    public class GetAllMeetupsFixture : ApiFixture
    {
        private static string Url => "/api/v1/meetups";

        public GetAllMeetupsFixture() : base(Url)
        {
        }
    }

    public class WhenGettingAllMeetupsTests : IClassFixture<GetAllMeetupsFixture>
    {
        private readonly GetAllMeetupsFixture _getAllMeetupsFixture;

        public WhenGettingAllMeetupsTests(GetAllMeetupsFixture getAllMeetupsFixture)
        {
            _getAllMeetupsFixture = getAllMeetupsFixture;
        }

        [Fact]
        public async Task ThenTheExpectedStatusCodeIsReturned()
        {
            var response = await _getAllMeetupsFixture.Response;

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ThenTheExpectedMeetupsAreReturned()
        {
            var expectedResponseContent = JToken.FromObject(new
            {
                meetups = new[]
                {
                    new
                    {
                        location = new
                        {
                            longitude = 52.9536,
                            latitude = -1.15047,
                            city = "Nottingham",
                            country = "United Kingdom"
                        },
                        name = "NottsJS",
                        travelAndExpenses = true,
                        topics = new[] {"Javascript", "Technology"},
                        organisers = new[]
                        {
                            new
                            {
                                name = "David Wood",
                                twitter = "https://twitter.com/codesleuth"
                            }
                        },
                        contactDetails = new
                        {
                            callForProposals = "https://github.com/nottsjs/speakers",
                            email = "contact@nottsjs.org",
                            twitter = "https://twitter.com/nottsjs",
                            website = "https://nottsjs.org"
                        },
                        speakerPack =
                        "https://docs.google.com/document/d/1lzFu_UDTHOhEJKlgJwawV7cWiiVRZDcXt0q1kPHg2M0/edit?usp=sharing"
                    }
                }
            });

            var content = await _getAllMeetupsFixture.Content();
            content.Should().BeEquivalentTo(expectedResponseContent);
        }
    }
}
 