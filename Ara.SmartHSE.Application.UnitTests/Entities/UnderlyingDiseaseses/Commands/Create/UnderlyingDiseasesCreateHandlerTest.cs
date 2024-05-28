//using Ara.SmartHSE.Application.Entities.UnderlyingDiseaseses.Commands.Create;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.UnderlyingDiseaseses.Commands.Create
//{
//    public class UnderlyingDiseasesCreateHandlerTest : Language
//    {

//        #region Fields

//        private readonly Mock<IUnderlyingDiseasesRepository> mock;
//        private readonly Mock<ILogger> _logger;
//        private readonly UnderlyingDiseasesCreateHandler _handler;
//        UnderlyingDiseasesCreateCommand request;
//        string sickness = "sickness";

//        #endregion

//        #region Ctor

//        public UnderlyingDiseasesCreateHandlerTest()
//        {
//            mock = new Mock<IUnderlyingDiseasesRepository>();
//            _logger = new Mock<ILogger>();
//            _handler = new UnderlyingDiseasesCreateHandler(mock.Object, _logger.Object, _sharedResources.Object);
//            request = new UnderlyingDiseasesCreateCommand
//            {
//                Sickness = sickness,
//            };
//        }
//        #endregion



//        #region Validation Request

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("UnderlyingDiseasesCreateHandler", "ValidationRequest")]
//        public async Task Validation_Sickness_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                request.Sickness = null;

//            else
//                request.Sickness = string.Empty;


//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());
//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.FillSickness(), response.Message);
//        }
//        #endregion

//        #region CheckRequestInDb

//        [Fact]
//        [Trait("UnderlyingDiseasesCreateHandler", "CheckRequestInDb")]
//        public async Task Validation_Has_This_Mac_Test()
//        {

//            //Arrange

//            mock    .Setup(s => s.hasThisSickness(request.Sickness)).ReturnsAsync(true);
//            //_unitOfWork.Setup(s => s.WatchRepository.FindWatchByMacAsync(request.Mac)).Callback<Watch>(() => request);
//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert


//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.Duplicate("نام بیماری"), response.Message);
//        }

//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("UnderlyingDiseasesCreateHandler", "Exception")]
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
//        [Trait("UnderlyingDiseasesCreateHandler", "Create_Test")]
//        public async Task Create_Test()
//        {

//            //Arrange
//            var id = Guid.NewGuid();
//            var CallBack = new UnderlyingDiseases()
//            {
//                Id = id,
//                Sickness = sickness,

//            };
//            mock.Setup(s => s.hasThisSickness(request.Sickness)).ReturnsAsync(false);
//            mock.Setup(u => u.AddAsync(It.IsAny<UnderlyingDiseases>())).Returns(Task.FromResult(CallBack));

//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert

//            mock.Verify(s => s.SaveChangesAsync(), Times.Once);

//            Assert.True(response.IsSuccessful);
//            Assert.NotNull(response.Data);
//            //Assert.Equal(MessageResponse.OKMessage("ثبت بیماری"), response.Message);
//            Assert.Equal(id, response.Data.UnderlyingDiseasId);
//            Assert.Equal(request.Sickness, response.Data.Name);


//        }

//        #endregion

//    }
//}
