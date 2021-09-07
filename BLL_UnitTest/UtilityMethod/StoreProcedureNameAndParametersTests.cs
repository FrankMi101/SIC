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
    public class StoreProcedureNameAndParametersTests
    {
        private string _sp = "dbo.SIC_sys_ListItems";
        private string _action = "DDList";
        private string _parameterStr = " @Operate,@UserID,@Para1,@Para2,@Para3,@Para4";
        private StoreProcedureNameAndParameters _spClass = new StoreProcedureNameAndParameters();

        [TestMethod()]
        public void SPNameAndPara_ProvideSPNameOnlywithouParameters_returnSPnamePlusParameters_Test()
        {
            //Arrange
            var parameters = new { Operate = "Grade", UserID = "mif", Para1 = "Admin", Para2 = "20192020", Para3 = "0509", Para4 = "S" };
             _action = _sp;
           var expect = _sp + _parameterStr;

            // Act       
            var result = _spClass.SPNameAndPara("GeneralList", _action, parameters);

            //Assert
            Assert.AreEqual(expect, result, $"Get SP name and parameters by parameters object {result} ");

        }

        [TestMethod()]
        public void SPNameAndPara_ProvideSPNameandParameters_returnSPnameParameters_Test()
        {
            //Arrange 
            _action = _sp + _parameterStr;
            var expect = _sp + _parameterStr;

            // Act       
            var result = _spClass.SPNameAndPara("GeneralList", _action, "");

            //Assert
            Assert.AreEqual(expect, result, $"Get SP name and parameters by direct SP and parameters string  {result} ");
        }

        [TestMethod()]
        public void SPNameAndPara_GetSPNamebyClassandAction_ReturnSPNameandParameters_Test()
        {
            //Arrange 
            _action = "DDList";
             var expect = _sp + _parameterStr;

            // Act       
            var result = _spClass.SPNameAndPara("GeneralList", _action, "");

            //Assert
            Assert.AreEqual(expect, result, $"Get SP name and parameters by direct SP and parameters string  {result} ");
        }

        [TestMethod()]
        public void SPNameAndPara_GetSPNamebyICommonSPClassandAction_ReturnSPNameandParameters_Test()
        {
            //Arrange 
            var  mySPclass = new List<CommonSP> { new GeneralList() };
            _action = "DDList";
            var expect = _sp + _parameterStr;

            // Act       
            var result = _spClass.SPNameAndPara(mySPclass, _action);

            //Assert
            Assert.AreEqual(expect, result, $"Get SP name and parameters by direct SP and parameters string  {result} ");
        }

    }
}