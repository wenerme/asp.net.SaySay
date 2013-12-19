<%@ Page Language="C#" MasterPageFile="BasicMasterPage.master" 
         Title="Index" 
         Inherits="Index" 
         CodeFile="Index.aspx.cs"
    %>

<asp:Content runat="server" ID="unknown" ContentPlaceHolderID="BodyContent">
    <% if (!IsLoggedIn())
       { %>
        <uc:MainHeroUnit runat="server" />
    <% } else
       { %>
        <uc:SayForm runat="server" />
    <% } %>

    <hr />
    
    <div class="row" style="text-align: center">
        共查询到 <%= ResultCount %> 条结果.
        
    </div>

    <div class="row">
        <% foreach (Say say in SayList)
           {
               theSayPart.SetSay(say);
        %>
            <uc:Say ID="theSayPart" runat="server"/>
        <%
           } %>
    </div>
    
    <div class="row" style="text-align: center">
        <% thePagination.SetPageNo(PageNo, MaxPageNo); %>
        <uc:Pagination runat="server" ID="thePagination"/>
        
    </div>

</asp:Content>