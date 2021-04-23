<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassListPage.aspx.cs" Inherits="SIC.ClassListPage" Async="true" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Group List</title>
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

        img {
            border-color: yellow
        }

        .imgHelp {
            width: 23px;
            height: 23px;
            margin-top: -10px;
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
                            <asp:ListItem Value="Course" Selected="True">Class Code</asp:ListItem>
                            <asp:ListItem Value="CourseTitle"> Class Titlee</asp:ListItem>
                        </asp:DropDownList>

                        <asp:TextBox ID="TextSearch" runat="server" Width="100px" Height="19px" placeholder=" Text "></asp:TextBox>

                        <asp:DropDownList ID="ddlSearchValue" runat="server" Width="100px" AutoPostBack="false">
                        </asp:DropDownList>

                        IN 
                    <asp:DropDownList ID="ddlType" runat="server" Width="70px" AutoPostBack="false" Enabled="false">
                        <asp:ListItem Value="School" Selected="True">School</asp:ListItem>
                        <asp:ListItem Value="Board"> All TCDSB</asp:ListItem>
                    </asp:DropDownList>
                        <asp:Button ID="btnSearch" runat="server" Text="Go" OnClick="BtnSearch_Click" CssClass="Gobutton" Visible="false" />
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
                        <div class="term">
                            S:
                              <asp:DropDownList ID="ddlSemester" runat="server" Width="40px" AutoPostBack="false">
                                  <asp:ListItem Value="1" Selected="True"> 1</asp:ListItem>
                                  <asp:ListItem Value="2">2</asp:ListItem>
                              </asp:DropDownList>
                            T:
                              <asp:DropDownList ID="ddlTerm" runat="server" Width="40px" AutoPostBack="false">
                                  <asp:ListItem Value="1" Selected="True"> 1</asp:ListItem>
                                  <asp:ListItem Value="2">2</asp:ListItem>
                                  <asp:ListItem Value="3">3</asp:ListItem>
                                  <asp:ListItem Value="4">4</asp:ListItem>
                              </asp:DropDownList>
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
                                        <ItemStyle Width="30px" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Menu" ItemStyle-CssClass="myAction">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link1" runat="server" Text='<%# Bind("Actions") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="40px" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ClassCode" HeaderText="Class Code" ItemStyle-CssClass="myClassCode">
                                        <ItemStyle Width="120px" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CourseCode" HeaderText="Course " ItemStyle-CssClass="myCourseCode">
                                        <ItemStyle Width="100px" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Course Title" ItemStyle-CssClass="myName">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link4" runat="server" Text='<%# Bind("CourseTitle") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="180px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CourseRoom" HeaderText="Class Room" ItemStyle-CssClass="visible-sm visible-md visible-lg" HeaderStyle-CssClass="visible-sm visible-md visible-lg">
                                        <ItemStyle Width="150px" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CourseTeacher" HeaderText="Course Teacher" ItemStyle-CssClass="visible-sm visible-md visible-lg" HeaderStyle-CssClass="visible-sm visible-md visible-lg">
                                        <ItemStyle Width="150px" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="StartDate" HeaderText="Start Date">
                                        <ItemStyle Width="100px" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EndDate" HeaderText="End Date">
                                        <ItemStyle Width="100px" Wrap="true" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="ClassSize" HeaderText="Class Size" ReadOnly="True" ItemStyle-CssClass="StudentNo">
                                        <ItemStyle Width="100px" Wrap="False" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Comments" HeaderText="Comments" ItemStyle-CssClass="visible-sm visible-md visible-lg" HeaderStyle-CssClass="visible-sm visible-md visible-lg">
                                        <ItemStyle Width="20%" Wrap="True" />
                                    </asp:BoundField>


                                </Columns>

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
      <%--  <div id="alphabateSearch">
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
        </div>--%>

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
            <iframe id="ActioniFramePage" name="ActioniFramePage" style="height: 425px; width: 99%" frameborder="0" scrolling="no" src="" runat="server"></iframe>
        </div>
        <div>
            <asp:HiddenField ID="hfCategory" runat="server" />
            <asp:HiddenField ID="hfPageID" runat="server" />
            <asp:HiddenField ID="hfCode" runat="server" />
            <asp:HiddenField ID="hfUserID" runat="server" />
            <asp:HiddenField ID="hfUserRole" runat="server" />
            <asp:HiddenField ID="hfUserLoginRole" runat="server" />
            <asp:HiddenField ID="hfRunningModel" runat="server" />
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

    var stName;
    var stID;
    var scYear;
    var scCode;
    var Grade;
    var myKey;
    var currentTR;
    var myIDs;
    var currentCell;
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


</script>
