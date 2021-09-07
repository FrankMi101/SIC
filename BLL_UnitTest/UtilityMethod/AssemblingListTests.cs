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
        private DropDownList _listControl = new DropDownList();
        private List<NameValueList> _nameValueslist = new List<NameValueList>();
     
        [TestInitialize]
        public void Setup()
        {
            // Runs before each test. (Optional)
            _nameValueslist.Add(new NameValueList() { Name = "Grade 1", Value = "01" });
            _nameValueslist.Add(new NameValueList() { Name = "Grade 2", Value = "02" });
            _nameValueslist.Add(new NameValueList() { Name = "Grade 3", Value = "03" });

        }

        [TestMethod()]
        public void SetLists_AssemblingDropDownListItem_ReturnListCount_Test()
        {
            //Arrange
            int expect = 3;

            // Act                                        
            AssemblingList.SetLists(_listControl, _nameValueslist);
            int result = _listControl.Items.Count;
            _listControl.SelectedIndex = 2;
            string result2 = _listControl.SelectedValue = "03";

            //Assert
            Assert.AreEqual(expect, result, $"List Count is  {result} ");
            Assert.AreEqual(expect, result, $"current selected item is  {result2} ");
        }

        [TestMethod()]
        public void SetLists_AssemblingDropDownListAndInitialSelected_ReturnSelectValue_Test()
        {
            //Arrange
            string expect = "Grade 2";

            // Act                                        
            AssemblingList.SetLists(_listControl, _nameValueslist, "02");
            string result = _listControl.SelectedItem.Text;

            //Assert
            Assert.AreEqual(expect, result, $"current selected item Text is  {result} ");

        }

        [TestMethod()]
        public void SetValue_AssemblingDropDownListAndSetSelectValue_ReturnSelectText_Test()
        {
            //Arrange

            string expect = "Grade 1";

            // Act    
            AssemblingList.SetLists(_listControl, _nameValueslist);
            AssemblingList.SetValue(_listControl, "01");
            string result = _listControl.SelectedItem.Text;

            //Assert
            Assert.AreEqual(expect, result, $"current selected item Text is  {result} ");
        }

        [TestMethod()]
        public void SetListSchool_AssemblingSchoolDropDownListAndInitialSelected_ReturnSelectSchool_Test()
        {
            //Arrange
            var _listControl2 = new DropDownList();
            var _schoolist = new List<NameValueList>
            {
               new NameValueList() { Name = "School 1", Value = "0201" },
               new NameValueList() { Name = "School 2", Value = "0302" },
               new NameValueList() { Name = "School 3", Value = "0501" },
            };
            string expect = "0302";

            // Act    
            AssemblingList.SetListSchool(_listControl, _listControl2, _schoolist, "0302");

            //Assert
            string result = _listControl.SelectedValue;
            string result2 = _listControl2.SelectedValue;
            Assert.AreEqual(expect, result, $"current selected school code is  {result} ");
            Assert.AreEqual(expect, result2, $"current selected school code  is  {result2} ");
        }

        [TestMethod()]
        public void SetListSchool_AssemblingSchoolDropDownListAndSetUpValue_ReturnSelectSchool_Test()
        {
            //Arrange
            var _listControl2 = new DropDownList();
            var _schoolist = new List<NameValueList>
            {
               new NameValueList() { Name = "School 1", Value = "0201" },
               new NameValueList() { Name = "School 2", Value = "0302" },
               new NameValueList() { Name = "School 3", Value = "0501" },
            };
            string expect = "0501";

            // Act    
            AssemblingList.SetListSchool(_listControl, _listControl2, _schoolist);
            AssemblingList.SetValue(_listControl, "0501");
            AssemblingList.SetValue(_listControl2, "0501");

            //Assert
            string result = _listControl.SelectedValue;
            string result2 = _listControl2.SelectedValue;
            Assert.AreEqual(expect, result, $"current selected school code is  {result} ");
            Assert.AreEqual(expect, result2, $"current selected school code  is  {result2} ");
        }
    }
}