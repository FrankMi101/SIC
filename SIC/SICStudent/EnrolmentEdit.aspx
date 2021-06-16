<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnrolmentEdit.aspx.cs" Inherits="SIC.SICStudent.EnrolmentEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/JqueryUI/jquery-ui.min.js"></script>
    <link href="../Content/BubbleHelp.css" rel="stylesheet" />
    <link href="../Content/ContentPage.css" rel="stylesheet" />
    <link href="../Content/ContentForms.css" rel="stylesheet" />
    <style>
        table {
            height: 100%;
            width: 100%;
        }

            table tbody tr:nth-child(odd) {
                background-color: aliceblue;
            }

        .saveButton {
            width: 120px;
            margin-right: 15px;
            margin-left: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <table class="Edit-Content">
            <tr>
                <td>Enrolment Type: </td>
                <td>
                    <asp:DropDownList ID="ddlEnrolmentType" runat="server" CssClass="Edit-Content"></asp:DropDownList>
                </td><td class="textRight">School Year:</td><td><asp:DropDownList ID="ddlSchoolYear" runat="server" CssClass="Edit-Content"></asp:DropDownList></td>
               
            </tr>
            <tr>
              <td>Active Flag</td><td>
                  <asp:CheckBox ID="CheckBoxActiveFlag" runat="server" Checked="false" />
                                  </td> <td class="textRight">Effective Date:  </td>
                <td>
                    <input runat="server" type="text" id="dateStart" size="9" /></td>
            </tr>
            <tr>
                <td>School BSID:</td>
                <td colspan="3">
                     <asp:DropDownList ID="ddlSchoolCode" runat="server" Width="80px" CssClass="Edit-Content"></asp:DropDownList>
                     <asp:DropDownList ID="ddlSchools" runat="server" Width="300px" CssClass="Edit-Content"></asp:DropDownList>
                    <asp:DropDownList ID="ddlSchoolBSID" Width="100px" runat="server" CssClass="Edit-Content"></asp:DropDownList>


                </td>
            </tr>
            <tr>
                <td>School Year Track:</td>
                <td>
                    <asp:DropDownList ID="ddlSchoolYearTrack" runat="server" CssClass="Edit-Content"></asp:DropDownList></td>

                <td class="textRight">Register Code: </td>
                <td>
                    <asp:DropDownList ID="ddlRegisterCode" runat="server" CssClass="Edit-Content"></asp:DropDownList></td>
            </tr>

            <tr>
                <td>EntryTypeName: </td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlEntryTypeName" runat="server" CssClass="Edit-Content"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>Remark: </td>
                <td colspan="3">
                    <asp:TextBox ID="TextBoxRemark" runat="server" Height="50px" TextMode="MultiLine" CssClass="Edit-Content"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Language:</td>
                <td>
                    <asp:TextBox ID="TextBoxLanguage" runat="server" CssClass="Edit-Content"></asp:TextBox>
                </td>

                <td class="textRight">Grade: </td>
                <td>
                    <asp:DropDownList ID="ddlGrade" runat="server" CssClass="Edit-Content"></asp:DropDownList></td>
            </tr>
            
            <tr>
                <td style="width: 20%">&nbsp;</td>
                <td style="width: 30%"></td>
                <td style="width: 20%"></td>
                <td style="width: 30%"></td>
            </tr>
            <tr>
                <td>Funding Source Type:</td>
                <td>
                    <asp:DropDownList ID="ddlFundingSourceType" runat="server" CssClass="Edit-Content"></asp:DropDownList>
                </td>
                <td class="textRight">Funding Resident :</td>
                <td>
                    <asp:CheckBox ID="CheckBoxFundingResident" runat="server" Checked="false" CssClass="Edit-Content" />
                </td>
            </tr>
            <tr>
                <td>Funding Payer Type : </td>
                <td colspan="3">
                    <asp:TextBox ID="TextBoxPayerType" runat="server" CssClass="Edit-Content"></asp:TextBox>
                </td>
            </tr>


            <tr>
                <td style="width: 20%">&nbsp;</td>
                <td style="width: 30%"></td>
                <td style="width: 20%"></td>
                <td style="width: 30%"></td>
            </tr>
            <tr>
                <td>Demit Reason Name: </td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlDemitReason" runat="server" CssClass="Edit-Content"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Demit Next School: </td>
                <td>
                    <asp:TextBox ID="TextBoxDemitNextSchool" runat="server" CssClass="Edit-Content"></asp:TextBox></td>

                <td class="textRight">Demit Next BSID:   </td>
                <td>
                    <asp:TextBox ID="TextBoxDemitNextBSID" runat="server" CssClass="Edit-Content"></asp:TextBox></td>
            </tr>
              <tr id="RowDemitBSID" runat= "server">
                <td>Demit Next School: </td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlDemitSchoolCode" runat="server" Width="80px" CssClass="Edit-Content"></asp:DropDownList>  
                    <asp:DropDownList ID="ddlDemitSchool" runat="server" Width="300px" CssClass="Edit-Content"></asp:DropDownList> 
                    <asp:DropDownList ID="ddlDemitSchoolBSID" runat="server" Width="100px" CssClass="Edit-Content"></asp:DropDownList> </td>

                
            </tr>
            <tr>
                <td colspan="4">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center;">
                    <asp:Button ID="ButtonAdd" runat="server" Text="Add New Record" CssClass="action-button saveButton" OnClick="ButtonAdd_Click" />
                    <asp:Button ID="ButtonDelete" runat="server" Text="Delete Record" CssClass="action-button saveButton" OnClick="ButtonDelete_Click" />
                    <asp:Button ID="ButtonUpdate" runat="server" Text="Update Record" CssClass="action-button saveButton" OnClick="ButtonUpdate_Click" />
                    <asp:Button ID="ButtonDemit" runat="server" Text="Demit Record" CssClass="action-button saveButton" OnClick="ButtonDemit_Click" />
                </td>
            </tr>
        </table>

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
            <asp:HiddenField ID="hfSchoolyearStartDate" runat="server" />
            <asp:HiddenField ID="hfSchoolyearEndDate" runat="server" />

        </div>
    </form>
</body>
</html>

<script src="../Scripts/MoursPoint.js"></script>
<script src="../Scripts/CommonDOM.js"></script>
<script src="../Scripts/Appr_Help.js"></script>
<script src="../Scripts/Appr_textEdit.js"></script>

<script type="text/javascript">

    var UserID = $("#hfUserID").val();
    var UserRole = $("#hfUserRole").val();
    var ItemCode = $("#hfCode").val();
    var minD = new Date($("#hfSchoolyearStartDate").val()); // today.getDate() - 90; //
    var maxD = new Date($("#hfSchoolyearEndDate").val());
    var preaLinkID;
    var Action;
    function pageLoad(sender, args) {

        $(document).ready(function () {

            InitialDatePickerControl();


            $("#btnSubmit").click(function (e) {
                SaveDataToDatabase("Add");
            });


        });
    }

    function SaveDataToDatabase(action) {
        try {
            Action = action;
            var para = {
                Operate: action,
                UserID: $("#hfUserID").val(),
                UserRole: $("#hfUserRole").val(),
                SchoolYear: $("#ddlSchoolYear").val(),
                SchoolCode: $("#ddlSchoolCode").val(),
                AppID: $("#ddlApps").val(),
                GroupID: $("#ddlGroupID").val(),
                MemberID: $("#TextBoxCPNum").val(),
                StartDate: $("#dateStart").val(),
                EndDate: $("#dateEnd").val(),
                Comments: $("#TextComments").val(),
                Permission: $("input:radio[name='rblPermission']:checked").val()
            };

            var result = SIC.Models.WebService.SaveSecurityGroupMember("Teachers", action, para, onSuccess, onFailure);
        }
        catch (e) {
            alert(action + " button click something going wrong");
        }
    }
    function onSuccess(result) {
        alert(Action + " save was " + result);
        location.reload();
    }
    function onFailure() {
        alert(Action + " operation failed");
    }

    function RemoveUserFromGroup(userID, userRole, schoolYear, schoolCode, appID, groupID, memberID) {
        try {
            Action = "Remove the User from Group";
            var result = confirm("Going to delete" + memberID + " ?");
            if (result) {
                var para = {
                    Operate: "Delete",
                    UserID: userID,
                    UserRole: userRole,
                    SchoolYear: schoolYear,
                    SchoolCode: schoolCode,
                    AppID: appID,
                    GroupID: groupID,
                    MemberID: memberID
                };
                var result = SIC.Models.WebService.SaveSecurityGroupMember("Teachers", "Delete", para, onSuccess, onFailure);
            }


        }
        catch (e) {
            alert(action + " button click something going wrong");
        }
    }
    function InitialDatePickerControl() {
        // var value = new Date().toDateString;
        // alert(minD);
        JDatePicker.Initial($("#dateStart"), minD, maxD, minD);
    }

</script>
