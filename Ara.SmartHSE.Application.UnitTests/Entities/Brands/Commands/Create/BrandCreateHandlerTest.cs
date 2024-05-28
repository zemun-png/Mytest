//using Ara.SmartHSE.Application.Entities.Areas.Commands.Create;
//using Ara.SmartHSE.Application.Entities.Brands.Commands.Create;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Brands.Commands.Create
//{
//    public class BrandCreateHandlerTest : Language
//    {


//        private readonly Mock<IBrandRepository> _brandRepository;
//        private readonly Mock<ILogger> _logger;

//        private readonly BrandCreateHandler _handler;

//        BrandCreateCommand _request;
//        Brand _brand;

//        #region Ctor

//        public BrandCreateHandlerTest()
//        {
//            _brandRepository = new Mock<IBrandRepository>();
//            _logger = new Mock<ILogger>();

//            _handler = new BrandCreateHandler(_brandRepository.Object, _logger.Object, _sharedResources.Object);

//            _request = new BrandCreateCommand()
//            {
//                BrandName = "BrandName"
//            };
//            _brand = new Brand() 
//            {
//                BrandName= _request.BrandName
//            };
//        }

//        #endregion


//        #region Validation Request

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("BrandCreateHandlerTest", "Validation Request")]
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
//        [Trait("BrandCreateHandlerTest", "Check Request In Db")]
//        public async Task HasThisName()
//        {
//            //Arrange

//            _brandRepository.Setup(s => s.HasThisName(_request.BrandName)).ReturnsAsync(_brand);
//            //Act

//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert

//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }
//        #endregion

//        #region Create

//        [Fact]
//        [Trait("BrandCreateHandlerTest", "CreateArea")]
//        public async Task Create_Test()
//        {
//            //Arrange

//            _brand = null;

//            _brandRepository.Setup(s => s.HasThisName(_request.BrandName)).ReturnsAsync(_brand);
//            _brandRepository.Setup(u => u.AddAsync(It.IsAny<Brand>())).Returns(Task.FromResult(new Brand()));


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
//        [Trait("BrandCreateHandlerTest", "Exception")]
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
