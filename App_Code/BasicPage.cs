using System;
using System.Web.UI;
using ASP;

public abstract class BasicPage : Page, IWithMessage
{
	public const string ROOT_URL = "/SaySay/";

	public Member CurrentMember { get; protected set; }
	public string Message { get; protected set; }
	public WithMessageType MessageType { get; private set; }

	public bool HaveMessage()
	{
		return Message != null;
	}

	public void DefaultMsg(string msg)
	{
		WithMsg(msg, WithMessageType.Default);
	}

	public void SuccessMsg(string msg)
	{
		WithMsg(msg, WithMessageType.Success);
	}

	public void InfoMsg(string msg)
	{
		WithMsg(msg, WithMessageType.Info);
	}

	public void WarningMsg(string msg)
	{
		WithMsg(msg, WithMessageType.Warning);
	}

	public void DangerMsg(string msg)
	{
		WithMsg(msg, WithMessageType.Danger);
	}

	public void WithMsg(string msg, WithMessageType type)
	{
		Message = msg;
		MessageType = type;
	}

	public bool IsLoggedIn()
	{
		return CurrentMember != null;
	}

	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);
		CurrentMember = Session["CurrentMember"] as Member;
	}

	protected override void OnUnload(EventArgs e)
	{
		base.OnUnload(e);
		Session["CurrentMember"] = CurrentMember;
	}
}