<%@ Page Title="Routine By Semester" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Routine By Semester.aspx.cs" Inherits="Routine_Generator.Select_Semester" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center bg-info">Routine By Semester</h2>
    <table class="table table-responsive table-hover table-bordered">
        <tr>
            <td class="text-right">Select Department&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonListDept" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                    <asp:ListItem class="radio-inline">SWE</asp:ListItem>
                    <asp:ListItem class="radio-inline">CSE</asp:ListItem>
                    <asp:ListItem class="radio-inline">MCT</asp:ListItem>
                    <asp:ListItem class="radio-inline">Pharmacy</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select Department" ControlToValidate="RadioButtonListDept" CssClass="auto-style1"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <table class="table table-responsive table-hover table-bordered">
        <tr>
            <td>
                <asp:Label ID="LabelMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Select Semester
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButtonList ID="RadioButtonListSelectSemester" runat="server">
                    <asp:ListItem class="radio-inline">Level 1 - Term 1</asp:ListItem>
                    <asp:ListItem class="radio-inline">Level 1 - Term 2</asp:ListItem>
                    <asp:ListItem class="radio-inline">Level 1 - Term 3</asp:ListItem>
                    <asp:ListItem class="radio-inline">Level 2 - Term 1</asp:ListItem>
                    <asp:ListItem class="radio-inline">Level 2 - Term 2</asp:ListItem>
                    <asp:ListItem class="radio-inline">Level 2 - Term 3</asp:ListItem>
                    <asp:ListItem class="radio-inline">Level 3 - Term 1</asp:ListItem>
                    <asp:ListItem class="radio-inline">Level 3 - Term 2</asp:ListItem>
                    <asp:ListItem class="radio-inline">Level 3 - Term 3</asp:ListItem>
                    <asp:ListItem class="radio-inline">Level 4 - Term 1</asp:ListItem>
                    <asp:ListItem class="radio-inline">Level 4 - Term 2</asp:ListItem>
                </asp:RadioButtonList>

            </td>
        </tr>
        <tr>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Semester" ForeColor="Red" ControlToValidate="RadioButtonListSelectSemester"></asp:RequiredFieldValidator>
        </tr>
    </table>
    <br />
    <span>Enter Section</span>
    <asp:TextBox ID="TextBoxSec" runat="server" CssClass="form-control" Width="50px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ControlToValidate="TextBoxSec" CssClass="auto-style1"></asp:RequiredFieldValidator>
    <br />
    <asp:Button ID="ButtonSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="ButtonSearch_Click" />
</asp:Content>
