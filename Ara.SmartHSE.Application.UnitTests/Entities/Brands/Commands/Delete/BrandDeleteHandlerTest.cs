//using Ara.SmartHSE.Application.Entities.Areas.Commands.Delete;
//using Ara.SmartHSE.Application.Entities.Brands.Commands.Delete;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Brands.Commands.Delete
//{
//    public class BrandDeleteHandlerTest : Language
//    {
//        #region Props

//        private readonly Mock<IBrandRepository> _brandRepository;
//        private readonly Mock<ILogger> _logger;
//        private readonly BrandDeleteHandler _handler;
//        BrandDeleteCommand request;
//        #endregion

//        public BrandDeleteHandlerTest()
//        {
//            _brandRepository = new Mock<IBrandRepository>();
//            _logger = new Mock<ILogger>();
//            _handler = new BrandDeleteHandler(_brandRepository.Object, _logger.Object, _sharedResources.Object);
//            request = new BrandDeleteCommand()
//            {
//                Id = Guid.NewGuid(),
//            };
//        }

//        #region Validation Request

//        [Fact]
//        [Trait("BrandDeleteHandlerTest", "Validation Request")]

//        public async Task Validation_Id()
//        {

//            //Arrange
//            request.Id = Guid.Empty;

//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(false);
//        }
//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("BrandDeleteHandlerTest", "Exception")]
//        public async Task Exception_Test()
//        {

//            //Arrange

//            request = null;
//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }
//        #endregion

//        #region Check In Db


//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("BrandDeleteHandlerTest", "CheckRequestInDb")]
//        public async Task Not_Found_Brand_Test( bool isNull)
//        {
//            //Arrange
//            Brand brand = new Brand()
//            {

//            };
//            if (isNull)
//                brand = null;
//            else
//             brand.Deleted = true;
//            _brandRepository.Setup(s => s.GetByIdAsync(request.Id)).ReturnsAsync(brand);

//            //Act

//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert

//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//            //Assert.Equal(MessageResponse.WatchId(), response.Message);
//        }
//        #endregion
//        #region Delete

//        [Fact]
//        [Trait("BrandDeleteHandlerTest", "Delete")]
//        public async Task Delete_Test()
//        {
//            Brand brand = new Brand()
//            {

//            };

//            _brandRepository.Setup(s => s.GetByIdAsync(request.Id)).ReturnsAsync(brand);

//            //Act

//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert
//            _brandRepository.Verify(s => s.SaveChangesAsync(), Times.Once);
//            Assert.True(response.IsSuccessful);
//            Assert.True(response.Data);
//        }
//        #endregion

//    }
//}
