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
		private const string InitialConnectionString = "Host=localhost;Username=postgres;Password=password;Pooling=false;Database=postgres";
		private const string SpeakopsDbConnectionString = "Host=localhost;Username=postgres;Password=password;Pooling=false;Database=speakops";

		public void Something()
		{
			using (var createDatabaseConnection = NpgsqlFactory.Instance.CreateConnection())
			{
				createDatabaseConnection.ConnectionString = InitialConnectionString;
				createDatabaseConnection.Open();

				createDatabaseConnection.Execute("create database speakops");
			}

			using (var createSchemaAndTablesConnection = NpgsqlFactory.Instance.CreateConnection())
			{
				createSchemaAndTablesConnection.ConnectionString = SpeakopsDbConnectionString;
				createSchemaAndTablesConnection.Open();

				var sql = File.ReadAllText("./Scripts/speakops_001.sql");

				createSchemaAndTablesConnection.Execute(sql);
			}

			var sessionFactory = SessionFactory.With(config =>
			{
				config
					.WithProviderFactory(NpgsqlFactory.Instance)
					.WithConnectionString(SpeakopsDbConnectionString);
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

		public void Dispose()
		{
			using (var deleteDatabaseConnection = NpgsqlFactory.Instance.CreateConnection())
			{
				deleteDatabaseConnection.ConnectionString = InitialConnectionString;
				deleteDatabaseConnection.Open();

				deleteDatabaseConnection.Execute("drop database speakops");
			}
		}
	}
}
