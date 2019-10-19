using Autofac;
using Autofac.Extras.Moq;
using LibraryWebAPI.Store.IRepositories;
using LibraryWebAPI.Store.IServices;
using LibraryWebAPI.Store.Services;
using NUnit.Framework;
using Shouldly;
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
            
        }


        [OneTimeTearDown]
        public void ClassCleanUp()
        {

           
        }

        [SetUp]
        public void TestSetUp()
        {
            _mock = AutoMock.GetLoose();
        }

        [TearDown]
        public void TestCleanUp()
        {
            _mock?.Dispose();
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


        [Test]
        public void CalculateFine_WhenCalledWithStudentId_ReturnStudentFine()
        {

            // Arrange
            int studentId = 1618017;
            DateTime issueDate = Convert.ToDateTime("10/19/2019");
            DateTime returnDate = Convert.ToDateTime("10/29/2019");
            double Fine = 20.00;

            var bookIssueRepositoryMock = _mock.Mock<IBookIssueRepository>();
            var returnBookRepositoryMock = _mock.Mock<IReturnBookRepository>();
            var studentRepositoryMock = _mock.Mock<IStudentRepository>();
            var unitOfWorkLibraryService = _mock.Mock<IUnitOfWorkLibraryService>();

            bookIssueRepositoryMock.Setup(x => x.GetBookIssueDate(studentId)).Returns(issueDate);
            returnBookRepositoryMock.Setup(x => x.GetBookReturnDate(studentId)).Returns(returnDate);
            studentRepositoryMock.Setup(x => x.SetStudentFine(studentId, Fine));

            unitOfWorkLibraryService.Setup(x => x.BookIssueRepositor).Returns(bookIssueRepositoryMock.Object);
            unitOfWorkLibraryService.Setup(x => x.ReturnBookRepository).Returns(returnBookRepositoryMock.Object);
            unitOfWorkLibraryService.Setup(x => x.StudentRepository).Returns(studentRepositoryMock.Object);

            _reportingService = _mock.Create<ReportingService>
                (new TypedParameter(typeof(UnitOfWorkLibraryService), unitOfWorkLibraryService.Object));

            // Act
            var actualFine =  _reportingService.CalculateFine(studentId);



            // Assert
            actualFine.ShouldBe(Fine);

        }







    }
}
