using System;
using System.IO;
using Badger.Data;
using Dapper;
using Npgsql;
using SpeakOps.Data.Commands;

namespace SpeakOps.Data.IntegrationTests
{
	public class PostgresFixture : IDisposable
	{
		private const string PostgresConnectionString = "Host=localhost;Username=postgres;Password=Spe@k0ps;Pooling=false;Database=postgres;Port=5435";
		private const string SpeakopsConnectionString = "Host=localhost;Username=postgres;Password=Spe@k0ps;Pooling=false;Database=speakops;Port=5435";

        public void Something()
		{
			RecreateDatabaseAndApplySchema();

		    var sessionFactory = SessionFactory.With(config =>
			{
				config
					.WithProviderFactory(NpgsqlFactory.Instance)
					.WithConnectionString(SpeakopsConnectionString);
			});

			using (var session = sessionFactory.CreateCommandSession())
			{
				session.Execute(new InsertMeetupCommand(new InsertMeetupCriteria
				{
					CallForProposals = "cfp",
					City = "city",
					Country = "country",
					Email = "email",
					Latitude = 2D,
					Longitude = 3D,
					Name = "name",
					SpeakerPack = "speakerpack",
					TravelAndExpenses = true,
					Twitter = "twitter",
					Website = "website"
				}));

				session.Commit();
			}
		}

	    private static void RecreateDatabaseAndApplySchema()
	    {
	        using (var deleteDatabaseConnection = NpgsqlFactory.Instance.CreateConnection())
	        {
	            deleteDatabaseConnection.ConnectionString = PostgresConnectionString;
	            deleteDatabaseConnection.Open();

	            deleteDatabaseConnection.Execute("drop database if exists speakops");
	        }

            using (var createDatabaseConnection = NpgsqlFactory.Instance.CreateConnection())
	        {
	            createDatabaseConnection.ConnectionString = PostgresConnectionString;
	            createDatabaseConnection.Open();

	            createDatabaseConnection.Execute("create database speakops");
	        }

	        using (var createSchemaAndTablesConnection = NpgsqlFactory.Instance.CreateConnection())
	        {
	            createSchemaAndTablesConnection.ConnectionString = SpeakopsConnectionString;
	            createSchemaAndTablesConnection.Open();

	            var sql = File.ReadAllText("./Scripts/speakops_001.sql");

	            createSchemaAndTablesConnection.Execute(sql);
	        }
	    }

	    public void Dispose()
		{
		    using (var deleteDatabaseConnection = NpgsqlFactory.Instance.CreateConnection())
		    {
		        deleteDatabaseConnection.ConnectionString = PostgresConnectionString;
		        deleteDatabaseConnection.Open();

		        deleteDatabaseConnection.Execute("drop database if exists speakops");
		    }
        }
	}
}
