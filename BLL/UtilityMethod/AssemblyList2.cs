﻿using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace BLL
{
  
    public static class AssemblingList2
    {
        readonly static string _db = DBConnection.OtherDB("SISDB");
        public static void SetLists(System.Web.UI.WebControls.ListControl myListControl, List<NameValueList> myListData)
        {           
                AssemblingMyList(myListControl, myListData, "Value", "Name");
        }
        public static void SetLists(System.Web.UI.WebControls.ListControl myListControl, List<NameValueList> myListData, object initialValue)
        {

            SetLists(myListControl, myListData);
            SetValue(myListControl, initialValue);
        }
        public static void SetLists(string JsonSource, System.Web.UI.WebControls.ListControl myListControl, string ddlType, CommonListParameter parameter)
        {
            List<NameValueList> myListData = ListDataSource(JsonSource, ddlType, parameter,"DDList");
            SetLists(myListControl, myListData);
        }
        public static void SetLists(string JsonSource, System.Web.UI.WebControls.ListControl myListControl, string ddlType, CommonListParameter parameter, object initialValue)
        {
            SetLists(JsonSource, myListControl, ddlType, parameter);
            SetValue(myListControl, initialValue);
        }
   
        public static void SetValue(System.Web.UI.WebControls.ListControl myListControl, object objectValue)
        {
            AssemblingList.SetValue(myListControl, objectValue);
        }
        public static void SetValueMultiple(System.Web.UI.WebControls.ListControl myListControl, string value)
        {
            AssemblingList.SetValueMultiple(myListControl, value);
        }

        private static void AssemblingMyList(System.Web.UI.WebControls.ListControl myListControl, object myList, string ValueField, string TextField)
        {
            try
            {
                // List<List2Item> myList = myList;
                myListControl.Items.Clear();
                myListControl.DataSource = myList;
                myListControl.DataTextField = TextField;
                myListControl.DataValueField = ValueField;
                myListControl.DataBind();
                myListControl.SelectedIndex = 0;

                if (myListControl.Items.Count > 1)
                    myListControl.Enabled = true;
                else
                    myListControl.Enabled = false;

            }
            catch (Exception ex)
            { var em = ex.Message; }
            finally
            { }
        }

        public static void SetListSchool(System.Web.UI.WebControls.ListControl myListControl1, System.Web.UI.WebControls.ListControl myListControl2, string ddlType, CommonListParameter parameter, object initialValue)
        {
            SetListSchool(myListControl1, myListControl2, ddlType, parameter);
            SetValue(myListControl1, initialValue);
            SetValue(myListControl2, initialValue);
        }
        public static void SetListSchool(System.Web.UI.WebControls.ListControl myListControl1, System.Web.UI.WebControls.ListControl myListControl2, string ddlType, CommonListParameter parameter)
        {
          //  string SP = SPandParameters.GetSPNameAndParameters("General", "Schools");

            List<NameValueList> myListData = ListDataSource("", ddlType, parameter, "DDLListSchool");  // CommonExcute<CommonList>.ListOfT(SP, parameter);
            AssemblingSchoolList(myListControl1, myListControl2, myListData);

        }
        private static void AssemblingSchoolList(System.Web.UI.WebControls.ListControl myListControl1, System.Web.UI.WebControls.ListControl myListControl2, List<NameValueList> myList)
        {
            try
            {
                var byList = myList.OrderBy(o => o.Value); 
                //var sList = from c in myList
                //             orderby c.Code
                //             select c;
                AssemblingMyList(myListControl2, myList, "Value", "Name"); // School Name DDL
                AssemblingMyList(myListControl1, byList, "Value", "Value"); // school Code DDL
                myListControl2.SelectedIndex = 0;
                SetValue(myListControl1, myListControl2.SelectedValue);
            }
            catch (Exception ex)
            { var em = ex.Message; }
            finally
            { }
        }

        private static List<NameValueList> ListDataSource(string JsonSource, string ddlType, CommonListParameter parameter, string action)
        {
            List<NameValueList> myListData;
            if (JsonSource == "")
            {
                parameter.Operate = ddlType;
                //  string SP = SPandParameters.GetSPNameAndParameters("General", "DDList");
                //   myListData = CommonListExecute<NVListItem>.GeneralList(SP, parameter);
                myListData = GeneralList.CommonList<NameValueList>(_db, action, parameter); //  CommonExcute<CommonList>.ListOfT(SP, parameter);
            }
            else
            {
                myListData = GeneralList.JsonSourceList<NameValueList>(JsonSource, ddlType, action);
            } 
            return myListData;

        }

    }
}
