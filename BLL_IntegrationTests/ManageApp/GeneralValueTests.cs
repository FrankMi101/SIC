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
    public class GeneralValueTests
    {
        private string _action = "ManageGroupMember";
        private string _expect = "Successfully";
        private string _testMetod = "";
        private string _AddTestNeedToClearn = "";
        private StoreProcedureNameAndParameters _spClass = new StoreProcedureNameAndParameters();
        private GroupOperation _groupInfo = new GroupOperation();

        [TestInitialize]
        public void Setup()
        {
            _testMetod = "Get";
            _groupInfo.UserID = "mif";
            _groupInfo.UserRole = "Admin";
            _groupInfo.SchoolYear = "20202021";
            _groupInfo.SchoolCode = "0501";
            _groupInfo.AppID = "SIC";
            _groupInfo.GroupType = "Grade";
            _groupInfo.IsActive = "X";
            _groupInfo.Permission = "Update";
        }

        [TestMethod()]
        public void CommonValue_UpdateDatabaseOnNotExistRecord_ReturnFailed_Test()
        {
            //Arrange 
            _groupInfo.Operate = "Edit";
            _groupInfo.GroupID = "Grade 0 Work Group";
            _groupInfo.GroupName = "Grade 0 Students work Group Name Change";

            _expect = "Failed";
            // Act  
            var mySPclass = new List<CommonSP> { new GeneralValue() };
            string sp = BLL.Common.SPName(mySPclass, _action, _groupInfo);
            var result = GeneralValue.CommonValue<string>(sp, _groupInfo);

            //Assert
            Assert.AreEqual(_expect, result, $" Update Student work group name is {result} ");

        }

        [TestMethod()]
        public void CommonValue_AddExistRecordToDatabase_ReturnAlreadyExistsMessage_Test()
        {
            //Arrange 
            _groupInfo.Operate = "Add";
            _groupInfo.GroupID = "Grade 11 Work Group";
            _groupInfo.GroupName = "Grade 11 Students work Group Name Change";
            _groupInfo.Comments = "add new Grade 11 student work group testing";
            _expect = "This is a already a Group named " + _groupInfo.GroupID + " In the system";
            // Act  
            var mySPclass = new List<CommonSP> { new GeneralValue() };
            string sp = BLL.Common.SPName(mySPclass, _action, _groupInfo);
            var result = GeneralValue.CommonValue<string>(sp, _groupInfo);
            _testMetod = "Add";
            //Assert
            Assert.AreEqual(_expect, result, $" Add new Student work group name is {result} ");
        }
        [TestMethod()]
        public void CommonValue_DeleteNotExistRecord_ReturnMessage_Test()
        {
            //Arrange 
            _groupInfo.Operate = "Del";
            _groupInfo.GroupID = "Grade 00 Work Group";
            _expect = "This is no such Group named " + _groupInfo.GroupID + " In the system";
            // Act  
            var mySPclass = new List<CommonSP> { new GeneralValue() };
            string sp = BLL.Common.SPName(mySPclass, _action, _groupInfo);
            var result = GeneralValue.CommonValue<string>(sp, _groupInfo);

            //Assert
            Assert.AreEqual(_expect, result, $" delete a Student work group name is {result} ");

        }
        [TestMethod()]
        public void CommonValue_UpdateDatabase_ReturnSeccessfully_Test()
        {
            //Arrange 
            _groupInfo.Operate = "Edit";
            _groupInfo.GroupID = "Grade 10 Work Group";
            _groupInfo.GroupName = "Grade 10 Students work Group Name Change";
            _groupInfo.StudentMember = "10";
            _testMetod = "Edit";
            // Act  
            var mySPclass = new List<CommonSP> { new GeneralValue() };
            string sp = BLL.Common.SPName(mySPclass, _action, _groupInfo);
            var result = GeneralValue.CommonValue<string>(sp, _groupInfo);

            //Assert
            Assert.AreEqual(_expect, result, $" Update Student work group name is {result} ");

        }
        [TestMethod()]
        public void CommonValue_AddRecordToDatabase_ReturnSeccessfully_Test()
        {
            //Arrange 
              _testMetod = "Add";

            // Act  
                 string result = InitialAddRecordForAddAndDeleteTest();
                _AddTestNeedToClearn = _groupInfo.GroupID;

            //Assert
            Assert.AreEqual(_expect, result, $" Add new Student work group name is {result} ");

            //Recover Test process
            // CommonValue_DeleteRecordToDatabase_ReturnSeccessfully_Test();
        }
        private string InitialAddRecordForAddAndDeleteTest()
        {
            _groupInfo.Operate = "Add";
            _groupInfo.GroupID = "Grade 08 Work Group";
            _groupInfo.GroupName = "Grade 08 Students work Group Name Change";
            _groupInfo.Comments = "add new Grade 08 student work group  testing";
            // Act  
            var mySPclass = new List<CommonSP> { new GeneralValue() };
            string sp = BLL.Common.SPName(mySPclass, _action, _groupInfo);
           return  GeneralValue.CommonValue<string>(sp, _groupInfo);
        }
        [TestMethod()]
        public void CommonValue_DeleteRecordToDatabase_ReturnSeccessfully_Test()
        {
            //Arrange 
            InitialAddRecordForAddAndDeleteTest();
            _groupInfo.Operate = "Del";
            _groupInfo.GroupID = "Grade 08 Work Group";
         //   CommonValue_AddRecordToDatabase_ReturnSeccessfully_Test();
            // Act  
            var mySPclass = new List<CommonSP> { new GeneralValue() };
            string sp = BLL.Common.SPName(mySPclass, _action, _groupInfo);
            var result = GeneralValue.CommonValue<string>(sp, _groupInfo);
            _testMetod = "Del";
            //Assert
            Assert.AreEqual(_expect, result, $" delete a Student work group name is {result} ");

        }
        [TestCleanup]
        public void TearDown()
        {
            if (_testMetod == "Add")
            {
                _groupInfo.Operate = "Del";
                _groupInfo.GroupID = _AddTestNeedToClearn;

                // clearn up Act  
                var mySPclass = new List<CommonSP> { new GeneralValue() };
                string sp = BLL.Common.SPName(mySPclass, _action, _groupInfo);
                var result = GeneralValue.CommonValue<string>(sp, _groupInfo);
            }

        }
    }
}