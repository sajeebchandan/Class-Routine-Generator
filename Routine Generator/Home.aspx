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
        <div class="table-responsive">
            <table class="table">
                <thead>
                    <tr>

                        <td>
                            <strong>Select Department</strong><br />
                            <asp:RadioButtonList ID="RadioButtonListDept" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                <asp:ListItem class="radio-inline">SWE</asp:ListItem>
                                <asp:ListItem class="radio-inline">CSE</asp:ListItem>
                                <asp:ListItem class="radio-inline">MCT</asp:ListItem>
                                <asp:ListItem class="radio-inline">Pharmacy</asp:ListItem>
                            </asp:RadioButtonList>

                            &nbsp; &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select department" ControlToValidate="RadioButtonListDept" CssClass="auto-style1" Style="color: #FF0000"></asp:RequiredFieldValidator>

                        </td>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>
        </div>
        <div class="table-responsive">
            <table class="table">
                <thead>
                    <tr>
                        <th>
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">View Empty Slot By Department</asp:LinkButton></th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
        </div>
    </div>
    <div class="collapse" id="info">
        Inout your course code into the textboxes along with your section and get the routine. Useful if you are not going with regular semester sequence
    </div>
</asp:Content>
