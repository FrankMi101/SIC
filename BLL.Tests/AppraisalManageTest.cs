// <copyright file="AppraisalManageTest.cs">Copyright ©  2018</copyright>
using System;
using System.Collections.Generic;
using BLL;
using ClassLibrary;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BLL.Tests
{
    /// <summary>This class contains parameterized unit tests for AppraisalManage</summary>
    [PexClass(typeof(AppraisalManage))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class AppraisalManageTest
    {
        /// <summary>Test stub for AppraisalStaffHistory(Object)</summary>
        [PexMethod]
        public List<AppraisalHistory> AppraisalStaffHistoryTest(object parameter)
        {
            List<AppraisalHistory> result = AppraisalManage.AppraisalStaffHistory(parameter)
              ;
            return result;
            // TODO: add assertions to method AppraisalManageTest.AppraisalStaffHistoryTest(Object)
        }

        /// <summary>Test stub for AppraisalStaffsNotice(Object)</summary>
        [PexMethod]
        public List<AppraisalNotice> AppraisalStaffsNoticeTest(object parameter)
        {
            List<AppraisalNotice> result = AppraisalManage.AppraisalStaffsNotice(parameter);
            return result;
            // TODO: add assertions to method AppraisalManageTest.AppraisalStaffsNoticeTest(Object)
        }

        /// <summary>Test stub for AppraisalStaffs(Object)</summary>
        [PexMethod]
        public List<AppraisalList> AppraisalStaffsTest(object parameter)
        {
            List<AppraisalList> result = AppraisalManage.AppraisalStaffs(parameter);
            return result;
            // TODO: add assertions to method AppraisalManageTest.AppraisalStaffsTest(Object)
        }

        /// <summary>Test stub for AppraiseeDelete(Object)</summary>
        [PexMethod]
        public string AppraiseeDeleteTest(object parameter)
        {
            string result = AppraisalManage.AppraiseeDelete(parameter);
            return result;
            // TODO: add assertions to method AppraisalManageTest.AppraiseeDeleteTest(Object)
        }

        /// <summary>Test stub for AppraiseeEdit(Object)</summary>
        [PexMethod]
        public string AppraiseeEditTest(object parameter)
        {
            string result = AppraisalManage.AppraiseeEdit(parameter);
            return result;
            // TODO: add assertions to method AppraisalManageTest.AppraiseeEditTest(Object)
        }

        /// <summary>Test stub for Appraisee(Object)</summary>
        [PexMethod]
        public List<Appraisee> AppraiseeTest(object parameter)
        {
            List<Appraisee> result = AppraisalManage.Appraisee(parameter);
            return result;
            // TODO: add assertions to method AppraisalManageTest.AppraiseeTest(Object)
        }

        /// <summary>Test stub for DeleteSatement(Object)</summary>
        [PexMethod]
        public string DeleteSatementTest(object parameter)
        {
            string result = AppraisalManage.DeleteSatement(parameter);
            return result;
            // TODO: add assertions to method AppraisalManageTest.DeleteSatementTest(Object)
        }

        /// <summary>Test stub for SatementNo(Object)</summary>
        [PexMethod]
        public int SatementNoTest(object parameter)
        {
            int result = AppraisalManage.SatementNo(parameter);
            return result;
            // TODO: add assertions to method AppraisalManageTest.SatementNoTest(Object)
        }

        /// <summary>Test stub for SaveSatement(Object)</summary>
        [PexMethod]
        public string SaveSatementTest(object parameter)
        {
            string result = AppraisalManage.SaveSatement(parameter);
            return result;
            // TODO: add assertions to method AppraisalManageTest.SaveSatementTest(Object)
        }

        /// <summary>Test stub for StaffList(Object)</summary>
        [PexMethod]
        public List<AppraisalList> StaffListTest(object parameter)
        {
            List<AppraisalList> result = AppraisalManage.StaffList(parameter);
            return result;
            // TODO: add assertions to method AppraisalManageTest.StaffListTest(Object)
        }

        /// <summary>Test stub for StatementNoList(Object)</summary>
        [PexMethod]
        public List<AppStatement> StatementNoListTest(object parameter)
        {
            List<AppStatement> result = AppraisalManage.StatementNoList(parameter);
            return result;
            // TODO: add assertions to method AppraisalManageTest.StatementNoListTest(Object)
        }

        /// <summary>Test stub for Statement(Object)</summary>
        [PexMethod]
        public List<AppStatement> StatementTest(object parameter)
        {
            List<AppStatement> result = AppraisalManage.Statement(parameter);
            return result;
            // TODO: add assertions to method AppraisalManageTest.StatementTest(Object)
        }
    }
}
