// <copyright file="DateFormatTest.cs">Copyright ©  2018</copyright>

using System;
using BLL;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BLL.Tests
{
    [TestClass]
    [PexClass(typeof(DateFormat))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class DateFormatTest
    {

        [PexMethod]
        public string YMD(DateTime vDate)
        {
            string result = DateFormat.YMD(vDate);
            return result;
            // TODO: add assertions to method DateFormatTest.YMD(DateTime)
        }
    }
}
