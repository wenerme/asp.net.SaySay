namespace ASP
{
	public enum WithMessageType
	{
		Default, Primary, Success, Info, Warning, Danger
	}
	public interface IWithMessage
	{
		string Message { get; }
		WithMessageType MessageType { get; }
		bool HaveMessage();

		void DefaultMsg(string msg);
		void SuccessMsg(string msg);
		void InfoMsg(string msg);
		void WarningMsg(string msg);
		void DangerMsg(string msg);
		void WithMsg(string msg, WithMessageType type);
	}
}