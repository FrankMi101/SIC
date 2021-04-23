var BasePara = {
    Operate: $("#hfPageID").val(),
    UserID: $("#hfUserID").val(),
    UserRole: $("#hfUserRole").val(),
    SchoolYear: "",
    SchoolCode: "",
    TabID: $("#hfSelectedTab").val(),
    ObjID: "",
    Semester: "",
    Term: "",
    Source: "InApp",
    AppID: "",
    GroupID: "",
    MemberID: "",
    MemberType: ""
};
function OpenMenu(sYear, sCode, tabID, objID, oen, sName) {
    BasePara.Semester = $("#ddlSemester").val();
    BasePara.Term = $("#ddlTerm").val();
    BasePara.SchoolYear = sYear;
    BasePara.SchoolCode = sCode;
    BasePara.TabID = $("#hfSelectedTab").val()
    BasePara.ObjID = objID;
    BasePara.AppID = oen;
    $("#LabelTeacherName").text(sName);
    CopyKeyIDToClipboard(objID + " " + sName);
    var menuList = SIC.Models.WebService.ActionMenuListService("Get", BasePara, onSuccessMenuList, onFailure);
}
function OpenMenu2(userID,userRole,sYear, sCode, appID,groupID,memberID, memberType) {
    BasePara.Semester = $("#ddlSemester").val();
    BasePara.Term = $("#ddlTerm").val();
    BasePara.SchoolYear = sYear;
    BasePara.SchoolCode = sCode;
    BasePara.TabID = $("#hfSelectedTab").val()
    BasePara.ObjID = groupID;
    BasePara.AppID = appID;
    BasePara.GroupID = groupID;
    BasePara.MemberID = memberID;
    BasePara.MemberType = memberType;
   // $("#LabelTeacherName").text(sName);
   // CopyKeyIDToClipboard(objID + " " + sName);
    var menuList = SIC.Models.WebService.ActionMenuListService("Get", BasePara, onSuccessMenuList, onFailure);
}
function onFailure() {
    alert("Get Menu Failed!");
}
var ActionMenuLevel1Length;

function onSuccessMenuList(result) {

    BuildingList.ULList($("#ActionMenuUL"), BuildingActionMenuList(result));
    var menulength = 100;// result.length * 40 / 4;
    if (menulength < 150) menulength = 150;
    var menuWidth = 215;
    if (ActionMenuLevel1Length == 1)   menuWidth = 300;
    ShowBuildingMenuList(menuWidth, menulength);
}
function BuildingActionMenuList(DataSet) {
    var img = '<img style="height: 25px; width: 30px; float:right; padding-top: -1px; " src="../images/submenu.png">'
    var list = '<ul class="Top_ul" >';
    var tabData = getTabData(DataSet);
    var cData = "";
    ActionMenuLevel1Length = tabData.length;
    if (ActionMenuLevel1Length == 1) { 
        list = '<ul class="Top_ul_W" >';
         for (x in DataSet) {
            var xItemID = "Tab_1" + '_menu_' + x.toString();
           // var category = DataSet[x].Category;
             var para = "javascript:openPage(" + DataSet[x].Ptop + "," + DataSet[x].Pleft + "," + DataSet[x].Pheight + "," + DataSet[x].Pwidth + ",'" + DataSet[x].MenuID + "','" + DataSet[x].Category + "','" + DataSet[x].Area + "','" + DataSet[x].Type + "','" + DataSet[x].AppSource + "','" + DataSet[x].AppID + "')";
          //  if (item == category)
                list += ' <li id="' + xItemID + '" class="ItemLevel1" >'
                    + '<img style="height: 18px; width: 18px; border="0" padding-top: -3px; src="../images/' + DataSet[x].Image + '"/>'
                    + '<a class="menuLink" href="' + para + '">'
                    + DataSet[x].Name + ' </a> </li>';

        };
        list += '</ul>';
    }
    else {
         tabData.forEach((item, index) => {
            var tabItemID = + "Tab_" + index.toString();
            list += '<li id="' + tabItemID + '"  class="ItemLevel0">' + img + '<a  href="#" target="">' + item + '</a>';
            list += '<ul class="ItemLevel1_ul hideMenuItem" >';
            for (x in DataSet) {
                var xItemID = tabItemID + '_menu_' + x.toString();
                var category = DataSet[x].Category;
                var para = "javascript:openPage(" + DataSet[x].Ptop + "," + DataSet[x].Pleft + "," + DataSet[x].Pheight + "," + DataSet[x].Pwidth + ",'" + DataSet[x].MenuID + "','" + DataSet[x].Category + "','" + DataSet[x].Area + "','" + DataSet[x].Type + "','" + DataSet[x].AppSource + "','" + DataSet[x].AppID + "')";
                if (item == category)
                    list += ' <li id="' + xItemID + '" class="ItemLevel1" >'
                        + '<img style="height: 18px; width: 18px; border="0"; margin-top:auto; src="../images/' + DataSet[x].Image + '"/>'
                        + '<a class="menuLink" href="' + para + '">'
                        + DataSet[x].Name + ' </a> </li>';
            };
            list += '</ul></li>';
        });
        list += '</ul>';
    }
    return list;

}
function ShowBuildingMenuList(width, length) {
    var vTop = mousey;
    if (vTop > 500) {
        vTop = vTop - 150;
    }
    var Objcontrol = $("#ActionMenuDIV");
    Objcontrol.css({
        top: vTop - 12,
        left: 58,
        width: width,
        height: length
    });
    Objcontrol.fadeToggle("fast");

}
function openPage(vTop, vLeft, vHeight, vWidth, menuID, category, area, type, source, appID) {
    if (vHeight == 999) vHeight = parent.window.innerHeight;
    if (vWidth == 9999) vWidth = parent.window.innerWidth;
    alert(" ActionMenu.js  --> H=" + vHeight + " : W= " + vWidth + " : Source =" + source + " : AppID =" + appID + " : Area =" + area + " : Category  =" + category);

    var para = "?pageID=" + menuID + "&uRole=" + BasePara.UserRole + "&sYear=" + BasePara.SchoolYear + "&sCode=" + BasePara.SchoolCode + "&grade=" + BasePara.TabID + "&sID=" + BasePara.ObjID + "&type=" + type + "&source=" + source + "&area=" + area + "&category=" + category + "&appID=" + appID + "&groupID=" + BasePara.GroupID + "&memberID=" + BasePara.MemberID;

    var goPage = "../Loading3.aspx"
    if (type == "PDF") goPage = "../Loading3Report.aspx";


    var goPage = goPage + para;

    try {
        $("#ActionMenuDIV").fadeToggle("fast");
        $("#editiFrame", parent.document).attr('src', goPage);
        $("#EditTitle", parent.document).html(menuID + " " + BasePara.ObjID);
        $("#EditDIV", parent.document).css({
            top: vTop,
            left: vLeft,
            height: vHeight - 50,
            width: vWidth - 50
        });
        //   PopUpDIV2();
        $("#PopUpDIV", parent.document).fadeToggle("fast");
        $("#EditDIV", parent.document).fadeToggle("fast");

    }

    catch (e) {
        window.alert(e.mess);
    }
}

function ChangeHeaderSchoolName() {
    var schoolcode = $("#ddlSchool").val();
    var schoolName = $("#ddlSchool option:selected").text();
    $("#LabelSchool", parent.document).text(schoolName);
    $("#LabelSchoolCode", parent.document).text(schoolcode);
    $("#LabelSchoolYear", parent.document).text($("#ddlSchoolYear").val());
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

function GO_ReportPrint(reportName) {
    if (reportName == "IEPPDF")

        var repara = {
            "PersonID": BasePara.PersonID,
            "SchoolYear": BasePara.SchoolYear,
            "SchoolCode": BasePara.SchoolCode,
            "Term": $("#ddlTerm").val()
        }
    var ddlList = SIC.Models.WebService.PrintReportService(reportName, repara, onSuccessPrintReport, onFailure);
}
function onSuccessPrintReport(result) {
    window.open(result);
}