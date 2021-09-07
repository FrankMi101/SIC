using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace BLL.Tests
{
    [TestClass()]
    public class AppsPageHelpTests
    {
        private MenuListParameter _spParamater = new MenuListParameter();
        private HelpMessage _helpMessage = new HelpMessage();
        private List<CommonSP>  _mySPclass = new List<CommonSP> { new AppsPageHelp() };

        [TestInitialize]
        public void Setup()
        {
            _spParamater.UserID = "mif";
            _spParamater.UserRole = "Admin";
            _spParamater.SchoolYear = "20202021";
            _spParamater.SchoolCode = "0501";
            _spParamater.TabID = "10";
            _spParamater.ObjID = "383823321";
            _spParamater.AppID = "SIC";

            _helpMessage.UserID = "mif";
            _helpMessage.Area = "List";
            _helpMessage.Operate = "Get";
        }


        [TestMethod()]
        [DataRow("StudentListPage")]
        [DataRow("GroupListPage")]
        [DataRow("ClassListPage")]
        [DataRow("StaffListPage")]
        [DataRow("SecurityGroupManage")]
        public void CommonList_SublistMeniItembyCategory_ReturnDetailMenuList_Test(string category)
        {
            //Arrange 
            _spParamater.Operate = category;
            var mySPclass = new List<CommonSP> { new AppsPageHelp() }; 

            // Act  
            string sp = BLL.Common.SPName(mySPclass, "ActionMenuList", _spParamater);
            var result = AppsPageHelp.CommonList<MenuItems>(sp, _spParamater);

            //Assert
            Assert.IsNotNull(result, $"Get Student List by Generic class  {result.Count} ");
        }
        [TestMethod()]
        [DataRow("Help","StudentInfo","SearchList")]
        [DataRow("Help", "ClassInfo", "ClassList")]
        [DataRow("Help", "TeacherInfo", "TasksList")]
        [DataRow("Help", "SchoolInfo", "TasksList")]
        [DataRow("Help", "BoardInfo", "TasksList")]
        public void CommonValue_GetContentbyCategory_ReturnText_Test(string contentCategory,string category,string itemCode)
        {
            //Arrange 
            _helpMessage.Category = category;
            _helpMessage.ContentType = contentCategory;
            _helpMessage.ItemCode = itemCode;
           
            // Act  
            string sp = BLL.Common.SPName(_mySPclass, "HelpContent", _helpMessage);
            var result = AppsPageHelp.CommonValue<string> (sp, _helpMessage);

            //Assert
            Assert.IsNotNull(result, $"Get Student List by Generic class  {result } ");
        }
        [TestMethod()]
        [DataRow("Help", "StudentInfo", "SearchList")]
        [DataRow("Help", "ClassInfo", "ClassList")]
        [DataRow("Help", "TeacherInfo", "TasksList")]
        [DataRow("Help", "SchoolInfo", "TasksList")]
        [DataRow("Help", "BoardInfo", "TasksList")]
        public void CommonValue_AddHelpContentbyCategory_ReturnSeccessfully_Test(string contentCategory, string category, string itemCode)
        {
            //Arrange 
            _helpMessage.Category = category;
            _helpMessage.ContentType = contentCategory;
            _helpMessage.ItemCode = itemCode;
            _helpMessage.Operate = "Add";
            _helpMessage.Value = " Add testing help content for " + contentCategory + " of " + category + " Menu List item " + " to Page " + itemCode;
            var excep = "Successfully";
          
            // Act  
            string sp = BLL.Common.SPName(_mySPclass, "HelpContent", _helpMessage);
            var result = AppsPageHelp.CommonValue<string>(sp, _helpMessage);

            //Assert
            Assert.AreEqual(excep, result, $"Add or update help content test  {result } ");
        }
        [TestMethod()]
        [DataRow("Help", "StudentInfo", "SearchList")]
        [DataRow("Help", "ClassInfo", "ClassList")]
        [DataRow("Help", "TeacherInfo", "TasksList")]
        [DataRow("Help", "SchoolInfo", "TasksList")]
        [DataRow("Help", "BoardInfo", "TasksList")]
        public void CommonValue_UpdateHelpContentbyCategory_ReturnSuccessfaul_Test(string contentCategory, string category, string itemCode)
        {
            //Arrange 
            _helpMessage.Category = category;
            _helpMessage.ContentType = contentCategory;
            _helpMessage.ItemCode = itemCode;
            _helpMessage.Operate = "Update";
            _helpMessage.Value = " update testing help content for " + contentCategory + " of " + category + " Menu List item " + " to Page " + itemCode;
            var excep = "Successfully";
 
            // Act  
            string sp = BLL.Common.SPName(_mySPclass, "HelpContent", _helpMessage);
            var result = AppsPageHelp.CommonValue<string>(sp, _helpMessage);

            //Assert
            Assert.AreEqual(excep, result, $"Add or update help content test  {result } ");
        }

        [TestMethod()]
        [DataRow("Message", "StudentInfo", "SearchList")]
        [DataRow("Message", "ClassInfo", "ClassList")]
        [DataRow("Message", "TeacherInfo", "TasksList")]
        [DataRow("Message", "SchoolInfo", "TasksList")]
        [DataRow("Message", "BoardInfo", "TasksList")]
        public void CommonValue_GetMessaheContentbyCategory_ReturnText_Test(string contentCategory, string category, string itemCode)
        {
            //Arrange 
            _helpMessage.Category = category;
            _helpMessage.ContentType = contentCategory;
            _helpMessage.ItemCode = itemCode; 
     
            // Act  
            string sp = BLL.Common.SPName(_mySPclass, "HelpContent", _helpMessage);
            var result = AppsPageHelp.CommonValue<string>(sp, _helpMessage);

            //Assert
            Assert.IsNotNull(result, $"Get Student List by Generic class  {result } ");
        }
        [TestMethod()]
        [DataRow("Message", "StudentInfo", "SearchList")]
        [DataRow("Message", "ClassInfo", "ClassList")]
        [DataRow("Message", "TeacherInfo", "TasksList")]
        [DataRow("Message", "SchoolInfo", "TasksList")]
        [DataRow("Message", "BoardInfo", "TasksList")]
        public void CommonValue_AddMessageContentbyCategory_ReturnSeccessfully_Test(string contentCategory, string category, string itemCode)
        {
            //Arrange 
            _helpMessage.Category = category;
            _helpMessage.ContentType = contentCategory;
            _helpMessage.ItemCode = itemCode;
            _helpMessage.Operate = "Add";
            _helpMessage.Value = "add Message content for " + contentCategory + " of " + category + " Menu List item " + " to Page " + itemCode;
          var excep = "Successfully";

            // Act  
            string sp = BLL.Common.SPName(_mySPclass, "HelpContent", _helpMessage);
            var result = AppsPageHelp.CommonValue<string>(sp, _helpMessage);

            //Assert
            Assert.AreEqual(excep, result, $"Add or update help content test  {result } ");
        }
        [TestMethod()]
        [DataRow("Message", "StudentInfo", "SearchList")]
        [DataRow("Message", "ClassInfo", "ClassList")]
        [DataRow("Message", "TeacherInfo", "TasksList")]
        [DataRow("Message", "SchoolInfo", "TasksList")]
        [DataRow("Message", "BoardInfo", "TasksList")]
        public void CommonValue_DeleteMessageContentbyCategory_ReturnSeccessfully_Test(string contentCategory, string category, string itemCode)
        {
            //Arrange 
            _helpMessage.Category = category;
            _helpMessage.ContentType = contentCategory;
            _helpMessage.ItemCode = itemCode;
            _helpMessage.Operate = "Del";
           
            var excep = "Successfully";
 
            // Act  
            string sp = BLL.Common.SPName(_mySPclass, "HelpContent", _helpMessage);
            var result = AppsPageHelp.CommonValue<string>(sp, _helpMessage);

            //Assert
            Assert.AreEqual(excep, result, $"Add or update help content test  {result } ");
        }

        [TestMethod()]
        [DataRow("Title", "StudentInfo", "SearchList")]
        [DataRow("SubTitle", "StudentInfo", "SearchList")]
        public void CommonValue_AddContentbyCategory_ReturnSeccessfully_Test(string contentCategory, string category, string itemCode)
        {
            //Arrange 
            _helpMessage.Category = category;
            _helpMessage.ContentType = contentCategory;
            _helpMessage.ItemCode = itemCode;
            _helpMessage.Operate = "Add";
            _helpMessage.Value = "new content for " + contentCategory + " of " + category + " Menu List item " + " to Page " + itemCode;

            var excep = "Successfully";
  

            // Act  
            string sp = BLL.Common.SPName(_mySPclass, "HelpContent", _helpMessage);
            var result = AppsPageHelp.CommonValue<string>(sp, _helpMessage);

            //Assert
            Assert.AreEqual(excep, result, $"Add or update help content test  {result } ");
        }
        [TestMethod()]
        [DataRow("Title", "StudentInfo", "SearchList")]
        [DataRow("SubTitle", "StudentInfo", "SearchList")]
        public void CommonValue_DeleteContentbyCategory_ReturnSeccessfully_Test(string contentCategory, string category, string itemCode)
        {
            //Arrange 
            _helpMessage.Category = category;
            _helpMessage.ContentType = contentCategory;
            _helpMessage.ItemCode = itemCode;
            _helpMessage.Operate = "Del";
 
            var excep = "Successfully";
        
            // Act  
            string sp = BLL.Common.SPName(_mySPclass, "HelpContent", _helpMessage);
            var result = AppsPageHelp.CommonValue<string>(sp, _helpMessage);

            //Assert
            Assert.AreEqual(excep, result, $"Add or update help content test  {result } ");
        }

        [TestMethod()]
        [DataRow("Help", "StudentInfo", "SearchList")]
        [DataRow("Title", "StudentInfo", "SearchList")]
        [DataRow("SubTitle", "StudentInfo", "SearchList")]
        [DataRow("Message", "StudentInfo", "SearchList")]
        public void PageHelp_GetContentbyCategory_ReturnText_Test(string contentCategory, string category, string itemCode)
        {
            //Arrange 
            _helpMessage.Category = category;
            _helpMessage.ContentType = contentCategory;
            _helpMessage.ItemCode = itemCode;            

            // Act  
            string sp = BLL.Common.SPName(_mySPclass, "HelpContent", _helpMessage);
            var result = AppsPageHelp.CommonValue<string>(sp, _helpMessage);

            //Assert
            Assert.IsNotNull(result,$"Get Help content test result  {result } ");
        }


    }
}