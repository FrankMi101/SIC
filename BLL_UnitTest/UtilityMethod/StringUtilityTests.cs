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
    public class StringUtilityTests
    {
        private string _text = "Azure Active Directory is at the core of any collaboration that takes place in Microsoft 365. It’s important to understand guest user access and collaboration";
        private int _MaxWord = 25;

        [TestMethod()]
        public void SummarizeText_InputTextBlank_ReturnBlank_Test()
        {
            //Arrange
            _text ="";
            var expect = "";

            // Act                                        
            var result = StringUtility.SummarizeText(_text, _MaxWord);

            //Assert
            Assert.AreEqual(expect, result, $"Summarize Text {result} ");

        }
        [TestMethod()]
        public void SummarizeText_TextLessthen25Words_ReturnText_Test()
        {
            //Arrange
            _text = _text.Substring(0,20);
            var expect = _text;

            // Act                                        
            var result = StringUtility.SummarizeText(_text, _MaxWord);

            //Assert
            Assert.AreEqual(expect, result, $"Summarize Text {result} ");
        }
        [TestMethod()]
        public void SummarizeText_TextGreatthen25Words_Return25WordsPlusText_Test()
        {
            //Arrange
             var expect = "Azure Active Directory is...";

            // Act                                        
            var result = StringUtility.SummarizeText(_text, _MaxWord);

            //Assert
            Assert.AreEqual(expect, result, $"Summarize Text {result} ");
        }
    }
}