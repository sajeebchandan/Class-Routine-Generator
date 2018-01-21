<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View Empty Slot.aspx.cs" Inherits="Routine_Generator.View_Empty_Slot" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .form-controlMod {
            width: 24%;
            height: 34px;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
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
    
    <asp:Button ID="ButtonGetSlot" runat="server" class="btn btn-primary btn-md" Style="margin-left: 2%;" Text="View Booked Slot List" OnClick="ButtonGetSlot_Click" CausesValidation="false" />
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


            <asp:GridView ID="GridViewWeekDay" runat="server" ShowHeader="true" ShowFooter="true" AutoGenerateColumns="False" Width="96%" Style="margin-left: 2%" GridLines="None" CssClass="table-responsive" OnRowDataBound="GridViewWeekDay_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table class="table  table-bordered  table-responsive">
                                <tr>
                                    <td class="text-center" style="background-color: black; color: white; width: 100%">
                                        <strong>
                                            <asp:Label ID="LabelHeader" runat="server" Text="Empty Slots" Style="font-size: 25px"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <FooterTemplate>
                            <table class="table  table-bordered  table-responsive">
                                <tr>
                                    <td class="text-center" style="background-color: black; color: white; width: 100%">
                                        <h5 style="text-align: center">Developed By <a style="color: lawngreen" href="https://facebook.com/sajeeb.chandan">Sajeeb Chandan</a></h5>
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
                                                <%--<asp:Label ID="LabelParentRowIndex" runat="server" Text='<%# Container.DataItemIndex %>' Style="font-size: 25px"></asp:Label>--%>
                                            </strong>
                                        </td>
                                    </tr>
                                </table>
                                <table class="table  table-bordered  table-responsive">
                                    <tr>
                                        <td style="background-color: ghostwhite; text-align: center; width: 20%; font-weight: bold; font-size: 18px">
                                            <asp:Label ID="LabelTime" runat="server" Text="Time"></asp:Label>
                                        </td>
                                        <td style="background-color: ghostwhite; text-align: center; width: 20%; font-weight: bold; font-size: 18px">
                                            <asp:Label ID="LabelRoom" runat="server" Text="Room No"></asp:Label>
                                        </td>
                                        <td style="background-color: ghostwhite; text-align: center; width: 60%; font-weight: bold; font-size: 18px">
                                            <asp:Label ID="LabelCheckAvailability" runat="server" Text="Check Availability"></asp:Label>

                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div>
                                <asp:GridView ID="GridViewChild" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="None" ShowHeader="False" OnRowCommand="GridViewChild_RowCommand">
                                    <Columns>
                                        <asp:TemplateField>
                                            <EditItemTemplate>
                                                <table class="table  table-bordered  table-responsive">
                                                    <tr>
                                                        <td style="background-color: beige; text-align: center; width: 20%; /*font-weight: bold; */ font-size: 18px">
                                                            <asp:Label ID="LabelTime" runat="server" Text='<%# Eval("Schedule").ToString().Replace(" ", "") %>'></asp:Label>
                                                            <asp:Label ID="LabelDay" runat="server" Style="font-size: 25px" Text='<%# Eval("Day") %>' Visible="false"></asp:Label>
                                                            <asp:Label ID="LabelDayID" runat="server" Text='<%# Eval("DayID") %>' Style="font-size: 25px" Visible="false"></asp:Label>
                                                            <asp:Label ID="LabelId" runat="server" Text='<%# Eval("Id") %>' Style="font-size: 25px" Visible="false"></asp:Label>
                                                        </td>
                                                        <td style="background-color: beige; text-align: center; width: 20%; /*font-weight: bold; */ font-size: 18px">
                                                            <asp:Label ID="LabelRoom" runat="server" Text='<%# Eval("Class").ToString().Replace(" ", "") %>'></asp:Label>
                                                        </td>
                                                        <td style="background-color: beige; text-align: center; width: 60%; /*font-weight: bold; */ font-size: 18px">
                                                            <%--<asp:TextBox ID="TextBoxDateOfAvailability" runat="server" placeholder="Enter Date" Visible="false" CssClass="form-controlMod"></asp:TextBox>

                                                            <asp:CalendarExtender ID="TextBoxDateOfAvailability_CalendarExtender" runat="server" Enabled="True" TargetControlID="TextBoxDateOfAvailability" Format="dd/MM/yyyy" StartDate='<%# DateTime.Now.AddDays(1) %>'></asp:CalendarExtender>

                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" runat="server" ControlToValidate="TextBoxDateOfAvailability" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            <br />--%>
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" runat="server" ControlToValidate="TextBoxDateOfAvailability" Display="Dynamic" ErrorMessage="*Required" Style="color: #FF3300"></asp:RequiredFieldValidator><br />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorDate" runat="server" ControlToValidate="TextBoxDateOfAvailability" Style="color: #FF0000;" ErrorMessage="Give date in dd/MM/yyyy Format" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))\/((0[1-9])|(1[0-2])))|((31\/((0[13578])|(1[02])))|((29|30)\/((0[1,3-9])|(1[0-2])))))\/((20[0-9][0-9])|(19[0-9][0-9])))|((29\/02\/(19|20)(([02468][048])|([13579][26]))))$ "></asp:RegularExpressionValidator><br />--%>
                                                            <%--<asp:LinkButton ID="LinkButtonCheckAvailability" runat="server" CommandArgument='<%# Eval("Id") %>' CommandName="CheckAvailability">Check Availability</asp:LinkButton>--%>
                                                            <%--<asp:TextBox ID="TextBoxTeacherInitial" runat="server" placeholder="Teacher Initial"></asp:TextBox>--%>
                                                            <span style="font-size:10px; font-weight:bold">Teacher Initial</span>
                                                            
                                                            <asp:ComboBox ID="ComboBoxTeacherInitial" runat="server" DataSourceID="SqlDataSourceTeacherInitial" DataTextField="Teacher" DataValueField="Teacher" MaxLength="0" Style="display: inline;" AutoCompleteMode="Suggest" ItemInsertLocation="OrdinalText"></asp:ComboBox>
                                                            <asp:SqlDataSource ID="SqlDataSourceTeacherInitial" runat="server" ConnectionString="<%$ ConnectionStrings:RUTINConnectionString %>" SelectCommand="SELECT DISTINCT Teacher FROM Routine WHERE Teacher IS NOT NULL"></asp:SqlDataSource>
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorTeacher" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ComboBoxTeacherInitial"></asp:RequiredFieldValidator>--%>
                                                            <br />
                                                            <span style="font-size:10px; font-weight:bold">Course Code &nbsp;</span>
                                                            
                                                            <asp:ComboBox ID="ComboBoxCourse" runat="server" DataSourceID="SqlDataSourceCourseCode" DataTextField="Course" DataValueField="Course" MaxLength="0" Style="display: inline;" AutoCompleteMode="Suggest" ItemInsertLocation="OrdinalText"></asp:ComboBox>
                                                            <asp:SqlDataSource ID="SqlDataSourceCourseCode" runat="server" ConnectionString="<%$ ConnectionStrings:RUTINConnectionString %>" SelectCommand="SELECT DISTINCT Course FROM Routine WHERE Course IS NOT NULL"></asp:SqlDataSource>
                                                            <%--<asp:TextBox ID="TextBoxCourse" runat="server" placeholder="Course Code"></asp:TextBox>--%>
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorCourse" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ComboBoxCourse"></asp:RequiredFieldValidator>--%>
                                                            <br />
                                                            <asp:LinkButton ID="LinkButtonBook" runat="server" CommandArgument='<%# Eval("Id") %>' CommandName="Book" CausesValidation="false">Book This Schedule</asp:LinkButton><br />
                                                            <asp:LinkButton ID="LinkButtonCancelBook" runat="server" CommandArgument='<%# Eval("Id") %>' CommandName="CancelBook" CausesValidation="False">Cancel</asp:LinkButton>
                                                            <br />
                                                            <asp:Label ID="LblMsg" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <table class="table  table-bordered  table-responsive">
                                                    <tr>
                                                        <td style="background-color: beige; text-align: center; width: 20%; /*font-weight: bold; */ font-size: 18px">
                                                            <asp:Label ID="LabelTime" runat="server" Text='<%# Eval("Schedule").ToString().Replace(" ", "") %>'></asp:Label>
                                                            <asp:Label ID="LabelDay" runat="server" Text='<%# Eval("Day") %>' Style="font-size: 25px" Visible="false"></asp:Label>
                                                            <asp:Label ID="LabelDayID" runat="server" Text='<%# Eval("DayID") %>' Style="font-size: 25px" Visible="false"></asp:Label>
                                                            <asp:Label ID="LabelId" runat="server" Text='<%# Eval("Id") %>' Style="font-size: 25px" Visible="false"></asp:Label>
                                                        </td>
                                                        <td style="background-color: beige; text-align: center; width: 20%; /*font-weight: bold; */ font-size: 18px">
                                                            <asp:Label ID="LabelRoom" runat="server" Text='<%# Eval("Class").ToString().Replace(" ", "") %>'></asp:Label>
                                                        </td>
                                                        <td style="background-color: beige; text-align: center; width: 60%; /*font-weight: bold; */ font-size: 18px">
                                                            <asp:TextBox ID="TextBoxDateOfAvailability" runat="server" placeholder="Enter Date" CssClass="form-controlMod"></asp:TextBox>

                                                            <asp:CalendarExtender ID="TextBoxDateOfAvailability_CalendarExtender" runat="server" Enabled="True" TargetControlID="TextBoxDateOfAvailability" Format="dd/MM/yyyy" StartDate='<%# DateTime.Now.AddDays(1) %>'></asp:CalendarExtender>

                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxDateOfAvailability" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            <br />
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" runat="server" ControlToValidate="TextBoxDateOfAvailability" Display="Dynamic" ErrorMessage="*Required" Style="color: #FF3300"></asp:RequiredFieldValidator><br />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorDate" runat="server" ControlToValidate="TextBoxDateOfAvailability" Style="color: #FF0000;" ErrorMessage="Give date in dd/MM/yyyy Format" ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))\/((0[1-9])|(1[0-2])))|((31\/((0[13578])|(1[02])))|((29|30)\/((0[1,3-9])|(1[0-2])))))\/((20[0-9][0-9])|(19[0-9][0-9])))|((29\/02\/(19|20)(([02468][048])|([13579][26]))))$ "></asp:RegularExpressionValidator><br />--%>
                                                            <asp:LinkButton ID="LinkButtonCheckAvailability" runat="server" CommandName="CheckAvailability" CommandArgument='<%# Eval("Id") %>' CausesValidation="false">Check Availability</asp:LinkButton><br />
                                                            <asp:LinkButton ID="LinkButtonMessage" runat="server" CommandName="TryBook" CommandArgument='<%# Eval("Id") %>' CausesValidation="false"></asp:LinkButton>
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
            <asp:AsyncPostBackTrigger ControlID="GridViewWeekDay" EventName="RowDataBound" />
            <asp:AsyncPostBackTrigger ControlID="GridViewWeekDay" EventName="RowCommand" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
