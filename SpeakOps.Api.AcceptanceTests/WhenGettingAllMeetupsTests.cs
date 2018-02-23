using System.Net;
using System.Threading.Tasks;
using Shouldly;
using SpeakOps.Api.AcceptanceTests.Helpers;
using SpeakOps.Api.AcceptanceTests.Responses;
using Xunit;

//https://github.com/dotnet/cli/issues/7901
//http://xunit.github.io/docs/getting-started-dotnet-core
//https://docs.microsoft.com/en-us/aspnet/core/testing/integration-testing
//https://github.com/shouldly/shouldly
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

            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ThenTheExpectedMeetupsAreReturned()
        {
            var content = await _getAllMeetupsFixture.Content<MeetupsResponse>();

            content.Meetups.Count.ShouldBe(1);
            var meetup = content.Meetups[0];
            meetup.Location.City.ShouldBe("Nottingham");
            meetup.Location.Country.ShouldBe("United Kingdom");
            meetup.Location.Longitude.ShouldBe("52.9535");
            meetup.Location.Latitude.ShouldBe("-1.15047");

            meetup.Name.ShouldBe("NottsJS");
            meetup.TravelAndExpenses.ShouldBe(true);

            meetup.Topics.Count.ShouldBe(2);
            meetup.Topics.ShouldContain(t => t == "Javascript");
            meetup.Topics.ShouldContain(t => t == "Technology");

            meetup.Organisers.Count.ShouldBe(1);
            var organiser = meetup.Organisers[0];
            organiser.Name.ShouldBe("David Wood");
            organiser.Twitter.ShouldBe("https://twitter.com/codesleuth");

            meetup.ContactDetails.CallForProposals.ShouldBe("https://github.com/nottsjs/speakers");
            meetup.ContactDetails.Email.ShouldBe("contact@nottsjs.org");
            meetup.ContactDetails.Twitter.ShouldBe("https://twitter.com/nottsjs");
            meetup.ContactDetails.Website.ShouldBe("https://nottsjs.org");

            meetup.SpeakerPack.ShouldBe("https://docs.google.com/document/d/1lzFu_UDTHOhEJKlgJwawV7cWiiVRZDcXt0q1kPHg2M0/edit?usp=sharing");
        }
    }
}
 