//using Ara.SmartHSE.Application.Dtos.BLEGateways;
//using Ara.SmartHSE.Application.Entities.BLEBeacons.Commands.Create;
//using Ara.SmartHSE.Application.Entities.BLEGateways.Commands.Create;
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

//namespace Ara.SmartHSE.Application.UnitTests.Entities.BLEGateways.Commands.Create
//{
//    public class BLEGatewaysCreateHandlerTest : Language
//    {
//        #region Props

//        private readonly Mock<IModelRepository> _modelRepository;
//        private readonly Mock<IBLEGatewaysRepository> _bLEGatewaysRepository;
//        private Mock<ILogger> _logger;
//        private BLEGatewayCreateHandler _handler;
//        private BLEGatewayCreateCommand _request;
//        private BLEGateway _bLEGateway;

//        DateTime deliver = DateTime.Now;
//        #endregion

//        public BLEGatewaysCreateHandlerTest()
//        {
//            _modelRepository = new Mock<IModelRepository>();
//            _bLEGatewaysRepository = new Mock<IBLEGatewaysRepository>();
//            _logger = new Mock<ILogger>();
//            _handler = new BLEGatewayCreateHandler(_modelRepository.Object, _logger.Object, _sharedResources.Object, _bLEGatewaysRepository.Object);
//            _request = new BLEGatewayCreateCommand
//            {
//                IndexId = 1,
//                Status = Domain.Enum.StatusOfWatch.idle,
//                ModelId = Guid.NewGuid(),
//                MACAddress = "MAC",
//                LocalIpAddress= "LocalIpAddress",
//                Location = "aa",
//                //DeliverTime = DateTime.Now,
//                FirmwareVersion= "FirmwareVersion",
//                RequestBy = "RequestBy",

//            };
//            _bLEGateway = new BLEGateway
//            {
//                IndexId = _request.IndexId,
//                Status = Domain.Enum.StatusOfWatch.idle,
//                ModelId = _request.ModelId,
//                MACAddress = _request.MACAddress,
//                LocalIpAddress = _request.LocalIpAddress,
//                Location = _request.Location,
//                DeliverTime = _request.DeliverTime,
//                FirmwareVersion = _request.FirmwareVersion,
//                CreatedBy = "RequestBy",
//            };
//        }

//        #region Validation Request

//        [Fact]
//        [Trait("BLEGatewaysCreateHandlerTest", "Validation Request")]
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
//        [Trait("BLEGatewaysCreateHandlerTest", "Validation Request")]
//        public async Task Validation_MACAddress_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                _request.MACAddress = null;
//            else
//                _request.MACAddress = string.Empty;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("BLEGatewaysCreateHandlerTest", "Validation Request")]
//        public async Task Validation_LocalIpAddress_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                _request.LocalIpAddress = null;
//            else
//                _request.LocalIpAddress = string.Empty;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }


//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("BLEGatewaysCreateHandlerTest", "Validation Request")]
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

//        [Fact]
//        [Trait("BLEGatewaysCreateHandlerTest", "Validation Request")]
//        public async Task Validation_DeliverTime_Test()
//        {

//            //Arrange

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }


//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("BLEGatewaysCreateHandlerTest", "Validation Request")]
//        public async Task Validation_FirmwareVersion_Test(bool isNull)
//        {
//            _request.DeliverTime = deliver;
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
//        [Trait("BLEGatewaysCreateHandlerTest", "Exception")]
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
//        [Trait("BLEGatewaysCreateHandlerTest", "Check In db")]
//        public async Task NotValidModelId(bool isNull)
//        {

//            //Arrange
//            _request.DeliverTime = deliver;
//            Model model = new Model()
//            {
//                Deleted = true,
//            };
//            if (isNull)
//                model = null;

//            _modelRepository.Setup(s => s.GetByIdAsyncAndInclude(_request.ModelId)).ReturnsAsync(model);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        [Fact]
//        [Trait("BLEGatewaysCreateHandlerTest", "Check In db")]
//        public async Task FindThisMac()
//        {

//            //Arrange
//            _request.DeliverTime = deliver;
//            Model model = new Model()
//            {
//            };
//            _modelRepository.Setup(s => s.GetByIdAsyncAndInclude(_request.ModelId)).ReturnsAsync(model);

//            _bLEGatewaysRepository.Setup(s => s.FindBLEByMacAsync(_request.MACAddress)).ReturnsAsync(_bLEGateway);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }



//        [Fact]
//        [Trait("BLEGatewaysCreateHandlerTest", "Check In db")]
//        public async Task FindThisIndexId()
//        {

//            //Arrange
//            _request.DeliverTime = deliver;
//            Model model = new Model() { };
//            _bLEGateway = null;
//            _modelRepository.Setup(s => s.GetByIdAsyncAndInclude(_request.ModelId)).ReturnsAsync(model);
//            _bLEGatewaysRepository.Setup(s => s.FindBLEByMacAsync(_request.MACAddress)).ReturnsAsync(_bLEGateway);
//            _bLEGatewaysRepository.Setup(s => s.HasThisIndexId(_request.IndexId)).ReturnsAsync(true);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        #endregion

//        #region Create

//        [Fact]
//        [Trait("BLEGatewaysCreateHandlerTest", "Create")]
//        public async Task Create_Test()
//        {

//            //Arrange
//            _request.DeliverTime = deliver;
//            Model model = new Model()
//            {
//                Id = _request.ModelId,
//                ModelName = "Name",
//                Brand = new Brand { BrandName = "BrandName" }
//            };
//            BLEGateway bLE = new();

//            bLE = null;
//            _modelRepository.Setup(s => s.GetByIdAsyncAndInclude(_request.ModelId)).ReturnsAsync(model);
//            _bLEGatewaysRepository.Setup(s => s.FindBLEByMacAsync(_request.MACAddress)).ReturnsAsync(bLE);
//            _bLEGatewaysRepository.Setup(s => s.HasThisIndexId(_request.IndexId)).ReturnsAsync(false);
//            _bLEGatewaysRepository.Setup(s => s.AddAsync(It.IsAny<BLEGateway>())).ReturnsAsync(_bLEGateway);

//            //Act

//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert

//            _bLEGatewaysRepository.Verify(x => x.SaveChangesAsync(), Times.Once);

//            Assert.True(response.IsSuccessful);
//            Assert.NotNull(response.Data);
//            Assert.Equal(response.Data.IndexId, _bLEGateway.IndexId);
//            Assert.Equal(response.Data.Status, _bLEGateway.Status);
//            Assert.Equal(response.Data.MACAddress, _bLEGateway.MACAddress);
//            Assert.Equal(response.Data.LocalIpAddress, _bLEGateway.LocalIpAddress);
//            Assert.Equal(response.Data.Location, _bLEGateway.Location);
//            Assert.Equal(response.Data.DeliverTime, _bLEGateway.DeliverTime);
//            Assert.Equal(response.Data.FirmwareVersion, _bLEGateway.FirmwareVersion);
//            Assert.Equal(response.Data.Model, model.ModelName);
//            Assert.Equal(response.Data.Brand, model.Brand.BrandName);
//            Assert.Equal(response.Data.ModelId, _request.ModelId);


//        }

//        #endregion

//    }
//}
