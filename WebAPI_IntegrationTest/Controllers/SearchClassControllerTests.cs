using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace WebAPI.Controllers.Tests
{
    [TestClass()]
    public class SearchClassControllerTests
    {
        [TestMethod()]
        public void Get_SearchClassListbySearchCondition_ReturnClassList_Test()
        {
            //Arrange                                            
            var parameter = new
            { Operate="Get", 
                UserID="mif", 
                UserRole="Admin",
                SchoolYear ="20202021", 
                SchoolCode ="0549",
                Grade ="Academic",
                SearchBy ="", 
                SearchValue = "",
                Scope ="School" 
            };
            var sp = "dbo.SIC_sys_ListofClasses";

            //Act
        //    var result = APIListofT<Classes>.CeneralList("ClassList", sp, parameter);
            var _iapiaction = new APIAction<Classes>();
            var result = _iapiaction.CeneralList("ClassList", sp, parameter);

            //Assert
            Assert.IsNotNull(result, $"Classes List Testing {result.Count}");
            Assert.AreEqual(218,result.Count, $"Classes  List Testing {result.Count}");
        }


    }
}