//using Ara.SmartHSE.Application.Entities.Areas.Commands.Delete;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Areas.Commands.Delete
//{
//    public class AreaDeleteHandlerTest : Language
//    {

//        #region Props

//        private readonly Mock<IAreaRepository> _areaRepository;
//        private readonly Mock<ILogger> _logger;
//        private readonly AreaDeleteHandler _handler;
//        AreaDeleteCommand request;
//        #endregion

//        public AreaDeleteHandlerTest()
//        {
//            _areaRepository = new Mock<IAreaRepository>();
//            _logger = new Mock<ILogger>();
//            _handler = new AreaDeleteHandler(_areaRepository.Object, _logger.Object, _sharedResources.Object);
//            request = new AreaDeleteCommand()
//            {
//                Id = Guid.NewGuid(),
//            };
//        }

//        #region Validation Request

//        [Fact]
//        [Trait("AreaDeleteHandler", "Validation Request")]

//        public async Task ValidationAreaId()
//        {

//            //Arrange
//            request.Id = Guid.Empty;

//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(false);
//            //Assert.Equal(MessageResponse.UnValidContractorId(), response.Message);
//        }
//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("AreaDeleteHandler", "Exception")]
//        public async Task Exception_Test()
//        {

//            //Arrange

//            request = null;
//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//            //Assert.Equal(MessageResponse.Exception(), response.Message);
//        }
//        #endregion

//        #region Check In Db


//        [Fact]
//        [Trait("AreaDeleteHandler", "CheckRequestInDb")]
//        public async Task Not_Found_Area_Test()
//        {
//            //Arrange
//            Area area = new Area()
//            {

//            };
//            area = null;
//            _areaRepository.Setup(s => s.GetByIdAsync(request.Id)).ReturnsAsync(area);

//            //Act

//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert

//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//            //Assert.Equal(MessageResponse.WatchId(), response.Message);
//        }
//        [Fact]
//        [Trait("AreaDeleteHandler", "CheckRequestInDb")]
//        public async Task Found_Area_And_It_Was_Delete_Test()
//        {
//            //Arrange
//            Area area = new Area()
//            {

//            };
//            area.Deleted = true;

//            _areaRepository.Setup(s => s.GetByIdAsync(request.Id)).ReturnsAsync(area);

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
//        [Trait("AreaDeleteHandler", "Delete")]
//        public async Task Delete_Test()
//        {
//            Area area = new Area()
//            {

//            };

//            _areaRepository.Setup(s => s.GetByIdAsync(request.Id)).ReturnsAsync(area);

//            //Act

//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert
//            _areaRepository.Verify(s => s.SaveChangesAsync(), Times.Once);
//            Assert.True(response.IsSuccessful);
//            Assert.True(response.Data);
//            //Assert.Equal(MessageResponse.OKMessage("حذف"), response.Message);
//        }
//        #endregion


//    }

//}
