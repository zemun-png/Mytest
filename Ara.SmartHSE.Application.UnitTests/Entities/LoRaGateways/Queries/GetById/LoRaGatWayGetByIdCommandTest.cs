//using Ara.SmartHSE.Application.Dtos;
//using Ara.SmartHSE.Application.Entities.EquipmentDetailses;
//using Ara.SmartHSE.Application.Entities.LoRaGateways.Queries.GetById;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Application.Interfaces.Repositories.UnitOfWork;
//using Ara.SmartHSE.Application.Resource;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Microsoft.Extensions.Localization;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.LoRaGateways.Queries.GetById
//{
//    public class LoRaGatWayGetByIdCommandTest : Language
//    {
//        #region Props

//        private readonly Mock<ILoRaGatewayRepository> _loRaGatewayRepository;
//        private readonly Mock<IEquipmentDetailsManager> _equipmentDetailsManager;
//        private readonly Mock<ILogger> _logger;
//        private readonly LoRaGatWayGetByIdHandler _handler;
//        private LoRaGatWayGetByIdQuery _request;
//        private LoRaGateway _loRaGateway;

//        #endregion

//        public LoRaGatWayGetByIdCommandTest()
//        {
//            _loRaGatewayRepository = new Mock<ILoRaGatewayRepository>();
//            _equipmentDetailsManager = new Mock<IEquipmentDetailsManager>();
//            _logger = new Mock<ILogger>();
//            _handler = new LoRaGatWayGetByIdHandler(_loRaGatewayRepository.Object, _logger.Object, _sharedResources.Object, _equipmentDetailsManager.Object);
//            _request = new LoRaGatWayGetByIdQuery() { LoRaGatWayId = Guid.NewGuid(), RequestBy = "request" };
//            _loRaGateway = new LoRaGateway
//            {
//                AliasName = "a",
//                Id = _request.LoRaGatWayId,
//                Firmware = "a",
//                GatewayID = "a",
//                GatewayEUI = "a",
//                Lat = $"a",
//                Long = $"a",
//                //Model = "a",
//                NetworkIP = "a",
//                SerialNumber = "a",
//            };
//        }

//        #region Validation Request

//        [Fact]

//        [Trait("LoRaGatWayGetByIdCommandTest", "Validation Request")]

//        public async Task Validation_LoRaGatWayId_Test()
//        {

//            //Arrange
//            _request.LoRaGatWayId = Guid.Empty;


//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            Assert.Equal(MessageResponse.LoRaGatewayId(), response.Message);
//        }

//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("LoRaGatWayGetByIdCommandTest", "Exception")]
//        public async Task Exception_Test()
//        {

//            //Arrange

//            _request = null;
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            Assert.Equal(MessageResponse.Exception(), response.Message);
//        }
//        #endregion

//        #region Check Request In Db


//        [Fact]
//        [Trait("LoRaGatWayGetByIdCommandTest", "Check Request In Db")]
//        public async Task Valid_LoRaGateways_Test()
//        {
//            //Arrange
//            _unitOfWork.Setup(s => s.LoRaGatewayRepository.GetByIdAsync(Guid.NewGuid())).ReturnsAsync(_loRaGateway);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            Assert.Equal(MessageResponse.NoData(), response.Message);
//        }

//        [Fact]
//        [Trait("LoRaGatWayGetByIdCommandTest", "Check Request In Db")]
//        public async Task Valid_LoRaGateways_Test_Two()
//        {
//            //Arrange
//            _loRaGateway.Deleted = true;

//            _unitOfWork.Setup(s => s.LoRaGatewayRepository.GetByIdAsync(_loRaGateway.Id)).ReturnsAsync(_loRaGateway);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            Assert.Equal(MessageResponse.NoData(), response.Message);
//        }

//        #endregion

//        #region GetById

//        [Fact]
//        [Trait("LoRaGatWayGetByIdCommandTest", "GetById")]
//        public async Task GetById_Test()
//        {
//            //Arrange

//            _unitOfWork.Setup(s => s.LoRaGatewayRepository.GetByIdAsync(_request.LoRaGatWayId)).ReturnsAsync(_loRaGateway);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.True(response.IsSuccessful);
//            Assert.NotNull(response.Data);
//            Assert.Equal(MessageResponse.HasData(), response.Message);

//            Assert.Equal(response.Data.AliasName, _loRaGateway.AliasName);
//            Assert.Equal(response.Data.Firmware, _loRaGateway.Firmware);
//            Assert.Equal(response.Data.GatewayEUI, _loRaGateway.GatewayEUI);
//            Assert.Equal(response.Data.GatewayID, _loRaGateway.GatewayID);
//            Assert.Equal(response.Data.Id, _loRaGateway.Id);
//            Assert.Equal(response.Data.Lat, _loRaGateway.Lat);
//            Assert.Equal(response.Data.Long, _loRaGateway.Long);
//            //Assert.Equal(response.Data.Model, _loRaGateway.Model);
//            Assert.Equal(response.Data.NetworkIP, _loRaGateway.NetworkIP);
//            Assert.Equal(response.Data.SerialNumber, _loRaGateway.SerialNumber);

//        }

//        #endregion
//    }
//}
