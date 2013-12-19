using System;
using System.Collections.Generic;
using System.Linq;
using ASP;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

public partial class Index: BasicPage
{
	public List<Say> SayList { get; private set; }
	public int PageNo { get; private set; }
	public int MaxPageNo { get; private set; }
	public int PrePage = 9;
	public long ResultCount = 0;
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Request["search"] != null)
		{
			Response.Redirect(ResolveUrl("~/search/" + Request["search"]));
			return;
		}

		if (Request.HttpMethod == "POST")
		{
			var content = Request["content"];
			if (!IsLoggedIn())
			{
				WarningMsg(@"
请先 <a href='login' class='btn btn-xs btn-default'>登录</a> 或 <a href='register' class='btn btn-xs btn-primary'>注册</a> 后再进行操作.");
				goto NoContent;
			}

			if(string.IsNullOrEmpty(content))
			{
				WarningMsg("发表的说说无效,请从新发布.");
				goto NoContent;
			}

			content = content.Trim();
			if (content.Length < 6)
			{
				WarningMsg("说说的长度至少为6.");
				goto NoContent;
			}
			DangerMsg(CurrentMember.Say(content));
			if(!HaveMessage())
				SuccessMsg("发表成功.");
		NoContent:
			;
		}
		
		SayList = GetCurrentSayList();
	}

	private List<Say> GetCurrentSayList()
	{
		MongoCursor<Say> list = null;
		String value;

		value = (String)RouteData.Values["by"];
		if (value != null)
		{
			var member = Member.GetMemberByAccount(value);
			if (member == null)
			{
				DangerMsg("查找的用户不存在.");
				goto CanNotResolve;
			} else
			{
				list = Say.GetSayBy(member);
				goto Resolved;
			}
		}

		

		value = (String)RouteData.Values["search"];
		if (value != null && !string.IsNullOrWhiteSpace(value))
		{
			list = Say.GetSayContains(value);
			goto Resolved;
		}

		CanNotResolve:
		list = Say.GetLatestSay();
		Resolved:

		ResultCount = list.Clone<Say>().Count();
		MaxPageNo = (int)Math.Ceiling(ResultCount / (double)PrePage);
		
		PageNo = RouteData.Values["pageno"] == null ? PageNo : int.Parse((string)RouteData.Values["pageno"]);
		PageNo = PageNo > MaxPageNo ? MaxPageNo : PageNo;
		PageNo = PageNo < 1 ? 1 : PageNo;

		// 控制分页
		return list
			.SetLimit(PrePage)
			.SetSkip(PageNo * PrePage - PrePage)
			.ToList();
	}
}