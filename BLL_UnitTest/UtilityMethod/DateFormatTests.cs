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
    public class DateFormatTests
    {
        private string _inputDate = "11/19/2020";
        [TestMethod()]
        public void Format_InputDate_Return_YYYYMMDDFormat_Test()
        {
            //Arrange
            DateTime tDate = Convert.ToDateTime(_inputDate);
            var expect = "2020/11/19";

            // Act                                        
            var result = DateFormat.Format(tDate, "YYYYMMDD");

            //Assert
            Assert.AreEqual(expect, result, $" {tDate } Date Format to YYYYMMDD , {result}  ");
        }

        [TestMethod()]
        public void Format_InputDate_Return_DDMMYYYYFormat_Test()
        {
            //Arrange
            DateTime tDate = Convert.ToDateTime(_inputDate);
            var expect = "19/11/2020";

            // Act                                        
            var result = DateFormat.Format(tDate, "DDMMYYYY");

            //Assert
            Assert.AreEqual(expect, result, $" {tDate } Date Format to DDMMYYYY , {result}  ");
        }
        [TestMethod()]
        public void Format_InputDate_Return_MMDDYYYYFormat_Test()
        {
            //Arrange
            DateTime tDate = Convert.ToDateTime(_inputDate);
            var expect = "11/19/2020";

            // Act                                        
            var result = DateFormat.Format(tDate, "MMDDYYYY");

            //Assert
            Assert.AreEqual(expect, result, $" {tDate } Date Format to MMDDYYYY, {result}  ");
        }
        [TestMethod()]
        public void Format_InputDate_Return_MMMDDYYYYFormat_Test()
        {
            //Arrange
            DateTime tDate = Convert.ToDateTime(_inputDate);
            var expect = "November 19 2020";

            // Act                                        
            var result = DateFormat.Format(tDate, "MMMDDYYYY");

            //Assert
            Assert.AreEqual(expect, result, $" {tDate } Date Format to MMMDDYYYY, {result}  ");

        }

        [TestMethod()]
        public void Format_InputDate_Return_MMMDDFormat_Test()
        {
            //Arrange
            DateTime tDate = Convert.ToDateTime(_inputDate);
            var expect = "November 19";

            // Act                                        
            var result = DateFormat.Format(tDate, "MMMDD");

            //Assert
            Assert.AreEqual(expect, result, $" {tDate } Date Format to MMMDD, {result}  ");
        }
        [TestMethod()]
        public void Format_InputDate_Return_YYYYMMMFormat_Test()
        {
            //Arrange
            DateTime tDate = Convert.ToDateTime(_inputDate);
            var expect = "2020 November";

            // Act                                        
            var result = DateFormat.Format(tDate, "YYYYMMM");

            //Assert
            Assert.AreEqual(expect, result, $" {tDate } Date Format to YYYYMMM, {result}  ");
        }




        [TestMethod()]
        public void YMD_InputDate_Return_DateStringwithSlash_Test()
        {
            //Arrange
            DateTime tDate = Convert.ToDateTime(_inputDate);
            var expect = "2020/11/19";

            // Act                                        
            var result = DateFormat.YMD(tDate,"/");

            //Assert
            Assert.AreEqual(expect, result, $" {tDate } Date Format to yyyy/mm/dd, {result}  ");
        }

        [TestMethod()]
        public void YMD_InputDate_Return_DateStringwithdash_Test()
        {
            //Arrange
            DateTime tDate = Convert.ToDateTime(_inputDate);
            var expect = "2020-11-19";

            // Act                                        
            var result = DateFormat.YMD(tDate,"-");

            //Assert
            Assert.AreEqual(expect, result, $" {tDate } Date Format to yyyy-mm-dd, {result}  ");
        }

        [TestMethod()]
        public void Age_BirthDate_Return_AgeToday_Test()
        {
            //Arrange
           
            DateTime tDate = Convert.ToDateTime(new DateTime(2010, 5, 20));
            var expect = 11;

            // Act                                        
            var result = DateFormat.Age(tDate);

            //Assert
            Assert.AreEqual(expect, result, $" {tDate } account Age to today by birthdate, {result}  ");
        }

        [TestMethod()]
        public void Age_BirthDateandGiveDate_Return_Agebygivedate_Test1()
        {
            //Arrange

            DateTime birthDate  = Convert.ToDateTime(new DateTime(2010, 5, 20));
            DateTime accountDate = Convert.ToDateTime(_inputDate);
            var expect = 10;

            // Act                                        
            var result = DateFormat.Age(birthDate, accountDate);

            //Assert
            Assert.AreEqual(expect, result, $" age is {result} from Birthdate {birthDate } to {accountDate} ");
        }

        [TestMethod()]
        public void SchoolYearFrom_returnwithdash_Test()
        {
            //Arrange
            string schoolyear = "20192020";
            var expect = "2019-2020";

            // Act                                        
            var result = DateFormat.SchoolYearFrom("-",schoolyear);

            //Assert
            Assert.AreEqual(expect, result, $"school year format to xxxx-xxxx {schoolyear} to {result} ");
        }

        [TestMethod()]
        public void SchoolYearNext_returnNextSchoolyear_Test()
        {
            //Arrange
            string schoolyear = "20192020";
            var expect = "2020-2021";

            // Act                                        
            var result = DateFormat.SchoolYearNext("-",schoolyear);

            //Assert
            Assert.AreEqual(expect, result, $"get next school year format to xxxx-xxxx {schoolyear} to {result} ");
        }

        [TestMethod()]
        public void SchoolYearPrevious_returnPreviousSchoolYear_Test()
        {
            //Arrange
            string schoolyear = "20192020";
            var expect = "2018-2019";

            // Act                                        
            var result = DateFormat.SchoolYearPrevious("-", schoolyear);

            //Assert
            Assert.AreEqual(expect, result, $"get previous school year format to xxxx-xxxx {schoolyear} to {result} ");
        }

        [TestMethod()]
        [DataRow("Next",6)]
        [DataRow("Next", 9)]
        [DataRow("Pre", 6)]
        [DataRow("Pre", 9)]
        public void YearTOGO_InputIndicator2Parameter_returnNextSchoolYearTest(string indicateor, int month)
        {
            //Arrange
            string schoolyear = "20192020";
            var expect = "20192020";

            // Act                                        
            var result = DateFormat.YearTOGO(indicateor, month, schoolyear);

            //Assert
            Assert.IsNotNull(result, $"get next school year format to xxxx-xxxx {schoolyear} to {result} ");

        }

        [TestMethod()]
        public void YearTOGO_InputIndicatorNextatJune_returnNextSchoolYearTest()
        {
            //Arrange
            string schoolyear = "20192020";
            var expect = "20192020";

            // Act                                        
            var result = DateFormat.YearTOGO("Next", 6, schoolyear);

            //Assert
            Assert.AreEqual(expect, result, $"get next school year format to xxxx-xxxx {schoolyear} to {result} ");

        }

        [TestMethod()]
        public void YearTOGO_InputIndicatorOtherthenNextatJune_returnPreviousSchoolYearTest()
        {
            //Arrange
            string schoolyear = "20192020";
            var expect = "20182019";

            // Act                                        
            var result = DateFormat.YearTOGO("Pre",6, schoolyear);

            //Assert
            Assert.AreEqual(expect, result, $"get previous school year format to xxxx-xxxx {schoolyear} to {result} ");

        }
        [TestMethod()]
        public void YearTOGO_InputIndicatorNextatSeptember_returnNextSchoolYearTest()
        {
            //Arrange
            string schoolyear = "20192020";
            var expect = "20202021";

            // Act                                        
            var result = DateFormat.YearTOGO("Next", 9, schoolyear);

            //Assert
            Assert.AreEqual(expect, result, $"get next school year format to xxxx-xxxx {schoolyear} to {result} ");

        }

        [TestMethod()]
        public void YearTOGO_InputIndicatorOthertatSeptmber_returnPreviousSchoolYearTest()
        {
            //Arrange
            string schoolyear = "20192020";
            var expect = "20192020";

            // Act                                        
            var result = DateFormat.YearTOGO("Pre", 9, schoolyear);

            //Assert
            Assert.AreEqual(expect, result, $"get previous school year format to xxxx-xxxx {schoolyear} to {result} ");

        }
    }
}