//using Ara.SmartHSE.Application.Entities.BLEBeacons.Commands.Edit;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.BLEBeacons.Commands.Edit
//{
//    public class BLEBeaconsEditHandlerTest : Language
//    {
//        #region Props

//        private readonly Mock<IModelRepository> _modelRepository;
//        private readonly Mock<IBLEBeaconRepository> _bLEBeaconRepository;
//        private Mock<ILogger> _logger;
//        private BLEBeaconsEditHandler _handler;
//        private BLEBeaconsEditCommand _request;
//        private BLEBeacon _beacon;
//        #endregion

//        public BLEBeaconsEditHandlerTest()
//        {
//            _modelRepository = new Mock<IModelRepository>();
//            _bLEBeaconRepository = new Mock<IBLEBeaconRepository>();
//            _logger = new Mock<ILogger>();
//            _handler = new BLEBeaconsEditHandler(_modelRepository.Object, _logger.Object, _sharedResources.Object, _bLEBeaconRepository.Object);
//            _request = new BLEBeaconsEditCommand
//            {
//                BLEBeaconId = Guid.NewGuid(),
//                IndexId = 1,
//                DeliverTime = DateTime.Now,
//                Location = "aa",
//                ModelId = Guid.NewGuid(),
//                Status = Domain.Enum.StatusOfWatch.idle,
//                RequestBy = "RequestBy",
//                MACAddress = "MAC",

//            };
//            _beacon = new BLEBeacon
//            {
//                Id = _request.BLEBeaconId,
//                IndexId = _request.IndexId,
//                DeliverTime = _request.DeliverTime,
//                Location = _request.Location,
//                ModelId = _request.ModelId,
//                Status = Domain.Enum.StatusOfWatch.idle,
//                MACAddress = _request.MACAddress,
//                CreatedBy = "RequestBy",
//            };
//        }

//        #region Validation Request

//        [Fact]
//        [Trait("BLEBeaconsEditHandlerTest", "Validation Request")]
//        public async Task Validation_Id_Test()
//        {

//            //Arrange

//            _request.BLEBeaconId = Guid.Empty;
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        [Fact]
//        [Trait("BLEBeaconsEditHandlerTest", "Validation Request")]
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
//        [Trait("BLEBeaconsEditHandlerTest", "Validation Request")]
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
//        [Trait("BLEBeaconsEditHandlerTest", "Validation Request")]
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



//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("BLEBeaconsEditHandlerTest", "Exception")]
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
//        [Trait("BLEBeaconsEditHandlerTest", "Check In db")]
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
//        [Trait("BLEBeaconsEditHandlerTest", "Check In db")]
//        public async Task FindThisBeacon(bool isNull)
//        {

//            //Arrange
//            Model model = new Model()
//            {
//            };


//            BLEBeacon bLEBeacon = new BLEBeacon();
//            if (isNull)
//                bLEBeacon = null;
//            else
//                bLEBeacon.Deleted = true;

//            _modelRepository.Setup(s => s.GetByIdAsync(_request.ModelId)).ReturnsAsync(model);

//            _bLEBeaconRepository.Setup(s => s.GetByIdAsync(_request.BLEBeaconId)).ReturnsAsync(bLEBeacon);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }



//        [Fact]
//        [Trait("BLEBeaconsEditHandlerTest", "Check In db")]
//        public async Task FindThisIndexId()
//        {

//            //Arrange

//            //Arrange
//            Model model = new Model();

//            BLEBeacon bLEBeacon = new BLEBeacon();

//            _modelRepository.Setup(s => s.GetByIdAsync(_request.ModelId)).ReturnsAsync(model);
//            _bLEBeaconRepository.Setup(s => s.GetByIdAsync(_request.BLEBeaconId)).ReturnsAsync(bLEBeacon);
//            _bLEBeaconRepository.Setup(s => s.HasThisIndexId(_request.BLEBeaconId, _request.IndexId)).ReturnsAsync(true);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        [Fact]
//        [Trait("BLEBeaconsEditHandlerTest", "Check In db")]
//        public async Task FindBLEBeaconByMacAndBLEIdAsync()
//        {
//            //Arrange
//            Model model = new Model();

//            BLEBeacon bLEBeacon = new BLEBeacon();

//            _modelRepository.Setup(s => s.GetByIdAsync(_request.ModelId)).ReturnsAsync(model);
//            _bLEBeaconRepository.Setup(s => s.GetByIdAsync(_request.BLEBeaconId)).ReturnsAsync(bLEBeacon);
//            _bLEBeaconRepository.Setup(s => s.HasThisIndexId(_request.BLEBeaconId, _request.IndexId)).ReturnsAsync(false);
//            _bLEBeaconRepository.Setup(s => s.FindBLEBeaconByMacAndBLEIdAsync(_request.MACAddress, _request.BLEBeaconId)).ReturnsAsync(bLEBeacon);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }
//        #endregion

//        #region Edit

//        [Fact]
//        [Trait("BLEBeaconsEditHandlerTest", "Edit")]
//        public async Task Edit_Test()
//        {

//            //Arrange

//            //Arrange
//            Model model = new Model();
//            model.ModelName = "Name";
//            BLEBeacon bLEBeacon = new BLEBeacon();
//            bLEBeacon = null;
//            _modelRepository.Setup(s => s.GetByIdAsync(_request.ModelId)).ReturnsAsync(model);
//            _bLEBeaconRepository.Setup(s => s.GetByIdAsync(_request.BLEBeaconId)).ReturnsAsync(_beacon);
//            _bLEBeaconRepository.Setup(s => s.HasThisIndexId(_request.BLEBeaconId, _request.IndexId)).ReturnsAsync(false);
//            _bLEBeaconRepository.Setup(s => s.FindBLEBeaconByMacAndBLEIdAsync(_request.MACAddress, _request.BLEBeaconId)).ReturnsAsync(bLEBeacon);

//            //Act

//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert

//            _bLEBeaconRepository.Verify(x => x.SaveChangesAsync(), Times.Once);

//            Assert.True(response.IsSuccessful);
//            Assert.NotNull(response.Data);
//            Assert.Equal(response.Data.IndexId, _beacon.IndexId);
//            Assert.Equal(response.Data.Status, _beacon.Status);
//            Assert.Equal(response.Data.MACAddress, _beacon.MACAddress);
//            Assert.Equal(response.Data.Location, _beacon.Location);
//            Assert.Equal(response.Data.Model, model.ModelName);
//            Assert.Equal(response.Data.DeliverTime, _beacon.DeliverTime);
//            Assert.Equal(response.Data.BLEBeaconId, _beacon.Id);
//            Assert.Equal(response.Data.ModelId, model.Id);


//        }

//        #endregion

//    }
//}
