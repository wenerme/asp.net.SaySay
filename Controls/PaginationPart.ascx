<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PaginationPart.ascx.cs" Inherits="ControlsPaginationPart" %>
<ul class="pagination">
    <li class="<%=PageNo == 1?"disabled":"" %>"><a href="<%=PageNoURL(1)%>">&laquo;</a></li>

    <% if (MinPageNo > 1)
       { %>
        <li class="disabled"><a href="">...</a></li>
    <% } %>
    <%
       // 输出中间部分
       for (int p = MinPageNo; p <= MaxPageNo; p ++)
       {
    %>
        <li class="<%= PageNo == p ? "disabled" : "" %>"><a href="<%= PageNoURL(p) %>"><%= p %></a></li>
    <% } %>
			  
    <% if (MaxPageNo < PageCount)
       { %>
        <li class="disabled"><a href="">...</a></li>
    <% } %>
			  
    <li class="<%= PageNo == PageCount ? "disabled" : "" %>"><a href="<%= PageNoURL(PageCount) %>">&raquo;</a></li>
</ul>