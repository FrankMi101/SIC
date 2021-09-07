﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecurityManageSub.aspx.cs" Inherits="SIC.SecurityManageSub" Async="true" %>

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
<%--    <script src="../Scripts/JqueryUI/jquery-ui.min.js"></script>
    <link href="../Scripts/JqueryUI/jquery-ui.min.css" rel="stylesheet" type="text/css" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />--%>
    <link href="../Content/BubbleHelp.css" rel="stylesheet" />
    <link href="../Content/ListPage.css" rel="stylesheet" />
    <link href="../Content/ContentPage.css" rel="stylesheet" />
    <link href="../Content/TabMenu.css" rel="stylesheet" />
    <link href="../Content/ActionMenu.css" rel="stylesheet" />
    <link href="../Content/SearchArea.css" rel="stylesheet" />

    <style type="text/css">
        body {
            height: 100%;
            width: 99%;
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

        .highlightBoard {
            border: 1px blue solid;
            color: white;
        }

        .highlightRow {
            background-image: url(images/highLightRow.png);
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



        .MessageRow {
            background: dodgerblue; /* For browsers that do not support gradients */
            background: -webkit-linear-gradient(dodgerblue, lightblue); /* For Safari 5.1 to 6.0 */
            background: -o-linear-gradient(dodgerblue, lightblue); /* For Opera 11.1 to 12.0 */
            background: -moz-linear-gradient(dodgerblue, lightblue); /* For Firefox 3.6 to 15 */
            background: linear-gradient(dodgerblue, lightblue); /* Standard syntax */
        }

            .MessageRow .SearchBox {
                background-color: transparent;
                border: 0px;
                font-weight: bold;
            }

        .content-grid th {
            background: linear-gradient(lightskyblue, white);
            color: black;
            font-size: 12px;
        }

        .ddlControls {
            height: 20px;
        }

        .Gridview-title {
            margin-top: 25px;
            display: block;
            width: 100%;
        }

        .Content-Area-SAP img {
            height: 18px;
            width: 18px;
            margin-top: -5px;
            margin-left: 5px;
        }
        .EditPage {
        height:95%;
        width:100%;
        }
        </style>
    <script type="text/javascript">

        function ShowSaveMessage(action, result) {
            alert(action + " operation was " + result);
            location.reload();
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager runat="server">
            <Services>
                <asp:ServiceReference Path="~/Models/WebService.asmx" />
            </Services>
        </asp:ScriptManager>
        <div class="MessageRow">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    Group ID:  
                    <asp:TextBox CssClass="SearchBox" ID="TextBoxGroupID" runat="server" Width="200px" placeholder="Group ID"></asp:TextBox>
                    Group Type:
                    <asp:TextBox CssClass="SearchBox" ID="TextBoxGroupType" Width="100px" runat="server" placeholder="Group Type"></asp:TextBox>
                    <br />

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="Content-Area Content-Area-SAP ">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="Gridview-title">
                        <a href="javascript:OpenAddMember('Students')">
                            <img src="../images/add.png" border="0" width="16" height="16" />
                            Add New Student Members to the Group</a>
                    </div>
                    <div style="overflow: scroll; width: 100%; height: 150px" onscroll="OnScrollDiv(this)" id="DivMainContent-sap">
                        <asp:GridView ID="GridView_Students_Group" CssClass="content-grid" runat="server" CellPadding="1" Height="100%" Width="100%" GridLines="Both" AutoGenerateColumns="False" BackColor="White" BorderColor="gray" BorderStyle="Ridge" BorderWidth="1px" CellSpacing="1" EmptyDataText="No Students has been added to the Group" EmptyDataRowStyle-CssClass="emptyData" ShowHeaderWhenEmpty="true">
                            <Columns>
                                <asp:BoundField DataField="RowNo" HeaderText="No." ItemStyle-CssClass="myRowNo">
                                    <ItemStyle Width="3%" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Class/Grade">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="Link5" runat="server" Text='<%# Bind("MemberID") %>'>  </asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Width="15%" Wrap="true" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="MemberName" ReadOnly="True" HeaderText="Description">
                                    <ItemStyle Width="35%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Comments" ReadOnly="True" HeaderText="Comments">
                                    <ItemStyle Width="54%" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Del" ItemStyle-CssClass="myDelAction">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="Link2" runat="server" Text='<%# Bind("DeleteAction") %>'>  </asp:HyperLink>
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
                    <div class="Gridview-title">
                        <a href="javascript:OpenAddMember('Teachers')">
                            <img src="../images/add.png" border="0" width="16" height="16" />
                            Add New Teacher Members to the Group </a>
                    </div>
                    <div style="overflow: scroll; width: 100%; height: 250px" onscroll="OnScrollDiv(this)" id="DivMainContent-sap">
                        <asp:GridView ID="GridView_Teachers_Group" CssClass="content-grid" runat="server" CellPadding="1" Height="100%" Width="100%" GridLines="Both" AutoGenerateColumns="False" BackColor="White" BorderColor="gray" BorderStyle="Ridge" BorderWidth="1px" CellSpacing="1" EmptyDataText="No Teacher has been add to the Group" EmptyDataRowStyle-CssClass="emptyData" ShowHeaderWhenEmpty="true">
                            <Columns>
                                <asp:BoundField DataField="RowNo" HeaderText="No." ItemStyle-CssClass="myRowNo">
                                    <ItemStyle Width="3%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Staff Name">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="Link1" runat="server" Text='<%# Bind("MemberName") %>'>  </asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Width="20%" Wrap="False" />
                                </asp:TemplateField>


                                <asp:BoundField DataField="Comments" ReadOnly="True" HeaderText="Comments">
                                    <ItemStyle Width="50%" />
                                </asp:BoundField>

                                <asp:BoundField DataField="StartDate" ReadOnly="True" HeaderText="Start Date" ItemStyle-CssClass="StartDate">
                                    <ItemStyle Width="12%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EndDate" ReadOnly="True" HeaderText="End Date" ItemStyle-CssClass="EndDate">
                                    <ItemStyle Width="12%" />
                                </asp:BoundField>


                                <asp:TemplateField HeaderText="Del" ItemStyle-CssClass="myDelAction">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="Link2" runat="server" Text='<%# Bind("DeleteAction") %>'>  </asp:HyperLink>
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


        <div>
            <asp:HiddenField ID="hfCategory" runat="server" />
            <asp:HiddenField ID="hfPageID" runat="server" />
            <asp:HiddenField ID="hfUserID" runat="server" />
            <asp:HiddenField ID="hfUserRole" runat="server" />
            <asp:HiddenField ID="hfAppID" runat="server" />
            <asp:HiddenField ID="hfSchoolCode" runat="server" />
            <asp:HiddenField ID="hfUserLoginRole" runat="server" />
            <asp:HiddenField ID="hfRunningModel" runat="server" />
            <asp:HiddenField ID="hfSchoolyearStartDate" runat="server" />
            <asp:HiddenField ID="hfSchoolyearEndDate" runat="server" />
            <input id="clipboardText" type="text" style="position: absolute; top: 1px; left: -50px; width: 1px; height: 1px" />
        </div>
    </form>
</body>
</html>

<script src="../Scripts/MoursPoint.js"></script>
<script src="../Scripts/CommonDOM.js"></script>
<script src="../Scripts/GridView.js"></script>
<script src="../Scripts/Appr_ListPage.js"></script>
<script src="../Scripts/Appr_Help.js"></script>
<script src="../Scripts/Appr_textEdit.js"></script>
<script src="../Scripts/CommonListBuild.js"></script>
<script src="../Scripts/ActionMenu.js"></script>

<script type="text/javascript">

    var ItemCode = $("#hfCode").val();
    var minD = new Date($("#hfSchoolyearStartDate").val()); // today.getDate() - 90; //
    var maxD = new Date($("#hfSchoolyearEndDate").val());
    var preaLinkID;
    var Action;
    var para = {
        Operate: "",
        UserID: $("#hfUserID").val(),
        UserRole: $("#hfUserRole").val(),
        SchoolCode: $("#hfSchoolCode").val(),
        AppID: $("#hfAppID").val(),
        GroupID: $("#TextBoxGroupID").val(),
        GroupType: $("#TextBoxGroupType").val(),
        MemberID: "",
        MemberType: "",
        ActionType: "Add"
    };

    function pageLoad(sender, args) {

        $(document).ready(function () {
            $("#closeMe").click(function (event) {
                $("#EditDIV").hide();

            });
        });
    }


    function onSuccess(result) {
        alert(Action + " save was " + result);
        location.reload();
    }
    function onFailure() {
        alert(Action + " operation failed");
    }
    function OpenAddMember(memberType) {
      
        var page = memberType == "Teachers" ? "SecurityManageSubTeachers.aspx" : "SecurityManageSubStudents.aspx";

        var param = "?sCode=" + para.SchoolCode + "&appID=" + para.AppID + "&groupID=" + para.GroupID + "&groupType=" + para.GroupType + "&Action=Add";

        OpenInPage("Add New Group Member of", page, param, para.GroupID);
    }
    function OpenGroupMemberActionPage(userID, userRole, schoolYear, schoolCode, appID, groupID, memberID, memberType, actionType) {
        try {
            var result = confirm("Going to delete " + memberID + " ?");
            if (result) {
                Action = "Remove Group Member: " + memberID
                para.Operate = actionType
                para.AppID = appID;
                para.GroupID = groupID;
                para.MemberID = memberID;
                var result = SIC.Models.WebService.SaveSecurityGroupMember(memberType, actionType, para, onSuccess, onFailure);
            }
        }
        catch(e) {
            alert(action + " button click something going wrong");
        }
    }
    function OpenInPage(title, page, para, groupId) {

        alert(para);
        var goPage = page + para;
        var vTop = 50;
        var vLeft = 100;
        var vHeight = 400;
        var vWidth = 550;
        try {

            $("#editiFrame").attr('src', goPage);
            $("#EditTitle").html(title + " " + groupId);
            $("#EditDIV").css({
                top: vTop,
                left: vLeft,
                height: vHeight - 50,
                width: vWidth - 50
            });
            //   PopUpDIV2();
            //  $("#PopUpDIV").fadeToggle("fast");
            $("#EditDIV").fadeToggle("fast");

        }

        catch(e) {
            window.alert("Error:" + e.mess);
        }

    }

</script>
