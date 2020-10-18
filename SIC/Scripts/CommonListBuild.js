var BuildingList =
{
    DropDown: function (ObjControl, ObjData) { BindingList(ObjControl, ObjData); },
    CheckBox: function (ObjControl, ObjData) { BindingList(ObjControl, ObjData); },
    RaidoButton: function (ObjControl, ObjData) { BindingList(ObjControl, ObjData); },
    ListBox: function (ObjControl, ObjData) { BindingList(ObjControl, ObjData); },
    ULList: function (ObjControl, ObjData) { BindingList(ObjControl, ObjData); }
};

function BindingList(ObjControl, ObjHtml) {
    ObjControl.html("");
    ObjControl.html(ObjHtml);
}

function BuildingULList(DataSet) {
    var list = "";
    for (x in DataSet) {
        var para = "javascript:openPage(" + DataSet[x].Value + "," + DataSet[x].Name + "')";
        list += ' <li><a class="menuLink" href="' + para + '">' + DataSet[x].Name + ' </a></li>';
    }
    return list;
}
function BuildingDropDownList(DataSet) {
    var list = "";
    for (x in DataSet) {
        list += "<option value ='" + DataSet[x].Value + "'>" + DataSet[x].Name + "</option>";
    }
    return list;
}

function BuildingCheckBoxList(DataSet) {
    var list = "";
    var checkBoxListlist = "";
    for (x in DataSet) {
        var checkStr = GetCheckBoxElement(x, DataSet[x].Value, DataSet[x].Name, 0);
        checkBoxListlist += checkStr;
    }
    list = '<table><tbody>' + checkBoxListlist + '</tbody></table>';
    return list;
}
function BuildingRadioButtonList(DataSet) {
    var list = "";
    var radiobuttonlist = "";
    for (x in DataSet) {
        var radiobuttonStr = GetRadioListElement(x, DataSet[x].Value, DataSet[x].Name, 0);
        radiobuttonlist += radiobuttonStr;
    }
    list = "<tbody>" + radiobuttonlist + "</tbody>";
    return list;

}
function BuildingListBoxList(DataSet) {
    var list = "";
    for (x in DataSet) {
        list += "<option value ='" + DataSet[x].Value + "'>" + DataSet[x].Name + "</option>";
    }
    return list;
}
function GetCheckBoxElement(x, value, name, checked) {
    var addEvent = "onclick ='javascript:getSelected()'";
    var controlId = "cbl_" + x;
    var controlName = "cbl$" + x;
    var checkedStr = "";
    if (checked == "1")
        checkedStr = 'checked="checked"'
    var inputStr = '<input type="checkbox" class ="qualClick" id ="' + controlId + '" name="' + controlName + '" value="' + value + '"' + checkedStr + '> ';
    var labelStr = '<label class ="qualClick"' + addEvent + ' for= "' + controlId + '" > ' + name + '</label > ';
    return '<tr><td>' + inputStr + labelStr + '</td></tr>';
}
function GetRadioListElement(x, value, name, checked) {
    var addEvent = "onclick ='javascript:getSelected()'";
    var controlId = "radio_" + x;
    var controlName = "radio$" + x;
    var checkedStr = "";
    if (checked == "1")
        checkedStr = 'checked="checked"'
    var inputStr = '<input type="radio"  id ="' + controlId + '" name="' + controlName + '" value="' + value + '"' + checkedStr + '> ';
    var labelStr = '<label class ="qualClick"' + addEvent + ' for= "' + controlId + '" > ' + name + '</label > ';
    return '<tr><td>' + inputStr + labelStr + '</td></tr>';
}