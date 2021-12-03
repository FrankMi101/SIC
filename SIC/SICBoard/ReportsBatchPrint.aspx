<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportsBatchPrint.aspx.cs" Inherits="SIC.ReportsBatchPrint" Async="true"  enableEventValidation="false" %>

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
            top: 30px;
            left: 1150px;
        }

        .StudentID {
            display: none;
        }
        .PageButton {
            margin-left:30px;
            margin-right:30px;
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
            <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                                 </ContentTemplate>
            </asp:UpdatePanel>--%>
                    <div class="SearchAreaDIV">
                        <img class="imgHelp" src="../images/help2.png" title="Help Content" />
                        <asp:Label ID="Label3" runat="server" Text="School Year: " CssClass="label1"></asp:Label>
                        <asp:DropDownList ID="ddlSchoolYear" runat="server" Width="85px" AutoPostBack="False" OnSelectedIndexChanged="DDLSchoolYear_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:Label ID="Label1" runat="server" Text="Panel: " CssClass="label1"></asp:Label>

                        <asp:DropDownList ID="DDLPanel" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLPanel_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="E">Elementary</asp:ListItem>
                            <asp:ListItem Value="S">Secondary</asp:ListItem>
                        </asp:DropDownList>

                        <asp:Label ID="Label2" runat="server" Text="School" CssClass="label1"></asp:Label>
                        <asp:DropDownList ID="ddlSchoolCode" runat="server" Width="60px" AutoPostBack="True" OnSelectedIndexChanged="DDLSchoolCode_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlSchool" runat="server" Width="400px" AutoPostBack="True" OnSelectedIndexChanged="DDLSchool_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:Label ID="Searchby" runat="server" Text="Search by" CssClass="label1" Visible="false"></asp:Label>
                        <asp:HiddenField ID="hfSearchby" runat="server" Value="SurName" />
                        <asp:HiddenField ID="hfSearchValue" runat="server" Value="" />


                        <div id="SearchingBar">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                <ProgressTemplate>
                                    <img src="../images/indicator.gif" alt="" />
                                    <b>Searching.....</b>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                        &nbsp;&nbsp;  &nbsp;&nbsp; 
                        With Program:
                     <asp:DropDownList ID="ddlProgram" runat="server" Width="100px" AutoPostBack="false">
                         <asp:ListItem Value="All" Selected="True"> All</asp:ListItem>
                         <asp:ListItem Value="IEP">IEP Student</asp:ListItem>
                         <asp:ListItem Value="IPRC">IPRC Student</asp:ListItem>
                         <asp:ListItem Value="Gift">Gift Student</asp:ListItem>
                         <asp:ListItem Value="Autism">Autism Student</asp:ListItem>
                         <asp:ListItem Value="Alternative">Alternative Student</asp:ListItem>
                     </asp:DropDownList>
                        <div class="term">
                            S:
                      <asp:DropDownList ID="ddlSemester" runat="server" Width="40px" AutoPostBack="false">
                          <asp:ListItem Value="1" Selected="True"> 1</asp:ListItem>
                          <asp:ListItem Value="2">2</asp:ListItem>
                      </asp:DropDownList>
                            T:
                      <asp:DropDownList ID="ddlTerm" runat="server" Width="40px" AutoPostBack="false">
                          <asp:ListItem Value="P"> School</asp:ListItem>
                          <asp:ListItem Value="1" Selected="True">1</asp:ListItem>
                          <asp:ListItem Value="2">2</asp:ListItem>
                          <asp:ListItem Value="3">3</asp:ListItem>
                      </asp:DropDownList>
                        </div>

                 </div>
                    <div style="margin: 5px">
                        Batch Print Form & Report:
                          <asp:DropDownList ID="ddlReportForm" runat="server" Width="150px" AutoPostBack="false">
                              <asp:ListItem Value="IEP"> IEP Report </asp:ListItem>
                              <asp:ListItem Value="IPRC">IPRC Form</asp:ListItem>
                              <asp:ListItem Value="Gift">Gift Report Card</asp:ListItem>
                              <asp:ListItem Value="RC">Report Card</asp:ListItem>
                              <asp:ListItem Value="OIC">Office Index Card</asp:ListItem>
                          </asp:DropDownList>
                        Print By: 
                        <asp:DropDownList ID="ddlPrintBy" runat="server" Width="100px" AutoPostBack="true" OnSelectedIndexChanged ="DDLPrintBy_SelectedIndexChanged"  >
                            <asp:ListItem Value="ListSchool"> School </asp:ListItem>
                            <asp:ListItem Value="Grade">Grade</asp:ListItem>
                            <asp:ListItem Value="Class">Class</asp:ListItem>
                            <asp:ListItem Value="Program">Program</asp:ListItem>
                            <asp:ListItem Value="Exceptionality">Exceptionality</asp:ListItem>
                        </asp:DropDownList>
                        By Value:
                         <asp:DropDownList ID="ddlPrintByValue" runat="server" Width="250px" AutoPostBack="false">
                      </asp:DropDownList>

                         <asp:ImageButton ID="btnSearchGo"  CssClass="SearchGoButton PageButton" runat="server" ToolTip="Search ..." ImageUrl="../images/Go.png" OnClick="BtnSearchGo_Click" />
                        <asp:CheckBox ID="chbOneFile" Checked="true" Text="In One File" runat="server" />
                        <asp:CheckBox ID="chbSelectAll" runat="server" Text="Select All" AutoPostBack="true" />

                        <asp:ImageButton ID="btnPrintReport" runat="server"   CssClass="SearchGoButton PageButton" ImageUrl="../images/print.png" />
                    </div>
   
        </div>

        <div>
            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>  </ContentTemplate>
            </asp:UpdatePanel>--%>
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
                                        <ItemStyle Width="30px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Selected">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chbSelected" Checked='<%# Convert.ToBoolean(Eval("Selected"))%>' runat="server" CssClass="myCheckSelected"></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" HorizontalAlign="center" />
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
                                    <asp:BoundField DataField="HomeRoom" HeaderText="Home Room">
                                        <ItemStyle Width="100px" Wrap="true" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Exceptionality">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="Link5" runat="server" Text='<%# Bind("Exceptionality") %>'>  </asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle Width="120px" Wrap="true" />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="StudentNo" HeaderText="Student No." ReadOnly="True" ItemStyle-CssClass="myStudentNo">
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
                                    <asp:TemplateField HeaderText="Alter">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chbAlternative" Checked='<%# Convert.ToBoolean(Eval("IsAlternative"))%>' runat="server" CssClass="myCheckAlternative"></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SSN">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chbSSN" Checked='<%# Convert.ToBoolean(Eval("IsSSN"))%>' runat="server" CssClass="myCheckSSN"></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ESL">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chbESL" Checked='<%# Convert.ToBoolean(Eval("IsESL"))%>' runat="server" CssClass="myCheckSSN"></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Comments" HeaderText="Comments" ItemStyle-CssClass="visible-sm visible-md visible-lg" HeaderStyle-CssClass="visible-sm visible-md visible-lg">
                                        <ItemStyle Width="20%" Wrap="True" />
                                    </asp:BoundField>


                                    <asp:BoundField DataField="StudentID" ReadOnly="True" ItemStyle-CssClass="StudentID">

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
              

        </div>


        <div id="HelpDIV" class="bubble epahide">
            <asp:TextBox ID="HelpTextContent" runat="server" TextMode="MultiLine" CssClass="HelpTextBox" BackColor="transparent"></asp:TextBox>

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
    var selectSet = [];

    function pageLoad(sender, args) {
        $(document).ready(function () {
            // currentSearchBoxID = "TextBoxAge";
            //$("#btnSearchGoLastName").hide();
            //$("#btnSearchGoFirstName").hide();
            //$("#btnSearchGoOEN").hide();
            //$("#btnSearchGoStudentNo").hide();
            //$("#btnSearchGoClass").hide();
            //$("#btnSearchGoAge").hide();
            try {
                //  $("#btnSearchGo" + $("#hfSearchby").val()).show();
                $("#btnSearchGo" + $("#hfSearchby").val()).removeClass("hideMe");
            }
            catch(e) { }
            var vHeight = window.innerHeight - 120;
            MakeStaticHeader("GridView1", vHeight, 1500, 20, false);
            preaLinkID = $("#hfSelectedTabL").val();
            ChangeHeaderSchoolName();
            // CheckSearchControl()

            $("#GridView1 tr").mouseenter(function (event) {
                //if (currentTR != undefined) { currentTR.removeClass("highlightRow"); }
                //currentTR = $(this)
                //currentTR.addClass("highlightRow");
                if ($("#ActionMenuDIV").is(":visible")) $("#ActionMenuDIV").hide();
            });
            //$("#ddlPrintBy").change(function (event) {
            //    var ddlType = $("#ddlPrintBy").val();
            //    BuildDDLList($("#ddlPrintByValue"), ddlType);
            //})

            $("#chbSelectAll").change(function (event) {
                var selectedValue = $('#chbSelectAll').is(":checked"); //  $("#chbSelectAll").is(":checked")? true: false;
                // if ($('#check_id').is(":checked"))
                // $('#check_id').val();

                // alert(selectedValue);
                $("#GridView1 tr").each(function () {
                    try {

                        var cellId = $(this).find('td .myCheckSelected')[0].childNodes[0].id;
                        //  var newcell = $(this).find('td .myCheckSelected')[0].childNodes[0].checked;
                        //  var chevalue = $("#" + cellId).is(":checked");
                        $("#" + cellId).attr('checked', selectedValue);
                        //  console.log($("#" + cellId).is(":checked"));

                    }
                    catch(ex) {
                    }
                });
            });
            $("#btnPrintReport").click(function (event) {
                var selectedDataSet = [];
                alert("click on");
                $("#GridView1 tr").each(function () {
                    try {
                        var cellId = $(this).find('td .myCheckSelected')[0].childNodes[0].id;
                        var chechedValue = $("#" + cellId).is(":checked");

                        if (chechedValue) {
                            var selectedOBJ = {
                                UserID: $("#hfUserID").val(),
                                SchoolYear: $("#ddlSchoolYear").val(),
                                SchoolCode: $("#ddlSchool").val(),
                                ObjID: $(this).find('td.StudentID').text(),
                                ObjNo: $(this).find('td.myGrade').text(),
                                ObjType: $(this).find('td.myStudentNo').text()
                            };       
                            selectedDataSet.push(selectedOBJ);
                        }
                    }
                    catch(ex) {

                    }
                });

                SIC.Models.WebService.SelectedStudentDataSet("BatchPrint", selectedDataSet, onSuccessSelectedData, onFailure);

            });

        });
    }
    function onSuccessSelectedData(result) {
        var reportID = $("#ddlReportForm").val();
        var semester = $("#ddlSemester").val();
        var term = $("#ddlTerm").val();
        var oneFile = $('#chbOneFile').is(":checked") ? "Yes" : "No";
        window.open("../LoadingMultipleReports.aspx?ReportID=" + reportID + "&Semester=" + semester + "&Term=" + term + "&OneFile=" + oneFile, "pdfprint", "width=850 height=650, top=50, left=50, toolbars=no, scrollbars=no,status=no,resizable=no");
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



    function onSuccessDDL(result) {
        BuildingList.DropDown($("#ddlSearchValue"), BuildingDropDownList(result));
    }


    var DataUrl = {
        "myUrl": "https://webt.tcdsb.org/Webapi/SIC/Api/SIC/"
    }

    function getUrl() {
        return DataUrl.myUrl + "?Operate=" + BaseParaDDL.Operate + "&UserID=" + BaseParaDDL.UserID + "&UserRole=" + BaseParaDDL.UserRole + "&SchoolYear=" + BaseParaDDL.SchoolYear + "&SchoolCode=" + BaseParaDDL.SchoolCode + "&Para1=1&Para2=2&Para3=1";
    }

    function ChangeSearchValueListAPI() {
        BaseParaDDL.Operate = $("#ddlSearchby").val();
        BaseParaDDL.SchoolYear = $("#ddlSchoolYear").val();
        BaseParaDDL.SchoolCode = $("#ddlSchool").val();
        var myUrl = getUrl();
        $.get(myUrl, function (data, status) {
            // alert("Data: " + data + "\nStatus: " + status);
            var objControl = $("#ddlSearchValue");
            var myData = JSON.parse(data);
            BuildingDDList(myData, objControl);
        });
        //$.getJSON(myUrl, function (result) {
        //    $.each(result, function (i, field) {
        //        $("div").append(field + " ");
        //    });
        //});
    }

    async function BuildDDLList(ddlControl,ddlType) {
       
         var para = {         
             Operate: ddlType,
             UserID : $("#hfUserID").val(),
             Para1 :$("#hfUserRole").val(),
             Para2 : $("#ddlSchoolYear").val(),
             Para3 : $("#ddlSchool").val(),
             Para4 : ddlType,
        };
        var para = "Operate=" + para.Operate + "&UserID=" + para.UserID + "&Para1=" + para.Para1 + "&Para2=" + para.Para2 + "&Para3=" + para.Para3 + "&Para4=" + para.Para4 ;
        var myUrl = "https://webt.tcdsb.org/Webapi/SIC/api/ListItems/?" + para;
 
        try {
            const response = await fetch(myUrl);
            const data = await response.json();
            BuildingList.DropDown(ddlControl, BuildingDropDownList(data) );
        }
        catch(ex) {
            alert(ex.message);
        }
    }

</script>
