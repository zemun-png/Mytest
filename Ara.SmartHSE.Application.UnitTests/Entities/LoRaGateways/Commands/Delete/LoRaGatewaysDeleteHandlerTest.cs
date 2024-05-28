//using Ara.SmartHSE.Application.Entities.LoRaGateways.Commands.Delete;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.LoRaGateways.Commands.Delete
//{
//    public class LoRaGatewaysDeleteHandlerTest : Language
//    {
//        #region Props

//        private readonly Mock<ILoRaGatewayRepository> _loRaGatewayRepository;
//        private readonly Mock<ILogger> _logger;
//        private readonly LoRaGatewaysDeleteHandler _handler;
//        LoRaGatewaysDeleteCommand _request;
//        LoRaGateway _loRaGateway;

//        #endregion

//        #region Ctor

//        public LoRaGatewaysDeleteHandlerTest()
//        {
//            _loRaGatewayRepository = new Mock<ILoRaGatewayRepository>();
//            _logger = new Mock<ILogger>();

//            _handler = new LoRaGatewaysDeleteHandler(_loRaGatewayRepository.Object, _logger.Object, _sharedResources.Object);
//            _request = new LoRaGatewaysDeleteCommand()
//            {
//                LoRaGatewayId = Guid.NewGuid(),
//            };
//            _loRaGateway = new LoRaGateway
//            {
//                Id = _request.LoRaGatewayId,
//            };
//        }

//        #endregion

//        #region Validation Request

//        [Fact]
//        [Trait("LoRaGatewaysDeleteHandlerTest", "Validation Request")]
//        public async Task Validation_Id_Test()
//        {

//            //Arrange
//            _request.LoRaGatewayId = Guid.Empty;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }
//        #endregion

//        #region Check Request In Db

//        [Fact]
//        [Trait("LoRaGatewaysDeleteHandlerTest", "Check Request In Db")]
//        public async Task Valid_LoRaGateways_Test()
//        {
//            //Arrange
//            _loRaGatewayRepository.Setup(s => s.GetByIdAsync(Guid.NewGuid())).ReturnsAsync(_loRaGateway);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }

//        [Fact]
//        [Trait("LoRaGatewaysDeleteHandlerTest", "Check Request In Db")]
//        public async Task Valid_LoRaGateways_Test_Two()
//        {
//            //Arrange
//            _loRaGateway.Deleted = true;

//            _loRaGatewayRepository.Setup(s => s.GetByIdAsync(_request.LoRaGatewayId)).ReturnsAsync(_loRaGateway);
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
//        [Trait("LoRaGatewaysDeleteHandlerTest", "Exception")]
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
//        [Trait("LoRaGatewaysDeleteHandlerTest", "Delete")]

//        public async Task Delete_Personnel_Test()
//        {

//            //Arrange

//            _loRaGatewayRepository.Setup(s => s.GetByIdAsync(_request.LoRaGatewayId)).ReturnsAsync(_loRaGateway);
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());
//            //Assert
//            _loRaGatewayRepository.Verify(x => x.SaveChangesAsync(), Times.Once);

//            Assert.True(response.IsSuccessful);
//            Assert.True(response.Data);
//        }

//        #endregion

//    }
//}
