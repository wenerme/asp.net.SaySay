using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public partial class ControlsSayPart : System.Web.UI.UserControl
{
	internal Member Member { get; private set; }
	public Say Say { get; private set; }
	
    protected void Page_Load(object sender, EventArgs e)
    {
		//Say = ViewState["say"] as Say;
		//Member = Say.ByMember();
    }

	public ControlsSayPart SetSay(Say say)
	{
		Say = say;
		Member = Say.ByMember();
		return this;
	}
}