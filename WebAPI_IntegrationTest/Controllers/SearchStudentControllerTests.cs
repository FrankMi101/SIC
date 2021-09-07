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
    public class SearchStudentControllerTests
    {
        [TestMethod()]
        public void Get_SearchStudentListbySearchCondition_ReturnStudentsList_Test()
        {
            //Arrange                                            
            var parameter = new
            {
                Operate = "Get",
                UserID = "mif",
                UserRole = "Admin",
                SchoolYear = "20202021",
                SchoolCode = "0501",
                Grade = "10",
                SearchBy = "",
                SearchValue = "",
                Scope = "School"
            };
            var sp = "dbo.SIC_sys_ListofStudents";

            //Act
             var _iapiaction = new APIAction<Student>();
            var result = _iapiaction.CeneralList("StudentList", sp, parameter);

           // var result = APIListofT<Student>.CeneralList("StudentList", sp, parameter);

            //Assert
            Assert.IsNotNull(result, $"Search Student List Testing {result.Count}");
        }
    }
}