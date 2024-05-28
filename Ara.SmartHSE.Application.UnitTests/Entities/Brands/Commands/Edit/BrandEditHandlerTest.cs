//using Ara.SmartHSE.Application.Entities.Brands.Commands.Create;
//using Ara.SmartHSE.Application.Entities.Brands.Commands.Edit;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Azure.Core;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Brands.Commands.Edit
//{
//    public class BrandEditHandlerTest : Language
//    {
//        private readonly Mock<IBrandRepository> _brandRepository;
//        private readonly Mock<ILogger> _logger;

//        private readonly BrandEditHandler _handler;

//        BrandEditCommand _request;


//        #region Ctor

//        public BrandEditHandlerTest()
//        {
//            _brandRepository = new Mock<IBrandRepository>();
//            _logger = new Mock<ILogger>();

//            _handler = new BrandEditHandler(_brandRepository.Object, _logger.Object, _sharedResources.Object);

//            _request = new BrandEditCommand()
//            {
//                Id=Guid.NewGuid(),
//                BrandName = "BrandName"
//            };
//        }

//        #endregion


//        #region Validation Request
//        [Fact]
//        [Trait("BrandEditHandlerTest", "Validation Request")]
//        public async Task Validation_Id_Test()
//        {

//            //Arrange

//                _request.Id= Guid.Empty;
//            //Act

//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }


//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("BrandEditHandlerTest", "Validation Request")]
//        public async Task Validation_BrandName_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                _request.BrandName = null;

//            else
//                _request.BrandName = string.Empty;
//            //Act

//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }

//        #endregion

//        #region Check Request In Db

//        [Fact]
//        [Trait("BrandEditHandlerTest", "Check Request In Db")]
//        public async Task HasThisName()
//        {
//            //Arrange

//            _brandRepository.Setup(s => s.ThisNameIsValid(_request.Id,_request.BrandName)).ReturnsAsync(true);
//            //Act

//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert

//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }


//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("BrandEditHandlerTest", "CheckRequestInDb")]
//        public async Task Not_Found_Brand_Test(bool isNull)
//        {
//            //Arrange
//            Brand brand = new Brand()
//            {

//            };
//            if (isNull)
//                brand = null;
//            else
//                brand.Deleted = true;
//            _brandRepository.Setup(s => s.GetByIdAsync(_request.Id)).ReturnsAsync(brand);

//            //Act

//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert

//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//            //Assert.Equal(MessageResponse.WatchId(), response.Message);
//        }







//        #endregion

//        #region Edit

//        [Fact]
//        [Trait("BrandEditHandlerTest", "CreateArea")]
//        public async Task Create_Test()
//        {
//            //Arrange
//            Brand brand = new Brand()
//            {

//            };
//            brand = null;

//            _brandRepository.Setup(s => s.ThisNameIsValid(_request.Id, _request.BrandName)).ReturnsAsync(false);
//            _brandRepository.Setup(u => u.GetByIdAsync(_request.Id)).Returns(Task.FromResult(new Brand() { Deleted=false}));


//            //Act

//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            _brandRepository.Verify(x => x.SaveChangesAsync(), Times.Once);
//            Assert.True(response.IsSuccessful);
//            Assert.True(response.Data);

//        }
//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("BrandEditHandlerTest", "Exception")]
//        public async Task Exception_Test()
//        {

//            //Arrange


//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }
//        #endregion


//    }
//}
