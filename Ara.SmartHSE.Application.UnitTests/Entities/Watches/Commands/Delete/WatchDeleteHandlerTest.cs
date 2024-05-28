//using Ara.SmartHSE.Application.Entities.Watches.Commands.Delete;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Watches.Commands.Delete
//{
//    public class WatchDeleteHandlerTest : Language
//    {
//        #region Fields

//        private readonly Mock<IWatchRepository> mock    ;
//        private readonly Mock<ILogger> _logger;
//        private readonly WatchDeleteHandler _handler;
//        WatchDeleteCommand _mainRequest;
//        Guid mainGuid = Guid.NewGuid();
//        Watch watch;

//        #endregion

//        #region Ctor

//        public WatchDeleteHandlerTest()
//        {
//            mock = new Mock<IWatchRepository>();
//            _logger = new Mock<ILogger>();
//            _handler = new WatchDeleteHandler(mock.Object, _logger.Object, _sharedResources.Object);
//            _mainRequest = new WatchDeleteCommand
//            {
//                WatchId = mainGuid,

//            };
//            watch = new Watch
//            {
//                //Id = mainGuid,
//                //Brand = "CN",
//                //Model = "m",
//                LoRaDevEUI = "LoRaDevEUI",
//                AppKey = "AppKey",
//                MACAddress = "MACAddress",
//                NetworkKey = "NetworkKey"
//            };
//        }
//        #endregion

//        #region Validation Request

//        [Fact]
//        [Trait("WatchDeleteHandlerTest", "ValidationRequest")]
//        public async Task Validation_Id_Test()
//        {

//            //Arrange
//            _mainRequest.WatchId = Guid.Empty;

//            //Act
//            var response = await _handler.Handle(_mainRequest, new CancellationToken());
//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//            //Assert.Equal(MessageResponse.WatchId(), response.Message);
//        }

//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("WatchDeleteHandlerTest", "Exception")]

//        public async Task Exception_Test()
//        {

//            //Arrange

//            //Act
//            var response = await _handler.Handle(_mainRequest, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//            //Assert.Equal(MessageResponse.Exception(), response.Message);
//        }
//        #endregion


//        #region Check Request In Db

//        [Fact]
//        [Trait("WatchDeleteHandler", "CheckRequestInDb")]
//        public async Task Not_Found_Watch_Test()
//        {
//            //Arrange

//            watch = null;
//            mock.Setup(s => s.GetByIdAsync(mainGuid)).ReturnsAsync(watch);

//            //Act

//            var response = await _handler.Handle(_mainRequest, new CancellationToken());

//            //Assert

//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//            //Assert.Equal(MessageResponse.WatchId(), response.Message);
//        }
//        [Fact]
//        [Trait("WatchDeleteHandler", "CheckRequestInDb")]
//        public async Task Found_Watch_And_It_Was_Delete_Test()
//        {
//            //Arrange
//            watch.Deleted = true;

//            mock.Setup(s => s.GetByIdAsync(mainGuid)).ReturnsAsync(watch);

//            //Act

//            var response = await _handler.Handle(_mainRequest, new CancellationToken());

//            //Assert

//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//            //Assert.Equal(MessageResponse.WatchId(), response.Message);
//        }


//        #endregion


//        #region Delete

//        [Fact]
//        [Trait("WatchDeleteHandler", "Delete")]
//        public async Task Delete_Test()
//        {
//            //Arrange
//            mock.Setup(s => s.GetByIdAsync(mainGuid)).ReturnsAsync(watch);

//            //Act

//            var response = await _handler.Handle(_mainRequest, new CancellationToken());

//            //Assert
//            mock.Verify(s => s.SaveChangesAsync(), Times.Once);
//            Assert.True(response.IsSuccessful);
//            Assert.True(response.Data);
//            //Assert.Equal(MessageResponse.OKMessage("حذف دستگاه"), response.Message);
//        }
//        #endregion
//    }
//}
