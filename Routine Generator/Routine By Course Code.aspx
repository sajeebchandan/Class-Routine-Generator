<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Routine By Course Code.aspx.cs" Inherits="Routine_Generator.Routine_By_Course_Code" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            color: #FF0000;
            text-align: left;
        }

        .lbl {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>



    <h2 class="text-center bg-info">Routine By Course Code</h2>

    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <table class="nav-justified">
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

                        <br />

                    </td>
                </tr>
                <tr>
                    <td class="text-right"></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select department" ControlToValidate="RadioButtonListDept" CssClass="auto-style1"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="text-right"></td>
                    <td>
                        <asp:Label ID="LabelMsg" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="text-right">Total Credit Taken (MAX 15)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <asp:Label ID="LabelCourseCounter" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="text-right">Course Code&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td>
                        <asp:TextBox ID="TextBoxCourse1" runat="server" placeholder="e.g. SWE313F" CssClass="form-control" Width="60%" AutoPostBack="True" OnTextChanged="TextBoxCourse1_TextChanged"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td class="text-right">Course Code&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td>
                        <asp:TextBox ID="TextBoxCourse2" runat="server" placeholder="e.g. SWE313F" CssClass="form-control" Width="60%" AutoPostBack="True" OnTextChanged="TextBoxCourse2_TextChanged"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td class="text-right">Course Code&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td>
                        <asp:TextBox ID="TextBoxCourse3" runat="server" placeholder="e.g. SWE313F" CssClass="form-control" Width="60%" AutoPostBack="True" OnTextChanged="TextBoxCourse3_TextChanged"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td class="text-right">Course Code&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td>
                        <asp:TextBox ID="TextBoxCourse4" runat="server" placeholder="e.g. SWE313F" CssClass="form-control" Width="60%" AutoPostBack="True" OnTextChanged="TextBoxCourse4_TextChanged"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td class="text-right">Course Code&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td>
                        <asp:TextBox ID="TextBoxCourse5" runat="server" placeholder="e.g. SWE313F" CssClass="form-control" Width="60%" AutoPostBack="True" OnTextChanged="TextBoxCourse5_TextChanged"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" CssClass="btn , btn-primary" OnClick="ButtonSubmit_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="TextBoxCourse1" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="TextBoxCourse2" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="TextBoxCourse3" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="TextBoxCourse4" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="TextBoxCourse5" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="ButtonSubmit" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
