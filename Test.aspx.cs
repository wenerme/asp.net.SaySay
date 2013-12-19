using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public partial class Test : BasicPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
		Response.Write("<pre>");
		Response.Write("生成测试数据\n");

	    DBHelper.GetCollection<Member>().Drop();
		DBHelper.GetCollection<Say>().Drop();

		{
			var wen = new Member();
			wen.Account = "wen";
			wen.Password = "wen";
			Member.TryRegister(wen);

			for (int i = 0; i < 10; i++)
			{
				wen.Say(@"这是一个简单的saysay.<br>只是用于测试内容.<br>关于我 <a href='http://wener.me'>wener</a>");
			}
	    }
		{
			var wen = new Member();
			wen.Account = "xiao";
			wen.Password = "wen";
			Member.TryRegister(wen);

			for (int i = 0; i < 10; i++)
			{
				wen.Say(@"这是由 xiao 发表的saysay.<br>只是用于测试内容.<br>关于我 <a href='http://wener.me'>wener</a>");
			}
		}

    }
}
