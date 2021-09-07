using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tests
{
    [TestClass()]
    public class BuildReportingParametersTests
    {
        [TestMethod()]
        [DataRow("IEP",4)]
        [DataRow("TPA",7)]
        [DataRow("SSF",6)]
        public void GetReportParameter_InputTypeAndSelectedStudent_ReturnIEPReportParameterType_Test(string reportType, int expect)
        {
            //Arrange
             var inputParameters = new ListOfSelected()
            {
                UserID = "mif",
                SchoolYear ="20002021",
                SchoolCode = "0508",
                ObjID = "0008089911",
                ObjNo = "04",
                ObjType = "1"

            };
         //   var reportType = "IEP";
            //var expect = 4;
            //if (reportType == "TPA") expect = 7;
            //if (reportType == "SSF") expect = 6;

            // Act   
            var result = BuildReportingParameters.GetReportParameter(reportType, inputParameters);
             

            //Assert
            Assert.AreEqual(expect, result.Count, $"Get Report Parameter by report Type { result.Count} ");

        }

        [TestMethod()]
        public void GetReportParameter_InputTypeAndSelectedStudent_ReturnTPAReportParameterType_Test()
        {
            //Arrange
            var inputParameters = new ListOfSelected()
            {
                UserID = "mif",
                SchoolYear = "20002021",
                SchoolCode = "0508",
                ObjID = "00053011",
                ObjNo = "Appraisal 1",
                ObjType = "AnnualPlan"
            };
            var reportType = "TPA";
            var expect = 7;
            // Act    

            var result = BuildReportingParameters.GetReportParameter(reportType, inputParameters);
            //Assert
            Assert.AreEqual(expect, result.Count, $"Get Report Parameter by report Type { result.Count} ");
          
        }

        [TestMethod()]
        public void GetReportParameter_InputTypeAndSelectedStudent_ReturnIPRCReportParameterType_Test()
        {
            //Arrange
            var inputParameters = new ListOfSelected()
            {
                UserID = "mif",
                SchoolYear = "20002021",
                SchoolCode = "0508",
                ObjID = "00053010101",
                ObjNo = "1",
                ObjType = "IPRCForm"
            };
            var reportType = "SSF";
            var expect = 6;
            // Act    

            var result = BuildReportingParameters.GetReportParameter(reportType, inputParameters);
            var pType = result.GetType();
            //Assert
            Assert.AreEqual(expect, result.Count, $"Get Report Parameter by report Type { result.Count} ");

        }
    }
}