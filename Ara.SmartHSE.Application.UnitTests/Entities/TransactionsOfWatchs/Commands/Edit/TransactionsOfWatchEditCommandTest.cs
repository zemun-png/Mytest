//using Ara.SmartHSE.Application.Dtos;
//using Ara.SmartHSE.Application.Entities.EquipmentDetailses.Commands.Edit;
//using Ara.SmartHSE.Application.Interfaces.Repositories.UnitOfWork;
//using Ara.SmartHSE.Application.Resource;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Microsoft.Extensions.Localization;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.TransactionsOfWatchs.Commands.Edit
//{
//    public class TransactionsOfWatchEditCommandTest
//    {
//        #region Props

//        private Mock<IUnitOfWork> _unitOfWork;
//        private Mock<ILogger> _logger;
//        private EquipmentDetailsEditHandler _handler;
//        private EquipmentDetailsEditCommand _request;
//        Transactions _transaction;

//        private readonly Mock<IStringLocalizer<SharedResources>> _sharedResources;
//        #endregion

//        public TransactionsOfWatchEditCommandTest()
//        {
//            _unitOfWork = new Mock<IUnitOfWork>();
//            _logger = new Mock<ILogger>();
//            _sharedResources = new Mock<IStringLocalizer<SharedResources>>();
//            _handler = new EquipmentDetailsEditHandler(_unitOfWork.Object, _logger.Object, _sharedResources.Object);
//            _request = new EquipmentDetailsEditCommand
//            {
//                //TransactionOfWatchId =Guid.NewGuid(),
//                //ChangeLog="ChangeLog",
//                //RequestBy   ="Requestby"
//            };
//            _transaction = new Transactions()
//            {
//                //Deleted = false,
//                //DateTimeOfChangeLog= _request.DateTimeOfChangeLog,
//                //ChangeLog=_request.ChangeLog,
//                //Id=Guid.NewGuid(),

//            };
//        }

//        #region Validation Request

//        [Fact]

//        [Trait("TransactionsOfWatchEditCommandTest", "Validation Request")]

//        public async Task Validation_WatchId_Test()
//        {

//            //Arrange

//            //_request.TransactionOfWatchId = Guid.Empty;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            Assert.Equal(MessageResponse.TransactionOfWatchId(), response.Message);
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("TransactionsOfWatchEditCommandTest", "Validation Request")]
//        public async Task Validation_ChangeLog_Test(bool isNull)
//        {

//            //Arrange
//            //if (isNull)
//            //    _request.ChangeLog = null;
//            //else
//            //    _request.ChangeLog = string.Empty;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            Assert.Equal(MessageResponse.ChangeLog(), response.Message);
//        }

//        [Fact]
//        [Trait("TransactionsOfWatchEditCommandTest", "Validation Request")]
//        public async Task Validation_DateTimeOfChangeLog_Test()
//        {

//            //Arrange


//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            Assert.Equal(MessageResponse.DateTimeOfChangeLog(), response.Message);
//        }

//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("TransactionsOfWatchEditCommandTest", "Exception")]
//        public async Task Exception_Test()
//        {

//            //Arrange
//            //_request.DateTimeOfChangeLog=DateTime.Now;
//            _request = null;
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            Assert.Equal(MessageResponse.Exception(), response.Message);
//        }
//        #endregion

//        #region Edit
//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("TransactionsOfWatchEditCommandTest", "Edit")]
//        public async Task NotFound_Watch(bool isNull)
//        {

//            //Arrange
//            //_request.DateTimeOfChangeLog = DateTime.Now;
//            if (isNull)
//                _transaction = null;
//            else
//                _transaction.Deleted = true;

//            //_unitOfWork.Setup(s => s.TransactionsRepository.GetByIdAsync(_request.TransactionOfWatchId)).ReturnsAsync(_transaction);
//            //Act

//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert


//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            Assert.Equal(MessageResponse.NotFound(), response.Message);


//        }





//        [Fact]
//        [Trait("TransactionsOfWatchEditCommandTest", "Edit")]
//        public async Task Create_Test()
//        {

//            //Arrange
//            //_request.DateTimeOfChangeLog = DateTime.Now;
//            //_unitOfWork.Setup(s => s.TransactionsRepository.GetByIdAsync(_request.TransactionOfWatchId)).ReturnsAsync(_transaction);

//            //_unitOfWork.Setup(s => s.MaintenanceOfWatchRepository.AddRangeAsync(new List<MaintenanceOfWatch>()));
//            //Act

//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert

//            _unitOfWork.Verify(x => x.SaveChangesAsync(), Times.Once);

//            Assert.True(response.IsSuccessful);
//            Assert.NotNull(response.Data);
//            Assert.Equal(MessageResponse.OKMessage("ویرایش تغییر وضعیت ساعت"), response.Message);

//            //Assert.Equal(_transaction.ChangeLog, response.Data.ChangeLog);
//            //Assert.Equal(_transaction.DateTimeOfChangeLog, response.Data.DateTimeOfChangeLog);
//            Assert.Equal(_transaction.Id, response.Data.Id);

//        }

//        #endregion

//    }
//}
