//using Ara.SmartHSE.Application.Entities.LoRaGateways.Commands.Edit;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.LoRaGateways.Commands.Edit
//{
//    public class LoRaGatewaysEditHandlerTest : Language
//    {
//        #region Props

//        private readonly Mock<IModelRepository> _modelRepository;
//        private readonly Mock<ILoRaGatewayRepository> _loRaGatewayRepository;
//        private Mock<ILogger> _logger;
//        private LoRaGatewaysEditHandler _handler;
//        private LoRaGatewaysEditCommand _request;
//        private LoRaGateway _loRaGateway;
//        #endregion

//        public LoRaGatewaysEditHandlerTest()
//        {
//            _modelRepository = new Mock<IModelRepository>();
//            _loRaGatewayRepository = new Mock<ILoRaGatewayRepository>();
//            _logger = new Mock<ILogger>();
//            _handler = new LoRaGatewaysEditHandler(_modelRepository.Object, _logger.Object, _sharedResources.Object, _loRaGatewayRepository.Object);
//            _request = new LoRaGatewaysEditCommand
//            {
//                LoRaGatewayId = Guid.NewGuid(),
//                IndexId = 1,
//                DeliverTime = DateTime.Now,
//                FirmwareVersion = "a",
//                Location = "aa",
//                ModelId = Guid.NewGuid(),
//                Status = Domain.Enum.StatusOfWatch.idle,
//                GatewayEUI = "GatewayEUI",
//                SerialNumber = "SerialNumber",
//                RequestBy = "RequestBy"
//            };
//            _loRaGateway = new LoRaGateway
//            {
//                IndexId = _request.IndexId,
//                DeliverTime = _request.DeliverTime,
//                FirmwareVersion = _request.FirmwareVersion,
//                Location = _request.Location,
//                ModelId = _request.ModelId,
//                Status = Domain.Enum.StatusOfWatch.idle,
//                GatewayEUI = _request.GatewayEUI,
//                SerialNumber = _request.SerialNumber,
//                CreatedBy = "RequestBy",
//            };
//        }

//        #region Validation Request
//        [Fact]
//        [Trait("LoRaGatewaysEditHandlerTest", "Validation Request")]
//        public async Task Validation_Id_Test()
//        {

//            //Arrange

//            _request.LoRaGatewayId = Guid.Empty;
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        [Fact]
//        [Trait("LoRaGatewaysEditHandlerTest", "Validation Request")]
//        public async Task Validation_ModelId_Test()
//        {

//            //Arrange

//            _request.ModelId = Guid.Empty;
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("LoRaGatewaysEditHandlerTest", "Validation Request")]

//        public async Task Validation_SerialNumber_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                _request.SerialNumber = null;
//            else
//                _request.SerialNumber = string.Empty;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }
//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("LoRaGatewaysEditHandlerTest", "Validation Request")]

//        public async Task Validation_GatewayEUI_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                _request.GatewayEUI = null;
//            else
//                _request.GatewayEUI = string.Empty;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }
//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("LoRaGatewaysEditHandlerTest", "Validation Request")]

//        public async Task Validation_Location_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                _request.Location = null;
//            else
//                _request.Location = string.Empty;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("LoRaGatewaysEditHandlerTest", "Validation Request")]

//        public async Task Validation_FirmwareVersion_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                _request.FirmwareVersion = null;
//            else
//                _request.FirmwareVersion = string.Empty;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);

//        }

//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("LoRaGatewaysEditHandlerTest", "Exception")]
//        public async Task Exception_Test()
//        {

//            //Arrange

//            _request = null;
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }
//        #endregion


//        #region Check In db

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("LoRaGatewaysEditHandlerTest", "Check In db")]
//        public async Task NotValidModelId(bool isNull)
//        {

//            //Arrange
//            Model model = new Model()
//            {
//                Deleted = true,
//            };
//            if (isNull)
//                model = null;

//            _modelRepository.Setup(s => s.GetByIdAsync(_request.ModelId)).ReturnsAsync(model);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }


//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("LoRaGatewaysEditHandlerTest", "Check In db")]
//        public async Task NotFoundLoRa(bool isNull)
//        {

//            //Arrange
//            LoRaGateway loRaGateway = new LoRaGateway
//            {
//                Deleted = true,
//            };
//            if (isNull)
//                loRaGateway = null;
//            Model model = new Model()
//            {
//                Id = _request.ModelId,
//            };


//            _modelRepository.Setup(s => s.GetByIdAsync(_request.ModelId)).ReturnsAsync(model);
//            _loRaGatewayRepository.Setup(s => s.GetByIdAsync(_request.ModelId)).ReturnsAsync(loRaGateway);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }





//        [Fact]
//        [Trait("LoRaGatewaysEditHandlerTest", "Check In db")]
//        public async Task FindThisIndexId()
//        {

//            //Arrange
//            LoRaGateway loragateway = new LoRaGateway() { };
//            Model model = new Model() { };
//            _modelRepository.Setup(s => s.GetByIdAsync(_request.ModelId)).ReturnsAsync(model);
//            _loRaGatewayRepository.Setup(s => s.GetByIdAsync(_request.LoRaGatewayId)).ReturnsAsync(loragateway);
//            _loRaGatewayRepository.Setup(s => s.HasThisIndexId(_request.LoRaGatewayId, _request.IndexId)).ReturnsAsync(true);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }








//        [Fact]
//        [Trait("LoRaGatewaysEditHandlerTest", "Check In db")]
//        public async Task FindThisSerial()
//        {

//            //Arrange
//            LoRaGateway loragateway = new LoRaGateway() { };
//            Model model = new Model()
//            {
//                Id = _request.ModelId
//            };

//            _modelRepository.Setup(s => s.GetByIdAsync(_request.ModelId)).ReturnsAsync(model);
//            _loRaGatewayRepository.Setup(s => s.GetByIdAsync(_request.LoRaGatewayId)).ReturnsAsync(loragateway);
//            _loRaGatewayRepository.Setup(s => s.HasThisIndexId(_request.LoRaGatewayId, _request.IndexId)).ReturnsAsync(false);
//            _loRaGatewayRepository.Setup(s => s.FindLoRaBySerialNumAndLoRaIdAsync(_request.SerialNumber, _request.LoRaGatewayId)).ReturnsAsync(loragateway);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }




//        #endregion


//        #region Edit

//        [Fact]
//        [Trait("LoRaGatewaysEditHandlerTest", "Edit")]
//        public async Task Edit_Test()
//        {

//            //Arrange
//            LoRaGateway loragateway = new LoRaGateway() { };
//            Model model = new Model()
//            {
//                Id = _request.ModelId,
//                Brand = new Brand { BrandName = "BrandName" },
//                ModelName = "ModelName",
//            };

//            _modelRepository.Setup(s => s.GetByIdAsync(_request.ModelId)).ReturnsAsync(model);
//            _loRaGatewayRepository.Setup(s => s.GetByIdAsync(_request.LoRaGatewayId)).ReturnsAsync(loragateway);
//            _loRaGatewayRepository.Setup(s => s.HasThisIndexId(_request.LoRaGatewayId, _request.IndexId)).ReturnsAsync(false);
//            loragateway = null;
//            _loRaGatewayRepository.Setup(s => s.FindLoRaBySerialNumAndLoRaIdAsync(_request.SerialNumber, _request.LoRaGatewayId)).ReturnsAsync(loragateway);

//            //Act

//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert

//            _loRaGatewayRepository.Verify(x => x.SaveChangesAsync(), Times.Once);

//            Assert.True(response.IsSuccessful);
//            Assert.NotNull(response.Data);
//            Assert.Equal(response.Data.IndexId, _loRaGateway.IndexId);
//            Assert.Equal(response.Data.DeliverTime, _loRaGateway.DeliverTime);
//            Assert.Equal(response.Data.FirmwareVersion, _loRaGateway.FirmwareVersion);
//            Assert.Equal(response.Data.Location, _loRaGateway.Location);
//            Assert.Equal(response.Data.ModelId, _request.ModelId);
//            Assert.Equal(response.Data.Status, _loRaGateway.Status);
//            Assert.Equal(response.Data.GatewayEUI, _loRaGateway.GatewayEUI);
//            Assert.Equal(response.Data.SerialNumber, _loRaGateway.SerialNumber);


//        }

//        #endregion

//    }
//}
