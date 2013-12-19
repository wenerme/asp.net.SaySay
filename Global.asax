<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        //在应用程序启动时运行的代码
        RegisterRoutes(RouteTable.Routes);
    }
    
    public static void RegisterRoutes(RouteCollection routes)
    {
        var optionalPageNo = new RouteValueDictionary {{"pageno",1}};
        routes.MapPageRoute("", "", "~/index.aspx");
        routes.MapPageRoute("", "page/{pageno}", "~/index.aspx");
        
        routes.MapPageRoute("", "search/{search}", "~/index.aspx");
        routes.MapPageRoute("", "search/{search}/page/{pageno}", "~/index.aspx");
        
        routes.MapPageRoute("", "by/{by}", "~/index.aspx");
        routes.MapPageRoute("", "by/{by}/page/{pageno}", "~/index.aspx");
        
        
        routes.MapPageRoute("", "{action}", "~/sign.aspx"
            , true
            , null
            , new RouteValueDictionary { { "action", "login|register|logout" } });
        // not found
        routes.MapPageRoute("NotFound", "{*url}", "~/NotFound.aspx");
    }
    
    void Application_End(object sender, EventArgs e)
    {
        //在应用程序关闭时运行的代码

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        //在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e) 
    {
        //在新会话启动时运行的代码

    }

    void Session_End(object sender, EventArgs e) 
    {
        //在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式 
        //设置为 StateServer 或 SQLServer，则不会引发该事件。

    }
       
</script>
