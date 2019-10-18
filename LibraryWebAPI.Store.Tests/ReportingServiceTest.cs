using Autofac;
using Autofac.Extras.Moq;
using LibraryWebAPI.Store.IRepositories;
using LibraryWebAPI.Store.IServices;
using LibraryWebAPI.Store.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LibraryWebAPI.Store.Tests
{
    [TestFixture,ExcludeFromCodeCoverage ]
    public class ReportingServiceTest
    {
        private AutoMock _mock;

        private IReportingService _reportingService; 

        [OneTimeSetUp]
        public void ClassSetUp()
        {
            _mock = AutoMock.GetLoose();
        }


        [OneTimeTearDown]
        public void ClassCleanUp()
        {

            _mock?.Dispose();
        }

        [SetUp]
        public void TestSetUp()
        {

        }

        [TearDown]
        public void TestCleanUp()
        {

        }

        [Test]

        public void StudentFineCheck_WhenCalledWithStudentId_ReturnFineAmountOfThatStudent()
        {
            // Arrange

            int studentId = 101;

            double fine = 20.00;


            var studentRepositoryMock = _mock.Mock<IStudentRepository>();
            var unitOfWorkLibraryService = _mock.Mock<IUnitOfWorkLibraryService>();

            studentRepositoryMock.Setup(x => x.CheckFine(studentId)).Returns(fine);

            unitOfWorkLibraryService.Setup(x => x.StudentRepository).Returns(studentRepositoryMock.Object);

            _reportingService = _mock.Create<ReportingService>
                (new TypedParameter(typeof(UnitOfWorkLibraryService), unitOfWorkLibraryService.Object));



            // Act

            _reportingService.StudentFineCheck(studentId);



            //Assert
            studentRepositoryMock.VerifyAll();


        }






    }
}
