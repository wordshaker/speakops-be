using Microsoft.AspNetCore.Mvc;

namespace SpeakOps.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class MeetupsController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new ObjectResult(new
            {
                meetups = new[]
                {
                    new
                    {
                        location = new
                        {
                            longitude = 52.9535,
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
        }
    }
}
