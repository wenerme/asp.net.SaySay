<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SayPart.ascx.cs" Inherits="ControlsSayPart" %>
<div class="col-xs-4 say-part">
    <h2>
        <a href="<%= ResolveUrl("~/by/" + Member.Account) %>"><%= Member.Account %></a>说道
    </h2>
    <p><%= Say.Content %></p>
</div>