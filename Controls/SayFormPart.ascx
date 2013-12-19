<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SayFormPart.ascx.cs" Inherits="ControlsSayFormPart" %>

<div class="row">
    <form class="col-xs-8 col-xs-offset-2" role="search" method="POST" action=".">
        <div class="input-group">
            <input type="text" name="content" class="form-control"
                   value=""
                   placeholder="想说点什么呢..."> 
            <span class="input-group-btn">
                <button class="btn btn-info btn-group" type="submit"><i class="glyphicon glyphicon-pencil"></i></button>
            </span>
        </div>
    </form>
</div>