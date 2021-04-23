<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientPageApi.aspx.cs" Inherits="SIC.SICSetup.ClientPageApi" %>

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
                <td style="width: 200px; border: 0px"></td>
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
        Para3: ""
    };

    function pageLoad(sender, args) {
        $(document).ready(function () {
            $("#ddlSearchby").change(function (e) {
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
        var para = "?Operate=" + BaseParaDDL.Operate + "&UserID=" + BaseParaDDL.UserID + "&UserRole=" + BaseParaDDL.UserRole + "&SchoolYear=" + BaseParaDDL.SchoolYear + "&SchoolCode=" + BaseParaDDL.SchoolCode;
     //   var myUrl = "https://webt.tcdsb.org/Webapi/SIC/Api/Generalist/" + para;
      //  var myUrl = "https://webt.tcdsb.org/Webapi/PLF/Api/Generalist/" + para;
        var myUrl = "https://webt.tcdsb.org/Webapi/PLF/Api/PLF/" + "?schoolYear=20192020&schoolCode=0290";

        $.get(myUrl, function (data, status) {
            // alert("Data: " + data + "\nStatus: " + status);
            renderHTMLonPage(data);
        });


        //$.get(myUrl, function (data, status) {
        //    if (status == "200")
        //        BindMyList(data);
        //    else
        //        alter(status); 
        //});


    }
    function renderHTMLonPage(data) {
        var list ="";
        for (i = 0; i < data.length; i++) {
          //  var myLabel = "#Label" + data[i].ItemCode;
          //  var myArea = "#Text" + data[i].ItemCode;
            //$(myLabel).text(data[i].Title);
            //$(myArea).val(data[i].Notes);

            list += "<option value ='" + data[i].ItemCode + "'>"  + BaseParaDDL.Operate + " -- " + data[i].Title + "</option>";

        };
        $("#DropDownList1").html("");
        $("#DropDownList1").html(list);

        $("#ListBox1").html("");
        $("#ListBox1").html(list);
    }

    function AssemblingControlsbyWebApi2(publishdate, schoolyear) {
        var servername = "https://webt.tcdsb.org/";
        var api = "Webapi/SIC/Api/Generalist/";
        var parameter = "?Operate=" + BaseParaDDL.Operate + "&UserID=" + BaseParaDDL.UserID + "&UserRole=" + BaseParaDDL.UserRole + "&SchoolYear=" + BaseParaDDL.SchoolYear + "&SchoolCode=" + BaseParaDDL.SchoolCode + "&Para1=1&Para2=2&Para3=3";
        var httpLink = servername + api + parameter;
        jQuery.support.cors = true;
        $.ajax({
            url: httpLink,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                var date = JSON.parse(data);
                BindMyList(date);
            },
            error: function (ex) {
                alert(ex.error);
            }
        });
    }
    function AssemblingControlByApi() {

        var myRequest = new XMLHttpRequest();

        //  myRequest.setRequestHeader("Access-Control-Allow-Origin", "https://webt.tcdsb.org/");
        //  myRequest.setRequestHeader("Content-Type", "application/json");

        var para = "?Operate=" + BaseParaDDL.Operate + "&UserID=" + BaseParaDDL.UserID + "&UserRole=" + BaseParaDDL.UserRole + "&SchoolYear=" + BaseParaDDL.SchoolYear + "&SchoolCode=" + BaseParaDDL.SchoolCode;
        var myUrl = "https://webt.tcdsb.org/Webapi/SIC/Api/Generalist/" + para;
        var Uri = "https://webt.tcdsb.org/Webapi/SIC/Api/Generalist?Operate=Grade&UserID=mif&UserRole=admin&SchoolYear=20202021&SchoolCode=0290";


        myRequest.open('GET', myUrl);
        myRequest.onload = function () {

            if (myRequest.status >= 200 && myRequest.status < 400) {
                var myData = JSON.parse(myRequest.responseText);
                BindMyList(date);
            } else {
                window.alert("Server connected. but data access wrong");
            }
        };
        myRequest.onerror = function (ex) {
            var ms = ""
            window.alert("Ajax Call Failed. can not call from the link");
        };
        myRequest.send();
    }

</script>

