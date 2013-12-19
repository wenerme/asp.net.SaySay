using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ControlsPaginationPart : System.Web.UI.UserControl
{
	public int MaxPageNo { get; set; }
	public int MinPageNo = 1;
	public int PageNo { get; set; }
	public int PageCount { get; set; }
	public int ShowPageNo = 11;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

	public string PageNoURL(int pageNo)
	{
		string path = HttpContext.Current.Request.Url.AbsoluteUri.TrimEnd('/');
		path = Regex.Replace(path, @"/?page/\d+", "");
		return path +"/page/"+ pageNo;
	}

	public void SetPageNo(int pageNo, int pageCount)
	{
		PageNo = pageNo;
		PageCount = pageCount;

		MinPageNo = PageNo - (ShowPageNo - 1) / 2;
		MaxPageNo = PageNo + (ShowPageNo - 1) / 2;

		if (MinPageNo < 1)
		{
			MaxPageNo += 1 - MinPageNo;
			MinPageNo = 1;
		}
		if (MaxPageNo > PageCount)
			MaxPageNo = PageCount;
	}
}