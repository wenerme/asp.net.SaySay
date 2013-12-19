using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace ASP
{
	public class Say:IEntity
	{
		public ObjectId Id { get; private set; }

		[BsonDateTimeOptions(Representation = BsonType.Document)]
		public DateTime Date { get; set; }
		public string Content { get; set; }
		public ObjectId By { get; internal set; }

		internal Say()
		{
			Date = DateTime.UtcNow;
		}

		public Member ByMember()
		{
			return DBHelper.GetCollection<Member>().FindOneById(By);
		}


		public static MongoCursor<Say> GetLatestSay()
		{
			return DBHelper
				.GetCollection<Say>()
				.FindAll()
				.SetSortOrder(SortBy.Descending("Date.Ticks"))
				;
		}
		public static MongoCursor<Say> GetSayBy(Member member)
		{
			return GetSayBy(member.Id);
		}
		public static MongoCursor<Say> GetSayBy(BsonValue id)
		{
			var query = Query.EQ("By", id);
			return DBHelper
				.GetCollection<Say>()
				.Find(query)
				.SetSortOrder(SortBy.Descending("Date.Ticks"))
				;
		}
		public static MongoCursor<Say> GetSayContains(string key)
		{
			var query = Query.Matches("Content", key);
			return DBHelper
				.GetCollection<Say>()
				.Find(query)
				.SetSortOrder(SortBy.Descending("Date.Ticks"))
				;
		}
	}
}