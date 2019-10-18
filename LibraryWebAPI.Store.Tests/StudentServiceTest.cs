using Autofac;
using Autofac.Extras.Moq;
using LibraryWebAPI.Core;
using LibraryWebAPI.Store.IRepositories;
using LibraryWebAPI.Store.IServices;
using LibraryWebAPI.Store.Services;
using Moq;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace LibraryWebAPI.Store.Tests
{
    [TestFixture, ExcludeFromCodeCoverage]
    public class StudentServiceTest
    {
      
        private IStudentService _studentService;
        private AutoMock _mock; 

  



        [OneTimeSetUp]
        public void ClassSetUp()
        {
            _mock = AutoMock.GetLoose();
        }

        [OneTimeTearDown]
        public void ClassCLeanUp()
        {
            _mock?.Dispose();
        }


        [SetUp]
        public void TestSetup()
        {

            

        }

        [TearDown]
        public void TestCleanUp()
        {

        }


        [Test]
        public void AddStudent_WhenCalledWithStudent_InsertTheStudent()
        {
            //Arrange

            var student = new Student
            {
                StudentId = 1618023,
                Name = "Sariful",
                Fine = 0.0

            };

            var _demoStudentRepository = _mock.Mock<IStudentRepository>();

            _demoStudentRepository.Setup(x => x.EnterStudent(student));

            _studentService = _mock.Create<StudentService>();


            // Act
            _studentService.AddStudent(student);


            //Assert

            _demoStudentRepository.VerifyAll();
        }
    }
}