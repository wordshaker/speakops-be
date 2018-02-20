using System.Collections.Generic;

namespace SpeakOps.Api.AcceptanceTests.Responses
{
    public class MeetupsResponse
    {
        public IList<Meetup> Meetups { get; set; }
    }

    public class Meetup
    {
        public Location Location { get; set; }
        public string Name { get; set; }
        public bool TravelAndExpenses { get; set; }
        public IList<string> Topics { get; set; }
        public IList<Organiser> Organisers { get; set; }
        public ContactDetails ContactDetails { get; set; }
        public string SpeakerPack { get; set; }
    }

    public class Location
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    public class Organiser
    {
        public string Name { get; set; }
        public string Twitter { get; set; }
    }

    public class ContactDetails
    {
        public string CallForProposals { get; set; }
        public string Email { get; set; }
        public string Twitter { get; set; }
        public string Website { get; set; }
    }
}