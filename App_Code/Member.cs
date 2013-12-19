using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace ASP
{
	public class Member: IEntity
	{
		public ObjectId Id { get; set; }
		public string Account { get; set; }
		public string Password { get; set; }

		public static bool TryLogin(ref Member member)
		{
			var query = Query.And(Query.EQ("Account", member.Account), Query.EQ("Password", member.Password));
			var result = member.GetCollection().FindOne(query);

			if (result != null)
				member = result;

			return result != null;
		}

		public static string TryRegister(Member member)
		{
			var query = Query.EQ("Account", member.Account);
			if (null != member.GetCollection().FindOne(query))
				return "该用户已被注册.";

			var result = member.GetCollection().Insert(member);
			if (!result.Ok)
				return result.ErrorMessage;

			return null;
		}

		public string Say(string content)
		{
			var say = new Say();
			say.By = Id;
			say.Content = content;
			var result = say.GetCollection().Save(say);
			return result.Ok ? null : result.ErrorMessage;
		}

		public static Member GetMemberByAccount(string account)
		{
			var query = Query.EQ("Account", account);
			return DBHelper.GetCollection<Member>().FindOne(query);
		}
	}
}