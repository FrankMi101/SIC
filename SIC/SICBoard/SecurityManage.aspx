﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecurityManage.aspx.cs" Inherits="SIC.SecurityManage" Async="true" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>School Staff List</title>
    <meta http-equiv="Pragma" content="No-cache" />
    <meta http-equiv="Cache-Control" content="no-Store,no-Cache" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <%--    <script src="../Scripts/bootstrap.min.js"></script>--%>
    <%--    <link href="../Content/bootstrap.min.css" rel="stylesheet" />--%>
    <link href="../Content/BubbleHelp.css" rel="stylesheet" />
    <%--    <link href="Content/DefaultPage.css" rel="stylesheet" />--%>
    <link href="../Content/ListPage.css" rel="stylesheet" />
    <link href="../Content/ContentPage.css" rel="stylesheet" />
    <link href="../Content/TabMenu.css" rel="stylesheet" />
    <link href="../Content/ActionMenu.css" rel="stylesheet" />
    <link href="../Content/SearchArea.css" rel="stylesheet" />

    <style type="text/css">
        body {
            height: 100%;
            width: 100%;
        }

        div {
            font-family: Arial;
            font-size: small;
        }


        .DataContentTile {
            font-family: Arial;
            font-size: small;
            font-weight: 300;
            color: blue;
            table-layout: auto;
            display: block;
            height: 99%;
        }



        .SubstituedCell {
            color: red;
            text-decoration: underline;
        }

        .emptyData {
            font-size: xx-large;
            text-align: center;
            color: blue;
        }


        .FixedHeader {
            position: absolute;
            font-weight: bold;
            width: 100%;
            display: block;
        }


        .defaultBoard {
            border: 1px blue none;
        }



        .hfSchoolYear, .hfSchoolCode, .hfEmployeeID, .hfTeacherName, .hfmyKey, .hfIDs {
            display: none;
            width: 0px;
        }



        .top5Row {
            border-top: 5px solid darkcyan;
        }

        .HideButton {
            margin: 0px;
            padding: 0px;
            border: 0px;
        }

        .staff-container {
            margin-top: 5px;
            display: grid;
            grid-template-columns: 54% auto;
            grid-template-rows: repeat(1,100%);
            margin: auto;
            text-align: left;
            width: 100%
        }

        .staff-list {
            text-align: left;
        }

        .function-list {
        }

        .SearchBox {
            width: 100px;
            height: 19px;
        }

            .SearchBox:focus {
                border: 1px solid dodgerblue;
            }

            .SearchBox:visited {
                border: 1px solid skyblue;
            }

        .img-selected {
            filter: contrast(300%);
        }

        #SearchingBar {
            position: absolute;
            top: 5px;
            left: 600px;
        }

        .highlightBoard {
            border: 2px #ff6a00 solid;
        }

        #editiFrame {
            width: 100%;
            height: 95%;
        }

        .staff-list img {
            height: 20px;
            width: 20px;
            margin-top: -2px;
            margin-bottom: 2px;
        }

        #GridView1 img {
            height: 18px;
            width: 18px;
            margin-top: 2px;
            margin-left: 2px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager runat="server">
            <Services>
                <asp:ServiceReference Path="~/Models/WebService.asmx" />

            </Services>
        </asp:ScriptManager>
        <div class="SearchArea-SchoolRow">

            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    Apps: 
            <asp:DropDownList ID="ddlApps" runat="server" Width="250px">
            </asp:DropDownList>
                    School:
            <asp:DropDownList ID="ddlSchoolCode" runat="server" Width="60px" AutoPostBack="True" OnSelectedIndexChanged="DDLSchoolCode_SelectedIndexChanged">
            </asp:DropDownList>
                    <asp:DropDownList ID="ddlSchool" runat="server" Width="350px" AutoPostBack="True" OnSelectedIndexChanged="DDLSchool_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:ImageButton ID="btnSearchGo" CssClass="SearchGoButton" runat="server" ToolTip="Search ..." ImageUrl="../images/Go.png" OnClick="BtnSearchGo_Click" />

                </ContentTemplate>

            </asp:UpdatePanel>

        </div>

        <div class="staff-container" style="margin-top: 5px;">
            <div class="staff-list">

                <a href="javascript:OpenGroupNew();">
                    <img src="../images/add.png" border="0" style="margin-bottom: -2px;" />Add New Security Group </a>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div style="overflow: scroll; width: 800px; height: 500px" onscroll="OnScrollDiv(this)" id="DivMainContent">
                            <asp:GridView ID="GridView1" CssClass="GridView-List" runat="server" CellPadding="1" Height="100%" Width="100%" GridLines="Both" AutoGenerateColumns="False" BackColor="White" BorderColor="gray" BorderStyle="Ridge" BorderWidth="1px" CellSpacing="1" EmptyDataText="No Security group show" EmptyDataRowStyle-CssClass="emptyData" ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:BoundField DataField="RowNo" HeaderText="No." ItemStyle-CssClass="myRowNo">
                                        <ItemStyle Width="3%" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="" ItemStyle-CssClass="myAction">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link1" runat="server" Text='<%# Bind("Actions") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="3%" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="AppID" HeaderText="App ID" ItemStyle-CssClass="AppID">
                                        <ItemStyle Width="5%" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Group ID" ItemStyle-CssClass="myGroupID">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link2" runat="server" Text='<%# Bind("GroupID") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="22%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Group Name">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link3" runat="server" Text='<%# Bind("GroupName") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="30%" Wrap="true" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="GroupType" ReadOnly="True" HeaderText="Group Type" ItemStyle-CssClass="myGroupType">
                                        <ItemStyle Width="10%" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Permission" ReadOnly="True" HeaderText="Permission" ItemStyle-CssClass="Permission">
                                        <ItemStyle Width="10%" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Active">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chbPickup" Checked='<%# Convert.ToBoolean(Eval("IsActive"))%>' runat="server" CssClass="myCheckPickedForGAL"></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" ItemStyle-CssClass="myEditAction">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link4" runat="server" Text='<%# Bind("EditAction") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="3%" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" ItemStyle-CssClass="myDeleteAction">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link5" runat="server" Text='<%# Bind("DeleteAction") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="3%" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" ItemStyle-CssClass="mySubAction">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link6" runat="server" Text='<%# Bind("SubActions") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="3%" Wrap="False" />
                                    </asp:TemplateField>
                                </Columns>

                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <HeaderStyle BackColor="cornflowerblue" ForeColor="white" Height="25px" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <RowStyle Height="25px" />
                                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#594B9C" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#33276A" />
                            </asp:GridView>

                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
            <div class="function-list">
                <iframe id="IframeSubArea" name="IframeSubArea" style="height: 100%; width: 100%" frameborder="0" scrolling="no" src="" runat="server"></iframe>
            </div>
        </div>

        <div id="HelpDIV" class="bubble epahide">
            <asp:TextBox ID="HelpTextContent" runat="server" TextMode="MultiLine" CssClass="HelpTextBox" BackColor="transparent"></asp:TextBox>
        </div>
        <div id="PopUpDIV" class="bubble epahide"></div>

        <div id="EditDIV" runat="server" class="EditDIV bubble epahide">
            <div class="editTitle">
                <table>
                    <tr>
                        <td style="width: 90%">
                            <div id="EditTitle"></div>
                        </td>
                        <td style="text-align: right">
                            <img id="closeMe" src="../images/close.png" style="height: 25px; width: 25px; margin: -3px 0 -3px 0" /></td>
                    </tr>
                </table>
            </div>
            <iframe class="EditPage" id="editiFrame" name="editiFrame" frameborder="0" scrolling="no" src="" runat="server"></iframe>
        </div>

        <div id="ActionMenuDIV" class="bubble epahide">
            <asp:Label runat="server" ID="LabelTeacherName" Text=""> </asp:Label>
            <div id="ActionMenuUL" class="LeftSideMenu">
            </div>
        </div>
        <div id="ActionPOPDIV" class="bubble epahide">
            <div class="editTitle" style="display: block; margin-top: 5px;">
                <div id="ActionTitle" style="display: inline; float: left; width: 96%"></div>
                <div style="display: inline; float: left;">
                    <img id="closeActionPOP" src="../images/close.ico" style="height: 25px; width: 25px; margin: -3px 0 -3px 0" />
                </div>
            </div>
            <iframe id="ActioniFramePage" name="ActioniFramePage" style="height: 425px; width: 99%" frameborder="0" scrolling="no" src="" runat="server"></iframe>
        </div>
        <div>
            <asp:HiddenField ID="hfSchoolYear" runat="server" />
            <asp:HiddenField ID="hfCategory" runat="server" />
            <asp:HiddenField ID="hfPageID" runat="server" />
            <asp:HiddenField ID="hfAppID" runat="server" />
            <asp:HiddenField ID="hfUserID" runat="server" />
            <asp:HiddenField ID="hfUserRole" runat="server" />
            <asp:HiddenField ID="hfUserLoginRole" runat="server" />
            <asp:HiddenField ID="hfRunningModel" runat="server" />
            <input id="clipboardText" type="text" style="position: absolute; top: 1px; left: -11px; width: 1px; height: 1px" />
        </div>
    </form>
</body>
</html>

<script src="../Scripts/MoursPoint.js"></script>
<script src="../Scripts/GridView.js"></script>
<script src="../Scripts/Appr_ListPage.js"></script>
<script src="../Scripts/Appr_Help.js"></script>
<script src="../Scripts/Appr_textEdit.js"></script>
<script src="../Scripts/CommonListBuild.js"></script>
<script src="../Scripts/ActionMenu.js"></script>

<script type="text/javascript">
    var UserID = $("#hfUserID").val();
    var UserRole = $("#hfUserRole").val();
    var ItemCode = $("#hfCode").val();
    var SchoolYear = $("#hfSchoolYear").val();

    var myKey;
    var currentTR;
    var myIDs;
    var currentTR;
    var currentSearchBoxID;
    function pageLoad(sender, args) {

        $(document).ready(function () {

            // var vHeight = window.innerHeight - 50;
            //  MakeStaticHeader("GridView1", vHeight, 1500, 20, false);

            $("#closeMe").click(function (event) {

                $("#PopUpDIV").hide();
                $("#EditDIV").hide();
            });

            $(".GridView-List img").click(function (en) {
                $(this).addClass("img-selected");
            })
            $('.GridView-List tr').mouseenter(function (event) {
                if (currentTR !== undefined) { currentTR.removeClass("GridView-Selected"); }
                currentTR = $(this);
                currentTR.addClass("GridView-Selected");
            });

        });
    }

    function onSuccess(result) {
        BuildingList.DropDown2($("#ddlSchool"), BuildingDropDownList(result), $("#ddlSchoolCode"), BuildingDropDownList1(result));

    }
    function onFailure() {
        alert("Get Menu Failed!");
    }
    function RemoveGroup(userid, allowDel, groupID) {

        if (allowDel == "Yes") {
            // DeleteActionService();
        }
        else {
            alert("The Group --" + groupID + " can not be delete.");
        }

    }
    function OpenGroupNew() {
        var page = "../SICCommon/Security_Group.aspx"
        var schoolyear = $("#hfSchoolYear").val();
        var schoolcode = $("#ddlSchool").val();
        var appID = $("#ddlApps").val();
        var userID = $("#hfUserID").val();
        var userrole = $("#hfUserRole").val();
        var groupID = "0";
        var para = "?SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&UserID=" + userID + "&UserRole=" + userrole + "&AppID=" + appID + "&GroupID=" + groupID + "&Action=Add";
        OpenInPage('New Security Group', page, para, groupID);
    }

    function OpenGroupActionPage(userID, userrole, schoolyear, schoolcode, appID, groupID, action) {

        if (action == "SubFun") {
            var para = + '&sYear=' + schoolyear + '&sCode=' + schoolcode + '&appID=' + appID + '&gID=' + groupID + '&gType=' + M.GroupType
            var goPage = "Loading.aspx?pID=SecurityManageSub.aspx" + para
            $("#IframeSubArea").attr('src', goPage);
        }
        else {
            var page = "../SICCommon/Security_Group.aspx"
            var para = "?SchoolYear=" + schoolyear + "&SchoolCode=" + schoolcode + "&UserID=" + userID + "&UserRole=" + userrole + "&AppID=" + appID + "&GroupID=" + groupID + "&Action=" + action;
            OpenInPage('Security Group', page, para, groupID);

        }


    }
    function OpenInPage(title, page, para, groupId) {


        var goPage = page + para;
        var vTop = 50;
        var vLeft = 5;
        var vHeight = 500;
        var vWidth = 700;
        try {

            $("#editiFrame").attr('src', goPage);
            $("#EditTitle").html(title + " " + groupId);
            $("#EditDIV").css({
                top: vTop,
                left: vLeft,
                height: vHeight - 50,
                width: vWidth - 50
            });
            $("#EditDIV").fadeToggle("fast");
        }

        catch(e) {
            window.alert("Error:" + e.mess);
        }

    }
</script>
