//using Ara.SmartHSE.Application.Entities.Watches.Commands.Create;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Watches.Commands.Create
//{
//    public class WatchCreateHandlerTest : Language
//    {
//        #region Fields

//        private readonly Mock<IWatchRepository> _watchRepository;
//        private readonly Mock<IModelRepository> _modelRepository;
//        private readonly Mock<ILogger> _logger;
//        private readonly WatchCreateHandler _handler;
//        WatchCreateCommand request;
//        string CompanyName = "CompanyName";
//        string Model = "Model";
//        string LoRaDevEUI = "LoRaDevEUI";
//        string AppKey = "AppKey";
//        string MACAddress = "Mac";
//        string NetworkKey = "NetworkKey";
//        #endregion

//        #region Ctor

//        public WatchCreateHandlerTest()
//        {
//            _watchRepository = new Mock<IWatchRepository>();
//            _modelRepository = new Mock<IModelRepository>();
//            _logger = new Mock<ILogger>();

//            _handler = new WatchCreateHandler(_watchRepository.Object, _logger.Object, _sharedResources.Object, _modelRepository.Object);
//            request = new WatchCreateCommand
//            {
//                //CompanyName = CompanyName,
//                //Model = Model,
//                LoRaDevEUI = LoRaDevEUI,
//                AppKey = AppKey,
//                MACAddress = MACAddress,
//                NetworkKey = NetworkKey,
//                //Status=Domain.Enum.StatusOfWatch.idle
//                FirmwareVersion = "asasd",
//            };
//        }
//        #endregion

//        #region Validation Request

//        //[Theory]
//        //[InlineData(true)]
//        //[InlineData(false)]
//        //[Trait("WatchCreateHandler", "ValidationRequest")]
//        //public async Task Validation_CompanyName_Test(bool isNull)
//        //{

//        //    //Arrange
//        //    if (isNull)
//        //        request.CompanyName = null;
//        //    else
//        //        request.CompanyName = string.Empty;


//        //    //Act
//        //    var response = await _handler.Handle(request, new CancellationToken());
//        //    //Assert
//        //    Assert.False(response.IsSuccessful);
//        //    Assert.Null(response.Data);
//        //    Assert.Equal(MessageResponse.CompanyName(), response.Message);
//        //}

//        //[Theory]
//        //[InlineData(true)]
//        //[InlineData(false)]
//        //[Trait("WatchCreateHandler", "ValidationRequest")]
//        //public async Task Validation_Model_Test(bool isNull)
//        //{

//        //    //Arrange
//        //    if (isNull)
//        //        request.Model = null;
//        //    else
//        //        request.Model = string.Empty;

//        //    //Act
//        //    var response = await _handler.Handle(request, new CancellationToken());

//        //    //Assert


//        //    Assert.False(response.IsSuccessful);
//        //    Assert.Null(response.Data);
//        //    Assert.Equal(MessageResponse.Model(), response.Message);
//        //}

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("WatchCreateHandler", "ValidationRequest")]
//        public async Task Validation_LoRaDevEUI_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                request.LoRaDevEUI = null;
//            else
//                request.LoRaDevEUI = string.Empty;

//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert


//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.LoRaDevEUI(), response.Message);
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("WatchCreateHandler", "ValidationRequest")]
//        public async Task Validation_AppKey_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                request.AppKey = null;
//            else
//                request.AppKey = string.Empty;


//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert


//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.AppKey(), response.Message);
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("WatchCreateHandler", "ValidationRequest")]
//        public async Task Validation_MACAddress_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                request.MACAddress = null;
//            else
//                request.MACAddress = string.Empty;

//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert


//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.MACAddress(), response.Message);
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("WatchCreateHandler", "ValidationRequest")]
//        public async Task Validation_NetworkKey_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                request.NetworkKey = null;
//            else
//                request.NetworkKey = string.Empty;
//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert


//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.NetworkKey(), response.Message);
//        }


//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("WatchCreateHandler", "ValidationRequest")]
//        public async Task Validation_FirmwareVersion_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                request.FirmwareVersion = null;
//            else
//                request.FirmwareVersion = string.Empty;
//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert


//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.FirmwareVersion(), response.Message);
//        }



//        //[Fact]
//        //[Trait("WatchCreateHandler", "ValidationRequest")]
//        //public async Task Validation_Status_Test()
//        //{

//        //    //Arrange
//        //    //if (isNull)
//        //    //    request.Status = ;
//        //    //else
//        //    //    request.Status = string.Empty;
//        //    //Act
//        //    var response = await _handler.Handle(request, new CancellationToken());

//        //    //Assert


//        //    Assert.False(response.IsSuccessful);
//        //    Assert.Null(response.Data);
//        //    Assert.Equal(MessageResponse.StatusWatch(), response.Message);
//        //}


//        #endregion

//        #region CheckRequestInDb

//        [Fact]
//        [Trait("WatchCreateHandler", "CheckRequestInDb")]
//        public async Task Validation_Has_This_Mac_Test()
//        {

//            //Arrange
//            var watch = new Watch()
//            {
//                //Brand = CompanyName,
//                //Model=Model,
//                LoRaDevEUI = LoRaDevEUI,
//                AppKey = AppKey,
//                MACAddress = MACAddress,
//                NetworkKey = NetworkKey
//            };
//            _watchRepository.Setup(s => s.FindWatchByMacAsync(request.MACAddress)).ReturnsAsync(watch);
//            //_unitOfWork.Setup(s => s.WatchRepository.FindWatchByMacAsync(request.Mac)).Callback<Watch>(() => request);
//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert


//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.DuplicateWatch(), response.Message);
//        }

//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("WatchCreateHandler", "Exception")]

//        public async Task Exception_Test()
//        {

//            //Arrange


//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.Exception(), response.Message);
//        }
//        #endregion

//        #region Create

//        [Fact]
//        [Trait("WatchCreateHandler", "Create_Test")]
//        public async Task Create_Test()
//        {

//            //Arrange
//            var id = Guid.NewGuid();
//            var watch = new Watch();
//            var CallBack = new Watch()
//            {
//                Id = id,
//                //Brand = CompanyName,
//                //Model = Model,
//                LoRaDevEUI = LoRaDevEUI,
//                AppKey = AppKey,
//                MACAddress = MACAddress,
//                NetworkKey = NetworkKey
//            };
//            //watch = null;

//            _watchRepository.Setup(s => s.FindWatchByMacAsync(request.MACAddress)).ReturnsAsync(watch);
//            _watchRepository.Setup(u => u.AddAsync(It.IsAny<Watch>())).Returns(Task.FromResult(CallBack));

//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert

//            _watchRepository.Verify(s => s.SaveChangesAsync(), Times.Once);

//            Assert.True(response.IsSuccessful);
//            Assert.NotNull(response.Data);
//            //Assert.Equal(MessageResponse.OKMessage("ثبت دستگاه"), response.Message);
//            Assert.Equal(id, response.Data.WatchId);
//            //Assert.Equal(request.Model, response.Data.Model);
//            Assert.Equal(request.AppKey, response.Data.AppKey);
//            Assert.Equal(request.MACAddress, response.Data.MACAddress);
//            Assert.Equal(request.NetworkKey, response.Data.NetworkKey);
//            Assert.Equal(request.LoRaDevEUI, response.Data.LoRaDevEUI);
//            //Assert.Equal(request.CompanyName, response.Data.CompanyName);

//        }

//        #endregion
//    }
//}
