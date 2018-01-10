<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Routine_Generator.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="table-responsive">
            <table class="table">
                <thead>
                    <tr>
                        <th><a href="Routine By Course Code.aspx" data-toggle="collapse" data-target="document.getElementById('info')">Routine By Course Code</a></th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>
        </div>
        <div class="table-responsive">
            <table class="table">
                <thead>
                    <tr>
                        <th><a href="Routine By Semester.aspx">Routine By Semester</a></th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>
        </div>
    </div>
    <div class="collapse" id="info">
        Inout your course code into the textboxes along with your section and get the routine. Useful if you are not going with regular semester sequence
    </div>
</asp:Content>
