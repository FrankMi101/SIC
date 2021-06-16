<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientPage.aspx.cs" Inherits="SIC.SICSetup.ClientPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Client Web API & Web Service Call </title>

    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script>


</script>
    <style>
        .btnLable {
            border: 2px outset skyblue;
        }

        td {
            border: 1px solid red;
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
        <h2>Client Call data source from Web API and Web Services</h2>

        <div>
            <ul class="Top_ul">
                <li id="NaN0" class="ItemLevel0">
                    <img style="height: 25px; width: 30px; float: right; padding-top: -1px;" src="../images/submenu.png" /><a href="#" target="">General Info</a><ul class="ItemLevel1_ul hideMenuItem">
                        <li id="NaN0_menu_0" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/card.png" /><a class="menuLink" href="javascript:openPage(5,10,750,1000,'StudentBiography','General Info','StudentListPage','PDF','OutApp','611-969-528')">Student Biography </a></li>
                        <li id="NaN0_menu_1" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/card.png" /><a class="menuLink" href="javascript:openPage(5,10,750,1000,'StudentGuardian','General Info','StudentListPage','PDF','OutApp','611-969-528')">Student Guardian </a></li>
                        <li id="NaN0_menu_2" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/pdf.png" /><a class="menuLink" href="javascript:openPage(5,10,750,1000,'OfficeIndexCard','General Info','StudentListPage','PDF','OutApp','611-969-528')">Office Index Card </a></li>
                        <li id="NaN0_menu_3" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/pdf.png" /><a class="menuLink" href="javascript:openPage(5,10,750,1000,'WhereStudentIs','General Info','StudentListPage','PDF','OutApp','611-969-528')">Where is student  </a></li>
                        <li id="NaN0_menu_4" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/pdf.png" /><a class="menuLink" href="javascript:openPage(5,10,750,1000,'Registration','General Info','StudentListPage','PDF','OutApp','611-969-528')">Student Registration History </a></li>
                        <li id="NaN0_menu_5" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/pdf.png" /><a class="menuLink" href="javascript:openPage(5,10,750,1000,'Enrolment','General Info','StudentListPage','PDF','OutApp','611-969-528')">Student Enrolment </a></li>
                        <li id="NaN0_menu_6" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/pdf.png" /><a class="menuLink" href="javascript:openPage(5,10,750,1000,'StudentContact','General Info','StudentListPage','PDF','OutApp','611-969-528')">Student Contact Card </a></li>
                        <li id="NaN0_menu_7" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/card.png" /><a class="menuLink" href="javascript:openPage(5,10,750,1000,'SchoolSafety','General Info','StudentListPage','Site','OutApp','611-969-528')">Student School Safety </a></li>
                    </ul>
                </li>
                <li id="NaN1" class="ItemLevel0">
                    <img style="height: 25px; width: 30px; float: right; padding-top: -1px;" src="../images/submenu.png" /><a href="#" target="">Academic Info</a><ul class="ItemLevel1_ul hideMenuItem">
                        <li id="NaN1_menu_8" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/card.png" /><a class="menuLink" href="javascript:openPage(5,10,750,1000,'CourseRegister','Academic Info','StudentListPage','Site','OutApp','611-969-528')">Course Register </a></li>
                        <li id="NaN1_menu_9" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/card.png" /><a class="menuLink" href="javascript:openPage(5,10,750,1000,'CourseMarks','Academic Info','StudentListPage','Site','OutApp','611-969-528')">Course Marks </a></li>
                        <li id="NaN1_menu_10" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/pdf.png" /><a class="menuLink" href="javascript:openPage(5,10,750,1000,'StudentTimeTable','Academic Info','StudentListPage','PDF','OutApp','611-969-528')">Student Timetable </a></li>
                        <li id="NaN1_menu_11" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/card.png" /><a class="menuLink" href="javascript:openPage(5,10,750,1000,'AttendingStatus','Academic Info','StudentListPage','Site','OutApp','611-969-528')">Attending Status </a></li>
                    </ul>
                </li>
                <li id="NaN2" class="ItemLevel0">
                    <img style="height: 25px; width: 30px; float: right; padding-top: -1px;" src="../images/submenu.png" /><a href="#" target="">Report Card</a>
                    <ul class="ItemLevel1_ul hideMenuItem">
                        <li id="NaN2_menu_12" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/card.png" /><a class="menuLink" href="javascript:openPage(5,10,750,1000,'ReportCard','Report Card','StudentListPage','Site','OutApp','611-969-528')">Report Card </a></li>
                        <li id="NaN2_menu_13" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/card.png" /><a class="menuLink" href="javascript:openPage(5,10,750,1000,'AlternativeRC','Report Card','StudentListPage','Form','OutApp','611-969-528')">Alternative Report Card </a></li>
                        <li id="NaN2_menu_14" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/pdf.png" /><a class="menuLink" href="javascript:openPage(5,10,750,1000,'AlternativeRCPDF','Report Card','StudentListPage','PDF','OutApp','611-969-528')">Alternative Report Card PDF </a></li>
                        <li id="NaN2_menu_15" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/card.png" /><a class="menuLink" href="javascript:openPage(5,10,999,9999,'GiftRC','Report Card','StudentListPage','Form','OutApp','611-969-528')">Gift Report Card </a></li>
                        <li id="NaN2_menu_16" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/pdf.png" /><a class="menuLink" href="javascript:openPage(5,10,750,1000,'GiftPDF','Report Card','StudentListPage','PDF','OutApp','611-969-528')">Gift Report Card PDF </a></li>
                    </ul>
                </li>
                <li id="NaN3" class="ItemLevel0">
                    <img style="height: 25px; width: 30px; float: right; padding-top: -1px;" src="../images/submenu.png" /><a href="#" target="">Special Education</a><ul class="ItemLevel1_ul hideMenuItem">
                        <li id="NaN3_menu_17" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/form.png" /><a class="menuLink" href="javascript:openPage(5,10,999,1200,'IEPForm','Special Education','StudentListPage','Site','OutApp','611-969-528')">IEP Form </a></li>
                        <li id="NaN3_menu_18" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/pdf.png" /><a class="menuLink" href="javascript:openPage(5,10,750,1000,'IEPPDF','Special Education','StudentListPage','PDF','OutApp','611-969-528')">IEP PDF Report </a></li>
                        <li id="NaN3_menu_19" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/pdf.png" /><a class="menuLink" href="javascript:openPage(5,10,750,1000,'IEPPDF2','Special Education','StudentListPage','Form','OutApp','611-969-528')">IEP PDF Link </a></li>
                        <li id="NaN3_menu_20" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/form.png" /><a class="menuLink" href="javascript:openPage(5,10,750,1000,'IPRC','Special Education','StudentListPage','Site','OutApp','611-969-528')">IPRC Form </a></li>
                        <li id="NaN3_menu_21" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/form.png" /><a class="menuLink" href="javascript:openPage(5,10,750,1000,'SBST','Special Education','StudentListPage','Site','OutApp','611-969-528')">SBST Form </a></li>
                        <li id="NaN3_menu_22" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/form.png" /><a class="menuLink" href="javascript:openPage(5,10,750,1000,'SSForms','Special Education','StudentListPage','Site','OutApp','611-969-528')">Special Services forms </a></li>
                        <li id="NaN3_menu_23" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/form.png" /><a class="menuLink" href="javascript:openPage(5,10,700,1000,'SSN','Special Education','StudentListPage','Site','OutApp','611-969-528')">Support Staff Needs </a></li>
                        <li id="NaN3_menu_24" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/pdf.png" /><a class="menuLink" href="javascript:openPage(5,10,700,1000,'SSNPDF','Special Education','StudentListPage','PDF','OutApp','611-969-528')">Support Staff Need PDF </a></li>
                    </ul>
                </li>
                <li id="NaN4" class="ItemLevel0">
                    <img style="height: 25px; width: 30px; float: right; padding-top: -1px;" src="../images/submenu.png" /><a href="#" target="">Learning Path</a>
                    <ul class="ItemLevel1_ul hideMenuItem">
                        <li id="NaN4_menu_25" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/pdf.png" /><a class="menuLink" href="javascript:openPage(5,10,700,1000,'Registration','Learning Path','StudentListPage','PDF','InApp','611-969-528')">School Attending Histroy </a></li>
                        <li id="NaN4_menu_26" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/pdf.png" /><a class="menuLink" href="javascript:openPage(5,10,700,1000,'AcademicAchievement','Learning Path','StudentListPage','PDF','InApp','611-969-528')">Academic Achievement </a></li>
                        <li id="NaN4_menu_27" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/pdf.png" /><a class="menuLink" href="javascript:openPage(5,10,700,1000,'SpecialEdHistroy','Learning Path','StudentListPage','PDF','InApp','611-969-528')">Special Ed. Histroy </a></li>
                        <li id="NaN4_menu_28" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/pdf.png" /><a class="menuLink" href="javascript:openPage(5,10,700,1000,'ClassMark','Learning Path','StudentListPage','PDF','InApp','611-969-528')">Class Taken </a></li>
                    </ul>
                </li>
                <li id="NaN5" class="ItemLevel0">
                    <img style="height: 25px; width: 30px; float: right; padding-top: -1px;" src="../images/submenu.png" /><a href="#" target="">Enrolment Records</a>
                    <ul class="ItemLevel1_ul hideMenuItem">
                        <li id="NaN5_menu_29" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/card.png" /><a class="menuLink" href="javascript:openPage(5,10,750,1400,'Enrolment','Enrolment Records','StudentListPage','Page','InApp','611-969-528')">View Student Enrolment Record </a></li>
                        <li id="NaN5_menu_30" class="ItemLevel1">
                            <img style="height: 18px; width: 18px; border: 0px; margin-top: auto;" src="../images/form.png" /><a class="menuLink" href="javascript:openPage(5,10,750,1400,'EnrolmentOperation','Enrolment Records','StudentListPage','Page','InApp','611-969-528')">Enrolment Record Adjustment </a></li>
                    </ul>
                </li>
            </ul>

        </div>

        <table style="width: 60%">
            <tr>
                <td style="width: 200px; border: 0px">List Box Content type:</td>
                <td style="width: 300px; border: 0px">
                    <asp:DropDownList ID="ddlSearchby" runat="server" Width="100%">
                        <asp:ListItem Value="UserRole" Selected="True"> User Role</asp:ListItem>
                        <asp:ListItem Value="Age">Age</asp:ListItem>
                        <asp:ListItem Value="Grade">Grade</asp:ListItem>
                        <asp:ListItem Value="Program">Program</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 200px; border: 0px">
                    <asp:Label ID="GetDateFromWebAPI" runat="server" Text="Get Data from Web API" CssClass="btnLable"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>DropDown List</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="100%">
                        <asp:ListItem Value="1" Selected="true">List Item 1</asp:ListItem>
                        <asp:ListItem Value="2">List Item 2</asp:ListItem>
                        <asp:ListItem Value="3">List Item 3</asp:ListItem>
                        <asp:ListItem Value="4">List Item 4</asp:ListItem>
                        <asp:ListItem Value="5">List Item 5</asp:ListItem>

                    </asp:DropDownList></td>
                <td>
                    <input id="selectedValueDDL" type="text" value="" style="width: 150px" />
                </td>
            </tr>
            <tr>
                <td>CheckBox List:</td>
                <td>
                    <div id="CheckBoxListDIV" runat="server" style="overflow: auto; width: 100%; height: 100px">

                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" Width="100%">
                            <asp:ListItem Value="1" Selected="true">List Item 1</asp:ListItem>
                            <asp:ListItem Value="2">List Item 2</asp:ListItem>
                            <asp:ListItem Value="3">List Item 3</asp:ListItem>
                            <asp:ListItem Value="4">List Item 4</asp:ListItem>
                            <asp:ListItem Value="5">List Item 5</asp:ListItem>


                        </asp:CheckBoxList>
                    </div>
                </td>
                <td>
                    <input id="selectedValueChb" type="text" value="" style="width: 150px" />
                </td>
            </tr>
            <tr>
                <td>RadioButtion List:</td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="100%">
                        <asp:ListItem Value="100" Selected="true">100%</asp:ListItem>
                        <asp:ListItem Value="67">67%</asp:ListItem>
                        <asp:ListItem Value="50">50%</asp:ListItem>
                        <asp:ListItem Value="33">33%</asp:ListItem>
                        <asp:ListItem Value="25">25%</asp:ListItem>
                        <asp:ListItem Value="00">XX%</asp:ListItem>

                    </asp:RadioButtonList></td>
                <td>
                    <input id="selectedValuerbl" type="text" value="" style="width: 150px" />
                </td>
            </tr>
            <tr>
                <td>List Box</td>
                <td>
                    <asp:ListBox ID="ListBox1" runat="server" Width="100%">
                        <asp:ListItem Value="1" Selected="true">List Item 1</asp:ListItem>
                        <asp:ListItem Value="2">List Item 2</asp:ListItem>
                        <asp:ListItem Value="3">List Item 3</asp:ListItem>
                        <asp:ListItem Value="4">List Item 4</asp:ListItem>
                        <asp:ListItem Value="5">List Item 5</asp:ListItem>

                    </asp:ListBox></td>
                <td>
                    <input id="selectedValuelbox" type="text" value="" style="width: 150px" />
                </td>
            </tr>
            <tr>
                <td>UL LI List</td>
                <td>
                    <div id="ActionMenuDIV">
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
                </td>
                <td>
                    <input id="selectedValuemenu" type="text" value="" style="width: 150px" />
                </td>
            </tr>
        </table>


        <div>
            <asp:HiddenField ID="hfCategory" runat="server" />
            <asp:HiddenField ID="hfPageID" runat="server" />
            <asp:HiddenField ID="hfCode" runat="server" />
            <asp:HiddenField ID="hfUserID" runat="server" Value="mid" />
            <asp:HiddenField ID="hfUserRole" runat="server" Value="Admin" />
            <asp:HiddenField ID="hfUserLoginRole" runat="server" />
            <asp:HiddenField ID="hfRunningModel" runat="server" />
        </div>
    </form>
</body>
</html>

<script src="../Scripts/CommonListBuild.js"></script>

<script type="text/javascript">

    var BaseParaDDL = {
        Operate: "Get",
        UserID: $("#hfUserID").val(),
        UserRole: $("#hfUserRole").val(),
        SchoolYear: "20202021",
        SchoolCode: "0290",
        Para1: "",
        Para2: "",
        Para3: "",
    };

    function pageLoad(sender, args) {
        $(document).ready(function () {
            $("#ddlSearchby").change(function (e) {
                AssemblingControlsbyWS();
            });
            $("#GetDateFromWebAPI").click(function (e) {
                AssemblingControlsbyWebApi();
            });
        });
    }
    function AssemblingControlsbyWS() {
        BaseParaDDL.Operate = $("#ddlSearchby").val();
        // var ddlList = SIC.Models.WebService.CommonLists(BaseParaDDL.Operate, BaseParaDDL, onSuccessControl, onFailure);
        var ddlList = SIC.Models.WebService.GCommonList(BaseParaDDL, onSuccessControl, onFailure);

    }
    function onFailure(result) {
        alert("Web Service Call Failed!");
    }
    function onSuccessControl(result) {

        BindMyList(result);

    }
    function BindMyList(result) {
        BuildingList.DropDown($("#DropDownList1"), BuildingDropDownList(result));

        BuildingList.CheckBox($("#CheckBoxListDIV"), BuildingCheckBoxList(result));

        BuildingList.RaidoButton($("#RadioButtonList1"), BuildingRadioButtonList(result));

        BuildingList.ListBox($("#ListBox1"), BuildingListBoxList(result));

        BuildingList.ULList($("#ActionMenuUL"), BuildingULList(result));
    }

    function AssemblingControlsbyWebApi() {
        BaseParaDDL.Operate = $("#ddlSearchby").val();
        var myUrl = "https://webt.tcdsb.org/Webapi/SIC/Api/SIC/" + "?Operate=" + BaseParaDDL.Operate + "&UserID=" + BaseParaDDL.UserID + "&UserRole=" + BaseParaDDL.UserRole + "&SchoolYear=" + BaseParaDDL.SchoolYear + "&SchoolCode=" + BaseParaDDL.SchoolCode + "&Para1=1&Para2=2&Para3=3";

        $.get(myUrl, function (data, status) {
            BindMyList(data);
        });

    }

    function GetDeadLineDateFromWebAPI(publishdate, schoolyear) {

        var servername = "http://webservice.tcdsb.org";
        var api = "/LTOapi/api/PositionApplyDeadLineDate";
        var parameter = "?userid=mif&schoolyear=" + schoolyear + "&publishdate=" + publishdate;
        var httpLink = servername + api + parameter;
        jQuery.support.cors = true;
        $.ajax({
            url: httpLink,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                var deadlinedate = data[0].ApplyDate;
                $("#dateDeadline").val(deadlinedate);
            },
            error: function (ex) {
                //   alert(ex.error);
            }
        });
    }


</script>

