using Autofac;
using Autofac.Extras.Moq;
using LibraryWebAPI.Core;
using LibraryWebAPI.Store.IRepositories;
using LibraryWebAPI.Store.IServices;
using LibraryWebAPI.Store.Repositories;
using LibraryWebAPI.Store.Services;
using Moq;
using NUnit.Framework;
using Shouldly;
using System.Diagnostics.CodeAnalysis;

namespace LibraryWebAPI.Store.Tests
{
    [TestFixture, ExcludeFromCodeCoverage]
    public class BookServiceTest
    {

        //private ContainerBuilder _builder;
        //private IContainer _container;

        private IBookService _bookService;
        private AutoMock _mock;
        


        public BookServiceTest()
        {
            //_builder.RegisterType<BookService>().As<IBookService>()
            //    .WithParameter(new TypedParameter(typeof(IBookRepository), new Mock<IBookRepository>().Object));

            //_container = _builder.Build();

        }







        [OneTimeSetUp ]
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
        public void GetBookDetails_WhenCallWithBookId_ReturnsBookOfThatId()
        {

            // Arrange

            var bookId = 101;

            var book = new Book
            {
                BookId = 101,
                Title = " C# Book ",
                Aurthor = " Gaonkar ",
                Edition = "5th",
                Barcode = "C#",
                CopyCount = 3
            };


             _mock.Mock<IBookRepository>().Setup(x => x.GetBookDetails(bookId)).Returns(book);


             _bookService = _mock.Create<BookService>();



            // Act

             var actualBook = _bookService.GetDetails(bookId);


            //Asseret

            //_mock.Mock<IBookRepository>().Verify(x => x.GetBookDetails(bookId));
            // Assert.AreEqual(book, actualBook);

            Should.Equals(book, actualBook);



        }





    }
}
