<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffListPageTPA.aspx.cs" Inherits="SIC.StaffListPageTPA" Async="true" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Appraisal Teacher List</title>
    <meta http-equiv="Pragma" content="No-cache" />
    <meta http-equiv="Cache-Control" content="no-Store,no-Cache" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
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
    </style>

</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager runat="server">
            <Services>
                <asp:ServiceReference Path="~/Models/WebService.asmx" />

            </Services>
        </asp:ScriptManager>
        <div class="SearchAreaRow">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="SearchAreaDIV">
                        <img class="imgHelp" src="../images/help2.png" title="Help Content" />
                        <asp:Label ID="Label3" runat="server" Text="School Year: " CssClass="label1"></asp:Label>
                        <asp:DropDownList ID="ddlSchoolYear" runat="server" Width="85px" AutoPostBack="False" OnSelectedIndexChanged="DDLSchoolYear_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:Label ID="Label1" runat="server" Text="Panel: " CssClass="label1"></asp:Label>

                        <asp:DropDownList ID="DDLPanel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLPanel_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="Elementary">Elementary</asp:ListItem>
                            <asp:ListItem>Secondary</asp:ListItem>
                        </asp:DropDownList>

                        <asp:Label ID="Label2" runat="server" Text="School" CssClass="label1"></asp:Label>
                        <asp:DropDownList ID="ddlSchoolCode" runat="server" Width="55px" AutoPostBack="True" OnSelectedIndexChanged="DDLSchoolCode_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlSchool" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="DDLSchool_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:Label ID="Searchby" runat="server" Text="Search by" CssClass="label1"></asp:Label>


                        <asp:DropDownList ID="ddlSearchby" runat="server" Width="100px" AutoPostBack="false" OnSelectedIndexChanged="DDLSearchBy_SelectedIndexChanged">
                            <asp:ListItem Value="SurName" Selected="True">Last Name</asp:ListItem>
                            <asp:ListItem Value="FirstName"> First Name</asp:ListItem>
                            <asp:ListItem Value="CPNum">CPNum</asp:ListItem>
                            <asp:ListItem Value="SIN">SIN</asp:ListItem>
                            <asp:ListItem Value="EmployeeID">Employee ID</asp:ListItem>
                            <asp:ListItem Value="UserID">Network UserID</asp:ListItem>
                        </asp:DropDownList>

                        <asp:TextBox ID="TextSearch" runat="server" Width="80px" Height="19px" placeholder="Surname"></asp:TextBox>

                        <asp:DropDownList ID="ddlSearchValue" runat="server" Width="100px" AutoPostBack="false">
                        </asp:DropDownList>
                        IN 
                    <asp:DropDownList ID="ddlType" runat="server" Width="70px" AutoPostBack="false" Enabled="false">
                        <asp:ListItem Value="School" Selected="True">School</asp:ListItem>
                        <asp:ListItem Value="Board"> All TCDSB</asp:ListItem>
                    </asp:DropDownList>
                        <%--<asp:Button ID="btnSearch" runat="server" Text="Go" OnClick="BtnSearch_Click" CssClass="Gobutton" />--%>
                         <asp:ImageButton ID="btnSearchGo" CssClass="SearchGoButton"  runat="server" ToolTip="Search ..." ImageUrl="../images/Go.png" OnClick="BtnSearch_Click" />
                        <asp:Button ID="btnGradeTab" runat="server" Text="" Height="0px" Width="0px" CssClass="HideButton" OnClick="BtnGradeTab_Click" />


                        <div id="SearchBar">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                <ProgressTemplate>
                                    <img src="../images/indicator.gif" alt="" />
                                    <b>Searching.....</b>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                    <div class="Horizontal_Tab" id="GradeTab" runat="server"></div>
                    <asp:HiddenField ID="hfSelectedTab" runat="server" />
                    <asp:HiddenField ID="hfSelectedTabL" runat="server" />
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
                            <asp:GridView ID="GridView1" runat="server" CellPadding="1" Height="100%" Width="100%" GridLines="Both" AutoGenerateColumns="False" BackColor="White" BorderColor="gray" BorderStyle="Ridge" BorderWidth="1px" CellSpacing="1" EmptyDataText="No Appraisal Staff in current search condition" EmptyDataRowStyle-CssClass="emptyData" ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:BoundField DataField="RowNo" HeaderText="No." ItemStyle-CssClass="myRowNo">
                                        <ItemStyle Width="2%" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Menu" ItemStyle-CssClass="myAction">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link1" runat="server" Text='<%# Bind("Actions") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="2%" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ALP" ItemStyle-CssClass="myALP">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link2" runat="server" Text='<%# Bind("EPA") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="2%" Wrap="False" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Teacher Name" ItemStyle-CssClass="myName">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link4" runat="server" Text='<%# Bind("TeacherName") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Type" ItemStyle-CssClass="myType">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link5" runat="server" Text='<%# Bind("AppraisalType") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="2%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="AppraisalStatus" HeaderText="Status" ItemStyle-CssClass="visible-sm visible-md visible-lg" HeaderStyle-CssClass="visible-sm visible-md visible-lg">
                                        <ItemStyle Width="2%" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AppraisalPhase" HeaderText="Appraisal Phase">
                                        <ItemStyle Width="9%" Wrap="false" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Assignment" HeaderText="Assignment" ItemStyle-CssClass="visible-sm visible-md visible-lg" HeaderStyle-CssClass="visible-sm visible-md visible-lg">
                                        <ItemStyle Width="9%" Wrap="True" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Appraiser" HeaderText="Apprailser" ItemStyle-CssClass="myApprailser visible-sm visible-md visible-lg" HeaderStyle-CssClass="visible-sm visible-md visible-lg">
                                        <ItemStyle Width="6%" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Mentor" HeaderText="Mentor" ItemStyle-CssClass="myMentor visible-sm visible-md visible-lg" HeaderStyle-CssClass="visible-sm visible-md visible-lg">
                                        <ItemStyle Width="6%" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Outcome">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link5" runat="server" Text='<%# Bind("AppraisalOutcome") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="6%" Wrap="true" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CurrentSession" HeaderText="cSession" ItemStyle-CssClass="visible-sm visible-md visible-lg" HeaderStyle-CssClass="visible-sm visible-md visible-lg">
                                        <ItemStyle Width="6%" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AppraisalProcess" HeaderText="process" ItemStyle-CssClass="visible-sm visible-md visible-lg" HeaderStyle-CssClass="visible-sm visible-md visible-lg">
                                        <ItemStyle Width="6%" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Appraisal 1" ItemStyle-CssClass="visible-sm visible-md visible-lg" HeaderStyle-CssClass="visible-sm visible-md visible-lg">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link6" runat="server" Text='<%# Bind("Appraisal1") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="6%" Wrap="True" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Appraisal 2" ItemStyle-CssClass="visible-sm visible-md visible-lg" HeaderStyle-CssClass="visible-sm visible-md visible-lg">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link7" runat="server" Text='<%# Bind("Appraisal2") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="6%" Wrap="True" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Appraisal 3" ItemStyle-CssClass="visible-sm visible-md visible-lg" HeaderStyle-CssClass="visible-sm visible-md visible-lg">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link8" runat="server" Text='<%# Bind("Appraisal3") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="6%" Wrap="True" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Appraisal 4" ItemStyle-CssClass="visible-sm visible-md visible-lg" HeaderStyle-CssClass="visible-sm visible-md visible-lg">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link9" runat="server" Text='<%# Bind("Appraisal4") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="6%" Wrap="True" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Comments" HeaderText="Comments" ItemStyle-CssClass="visible-sm visible-md visible-lg" HeaderStyle-CssClass="visible-sm visible-md visible-lg">
                                        <ItemStyle Width="6%" Wrap="True" />
                                    </asp:BoundField>

                                </Columns>
                                <RowStyle Height="30px" />
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <HeaderStyle BackColor="cornflowerblue" ForeColor="white" Height="25px" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />

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
        <div id="alphabateSearch">
            <ul>
                <li class="alphabateKey"><a href="#" class="alphabateLink">A</a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink">B</a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink">C</a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink">D</a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink">E</a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink"></a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink">F</a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink">G</a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink">H</a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink">I</a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink">J</a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink"></a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink">K</a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink">L</a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink">M</a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink">N</a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink">O</a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink"></a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink">P</a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink">Q</a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink">R</a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink">S</a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink">T</a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink"></a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink">U</a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink">V</a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink">W</a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink">X</a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink">Y</a></li>
                <li class="alphabateKey"><a href="#" class="alphabateLink">Z</a></li>
            </ul>
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
        <div id="ActionPOPDIV" class="bubble epahide">
            <div class="editTitle" style="display: block; margin-top: 5px;">
                <div id="ActionTitle" style="display: inline; float: left; width: 96%"></div>
                <div style="display: inline; float: left;">
                    <img id="closeActionPOP" src="../images/close.ico" style="height: 25px; width: 25px; margin: -3px 0 -3px 0" />
                </div>
            </div>
            <iframe id="ActioniFramePage" name="ActioniFramePage" style="height: 425px; width: 99%" frameborder="0" scrolling="no" src="iBlankPage.html" runat="server"></iframe>
        </div>
        <div>
            <asp:HiddenField ID="hfCategory" runat="server" />
            <asp:HiddenField ID="hfPageID" runat="server" />
            <asp:HiddenField ID="hfCode" runat="server" />
            <asp:HiddenField ID="hfUserID" runat="server" />
            <asp:HiddenField ID="hfUserRole" runat="server" />
            <asp:HiddenField ID="hfUserLoginRole" runat="server" />
            <asp:HiddenField ID="hfRunningModel" runat="server" />
              <input id ="clipboardText" type ="text" style="position:absolute;top:100px;left:100px;" />
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
    var myIDs;
    var currentTR;
    function pageLoad(sender, args) {

        $(document).ready(function () {
            var vHeight = window.innerHeight - 70;
            MakeStaticHeader("GridView1", vHeight, 1500, 20, false);
            preaLinkID = $("#hfSelectedTabL").val();
            ChangeHeaderSchoolName();
            $("#GridView1 tr").mouseenter(function (event) {
               // if (currentTR != undefined) { currentTR.removeClass("highlightRow"); }
               // currentTR = $(this)
               // currentTR.addClass("highlightRow");
                if ($("#ActionMenuDIV").is(":visible")) $("#ActionMenuDIV").hide();

            });
            $("#GradeTab").click(function (e) {
                var cEvantID = e.originalEvent.srcElement.id;
                $("#hfSelectedTab").val(cEvantID);
                $("#hfSelectedTabL").val(e.originalEvent.srcElement.parentNode.id);
                $("#btnGradeTab").click();
                preaLinkID = $("#hfSelectedTabL").val();
            });
            $(".alphabateLink").click(function (e) {

                var cEvantID = e.currentTarget.innerText;
                $("#TextSearch").val(cEvantID);
                $("#btnGradeTab").click();
            });
            $("#DDLPanel").change(function () {
                BuildingSchoolList();
            });
        });
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
    function onFailure() {
        alert("Get Menu Failed!");
    }

</script>
