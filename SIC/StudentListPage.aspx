<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentListPage.aspx.cs" Inherits="SIC.StudentListPage" Async="true" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SIC Student List</title>
    <meta http-equiv="Pragma" content="No-cache" />
    <meta http-equiv="Cache-Control" content="no-Store,no-Cache" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <script src="../Scripts/jquery-3.2.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/BubbleHelp.css" rel="stylesheet" />
    <link href="../Content/ListPage.css" rel="stylesheet" />
    <link href="../Content/ContentPage.css" rel="stylesheet" />
    <link href="../Content/TabMenu.css" rel="stylesheet" />

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

        #ActionMenuDIV {
            border: 2px lightblue ridge;
            height: 180px;
            width: 210px;
            background: lightblue; /* For browsers that do not support gradients */
            background: -webkit-linear-gradient(lightblue, white); /* For Safari 5.1 to 6.0 */
            background: -o-linear-gradient(lightblue, white); /* For Opera 11.1 to 12.0 */
            background: -moz-linear-gradient(lightblue, white); /* For Firefox 3.6 to 15 */
            background: linear-gradient(lightblue, white); /* Standard syntax */
        }

            #ActionMenuDIV li {
                height: 25px;
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

        .Gobutton {
            display: inline;
            padding-top: 0px;
            margin-bottom: -5px;
        }

        #SearchBar {
            position: absolute;
            top: 22px;
            left: 1000px;
        }

        #HelpTextBox {
            width: 100%;
            height: 100%;
        }

        .top5Row {
            border-top: 5px solid darkcyan;
        }

        .HideButton {
            margin: 0px;
            padding: 0px;
            border: 0px;
        }

        #alphabateSearch .alphabateKey {
            list-style-type: none;
            display: inline;
            padding-right: 15px;
        }

        #alphabateSearch ul {
            margin-top: -20px;
        }

        #TextSearch {
            margin-bottom: -5px;
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

        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div style="display: inline;">
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


                    <asp:DropDownList ID="ddlSearchby" runat="server" Width="100px" AutoPostBack="true" OnSelectedIndexChanged="DDLSearchBy_SelectedIndexChanged">
                        <asp:ListItem Value="SurName" Selected="True"> SurName</asp:ListItem>
                        <asp:ListItem Value="Age">Age</asp:ListItem>
                        <asp:ListItem Value="Grade">Grade</asp:ListItem>
                        <asp:ListItem Value="Program">Program</asp:ListItem>
                    </asp:DropDownList>

                    <asp:TextBox ID="TextSearch" runat="server" Width="80px" Height="19px" placeholder="Surname"></asp:TextBox>

                    <asp:DropDownList ID="ddlSearchValue" runat="server" Width="100px" AutoPostBack="false">
                    </asp:DropDownList>
                    IN 
                    <asp:DropDownList ID="ddlScope" runat="server" Width="70px" AutoPostBack="false">
                        <asp:ListItem Value="School" Selected="True"> School</asp:ListItem>
                        <asp:ListItem Value="Board">Board</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btnSearch" runat="server" Text="Go" OnClick="BtnSearch_Click" CssClass="Gobutton" />
                    <asp:Button ID="btnGradeTab" runat="server" Text="" Height="0px" Width="0px" CssClass="HideButton" OnClick="BtnGradeTab_Click" />


                    <div id="SearchBar">
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <img src="../images/indicator.gif" alt="" />
                                <b>Searching.....</b>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                    With Program:
                     <asp:DropDownList ID="ddlProgram" runat="server" Width="100px" AutoPostBack="false">
                         <asp:ListItem Value="All" Selected="True"> All</asp:ListItem>
                         <asp:ListItem Value="IEP">IEP Student</asp:ListItem>
                         <asp:ListItem Value="IPRC">IPRC Student</asp:ListItem>
                         <asp:ListItem Value="Gift">Gift Student</asp:ListItem>
                         <asp:ListItem Value="Autism">Autism Student</asp:ListItem>
                         <asp:ListItem Value="Alternative">Alternative Student</asp:ListItem>
                     </asp:DropDownList>
                    T:
                      <asp:DropDownList ID="ddlTerm" runat="server" Width="40px" AutoPostBack="false">
                          <asp:ListItem Value="P"> School</asp:ListItem>
                          <asp:ListItem Value="1" Selected="True">1</asp:ListItem>
                          <asp:ListItem Value="2">2</asp:ListItem>
                          <asp:ListItem Value="3">3</asp:ListItem>
                      </asp:DropDownList>
                    S:
                      <asp:DropDownList ID="ddlSmester" runat="server" Width="40px" AutoPostBack="false">
                          <asp:ListItem Value="1" Selected="True"> 1</asp:ListItem>
                          <asp:ListItem Value="2">2</asp:ListItem>
                      </asp:DropDownList>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

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

                                    <asp:TemplateField HeaderText="Student Name" ItemStyle-CssClass="myName">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link4" runat="server" Text='<%# Bind("StudentName") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="150px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Grade" HeaderText="Grade" ItemStyle-CssClass="myGrade">
                                        <ItemStyle Width="50px" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Gender" HeaderText="Gender" ItemStyle-CssClass="visible-sm visible-md visible-lg" HeaderStyle-CssClass="visible-sm visible-md visible-lg">
                                        <ItemStyle Width="50px" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BirthDate" HeaderText="Birth Date">
                                        <ItemStyle Width="100px" Wrap="true" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Exceptionality">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link5" runat="server" Text='<%# Bind("Exceptionality") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="120px" Wrap="true" />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="StudentNo" HeaderText="Student No." ReadOnly="True" ItemStyle-CssClass="StudentNo">
                                        <ItemStyle Width="80px" Wrap="False" />
                                    </asp:BoundField>


                                    <asp:BoundField DataField="OEN" ReadOnly="True" HeaderText="OEN Number" ItemStyle-CssClass="OEN">
                                        <ItemStyle Width="80px" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SchoolName" ReadOnly="True" HeaderText="School" ItemStyle-CssClass="School">
                                        <ItemStyle Width="250px" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Gift">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chbGift" Checked='<%# Convert.ToBoolean(Eval("IsGift"))%>' runat="server" CssClass="myCheckGift"></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="IPRC">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chbIPRC" Checked='<%# Convert.ToBoolean(Eval("IsIPRC"))%>' runat="server" CssClass="myCheckIPRC"></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="IEP">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chbIEP" Checked='<%# Convert.ToBoolean(Eval("IsIEP"))%>' runat="server" CssClass="myCheckIEP"></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Alternative">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chbAlternative" Checked='<%# Convert.ToBoolean(Eval("IsAlternative"))%>' runat="server" CssClass="myCheckAlternative"></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Comments" HeaderText="Comments" ItemStyle-CssClass="visible-sm visible-md visible-lg" HeaderStyle-CssClass="visible-sm visible-md visible-lg">
                                        <ItemStyle Width="20%" Wrap="True" />
                                    </asp:BoundField>


                                    <asp:BoundField DataField="StudentID" ReadOnly="True" ItemStyle-CssClass="StudentID" Visible="false">

                                        <%-- <ItemStyle Width="0px" />--%>
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
            <ul id="ActionMenuUL">
                <li id="submenu1"><a class="menuLink" href="javascript:openPage(5,10,750,1000,'IEPForm');">IEP Form </a></li>
                <li id="submenu2"><a class="menuLink" href="javascript:openPage(5,10,750,1000,'IEPReport');">IEP Report </a></li>
                <li id="submenu3"><a class="menuLink" href="javascript:openPage(5,10,750,1000,'GiftForm');">Gift Form </a></li>
                <li id="submenu4"><a class="menuLink" href="javascript:openPage(5,10,750,1000,'GiftReport');">Gift Report </a></li>
                <li id="submenu5"><a class="menuLink" href="javascript:openPage(5,10,750,1000,'AlterRCForm');">Alternative Report Card</a></li>
                <li id="submenu6"><a class="menuLink" href="javascript:openPage(5,10,750,1000,'AlterRCReport');">Alternative Report Card Report </a></li>

            </ul>
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
        </div>
    </form>
</body>
</html>

<script src="../Scripts/MoursPoint.js"></script>

<script src="../Scripts/GridView.js"></script>
<script src="../Scripts/Appr_ListPage.js"></script>
<script src="../Scripts/Appr_Help.js"></script>
<script src="../Scripts/Appr_textEdit.js"></script>

<script type="text/javascript">
    var UserID = $("#hfUserID").val();
    var UserRole = $("#hfUserRole").val();
    var ItemCode = $("#hfCode").val();
    var preaLinkID;
    var BasePara = {
        UserID: $("#hfUserID").val(),
        UserRole: $("#hfUserRole").val(),
        SchoolYear: "",
        SchoolCode: "",
        Grade: "",
        StudentID: "",
        StudentName: ""
    };
    var stName;
    var stID;
    var scYear;
    var scCode;
    var Grade;
    var myKey;
    var currentTR;
    var myIDs;
    var currentTR;
    function pageLoad(sender, args) {

        $(document).ready(function () {
            var vHeight = window.innerHeight - 70;
            MakeStaticHeader("GridView1", vHeight, 1500, 20, false);
            preaLinkID = $("#hfSelectedTabL").val();
            ChangeHeaderSchoolName();
            $("#GridView1 tr").mouseenter(function (event) {
                if (currentTR != undefined) { currentTR.removeClass("highlightRow"); }
                currentTR = $(this)
                currentTR.addClass("highlightRow");
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
            //$("#ddlSchool").change(function (e) {
            //     ChangeTitleSchool();
            //});
            //$("#ddlSchoolCode").change(function (e) {
            //   ChangeTitleSchool();
            //});
        });
    }
    function ChangeHeaderSchoolName() {
        var schoolcode = $("#ddlSchool").val();
        var schoolName = $("#ddlSchool option:selected").text();
        $("#LabelSchool", parent.document).text(schoolName);
        $("#LabelSchoolCode", parent.document).text(schoolcode);
        $("#LabelSchoolYear", parent.document).text($("#ddlSchoolYear").val());
    }
    function OpenMenu(sYear, sCode, grade, sID, sName) {
        BasePara.StudentName = sName;
        BasePara.StudentID = sID;
        BasePara.SchoolYear = sYear;
        BasePara.SchoolCode = sCode;
        BasePara.Grade = grade;
        $("#LabelTeacherName").text(sName);

        var menuList = SIC.Models.WebService.MenuOfStudentList("Get", BasePara, onSuccessMenu, onFailure);
    }
    function onSuccessMenu(result) {
        BuildingMenuList(result);
    }

    function onFailure() {
        alert("Get Menu Failed!");
    }
    function BuildingMenuList(result) {
        var list = "";
        var myObj = result;
        //  $("#ActionMenuDIV").html("");
        for (x in myObj) {
            // list += "<option value ='" + myObj[x].myCode + "'>" + myObj[x].myName + "</option>";
            var para = "javascript:openPage(" + myObj[x].Ptop + "," + myObj[x].Pleft + "," + myObj[x].Pheight + "," + myObj[x].Pwidth + ",'" + myObj[x].MenuID + "','" + myObj[x].Type + "')";

            list += ' <li><a class="menuLink" href="' + para + '">' + myObj[x].Name + ' </a></li>';
        }

        var menulength = myObj.length * 40;
        $("#ActionMenuUL").html("");
        $("#ActionMenuUL").html(list);

        var vTop = mousey;
        if (vTop > 500) {
            vTop = vTop - 150;
        }
        //  var vLeft = event.currentTarget.offsetLeft;
        $("#ActionMenuDIV").css({
            top: vTop + 15,
            left: 60,
            width: 250,
            height: menulength

        });
        $("#ActionMenuDIV").fadeToggle("fast");

    }
    function openPage(vTop, vLeft, vHeight, vWidth, menuID, type) {
        var para = "?pageID=" + menuID + "&uRole=" + BasePara.UserRole + "&sYear=" + BasePara.SchoolYear + "&sCode=" + BasePara.SchoolCode + "&grade=" + BasePara.Grade + "&sID=" + BasePara.StudentID;
        var goPage = "Loading3.aspx"
        if (type == "PDF") goPage = "Loading3Report.aspx"

        var goPage = goPage + para



        try {
            $("#ActionMenuDIV").fadeToggle("fast");

            $("#editiFrame", parent.document).attr('src', goPage);
            $("#EditTitle", parent.document).html(menuID);
            $("#EditDIV", parent.document).css({
                top: vTop,
                left: vLeft,
                height: vHeight,
                width: vWidth
            });
            //   PopUpDIV2();
            $("#PopUpDIV", parent.document).fadeToggle("fast");
            $("#EditDIV", parent.document).fadeToggle("fast");

        }

        catch (e) {
            window.alert(e.mess);
        }
    }
</script>
