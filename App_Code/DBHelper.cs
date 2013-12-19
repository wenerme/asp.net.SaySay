using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace ASP
{
	public static class DBHelper
	{
		const string ConnectionString = "mongodb://localhost";
		public static readonly MongoDatabase DB = null;
		static DBHelper()
		{
			var client = new MongoClient(ConnectionString);
			var server = client.GetServer();
			DB = server.GetDatabase("saysay");

			// create user collection
			var users = GetCollection<Member>();
			users.EnsureIndex(new IndexKeysBuilder()
				.Ascending("Account"), IndexOptions.SetUnique(true));

			var says = GetCollection<Say>();
			says.EnsureIndex(new IndexKeysBuilder()
				.Descending("Date.Ticks", "By"));

		}
		#region Extension IEntity

		/// <summary>
		/// A T extension method that collections the given item.
		/// </summary>
		///
		/// <typeparam name="T"> Generic type parameter. </typeparam>
		/// <param name="item"> The item to act on. </param>
		///
		/// <returns>
		/// A list of.
		/// </returns>
		///
		public static MongoCollection<T> GetCollection<T>(this T item)
			where T:IEntity
		{
			return GetCollection<T>();
		}
		public static MongoCollection<T> GetCollection<T>()
			where T : IEntity
		{
			return DB.GetCollection<T>(GetCollectionName<T>());
		}
		/// <summary>
		/// An IEntity extension method that gets collection name.
		/// </summary>
		///
		/// <param name="item"> The item to act on. </param>
		///
		/// <returns>
		/// The collection name.
		/// </returns>
		///
		public static string GetCollectionName<T>(this T item)
			where T : IEntity
		{
			return GetCollectionName<T>();
		}
		public static string GetCollectionName<T>()
			where T : IEntity
		{
			return typeof(T).Name;
		}
		#endregion

	}
}