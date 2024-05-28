//using Ara.SmartHSE.Application.Entities.BLEBeacons.Commands.Create;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.BLEBeacons.Commands.Create
//{
//    public class BLEBeaconsCreateHandlerTest : Language
//    {
//        #region Props

//        private readonly Mock<IModelRepository> _modelRepository;
//        private readonly Mock<IBLEBeaconRepository> _bLEBeaconRepository; 
//        private Mock<ILogger> _logger;
//        private BLEBeaconsCreateHandler _handler;
//        private BLEBeaconsCreateCommand _request;
//        private BLEBeacon _beacon;
//        #endregion

//        public BLEBeaconsCreateHandlerTest()
//        {
//            _modelRepository = new Mock<IModelRepository>();
//            _bLEBeaconRepository = new Mock<IBLEBeaconRepository>();
//            _logger = new Mock<ILogger>();
//            _handler = new BLEBeaconsCreateHandler(_modelRepository.Object, _logger.Object, _sharedResources.Object, _bLEBeaconRepository.Object);
//            _request = new BLEBeaconsCreateCommand
//            {
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
//        [Trait("BLEBeaconsCreateHandlerTest", "Validation Request")]
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
//        [Trait("BLEBeaconsCreateHandlerTest", "Validation Request")]
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
//        [Trait("BLEBeaconsCreateHandlerTest", "Validation Request")]
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
//        [Trait("BLEBeaconsCreateHandlerTest", "Exception")]
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
//        [Trait("BLEBeaconsCreateHandlerTest", "Check In db")]
//        public async Task NotValidModelId(bool isNull)
//        {

//            //Arrange
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
//        [Trait("BLEBeaconsCreateHandlerTest", "Check In db")]
//        public async Task FindThisMac()
//        {

//            //Arrange
//            Model model = new Model()
//            {
//            };
//            _modelRepository.Setup(s => s.GetByIdAsyncAndInclude(_request.ModelId)).ReturnsAsync(model);

//            _bLEBeaconRepository.Setup(s => s.FindBLEBeaconByMacAsync(_request.MACAddress)).ReturnsAsync(_beacon);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }



//        [Fact]
//        [Trait("BLEBeaconsCreateHandlerTest", "Check In db")]
//        public async Task FindThisIndexId()
//        {

//            //Arrange
//            Model model = new Model() { };
//            _beacon = null;
//            _modelRepository.Setup(s => s.GetByIdAsyncAndInclude(_request.ModelId)).ReturnsAsync(model);
//            _bLEBeaconRepository.Setup(s => s.FindBLEBeaconByMacAsync(_request.MACAddress)).ReturnsAsync(_beacon);
//            _bLEBeaconRepository.Setup(s => s.HasThisIndexId(_request.IndexId)).ReturnsAsync(true);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        #endregion

//        #region Create

//        [Fact]
//        [Trait("BLEBeaconsCreateHandlerTest", "Create")]
//        public async Task Create_Test()
//        {

//            //Arrange
//            Model model = new Model()
//            {
//                Id = _request.ModelId,
//                ModelName = "Name",
//                Brand = new Brand { BrandName = "BrandName" }
//            };
//            BLEBeacon bLEBeacon = new BLEBeacon();

//            bLEBeacon = null;
//            _modelRepository.Setup(s => s.GetByIdAsyncAndInclude(_request.ModelId)).ReturnsAsync(model);
//            _bLEBeaconRepository.Setup(s => s.FindBLEBeaconByMacAsync(_request.MACAddress)).ReturnsAsync(bLEBeacon);
//            _bLEBeaconRepository.Setup(s => s.HasThisIndexId(_request.IndexId)).ReturnsAsync(false);
//            _bLEBeaconRepository.Setup(s => s.AddAsync(It.IsAny<BLEBeacon>())).ReturnsAsync(_beacon);

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
//            Assert.Equal(response.Data.Brand, model.Brand.BrandName);
//            Assert.Equal(response.Data.DeliverTime, _beacon.DeliverTime);
//            Assert.Equal(response.Data.ModelId, _request.ModelId);
//            Assert.Equal(response.Data.ModelId, model.Id);


//        }

//        #endregion

//    }
//}
