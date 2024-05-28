//using Ara.SmartHSE.Application.Entities.BLEBeacons.Commands.Edit;
//using Ara.SmartHSE.Application.Entities.BLEGateways.Commands.Edit;
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

//namespace Ara.SmartHSE.Application.UnitTests.Entities.BLEGateways.Commands.Edit
//{
//    public class BLEGatewaysEditHandlerTest : Language
//    {
//        #region Props

//        private readonly Mock<IModelRepository> _modelRepository;
//        private readonly Mock<IBLEGatewaysRepository> _bLEGatewaysRepository;
//        private Mock<ILogger> _logger;
//        private BLEGatewayEditHandler _handler;
//        private BLEGatewayEditCommand _request;
//        private BLEGateway _bLEGateway;
//        DateTime deliver=DateTime.Now;
//        #endregion

//        public BLEGatewaysEditHandlerTest()
//        {
//            _modelRepository = new Mock<IModelRepository>();
//            _bLEGatewaysRepository = new Mock<IBLEGatewaysRepository>();
//            _logger = new Mock<ILogger>();
//            _handler = new BLEGatewayEditHandler(_modelRepository.Object, _logger.Object, _sharedResources.Object, _bLEGatewaysRepository.Object);
//            _request = new BLEGatewayEditCommand
//            {
//                BLEId = Guid.NewGuid(),
//                IndexId = 1,
//                Status = Domain.Enum.StatusOfWatch.idle,
//                ModelId = Guid.NewGuid(),
//                MACAddress = "MAC",
//                LocalIpAddress= "LocalIpAddress",
//                Location = "aa",
//                FirmwareVersion= "FirmwareVersion",
//                RequestBy = "RequestBy",

//            };
//            _bLEGateway = new BLEGateway
//            {
//                Id = _request.BLEId,
//                IndexId = _request.IndexId,
//                Status = Domain.Enum.StatusOfWatch.idle,
//                ModelId = _request.ModelId,
//                MACAddress = _request.MACAddress,
//                LocalIpAddress=_request.LocalIpAddress,
//                Location = _request.Location,
//                DeliverTime = _request.DeliverTime,
//                FirmwareVersion = _request.FirmwareVersion,
//                CreatedBy = "RequestBy",
//            };
//        }

//        #region Validation Request

//        [Fact]
//        [Trait("BLEGatewaysEditHandlerTest", "Validation Request")]
//        public async Task Validation_Id_Test()
//        {

//            //Arrange

//            _request.BLEId = Guid.Empty;
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        [Fact]
//        [Trait("BLEGatewaysEditHandlerTest", "Validation Request")]
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
//        [Trait("BLEGatewaysEditHandlerTest", "Validation Request")]
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
//        [Trait("BLEGatewaysEditHandlerTest", "Validation Request")]
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
//        [Trait("BLEGatewaysEditHandlerTest", "Validation Request")]
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
//        [Trait("BLEGatewaysEditHandlerTest", "Exception")]
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
//        [Trait("BLEGatewaysEditHandlerTest", "Check In db")]
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
//        [Trait("BLEGatewaysEditHandlerTest", "Check In db")]
//        public async Task FindThisBeacon(bool isNull)
//        {

//            //Arrange
//            _request.DeliverTime = deliver;

//            Model model = new Model()
//            {
//            };


//            BLEGateway bLEGateWay = new BLEGateway();
//            if (isNull)
//                bLEGateWay = null;
//            else
//                bLEGateWay.Deleted = true;

//            _modelRepository.Setup(s => s.GetByIdAsync(_request.ModelId)).ReturnsAsync(model);

//            _bLEGatewaysRepository.Setup(s => s.GetByIdAsync(_request.BLEId)).ReturnsAsync(bLEGateWay);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }



//        [Fact]
//        [Trait("BLEGatewaysEditHandlerTest", "Check In db")]
//        public async Task FindThisIndexId()
//        {

//            //Arrange
//            _request.DeliverTime = deliver;

//            Model model = new Model();

//            BLEGateway bLEGateWay = new BLEGateway();

//            _modelRepository.Setup(s => s.GetByIdAsync(_request.ModelId)).ReturnsAsync(model);
//            _bLEGatewaysRepository.Setup(s => s.GetByIdAsync(_request.BLEId)).ReturnsAsync(bLEGateWay);
//            _bLEGatewaysRepository.Setup(s => s.HasThisIndexId(_request.BLEId, _request.IndexId)).ReturnsAsync(true);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        [Fact]
//        [Trait("BLEGatewaysEditHandlerTest", "Check In db")]
//        public async Task FindBLEGateWayByMacAndBLEIdAsync()
//        {
//            //Arrange
//            _request.DeliverTime = deliver;

//            Model model = new Model();

//            BLEGateway bLEGateWay = new BLEGateway();

//            _modelRepository.Setup(s => s.GetByIdAsync(_request.ModelId)).ReturnsAsync(model);
//            _bLEGatewaysRepository.Setup(s => s.GetByIdAsync(_request.BLEId)).ReturnsAsync(bLEGateWay);
//            _bLEGatewaysRepository.Setup(s => s.HasThisIndexId(_request.BLEId, _request.IndexId)).ReturnsAsync(false);
//            _bLEGatewaysRepository.Setup(s => s.FindBLEByMacAndBLEIdAsync(_request.MACAddress, _request.BLEId)).ReturnsAsync(bLEGateWay);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }
//        #endregion

//        #region Edit

//        [Fact]
//        [Trait("BLEGatewaysEditHandlerTest", "Edit")]
//        public async Task Edit_Test()
//        {

//            //Arrange

//            _request.DeliverTime = deliver;
//            Model model = new Model();
//            model.ModelName = "Name";
//            BLEGateway bLEGateWay = new BLEGateway();
//            bLEGateWay = null;
//            _modelRepository.Setup(s => s.GetByIdAsync(_request.ModelId)).ReturnsAsync(model);
//            _bLEGatewaysRepository.Setup(s => s.GetByIdAsync(_request.BLEId)).ReturnsAsync(_bLEGateway);
//            _bLEGatewaysRepository.Setup(s => s.HasThisIndexId(_request.BLEId, _request.IndexId)).ReturnsAsync(false);
//            _bLEGatewaysRepository.Setup(s => s.FindBLEByMacAndBLEIdAsync(_request.MACAddress, _request.BLEId)).ReturnsAsync(bLEGateWay);

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
//            Assert.Equal(response.Data.FirmwareVersion, _bLEGateway.FirmwareVersion);
//            Assert.Equal(response.Data.Model, model.ModelName);
//            Assert.Equal(response.Data.DeliverTime, _bLEGateway.DeliverTime);
//            Assert.Equal(response.Data.BLEId, _bLEGateway.Id);
//            Assert.Equal(response.Data.ModelId, model.Id);
//        }

//        #endregion

//    }
//}
