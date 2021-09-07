<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoadingParameters.aspx.cs" Inherits="SIC.LoadingParameters" %>


<!DOCTYPE  ">
<html>

<head runat="server">
    <title>Loading Parameteres Page</title>
    <meta http-equiv="Pragma" content="No-cache" />
    <meta http-equiv="Cache-Control" content="no-Store,no-Cache" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <link href="../Content/BubbleHelp.css" rel="stylesheet" />
    <link href="../Content/ContentPage.css" rel="stylesheet" />
    <link href="../Content/TabMenu.css" rel="stylesheet" />
    <link href="../Content/ActionMenu.css" rel="stylesheet" />
    <link href="../Content/SearchArea.css" rel="stylesheet" />

    <style>
        .twoColumn-container {
            margin-top: 5px;
            display: grid;
            grid-template-columns: 25% auto;
            margin: auto;
            text-align: left;
            width: 100%
        }
        .labelItem {
            width:150px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="twoColumn-container">
            <table>
                <tr><td><label class="labelItem" id="lableSchoolYear" for="ddlSchoolYear">School Year: </label></td><td><asp:DropDownList ID="ddlSchoolYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLSchoolYear_SelectedIndexChanged"></asp:DropDownList></td></tr>
                 <tr><td> <label id="lableSchoolCode" for="ddlSchools">School: </label></td><td><asp:DropDownList ID="ddlSchoolCode" runat="server"   AutoPostBack="true" OnSelectedIndexChanged="DDLSchoolCode_SelectedIndexChanged"></asp:DropDownList>

                <asp:DropDownList ID="ddlSchools" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLSchools_SelectedIndexChanged"  ></asp:DropDownList></td></tr>
                 <tr><td> <label  class="labelItem" id="lableGrade" for="ddlGrades">Grade:</label></td><td><asp:DropDownList ID="ddlGrades" runat="server"></asp:DropDownList></td></tr>
                 <tr><td><label class="labelItem" id="lableReportPeriod" for="ddlReportPeriod">Report Period:</label></td><td> <asp:DropDownList ID="ddlReportPeriod" runat="server"></asp:DropDownList></td></tr>
                 <tr><td> <label class="labelItem" id="lableCourse" for="ddlCourse">Classes:</label></td><td> 
                <asp:DropDownList ID="ddlCourse" runat="server"></asp:DropDownList></td></tr>
                <tr><td>   <label  class="labelItem" id="lableVirtual" for="ddlCourse">Virtual School:</label></td><td>  <asp:CheckBox ID="chkVirtual" runat="server" Checked="true" /></td></tr>
                <tr><td  >&nbsp;</td><td ></td></tr>
                <tr><td></td><td><asp:Button ID="ButtonSubmit" runat="server" Text="Build or Download Report" /></td></tr>
            </table>
       
        </div>
        <br />
        


        <asp:HiddenField ID="hfPageID" runat="server" />
        <asp:HiddenField ID="hfAppID" runat="server" />
        <asp:HiddenField ID="hfUserID" runat="server" />
        <asp:HiddenField ID="hfUserRole" runat="server" />
        <asp:HiddenField ID="hfObjName" runat="server" />
        <asp:HiddenField ID="hfObjType" runat="server" />
        <asp:HiddenField ID="hfObjPageH" runat="server" />
        <asp:HiddenField ID="hfObjPageW" runat="server" />
    </form>
</body>
</html>

<script src="../Scripts/MoursPoint.js"></script>

<script type="text/javascript">



    function pageLoad(sender, args) {

        $(document).ready(function () {


            $("#closeMe").click(function (event) {

                $("#PopUpDIV").hide();
                $("#EditDIV").hide();
            });

            $("#ButtonSubmit").click(function (en) {

                   alert("Action");
                var BasePara = {
                    UserID: $("#hfUserID").val(),
                    UserRole: $("#hfUserRole").val(),
                    SchoolYear: $("#ddlSchoolYear").val(),
                    SchoolCode: $("#ddlSchools").val(),
                    Grade: $("#ddlGrade").val(),
                    ReportPeriod: $("#ddlReportPeriod").val(),
                    CourseCode: $("#ddlCoursCode").val(),
                    Virtual: $("#chkVirtual").checked == true ? "Yes" : "No", // $("#chkVirtual").prop("checked").val(), 
                    ObjName: $("#hfObjName").val(),
                    ObjType: $("#hfObjType").val(),
                    ObjPageH: $("#hfObjPageH").val(),
                    ObjPageW: $("#hfObjPageW").val()
                };
                var page = "OutSidePage.aspx";
                var para = "?uRole=" + BasePara.UserRole + "&sYear=" + BasePara.SchoolYear + "&sCode=" + BasePara.SchoolCode + "&grade=" + BasePara.Grade + "&rPeriod=" + BasePara.ReportPeriod + "&cCode=" + BasePara.CourseCode;
                para += "&cVirtual=" + BasePara.Virtual + "&oName=" + BasePara.ObjName + "&oType=" + BasePara.ObjType;

                OpenOutPage('Build Page by Parameters', page, para, BasePara.ObjPageH, BasePara.ObjPageW);
            })


        });
    }

    function OpenOutPage(title, page, para, vHeight, vWidth) {


        var goPage = page + para;


        // ChildWindow = window.showModalDialog('../CommonPage/BaseHelp.aspx?cID=' + cID + '&iID=' + iID, window, "scroll:no;resizable:no;help:no;status:no;dialogTop:50;dialogLeft:50;dialogHeight:550px;dialogWidth:650px");
        ChildWindow = window.open(goPage, "ObjPage", " width=" + vWidth + ",height=" + vHeight + ",top=10, left=10, toolbars=no, scrollbars=no,status=no,resizable=yes");

    }

        catch(e) {
        window.alert("Error:" + e.mess);
    }

    }
</script>
