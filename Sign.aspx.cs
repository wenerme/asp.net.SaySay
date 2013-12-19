using System;
using System.Web.Routing;
using ASP;

public partial class Sign : BasicPage
{
	public string Action { get; private set; }

	protected void Page_Load(object sender, EventArgs e)
	{
		Action = (String)RouteData.Values["action"];
		if (Action == null)
		{
			Response.Redirect("login");
			return;
		}

		if (Action == "logout")
		{
			CurrentMember = null;
			Response.Redirect("~/");
		}

		if (Request.HttpMethod == "POST")
		{
			var member = new Member();
			member.Account = Request["account"];
			member.Password = Request["password"];

			if (Action == "login")
			{
				if (! Member.TryLogin(ref member))
					DangerMsg("登录失败,帐号或密码错误.");
					
			} else
			{
				DangerMsg(Member.TryRegister(member));
			}

			// 如果操作失败,则当前用户为空
			CurrentMember = HaveMessage() ? null : member;
			if (! HaveMessage())
				Response.Redirect(".");
		}
	}
}