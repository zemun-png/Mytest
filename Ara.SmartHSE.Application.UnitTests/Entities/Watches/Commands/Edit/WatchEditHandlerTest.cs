//using Ara.SmartHSE.Application.Entities.Watches.Commands.Edit;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Watches.Commands.Edit
//{
//    public class WatchEditHandlerTest : Language
//    {
//        #region Fields

//        private readonly Mock<IWatchRepository> _watchRepository;
//        private readonly Mock<IModelRepository> _modelRepository;
//        private readonly Mock<ILogger> _logger;
//        private readonly WatchEditHandler _handler;
//        WatchEditCommand _mainRequest;

//        Guid mainGuid = Guid.NewGuid();
//        string CompanyName = "CompanyName";
//        string Model = "Model";
//        string LoRaDevEUI = "0000Mac";
//        string AppKey = "AppKey";
//        string MACAddress = "Mac";
//        string NetworkKey = "NetworkKey";

//        Watch watch;
//        #endregion

//        #region Ctor

//        public WatchEditHandlerTest()
//        {
//            _watchRepository = new Mock<IWatchRepository>();
//            _modelRepository = new Mock<IModelRepository>();
//            _logger = new Mock<ILogger>();

//            _handler = new WatchEditHandler(_watchRepository.Object, _logger.Object, _sharedResources.Object, _modelRepository.Object);
//            _mainRequest = new WatchEditCommand
//            {
//                WatchId = mainGuid,
//                //CompanyName = CompanyName,
//                //MACAddress =MACAddress,
//                //Model = Model,
//                NetworkKey = NetworkKey,
//                AppKey = AppKey,
//                LoRaDevEUI = LoRaDevEUI,
//                FirmwareVersion = "FirmwareVersion",

//            };
//            watch = new Watch
//            {
//                Id = mainGuid,
//                //Brand = CompanyName,
//                MACAddress = MACAddress,
//                //Model = Model,
//                NetworkKey = NetworkKey,
//                AppKey = AppKey,
//                LoRaDevEUI = LoRaDevEUI,
//            };
//        }
//        #endregion

//        #region Validation Request

//        [Fact]
//        [Trait("WatchEditHandler", "ValidationRequest")]
//        public async Task Validation_Id_Test()
//        {

//            //Arrange
//            _mainRequest.WatchId = Guid.Empty;

//            //Act
//            var response = await _handler.Handle(_mainRequest, new CancellationToken());
//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.WatchId(), response.Message);
//        }

//        //[Theory]
//        //[InlineData(true)]
//        //[InlineData(false)]
//        //[Trait("WatchEditHandler", "ValidationRequest")]
//        //public async Task Validation_CompanyName_Test(bool isNull)
//        //{

//        //    //Arrange
//        //    _mainRequest.WatchId = mainGuid;
//        //    if (isNull)
//        //        _mainRequest.CompanyName = null;

//        //    else
//        //        _mainRequest.CompanyName = string.Empty;

//        //    //Act
//        //    var response = await _handler.Handle(_mainRequest, new CancellationToken());
//        //    //Assert
//        //    Assert.False(response.IsSuccessful);
//        //    Assert.Null(response.Data);
//        //    Assert.Equal(MessageResponse.CompanyName(), response.Message);
//        //}
//        //[Theory]
//        //[InlineData(true)]
//        //[InlineData(false)]
//        //[Trait("WatchEditHandler", "ValidationRequest")]
//        //public async Task Validation_Model_Test(bool isNull)
//        //{

//        //    //Arrange
//        //    _mainRequest.WatchId = mainGuid;
//        //    if (isNull)
//        //        //_mainRequest.Model = null;

//        //    else
//        //        //_mainRequest.Model = string.Empty;

//        //    //Act
//        //    var response = await _handler.Handle(_mainRequest, new CancellationToken());
//        //    //Assert
//        //    Assert.False(response.IsSuccessful);
//        //    Assert.Null(response.Data);
//        //    Assert.Equal(MessageResponse.Model(), response.Message);
//        //}

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("WatchEditHandler", "ValidationRequest")]
//        public async Task Validation_LoRaDevEUI_Test(bool isNull)
//        {

//            //Arrange

//            _mainRequest.WatchId = mainGuid;
//            if (isNull)
//                _mainRequest.LoRaDevEUI = null;

//            else
//                _mainRequest.LoRaDevEUI = string.Empty;
//            //Act
//            var response = await _handler.Handle(_mainRequest, new CancellationToken());

//            //Assert


//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.LoRaDevEUI(), response.Message);
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("WatchEditHandler", "ValidationRequest")]
//        public async Task Validation_AppKey_Test(bool isNull)
//        {

//            //Arrange
//            _mainRequest.WatchId = mainGuid;

//            if (isNull)
//                _mainRequest.AppKey = null;

//            else
//                _mainRequest.AppKey = string.Empty;
//            //Act
//            var response = await _handler.Handle(_mainRequest, new CancellationToken());

//            //Assert


//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.AppKey(), response.Message);
//        }
//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("WatchEditHandler", "ValidationRequest")]
//        public async Task Validation_MACAddress_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                _mainRequest.MACAddress = null;

//            else
//                _mainRequest.MACAddress = string.Empty;
//            _mainRequest.WatchId = mainGuid;
//            //Act
//            var response = await _handler.Handle(_mainRequest, new CancellationToken());

//            //Assert


//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.MACAddress(), response.Message);
//        }
//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("WatchEditHandler", "ValidationRequest")]
//        public async Task Validation_NetworkKey_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                _mainRequest.NetworkKey = null;

//            else
//                _mainRequest.NetworkKey = string.Empty;
//            _mainRequest.WatchId = mainGuid;
//            //Act
//            var response = await _handler.Handle(_mainRequest, new CancellationToken());

//            //Assert


//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.NetworkKey(), response.Message);
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("WatchEditHandler", "ValidationRequest")]
//        public async Task Validation_FirmwareVersion_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                _mainRequest.FirmwareVersion = null;

//            else
//                _mainRequest.FirmwareVersion = string.Empty;
//            _mainRequest.WatchId = mainGuid;
//            //Act
//            var response = await _handler.Handle(_mainRequest, new CancellationToken());

//            //Assert


//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.FirmwareVersion(), response.Message);
//        }
//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("WatchEditHandler", "Exception")]

//        public async Task Exception_Test()
//        {

//            //Arrange
//            _mainRequest.WatchId = mainGuid;

//            //Act
//            var response = await _handler.Handle(_mainRequest, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.Exception(), response.Message);
//        }
//        #endregion

//        #region Check Request In Db

//        [Fact]
//        [Trait("WatchEditHandler", "CheckRequestInDb")]

//        public async Task Not_Found_Watch_Test()
//        {
//            //Arrange

//            watch = null;
//            _watchRepository.Setup(s => s.GetByIdAsync(mainGuid)).ReturnsAsync(watch);

//            //Act

//            var response = await _handler.Handle(_mainRequest, new CancellationToken());

//            //Assert

//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.WatchId(), response.Message);
//        }
//        [Fact]
//        [Trait("WatchEditHandler", "CheckRequestInDb")]
//        public async Task Found_Watch_And_It_Was_Delete_Test()
//        {
//            //Arrange
//            watch.Deleted = true;

//            _watchRepository.Setup(s => s.GetByIdAsync(mainGuid)).ReturnsAsync(watch);

//            //Act

//            var response = await _handler.Handle(_mainRequest, new CancellationToken());

//            //Assert

//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.WatchId(), response.Message);
//        }

//        [Fact]
//        [Trait("WatchEditHandler", "CheckRequestInDb")]
//        public async Task Find_Watch_By_Mac_And_WatchId_Test()
//        {
//            //Arrange
//            _watchRepository.Setup(s => s.GetByIdAsync(mainGuid)).ReturnsAsync(watch);
//            _watchRepository.Setup(s => s.FindWatchByMacAndWatchIdAsync(MACAddress, mainGuid)).ReturnsAsync(watch);

//            //Act

//            var response = await _handler.Handle(_mainRequest, new CancellationToken());

//            //Assert

//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.NotAccessForEditDevice(), response.Message);
//        }
//        #endregion

//        #region Edit

//        [Fact]
//        [Trait("WatchEditHandler", "Edit")]
//        public async Task Edit_Test()
//        {
//            //Arrange
//            _watchRepository.Setup(s => s.GetByIdAsync(mainGuid)).ReturnsAsync(watch);
//            _watchRepository.Setup(s => s.FindWatchByMacAndWatchIdAsync(MACAddress, Guid.NewGuid())).ReturnsAsync(watch);

//            //Act

//            var response = await _handler.Handle(_mainRequest, new CancellationToken());

//            //Assert
//            _watchRepository.Verify(s => s.SaveChangesAsync(), Times.Once);
//            Assert.True(response.IsSuccessful);
//            Assert.NotNull(response.Data);
//            //Assert.Equal(MessageResponse.OKMessage("ویرایش"), response.Message);
//            Assert.Equal(_mainRequest.WatchId, response.Data.WatchId);

//            //Assert.Equal(_mainRequest.CompanyName, response.Data.CompanyName);
//            //Assert.Equal(_mainRequest.Model, response.Data.Model);
//            Assert.Equal(_mainRequest.LoRaDevEUI, response.Data.LoRaDevEUI);
//            Assert.Equal(_mainRequest.AppKey, response.Data.AppKey);
//            Assert.Equal(_mainRequest.MACAddress, response.Data.MACAddress);
//            Assert.Equal(_mainRequest.NetworkKey, response.Data.NetworkKey);
//        }
//        #endregion
//    }
//}
