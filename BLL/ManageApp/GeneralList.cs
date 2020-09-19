using System;
using System.Collections.Generic;

namespace BLL
{
    public class GeneralList
    {
        public static string GetSP(string action)
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
        public static List<T> CommonList<T>(string action, object parameter)
        {
            try
            {
                string sp = GetSP(action);
                var myList = new CommonOperate<T>();
                return myList.ListOfT(sp, parameter);
                //  return CommonExecute<T>.ListOfT(sp, parameter);
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
                //  return CommonExecute<T>.ValueOfT(sp, parameter);
            }
            catch (Exception ex)
            {
                string em = ex.StackTrace;
                throw;
            }

        }

        public static List<T> JsonSourceList<T>(string JsonSource, string ddlType, string action)
        { // tempraryly 
            var myList = new CommonOperate<T>();
            var parameter = new { Operate = "Json", Type = ddlType, Action = action };
            return myList.ListOfT(action, parameter);
        }

        private static string GetSPInClass(string action)
        {
            string parameter = " @Operate,@UserID,@Para1,@Para2,@Para3,@Para4";
            string parameter1 = " @Operate,@UserID,@UserRole,@SchoolYear,@SchoolCode";

            switch (action)
            {

                case "DDList":
                    return "dbo.SIC_sys_ListItems" + parameter;
                case "DDLListSchool":
                    return "dbo.SIC_sys_ListItemsSchool" + parameter;
                case "DDLListStudents":
                    return "dbo.SIC_sys_ListItemsStudents" + parameter;
                case "SchoolList":
                    return "dbo.SIC_sys_SchoolList" + parameter1 + ",@Panel,";
                case "StudentList":
                    return "dbo.SIC_sys_StudentList" + parameter1 + ",@Grade,@SearchBy,@SearchValue,@Scope,@Program,@Term,@Semester";
                case "StaffList":
                    return "dbo.SIC_sys_StaffList" + parameter1 + ",@SearchBy,@SearchValue,@Scope";
                case "Grade":
                    return "dbo.SIC_sys_GradeList" + parameter1;
                case "MenuOfStudentList":
                    return "dbo.SIC_sys_MenuOfStudentList" + parameter1 + ",@Grade,@StudentID";
                case "MenuOfClassList":
                    return "dbo.SIC_sys_MenuOfClassList" + parameter1 + ",@ClassCode";
                case "MenuOfSchoolList":
                    return "dbo.SIC_sys_MenuOfSchoolList" + parameter1 ;
                 default:

                    return "";

            }


        }

    }
}
