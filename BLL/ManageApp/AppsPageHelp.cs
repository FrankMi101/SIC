using ClassLibrary;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class AppsPageHelp : CommonSP
    {
        public override string GetSPandParametersByOverride(string action)
        {
            return GetSPNameAndParameters(action);
        }
        public static string GetSP(string action)
        {
            return GetSPNameAndParameters(action);
        }
        public static List<T> CommonList<T>(string action, object parameter)
        {
            try
            {
                string sp = GetSP(action);
                var myList = new CommonOperate<T>();
                return myList.ListOfT(sp, parameter);
            }
            catch (Exception ex)
            {
                string em = ex.StackTrace;
                throw;
            }
        }
        public static T CommonValue<T>(string action, object parameter)
        {
            try
            {
                string sp = GetSP(action);
                var myValue = new CommonOperate<T>();
                return myValue.ValueOfT(sp, parameter);
            }
            catch (Exception ex)
            {
                string em = ex.StackTrace;
                throw;
            }
        }
        public static string PageHelp(string action, HelpMessage parameter)
        {
            parameter.Operate = action;
            return CommonValue<string>(action, parameter);
        }

        private static string GetSPNameAndParameters(string action)
        {
            switch (SPSource.SPFile)
            {
                case "JsonFile":
                    return GetSPFrom.JsonFile(action);
                case "DBTable":
                    return GetSPFrom.DbTable(action, "AppraisalGeneral");
                default:
                    return GetSPInClass(action);
            }
        }
        private static string GetSPInClass(string action)
        {

            string parameter0 = " @Operate,@UserID,@UserRole,@SchoolYear,@SchoolCode";
            string parameters = parameter0 + ",@Grade,@StudentID,@PageID";

            switch (action)
            {
              
                case "GoPage":
                    return "dbo.SIC_sys_ActionMenu_GoPage" + parameters;
                case "GoPageGroup":
                    return "dbo.SIC_sys_ActionMenu_GoPage" + parameters + ",@Term,@Category,@AppID";
                case "GoPageItems":
                    return "dbo.SIC_sys_ActionMenu_GoPage" + parameters + ",@Term,@Category,@AppID,@GroupID,@MemberID";
                case "MultipleReport":
                    return "dbo.SIC_sys_ActionMenu_GoPage" + parameters + ",@Term";
                case "HelpContent":
                    return "dbo.SIC_sys_HelpTitleContentSP";
                case "ActionMenuList":
                    return "dbo.SIC_sys_ActionMenuList" + parameter0 + ",@TabID,@ObjID,@AppID,@Semester,@Term";

                default:
                    return action;

            }
        }

    }
}
