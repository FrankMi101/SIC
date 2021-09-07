using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using System.Web.UI.WebControls;

namespace BLL.Tests
{
    [TestClass()]
    public class GeneralListTests
    {
        private string _sp = "dbo.SIC_sys_ListItems";
        private string _action = "DDList";
        private StoreProcedureNameAndParameters _spClass = new StoreProcedureNameAndParameters();

        private DropDownList _listControl = new DropDownList();
        private List<NameValueList> _nameValueslist = new List<NameValueList>();

        [TestInitialize]
        public void Setup()
        {
           
        }


        [TestMethod()]
        [DataRow("AppsName")]
        [DataRow("Course")]
        [DataRow("Grade")]
        [DataRow("ListSchool")]
        [DataRow("SchoolYear")]
        [DataRow("UserRole")]
        [DataRow("SchoolArea")]
        public void CommonList_byGenericCommonSPClaas_ReturnGenericListbyCategory_Test(string category)
        {
            //Arrange
            var parameter = new CommonListParameter()
            {
                Operate = category,
                UserID ="mif",
                Para1 = "Admin",
                Para2 = "20202021",
                Para3 ="0501",
                Para4 =""
            };
            var objSPclass = new List<CommonSP> { new GeneralList() };
            string sp = BLL.Common.SPName(objSPclass, _action, parameter);

            // Act  
            var result = GeneralList.CommonList<NameValueList>(sp, parameter);
 ;
            //Assert
            Assert.IsNotNull(result, $"List Items return Count is  {result.Count} ");
         }

        [TestMethod()]
        public void CommonList_byGenericCommonSPClaas_ReturnStudentListbyAction_Test()
        {   //Arrange 
            var parameter = new
            {
                Operate = "StudentList",
                UserID = "mif",
                UserRole = "Admin",
                SchoolYear = "20202021",
                SchoolCode = "0501",
                Grade = "10",
                SearchBy = "", 
                Searchvalue ="",  
                Scope = "School",
                Program = "",
                Term = "0",
                Semester ="0"
            };
            var mySPclass = new List<CommonSP> { new GeneralList() };
            _action = "StudentListPage";
 
            // Act  
            string sp = BLL.Common.SPName(mySPclass, _action, parameter);
            var result = GeneralList.CommonList<StudentList>(sp, parameter);
 
            //Assert
            Assert.IsNotNull(result, $"Get Student List by Generic class  {result.Count} ");

        }
        [TestMethod()]
        public void CommonList_byGenericCommonSPClaasNoParameterProvide_ReturnStudentListbyAction_Test()
        {   //Arrange 
            var parameter = new
            {
                Operate = "StudentList",
                UserID = "mif",
                UserRole = "Admin",
                SchoolYear = "20202021",
                SchoolCode = "0501",
                Grade = "10",
                SearchBy = "",
                Searchvalue = "",
                Scope = "School"
            };
  
            // Act  
            string sp =  "dbo.SIC_sys_ListofStudents";
             sp = _spClass.SPNameAndPara("GeneralList", sp, parameter);
            var result = GeneralList.CommonList<StudentList>(sp, parameter);

            //Assert
            Assert.IsNotNull(result, $"Get Student List by Generic class  {result.Count} ");
        }
        [TestMethod()]
        public void CommonList_GenericCommonListbyGivenSP_ReturnSignalStudentbyStudentNo_Test()
        {   //Arrange 
            var parameter = new
            {
                Operate = "StudentList",
                UserID = "mif",
                UserRole = "Admin",
                SchoolYear = "20202021",
                SchoolCode = "0501",
                Grade = "99",
                SearchBy = "StudentNo",
                SearchValue = "344-808-845",
            };
            string expect = parameter.SearchValue;
            // Act  
            string sp = "dbo.SIC_sys_ListofStudents";
            sp = _spClass.SPNameAndPara("GeneralList", sp, parameter);
            var result = GeneralList.CommonList<StudentList>(sp, parameter);

            //Assert
            Assert.AreEqual(1, result.Count, $"Get Student search result by Student No {result[0].StudentName} ");
            Assert.AreEqual(expect, result[0].StudentNo, $"Get Student search result by Student No {result[0].StudentName} ");
        }

        [TestMethod()]
        public void CommonList_GenericCommonListSearchbyLastName_ReturnStudentListMatchSearchCondition_Test()
        {   //Arrange 
            var parameter = new
            {
                Operate = "StudentList",
                UserID = "mif",
                UserRole = "Admin",
                SchoolYear = "20202021",
                SchoolCode = "0501",
                Grade = "99",
                SearchBy = "LastName",
                SearchValue = "Pa",
            };
            string expect = parameter.SearchValue;
            // Act  
            string sp = "dbo.SIC_sys_ListofStudents";
            sp = _spClass.SPNameAndPara("GeneralList", sp, parameter);
            var result = GeneralList.CommonList<StudentList>(sp, parameter);

            //Assert
            Assert.AreEqual(expect, result[0].StudentName.Substring(0,2), $"Get Student List search result by LastNameo {result[0].StudentName} ");
        }
    }
}