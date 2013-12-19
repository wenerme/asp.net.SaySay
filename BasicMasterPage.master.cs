
namespace ASP
{
	public partial class BasicMasterPage : System.Web.UI.MasterPage
	{
		public new BasicPage Page { get { return base.Page as BasicPage; } }

		public bool HaveErrorMessage()
		{
			return Page.HaveMessage();
		}

		public string GetErrorMessage()
		{
			return Page.Message;
		}
	}
}