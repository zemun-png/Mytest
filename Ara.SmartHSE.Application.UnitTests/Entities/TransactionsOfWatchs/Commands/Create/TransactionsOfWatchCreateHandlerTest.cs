//using Ara.SmartHSE.Application.Dtos;
//using Ara.SmartHSE.Application.Entities.EquipmentDetailses.Commands.Create;
//using Ara.SmartHSE.Application.Interfaces.Repositories.UnitOfWork;
//using Ara.SmartHSE.Application.Resource;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Microsoft.Extensions.Localization;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.TransactionsOfWatchs.Commands.Create
//{
//    public class TransactionsOfWatchCreateHandlerTest
//    {
//        #region Props

//        private Mock<IUnitOfWork> _unitOfWork;
//        private Mock<ILogger> _logger;

//        private readonly Mock<IStringLocalizer<SharedResources>> _sharedResources;
//        private EquipmentDetailsCreateHandler _handler;
//        private EquipmentDetailsCreateCommand _request;
//        Watch _watch;
//        Transactions _response;
//        #endregion

//        public TransactionsOfWatchCreateHandlerTest()
//        {
//            _unitOfWork = new Mock<IUnitOfWork>();
//            _logger = new Mock<ILogger>();
//            _sharedResources = new Mock<IStringLocalizer<SharedResources>>();
//            _handler = new EquipmentDetailsCreateHandler(_unitOfWork.Object, _logger.Object, _sharedResources.Object);
//            _request = new EquipmentDetailsCreateCommand
//            {
//                RequestBy = "Request",
//                ChangeLog = "QWE-QWE",
//                WatchId = Guid.NewGuid(),
//                DateTimeOfChangeLog = DateTime.Now
//            };
//            _watch = new Watch()
//            {
//                Deleted = false
//            };
//            _response = new Transactions
//            {
//                DateTimeOfChangeLog = _request.DateTimeOfChangeLog,
//                ChangeLog = _request.ChangeLog,
//                Id = Guid.NewGuid(),
//            };
//        }

//        #region Validation Request

//        [Fact]

//        [Trait("TransactionsOfWatchCreateHandlerTest", "Validation Request")]

//        public async Task Validation_WatchId_Test()
//        {

//            Arrange

//            _request.WatchId = Guid.Empty;

//            Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            Assert.Equal(MessageResponse.WatchId(), response.Message);
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("TransactionsOfWatchCreateHandlerTest", "Validation Request")]

//        public async Task Validation_ChangeLog_Test(bool isNull)
//        {

//            Arrange
//            if (isNull)
//                _request.ChangeLog = null;
//            else
//                _request.ChangeLog = string.Empty;

//            Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            Assert.Equal(MessageResponse.ChangeLog(), response.Message);
//        }
//        [Fact]
//        [Trait("TransactionsOfWatchCreateHandlerTest", "Validation Request")]

//        public async Task Validation_DateTimeOfChangeLog_Test()
//        {

//            Arrange


//            Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            Assert.Equal(MessageResponse.DateTimeOfChangeLog(), response.Message);
//        }

//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("TransactionsOfWatchCreateHandlerTest", "Exception")]
//        public async Task Exception_Test()
//        {

//            Arrange
//            _request.DateTimeOfChangeLog = DateTime.Now;
//            _request = null;
//            Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            Assert.Equal(MessageResponse.Exception(), response.Message);
//        }
//        #endregion

//        #region Create
//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("TransactionsOfWatchCreateHandlerTest", "Create")]
//        public async Task NotFound_Watch(bool isNull)
//        {

//            Arrange
//            _request.DateTimeOfChangeLog = DateTime.Now;
//            if (isNull)
//                _watch = null;
//            else
//                _watch.Deleted = true;

//            _unitOfWork.Setup(s => s.WatchRepository.GetByIdAsync(_request.WatchId)).ReturnsAsync(_watch);
//            Act

//            var response = await _handler.Handle(_request, new CancellationToken());

//            Assert


//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            Assert.Equal(MessageResponse.NotFound(), response.Message);


//        }





//        [Fact]
//        [Trait("TransactionsOfWatchCreateHandlerTest", "Create")]
//        public async Task Create_Test()
//        {

//            Arrange
//            _request.DateTimeOfChangeLog = DateTime.Now;

//            _unitOfWork.Setup(s => s.WatchRepository.GetByIdAsync(_request.WatchId)).ReturnsAsync(_watch);
//            _unitOfWork.Setup(s => s.TransactionsRepository.AddAsync(It.IsAny<Transactions>())).ReturnsAsync(_response);
//            Act

//            var response = await _handler.Handle(_request, new CancellationToken());

//            Assert

//            _unitOfWork.Verify(x => x.SaveChangesAsync(), Times.Once);

//            Assert.True(response.IsSuccessful);
//            Assert.NotNull(response.Data);
//            Assert.Equal(MessageResponse.OKMessage("تغییر وضعیت ساعت"), response.Message);
//            Assert.Equal(_response.Id, response.Data.Id);
//            Assert.Equal(_response.ChangeLog, response.Data.ChangeLog);
//            Assert.Equal(_response.DateTimeOfChangeLog, response.Data.DateTimeOfChangeLog);
//        }

//        #endregion

//    }
//}
