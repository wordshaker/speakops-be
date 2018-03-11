using Badger.Data;
using NpgsqlTypes;

namespace SpeakOps.Data.Commands
{
	public class InsertMeetupCommand : ICommand
	{
		private readonly InsertMeetupCriteria _criteria;

		public InsertMeetupCommand(InsertMeetupCriteria criteria)
		{
			_criteria = criteria;
		}

		public IPreparedCommand Prepare(ICommandBuilder builder)
		{
			var location = new NpgsqlPoint(_criteria.Latitude, _criteria.Longitude);

			return builder
			       .WithSql("insert into speakops.meetups(name, location, city, country, travelandexpenses, callforproposals, email, twitter, website, speakerpack) values (@name, @location, @city, @country, @travelandexpenses, @callforproposals, @email, @twitter, @website, @speakerpack)")
			       .WithParameter("name", _criteria.Name)
			       .WithParameter("location", location)
			       .WithParameter("city", _criteria.City)
			       .WithParameter("country", _criteria.Country)
			       .WithParameter("travelandexpenses", _criteria.TravelAndExpenses)
			       .WithParameter("callforproposals", _criteria.CallForProposals)
			       .WithParameter("email", _criteria.Email)
			       .WithParameter("twitter", _criteria.Twitter)
			       .WithParameter("website", _criteria.Website)
			       .WithParameter("speakerpack", _criteria.SpeakerPack)
			       .Build();

		}
	}

	public class Organiser
	{
		public string Name { get; set; }
		public string Twitter { get; set; }
	}

	public class InsertMeetupCriteria
	{
		public string CallForProposals { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
		public string Email { get; set; }
		public double Longitude { get; set; }
		public double Latitude { get; set; }
		public string Name { get; set; }
		public string SpeakerPack { get; set; }
		public bool TravelAndExpenses { get; set; }
		public string Twitter { get; set; }
		public string Website { get; set; }
	}
}
