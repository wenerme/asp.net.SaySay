<%@ Page Title="用户登录" Language="C#" MasterPageFile="BasicMasterPage.master" 
    AutoEventWireup="true"
    CodeFile="Sign.aspx.cs" Inherits="Sign"
%>
<asp:Content runat="server" ID="Header" ContentPlaceHolderID="HeaderContent">
    
    <script src="scripts/login.js"> </script>

</asp:Content>
<asp:Content runat="server" ID="Body" ContentPlaceHolderID="BodyContent">
    <div class="col-xs-4 col-xs-offset-4 no-float">
        <div class="section-header page-header">
            <h1>用户登陆</h1>
        </div>

        <form id="main-form" role="form" method="post" action="login" 
            data-login-action="login" 
            data-register-action="register"
            data-form-mode="<%=Page.RouteData.Values["action"] %>"
            >

            <div class="form-group">
                <div class="input-group">
                    <span class="input-group-addon">
                        <i class="fa fa-user"></i>
                    </span> 
                    <input type="text" 
                        class="form-control" 
                        name="account" 
                        required="required" 
                        placeholder="用户名">
                </div>
            </div>
            <div class="form-group">
                <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-key"></i></span> 
                    <input
                        type="password" class="form-control" name="password"
                        required="required" placeholder="密码">
                </div>
            </div>

            <div class="form-group register-field with-dec">
                <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-arrows-v"></i>
                    </span> <input type="password" class="form-control" name="repeat_password"
                                   placeholder="请再次输入密码">
                </div>

                <button type="button" class="close dec-tr register-off-btn"
                        aria-hidden="true">&times;</button>
            </div>
            <div class="form-group">
                <button type="submit"
                        class="login-btn btn btn-default col-sm-4 col-sm-offset-1">登录</button>
                <button class="register-btn btn btn-primary col-sm-4 col-sm-offset-1">注册</button>
            </div>
        </form>
    </div>

</asp:Content>