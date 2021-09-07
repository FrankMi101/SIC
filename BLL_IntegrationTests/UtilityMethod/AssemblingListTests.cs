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
    public class AssemblingListTests
    {
        private CommonListParameter _clParameter = new CommonListParameter();
        private DropDownList _listControl = new DropDownList();
        private DropDownList _listControl2 = new DropDownList();
        private string _jsonStr = "";

        [TestInitialize]
        public void Setup()
        {
            // Runs before each test. (Optional)
            _clParameter.Operate = "";
            _clParameter.UserID = "mif";
            _clParameter.Para1 = "Admin";
            _clParameter.Para2 = "20192020";
            _clParameter.Para3 = "0501";
        }

        [TestMethod()]
        [DataRow("UserRole", "Admin")]
        public void SetLists_InitialValueInListItem_SetToSelectedItem_Admin_Test(string ddlControlCategory, string expect)
        {
            //Arrange
            _clParameter.Operate = ddlControlCategory;

            //Act 
            AssemblingList.SetLists(_jsonStr, _listControl, ddlControlCategory, _clParameter,"Admin");
             string result = _listControl.SelectedValue;
            //Assert
            Assert.AreEqual(expect, result, $" Assembling list control {ddlControlCategory} has items count {result} . ");
         }
        [TestMethod()]
        [DataRow("UserRole", 29)]
        public void SetLists_InitialValueNotinListItem_SetToFirstItem_Other_Test(string ddlControlCategory, int expect)
        {
            //Arrange
            _clParameter.Operate = ddlControlCategory;

            //Act 
            AssemblingList.SetLists(_jsonStr, _listControl, ddlControlCategory, _clParameter, "AdminNoInList");

            int result = _listControl.Items.Count;
            string expect2 = "Other";
            string result2 = _listControl.SelectedValue;
            //Assert
            Assert.AreEqual(expect, result, $" Assembling list control {ddlControlCategory} has items count {result} . ");
            Assert.AreEqual(expect2, result2, $" Assembling list control {ddlControlCategory} has items count {result} . ");
        }
        [TestMethod()]
        [DataRow("Age", 2)]
        [DataRow("AppsName", 6)]
        [DataRow("Grade", 4)]
        [DataRow("ListSchool", 256)]
        [DataRow("SchoolArea", 12)]
        [DataRow("SchoolYear", 12)]
        [DataRow("UserRole", 29)]
        public void SetLists_AssemblingListContrtolwithoutInitial_NoReturnValue_Test(string ddlControlCategory, int expect)
        {
            //Arrange
            _clParameter.Operate = ddlControlCategory;

            //Act 
            AssemblingList.SetLists(_jsonStr, _listControl, ddlControlCategory,  _clParameter);
            int result = _listControl.Items.Count;

            //Assert
            Assert.AreEqual(expect, result, $" Assembling list control {ddlControlCategory} has items count {result} . ");
        }

        [TestMethod()]
        [DataRow("Age", "19","19")]
        [DataRow("AppsName", "SIC", "School Information Center")]
        [DataRow("Grade","11", "Gr.11")]
        [DataRow("ListSchool", "0501", "Notre Dame High School")]
        [DataRow("SchoolArea", "Area 05","Area 05")]
        [DataRow("SchoolYear", "20192020","20192020")]
        [DataRow("UserRole", "SeTeacher", "SeTeacher")]
        public void SetLists_AssemblingListContrtolwithInitial_NoReturnValue_Test(string ddlControlCategory, string initialValue, string expect)
        {
            //Arrange
            _clParameter.Operate = ddlControlCategory;

            //Act 
            AssemblingList.SetLists(_jsonStr, _listControl, ddlControlCategory, _clParameter,initialValue);
            string result = _listControl.SelectedItem.Text;

            //Assert
            Assert.AreEqual(expect, result, $" Assembling list control {ddlControlCategory} has items count {result} . ");
        }

        [TestMethod()]
        public void SetListSchool_AssemblingSchoolListContrtolwithoutInitial_NoReturnValue_Test()
        {
            //Arrange
            _clParameter.Operate = "DDLListSchool";
            _clParameter.Para4 = "S";
            string expect = "Bishop Allen Academy";
            //Act 
            AssemblingList.SetListSchool(_listControl, _listControl2, "DDLListSchool", _clParameter);
            _listControl2.SelectedIndex = 0;
            string result = _listControl2.SelectedItem.Text.Trim();

            //Assert
            Assert.AreEqual(expect, result, $" Assembling list control School has items count {result} . ");
        }

        [TestMethod()]
        public void SetListSchool_AssemblingSchoolListContrtolwithInitial_NoReturnValue_Test()
        {
            //Arrange
            _clParameter.Operate = "DDLListSchool";
            _clParameter.Para4 = "S";
            string expect = "Notre Dame High School";
            //Act 
            AssemblingList.SetListSchool(_listControl, _listControl2, "DDLListSchool", _clParameter,"0501");
            string result = _listControl2.SelectedItem.Text.Trim();

            //Assert
            Assert.AreEqual(expect, result, $" Assembling list control School has items count {result} . ");
        }

        [TestMethod()]
        [DataRow("Principal", "0501", "Notre Dame High School")]
        [DataRow("Teacher", "0511", "Loretto College School")]
        [DataRow("SeTeacher","0549", "Bishop Allen Academy")]
        public void SetListSchool_AssemblingSchoolListbyUserRole_OnlyOneSchoolReturn_Test(string userRole,string schoolCode, string expect)
        {
            //Arrange
            _clParameter.Operate = "DDLListSchool";
            _clParameter.Para1 = userRole;
            _clParameter.Para3 = schoolCode;
            _clParameter.Para4 = "S";

             //Act 
            AssemblingList.SetListSchool(_listControl, _listControl2, "DDLListSchool", _clParameter, "0501");
            string result = _listControl2.SelectedItem.Text.Trim();
            int count = _listControl2.Items.Count;

            //Assert
            Assert.AreEqual(expect, result, $" Assembling list control School has items count {result} . ");
            Assert.AreEqual(1, count, $" Assembling school by user role only one School in list control {count} . ");
        }

     
    }
}