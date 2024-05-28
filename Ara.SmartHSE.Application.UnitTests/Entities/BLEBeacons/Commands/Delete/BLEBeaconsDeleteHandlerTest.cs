//using Ara.SmartHSE.Application.Entities.BLEBeacons.Commands.Delete;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.BLEBeacons.Commands.Delete
//{
//    public class BLEBeaconsDeleteHandlerTest : Language
//    {
//        #region Props

//        private readonly Mock<IBLEBeaconRepository> _bLEBeaconRepository;
//        private readonly Mock<ILogger> _logger;
//        private readonly BLEBeaconsDeleteHandler _handler;
//        BLEBeaconsDeleteCommand _request;
//        BLEBeacon _bLEBeacon;

//        #endregion

//        #region Ctor

//        public BLEBeaconsDeleteHandlerTest()
//        {
//            _bLEBeaconRepository = new Mock<IBLEBeaconRepository>();
//            _logger = new Mock<ILogger>();

//            _handler = new BLEBeaconsDeleteHandler(_bLEBeaconRepository.Object, _logger.Object, _sharedResources.Object);
//            _request = new BLEBeaconsDeleteCommand()
//            {
//                BLEBeaconId = Guid.NewGuid(),
//            };
//            _bLEBeacon = new BLEBeacon
//            {
//                Id = _request.BLEBeaconId,
//            };
//        }

//        #endregion

//        #region Validation Request

//        [Fact]
//        [Trait("BLEBeaconsDeleteHandlerTest", "Validation Request")]
//        public async Task Validation_Id_Test()
//        {

//            //Arrange
//            _request.BLEBeaconId = Guid.Empty;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }
//        #endregion

//        #region Check Request In Db

//        [Fact]
//        [Trait("BLEBeaconsDeleteHandlerTest", "Check Request In Db")]
//        public async Task Valid_LoRaGateways_Test()
//        {
//            //Arrange
//            _bLEBeaconRepository.Setup(s => s.GetByIdAsync(Guid.NewGuid())).ReturnsAsync(_bLEBeacon);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }

//        [Fact]
//        [Trait("BLEBeaconsDeleteHandlerTest", "Check Request In Db")]
//        public async Task Valid_LoRaGateways_Test_Two()
//        {
//            //Arrange
//            _bLEBeacon.Deleted = true;

//            _bLEBeaconRepository.Setup(s => s.GetByIdAsync(_request.BLEBeaconId)).ReturnsAsync(_bLEBeacon);
//            // _unitOfWork.Setup(s => s.LoRaGatewayRepository.GetByIdAsync(_loRaGateway.Id)).ReturnsAsync(_loRaGateway);


//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }

//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("BLEBeaconsDeleteHandlerTest", "Exception")]
//        public async Task Exception_Test()
//        {

//            //Arrange

//            _request = null;
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }
//        #endregion

//        #region Delete

//        [Fact]
//        [Trait("BLEBeaconsDeleteHandlerTest", "Delete")]

//        public async Task Delete_Test()
//        {

//            //Arrange

//            _bLEBeaconRepository.Setup(s => s.GetByIdAsync(_request.BLEBeaconId)).ReturnsAsync(_bLEBeacon);
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());
//            //Assert
//            _bLEBeaconRepository.Verify(x => x.SaveChangesAsync(), Times.Once);

//            Assert.True(response.IsSuccessful);
//            Assert.True(response.Data);
//        }

//        #endregion

//    }
//}
