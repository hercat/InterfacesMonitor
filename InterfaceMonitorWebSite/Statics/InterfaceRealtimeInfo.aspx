<%@ Page Title="接口实时状态" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="InterfaceRealtimeInfo.aspx.cs" Inherits="InterfaceMonitorWebSite.Statics.InterfaceRealtimeInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyRight" runat="server">
    <div>
        <div id="content_title">
            <span>接口实时状态</span>
        </div>
        <div id="content">
            <div>                             
                <div style="position:relative;display:inline;">
                    <img src="../images/green48.ico" />Interface1
                </div>
                <div style="position:relative;display:inline;">
                    <img src="../images/red48.ico" />Interface2
                </div>             
            </div>
        </div>
    </div>
</asp:Content>
