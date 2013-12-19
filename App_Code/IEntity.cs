using MongoDB.Bson;

namespace ASP
{
	public interface IEntity
	{
		 ObjectId Id { get; }
	}
}