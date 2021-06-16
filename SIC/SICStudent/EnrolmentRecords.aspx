<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnrolmentRecords.aspx.cs" Inherits="SIC.EnrolmentRecords" Async="true" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SIC Student List</title>
    <meta http-equiv="Pragma" content="No-cache" />
    <meta http-equiv="Cache-Control" content="no-Store,no-Cache" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <%--    <script src="../Scripts/bootstrap.min.js"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />--%>
    <link href="../Content/BubbleHelp.css" rel="stylesheet" />
    <link href="../Content/ListPage.css" rel="stylesheet" />
    <link href="../Content/ContentPage.css" rel="stylesheet" />
    <link href="../Content/TabMenu.css" rel="stylesheet" />
    <link href="../Content/TopNavList.css" rel="stylesheet" />
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

        img {
            border-color: yellow
        }

        .label1 {
            font-family: Arial;
            font-size: 13px;
        }



        .top5Row {
            border-top: 5px solid darkcyan;
        }

        .HideButton {
            margin: 0px;
            padding: 0px;
            border: 0px;
        }

        #SearchingBar {
            position: absolute;
            top: 35px;
            left: 1010px;
        }
        .EditPage {
            height:100%;
            width:100%;
            
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
        <div class="SearchAreaRow" style="height: 60px;">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="SearchAreaDIV">
                        <img class="imgHelp" src="../images/help2.png" title="Help Content" />
                        <asp:Label ID="Label3" runat="server" Text="School Year: " CssClass="label1"></asp:Label>
                        <asp:DropDownList ID="ddlSchoolYear" runat="server" Width="85px" AutoPostBack="True" OnSelectedIndexChanged="DDLSchoolYear_SelectedIndexChanged">
                        </asp:DropDownList>



                        <asp:Label ID="Searchby" runat="server" Text="Search by" CssClass="label1" Visible="false"></asp:Label>
                        <asp:HiddenField ID="hfSearchby" runat="server" Value="SurName" />

                        <asp:HiddenField ID="hfSearchValue" runat="server" Value="" />
                        <asp:ImageButton ID="btnSearchGo" Visible="false" CssClass="SearchGoButton" runat="server" ToolTip="Search ..." ImageUrl="../images/Go.png" OnClick="BtnSearchGo_Click" />

                    </div>

                    </div>
                    <div style="margin-top: 5px; width: 1010px;" class="Search-Area-Sigal ">
                        Student Name ;
                        <asp:TextBox CssClass="SearchTextBox" ID="TextBoxStudentName" runat="server" Width="200px" placeholder="Student name"></asp:TextBox>
                        Grade  
                         <asp:TextBox CssClass="SearchTextBox" ID="TextGrade" runat="server" placeholder="Grade"></asp:TextBox>
                        Student No.
                      
                        <asp:TextBox CssClass="SearchTextBox" ID="TextBoxStudentNo" runat="server" placeholder="Student No."></asp:TextBox>
                        OEN.
                         <asp:TextBox CssClass="SearchTextBox" ID="TextBoxOEN" runat="server" placeholder="OEN"></asp:TextBox>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div id="DivRoot" style="width: 100%;">
                        <div style="overflow: hidden;" id="DivHeaderRow">
                            <table id="GridView2" style="border: 1px ridge gray; width: 100%; height: 100%; background-color: white;" rules="all" cellspacing="1" cellpadding="1">
                            </table>
                        </div>

                        <div style="overflow: scroll; width: 100%; height: 100%" onscroll="OnScrollDiv(this)" id="DivMainContent">
                            <asp:GridView ID="GridView1" runat="server" CellPadding="1" Height="100%" Width="100%" GridLines="Both" AutoGenerateColumns="False" BackColor="White" BorderColor="gray" BorderStyle="Ridge" BorderWidth="1px" CellSpacing="1"
                                EmptyDataText="No Students in current search condition" EmptyDataRowStyle-CssClass="emptyData" ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:BoundField DataField="RowNo" HeaderText="No." ItemStyle-CssClass="myRowNo">
                                        <ItemStyle Width="2%" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Edit" ItemStyle-CssClass="myAction">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link1" runat="server" Text='<%# Bind("EditAction") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="3%" Wrap="False" />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="ActiveFlag" HeaderText="Active">
                                        <ItemStyle Width="3%" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EnrolmentTypeName" HeaderText="Enrolment Name">
                                        <ItemStyle Width="5%" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EnrolmentTypeID" HeaderText="Type ID">
                                        <ItemStyle Width="3%" Wrap="false" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EffectiveDate" HeaderText="Effective Date">
                                        <ItemStyle Width="5%" Wrap="true" />
                                    </asp:BoundField>


                                    <asp:BoundField DataField="SchoolName" HeaderText="School Name" ReadOnly="True" ItemStyle-CssClass="SchoolName">
                                        <ItemStyle Width="17%" Wrap="True" />
                                    </asp:BoundField>


                                    <asp:BoundField DataField="SchoolNameNext" ReadOnly="True" HeaderText="School Next" ItemStyle-CssClass="SchoolNext">
                                        <ItemStyle Width="10%" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SchoolBSID" ReadOnly="True" HeaderText="BSID" ItemStyle-CssClass="School">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SchoolYearTrack" HeaderText="Year Track" ItemStyle-CssClass="mySchoolYerTrack">
                                        <ItemStyle Width="5%" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Grade" HeaderText="Grade" ItemStyle-CssClass="myGrade">
                                        <ItemStyle Width="3%" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RegisterCode" HeaderText="Register">
                                        <ItemStyle Width="5%" Wrap="True" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EntryTypeName" HeaderText="Entry Type">
                                        <ItemStyle Width="5%" Wrap="True" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LanguageInstruct" HeaderText="Language">
                                        <ItemStyle Width="5%" Wrap="True" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FundingSourceType" HeaderText="Funding Source">
                                        <ItemStyle Width="4%" Wrap="True" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="DemitReasonName" HeaderText="Demit Reason">
                                        <ItemStyle Width="8%" Wrap="True" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DemitNextSchoolCode" HeaderText="Demit Next">
                                        <ItemStyle Width="5%" Wrap="True" />
                                    </asp:BoundField>




                                </Columns>

                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <HeaderStyle BackColor="cornflowerblue" ForeColor="white" Height="25px" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <RowStyle Height="30px" />
                                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#594B9C" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#33276A" />
                            </asp:GridView>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>


        <div id="HelpDIV" class="bubble epahide">
            <asp:TextBox ID="HelpTextContent" runat="server" TextMode="MultiLine" CssClass="HelpTextBox" BackColor="transparent"></asp:TextBox>

        </div>

        <div id="ActionMenuDIV" class="bubble epahide">
            <asp:Label runat="server" ID="LabelTeacherName" Text=""> </asp:Label>

            <div id="ActionMenuUL" class="LeftSideMenu">
            </div>


        </div>
        <div id="PopUpDIV" class="bubble epahide"></div>
        <div id="EditDIV" runat="server" class="EditDIV bubble epahide">
            <div class="editTitle">
                <table>
                    <tr>
                        <td style="width: 95%">
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
            <asp:HiddenField ID="hfArea" runat="server" />
            <asp:HiddenField ID="hfItemCode" runat="server" />
            <asp:HiddenField ID="hfUserID" runat="server" />
            <asp:HiddenField ID="hfUserRole" runat="server" />
            <asp:HiddenField ID="hfUserLoginRole" runat="server" />
            <asp:HiddenField ID="hfRunningModel" runat="server" />
            <asp:HiddenField ID="hfSearchTextFields" runat="server" />
            <input id="clipboardText" type="text" style="position: absolute; top: 10px; left: -500px;" />
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
    var preaLinkID;

    var BaseParaDDL = {
        Operate: "Get",
        UserID: $("#hfUserID").val(),
        UserRole: $("#hfUserRole").val(),
        SchoolYear: $("#ddlSchoolYear").val(),
        SchoolCode: $("#ddlSchool").val(),
        Para1: "",
        Para2: "",
        Para3: "",
    };

    var stName;
    var stID;
    var scYear;
    var scCode;
    var Grade;
    var myKey;
    var currentTR;
    var myIDs;
    var currentSearchBoxID = "";

    function pageLoad(sender, args) {
        $(document).ready(function () {

            var vHeight = window.innerHeight - 120;
            MakeStaticHeader("GridView1", vHeight, 1500, 20, false);
            $("#GridView1 tr").mouseenter(function (event) {
                if ($("#ActionMenuDIV").is(":visible")) $("#ActionMenuDIV").hide();
            });
            $("#closeMe").click(function (event) {

                $("#PopUpDIV").hide();
                $("#EditDIV").hide();
            });

        });
    }
    function clearSearhBox() {
        $("#" + currentSearchBoxID).val("");
    }
    function openTopSubMenu(cEventID, eY, eX) {


        $("#TopSubMenuItems").css({
            top: eY + 26,
            left: eX - 2,
            height: eH,
            width: 300
        })
        $("#TopSubMenuItems").show();
        currentY = eY;
        //  $("#TopSubMenuItems").fadeToggle("fast");
        //if (currentY != eY) {
        //    $("#TopSubMenuItems").fadeToggle("fast");
        //}

    }

    function BuildingSchoolList() {
        BaseParaDDL.Operate = "SchoolList";
        BaseParaDDL.SchoolYear = $("#ddlSchoolYear").val();
        BaseParaDDL.SchoolCode = $("#DDLPanel").val();

        var ddlList = SIC.Models.WebService.CommonLists(BaseParaDDL.Operate, BaseParaDDL, onSuccessSchoolList, onFailure);
    }
    function onSuccessSchoolList(result) {
        BuildingList.DropDown2($("#ddlSchool"), BuildingDropDownList(result), $("#ddlSchoolCode"), BuildingDropDownList1(result));

    }




    var DataUrl = {
        "myUrl": "https://webt.tcdsb.org/Webapi/SIC/Api/SIC/"
    }

    function getUrl() {
        return DataUrl.myUrl + "?Operate=" + BaseParaDDL.Operate + "&UserID=" + BaseParaDDL.UserID + "&UserRole=" + BaseParaDDL.UserRole + "&SchoolYear=" + BaseParaDDL.SchoolYear + "&SchoolCode=" + BaseParaDDL.SchoolCode + "&Para1=1&Para2=2&Para3=1";
    }

    function OpenEditPage(action, goPage, target, pHeight, pWidth, userID, userRole, schoolYear, schoolCode, personId, typeId, effectiveDate) {
        // var page = "../SICCommon/Security_Role.aspx"
        if ($("#hfUserRole").val() != "Admin") {
            alert("Current User is View Permission only");
        }
        else {
            var para = "?UserID=" + userID + "&UserRole=" + userRole + "&SchoolYear=" + schoolYear + "&SchoolCode=" + schoolCode + "&PersonID=" + personId + "&TypeID=" + typeId + "&EffectiveDate=" + effectiveDate + "&Action=" + action;
            var goPage = goPage + para
            if (target == "EditDIV") {
                var xName = "Enrolment Record Edit";
                OpenInPage(xName, goPage, pHeight, pWidth);
            }
            else {
                $("#" + target).attr('src', goPage);
            }
        }
    }
    function OpenInPage(title, goPage, pHeight, pWidth) {

        //   var goPage = page + para;
        var vTop = 100;
        var vLeft = 100;
        var vHeight = pHeight;
        var vWidth = pWidth;
        try {

            $("#editiFrame").attr('src', goPage);
            $("#EditTitle").html(title);
            $("#EditDIV").css({
                top: vTop,
                left: vLeft,
                height: vHeight - 50,
                width: vWidth - 50
            });
            $("#EditDIV").fadeToggle("fast");
        }

        catch (e) {
            window.alert("Error:" + e.mess);
        }

    }

</script>
