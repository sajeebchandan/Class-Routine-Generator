<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View Routine.aspx.cs" Inherits="Routine_Generator.View_Routine_By_Course_Code" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link rel="stylesheet" href="Content/bootstrap.cosmo.css" />--%>
    <style type="text/css">
        .auto-style1 {
            font-size: 15px;
        }

        .contas {
            display: block;
            width: 122px;
            margin: -20px 350px;
            visibility: hidden;
        }

        .dibi {
            height: 20px;
            width: 20px;
            position: absolute;
            border-radius: 50%;
            background: #000;
            display: inline-block;
        }

            .dibi:first-child {
                animation: move 1s ease-in-out infinite alternate;
                background: #4285f4;
                margin-left: 0;
            }

            .dibi:nth-child(2) {
                animation: move 1s ease-in-out -0.25s infinite alternate;
                margin-left: 35px;
                background: #db4437;
            }

            .dibi:nth-child(3) {
                animation: move 1s ease-in-out -0.5s infinite alternate;
                margin-left: 70px;
                background: #f4b400;
            }

            .dibi:nth-child(4) {
                animation: move 1s ease-in-out -0.75s infinite alternate;
                margin-left: 105px;
                background: #0f9d58;
            }

        @-moz-keyframes move {
            0% {
                transform: translateY(-10px);
            }

            100% {
                transform: translateY(5px);
            }
        }

        @-webkit-keyframes move {
            0% {
                transform: translateY(-10px);
            }

            100% {
                transform: translateY(5px);
            }
        }

        @-o-keyframes move {
            0% {
                transform: translateY(-10px);
            }

            100% {
                transform: translateY(5px);
            }
        }

        @keyframes move {
            0% {
                transform: translateY(-10px);
            }

            100% {
                transform: translateY(5px);
            }
        }
    </style>
    <script type="text/javascript">
        function onClickbtn() {
            //document.getElementById('msg').innerText = "Please Wait until download start. It's working on your machine. So no data is needed.";
            document.getElementById("contass").style.visibility = "visible";
            html2canvas(document.querySelector("#ContentPlaceHolder1_GridViewWeekDay")).then(canvas => {
                //document.body.appendChild(canvas)
                var conta = document.getElementById("containers");
                var title = document.getElementById("routinetitle").textContent + '.jpg';
                //document.body.replaceChild(canvas, conta)
                download(canvas.toDataURL("image/jpeg"), title, 'image/jpeg')
                document.getElementById("contass").style.visibility = "hidden";
            });
        }
        function onClickbtnMin() {
            //document.getElementById('contass').innerText = "Please Wait until download start. It's working on your machine. So no data is needed.";
            document.getElementById("contass").style.visibility = "visible";
            html2canvas(document.querySelector("#ContentPlaceHolder1_GridViewMin")).then(canvas => {
                //document.body.appendChild(canvas)
                var conta = document.getElementById("containers");
                var title = document.getElementById("routinetitle").textContent + '-Minified' + '.jpg';
                //document.body.replaceChild(canvas, conta)
                download(canvas.toDataURL("image/jpeg"), title, 'image/jpeg')
                document.getElementById('ContentPlaceHolder1_GridViewMin').style.display = 'none';
                document.getElementById("contass").style.visibility = "hidden";
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div id="Background"></div>
            <div id="Progress">
                <h3>
                    <p style="text-align: center">
                        <b class="UpdateProgress">Filtering...<br />
                        </b>
                    </p>
                </h3>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>












    <h2 class="text-center bg-info" id="routinetitle">Routine of Spring 2018</h2>
    <input type="button" id="btnSave" value="Save as Image" class="btn btn-primary btn-md" style="margin-left: 2%;" onclick="onClickbtn()" />
    <asp:Button ID="Button1" runat="server" class="btn btn-primary btn-md" Style="margin-left: 2%;" Text="Save Minified Image" OnClick="Button1_Click" />
    <span class="contas" id="contass">
        <div class="dibi"></div>
        <div class="dibi"></div>
        <div class="dibi"></div>
        <div class="dibi"></div>
    </span>
    <br />
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="margin-left: 2%">
                <table class="table-responsive">
                    <tr>
                        <td>
                            <asp:LinkButton ID="LinkButtonLAB1" runat="server" OnClick="LinkButtonLAB1_Click" CssClass="btn-link"></asp:LinkButton>
                            <br />
                            <asp:LinkButton ID="LinkButtonLAB2" runat="server" OnClick="LinkButtonLAB2_Click" CssClass="btn-link"></asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>

            <asp:GridView ID="GridViewWeekDay" runat="server" ShowHeader="true" ShowFooter="true" AutoGenerateColumns="False" Width="96%" Style="margin-left: 2%" GridLines="None" CssClass="table-responsive" OnRowDataBound="GridViewWeekDay_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table class="table  table-bordered  table-responsive">
                                <tr>
                                    <td class="text-center" style="background-color: black; color: white; width: 100%">
                                        <strong>
                                            <asp:Label ID="LabelHeader" runat="server" Text='<%# HeaderText().ToString().Replace("_", " ") %>' Style="font-size: 25px"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <FooterTemplate>
                            <table class="table  table-bordered  table-responsive">
                                <tr>
                                    <td class="text-center" style="background-color: black; color: white; width: 100%">
                                        <h5 style="text-align: center">Developed By <a style="color:lawngreen" href="https://facebook.com/sajeeb.chandan">Sajeeb Chandan</a></h5>
                                    </td>
                                </tr>
                            </table>
                        </FooterTemplate>
                        <ItemTemplate>
                            <div style="width: 100%;">
                                <table class="table  table-bordered  table-responsive">
                                    <tr>
                                        <td class="text-center" style="background-color: antiquewhite; width: 100%">
                                            <strong>
                                                <asp:Label ID="LabelDistinctDay" runat="server" Text='<%# Eval("Day") %>' Style="font-size: 25px"></asp:Label>
                                            </strong>
                                        </td>
                                    </tr>
                                </table>
                                <table class="table  table-bordered  table-responsive">
                                    <tr>
                                        <td style="background-color: ghostwhite; text-align: center; width: 40%; font-weight: bold; font-size: 18px">
                                            <asp:Label ID="LabelCourseCode" runat="server" Text="Course Code"></asp:Label>
                                        </td>
                                        <td style="background-color: ghostwhite; text-align: center; width: 15%; font-weight: bold; font-size: 18px">
                                            <asp:Label ID="LabelTeacherInitial" runat="server" Text="Teacher"></asp:Label>
                                        </td>
                                        <td style="background-color: ghostwhite; text-align: center; width: 30%; font-weight: bold; font-size: 18px">
                                            <asp:Label ID="LabelTime" runat="server" Text="Time"></asp:Label>
                                        </td>
                                        <td style="background-color: ghostwhite; text-align: center; width: 15%; font-weight: bold; font-size: 18px">
                                            <asp:Label ID="LabelRoom" runat="server" Text="Room No"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div>
                                <asp:GridView ID="GridViewChild" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="None" ShowHeader="False">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <table class="table  table-bordered  table-responsive">
                                                    <tr>
                                                        <td style="background-color: beige; text-align: center; width: 40%; font-weight: bold; font-size: 18px">
                                                            <asp:Label ID="LabelCourseCode" runat="server" Text='<%# Eval("Course Code").ToString().Replace(" ", "") %>'></asp:Label>
                                                            <br />
                                                            <asp:Label ID="LabelCourse" runat="server" Text='<%# GetCourseName((string)Eval("Course Code")) %>' CssClass="auto-style1" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td style="background-color: beige; text-align: center; width: 15%; font-weight: bold; font-size: 18px">
                                                            <asp:Label ID="LabelTeacherInitial" runat="server" Text='<%# Eval("Teacher Initial").ToString().Replace(" ", "") %>'></asp:Label>
                                                            <br />
                                                            <asp:Label ID="LabelTeacher" runat="server" Text='<%# getTeacherName((string)Eval("Teacher Initial")) %>' CssClass="auto-style1" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td style="background-color: beige; text-align: center; width: 30%; font-weight: bold; font-size: 18px">
                                                            <asp:Label ID="LabelTime" runat="server" Text='<%# Eval("Class Time").ToString().Replace(" ", "") %>'></asp:Label>
                                                        </td>
                                                        <td style="background-color: beige; text-align: center; width: 15%; font-weight: bold; font-size: 18px">
                                                            <asp:Label ID="LabelRoom" runat="server" Text='<%# Eval("Room No").ToString().Replace(" ", "") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>





            <%-- A Hidden GridView For Minified Version OF Routine--%>
            <asp:GridView ID="GridViewMin" runat="server" AutoGenerateColumns="False" ShowHeader="true" ShowFooter="true" Width="100%" Style="margin-left: 0%" Visible="false" GridLines="None" CssClass="table-responsive" OnRowDataBound="GridViewMin_RowDataBound">
                <Columns>
                    <asp:TemplateField>

                        <HeaderTemplate>
                            <table class="table  table-bordered  table-responsive">
                                <tr>
                                    <td class="text-center" style="background-color: black; color: white; width: 100%">
                                        <strong>
                                            <asp:Label ID="LabelHeaderMin" runat="server" Text='<%# HeaderText().ToString().Replace("_", " ") %>' Style="font-size: 25px"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <FooterTemplate>
                            <table class="table  table-bordered  table-responsive">
                                <tr>
                                    <td class="text-center" style="background-color: black; color: white; width: 100%">
                                        <h5 style="text-align: center">Developed By <a style="color:lawngreen" href="https://facebook.com/sajeeb.chandan">Sajeeb Chandan</a></h5>
                                    </td>
                                </tr>
                            </table>
                        </FooterTemplate>
                        <ItemTemplate>
                            <div style="width: 100%;">
                                <table class="table  table-bordered  table-responsive">
                                    <tr>
                                        <td class="text-center" style="background-color: antiquewhite; width: 100%">
                                            <strong>
                                                <asp:Label ID="LabelDistinctDay" runat="server" Text='<%# Eval("Day") %>' Style="font-size: 40px; font-weight: 900"></asp:Label>
                                            </strong>
                                        </td>
                                    </tr>
                                </table>
                                <table class="table  table-bordered  table-responsive">
                                    <tr>
                                        <td style="background-color: ghostwhite; text-align: center; width: 40%; font-weight: 900; font-size: 35px">
                                            <asp:Label ID="LabelCourseCode" runat="server" Text="Course Code"></asp:Label>
                                        </td>
                                        <td style="background-color: ghostwhite; text-align: center; width: 15%; font-weight: 900; font-size: 35px">
                                            <asp:Label ID="LabelTeacherInitial" runat="server" Text="Teacher"></asp:Label>
                                        </td>
                                        <td style="background-color: ghostwhite; text-align: center; width: 30%; font-weight: 900; font-size: 35px">
                                            <asp:Label ID="LabelTime" runat="server" Text="Time"></asp:Label>
                                        </td>
                                        <td style="background-color: ghostwhite; text-align: center; width: 15%; font-weight: 900; font-size: 35px">
                                            <asp:Label ID="LabelRoom" runat="server" Text="Room No"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div>
                                <asp:GridView ID="GridViewChild" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="None" ShowHeader="False">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <table class="table  table-bordered  table-responsive">
                                                    <tr>
                                                        <td style="background-color: beige; text-align: center; width: 40%; font-weight: 900; font-size: 30px">
                                                            <asp:Label ID="LabelCourseCode" runat="server" Text='<%# Eval("Course Code").ToString().Replace(" ", "") %>'></asp:Label>

                                                        </td>
                                                        <td style="background-color: beige; text-align: center; width: 15%; font-weight: 900; font-size: 30px">
                                                            <asp:Label ID="LabelTeacherInitial" runat="server" Text='<%# Eval("Teacher Initial").ToString().Replace(" ", "") %>'></asp:Label>

                                                        </td>
                                                        <td style="background-color: beige; text-align: center; width: 30%; font-weight: 900; font-size: 30px">
                                                            <asp:Label ID="LabelTime" runat="server" Text='<%# Eval("Class Time").ToString().Replace(" ", "") %>'></asp:Label>
                                                        </td>
                                                        <td style="background-color: beige; text-align: center; width: 15%; font-weight: 900; font-size: 30px">
                                                            <asp:Label ID="LabelRoom" runat="server" Text='<%# Eval("Room No").ToString().Replace(" ", "") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>



        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="LinkButtonLAB1" EventName="Click"></asp:AsyncPostBackTrigger>
            <asp:AsyncPostBackTrigger ControlID="LinkButtonLAB2" EventName="Click"></asp:AsyncPostBackTrigger>
            <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click"></asp:AsyncPostBackTrigger>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
