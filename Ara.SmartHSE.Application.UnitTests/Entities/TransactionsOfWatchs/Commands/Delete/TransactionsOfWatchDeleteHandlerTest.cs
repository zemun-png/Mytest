//using Ara.SmartHSE.Application.Dtos;
//using Ara.SmartHSE.Application.Entities.EquipmentDetailses.Commands.Delete;
//using Ara.SmartHSE.Application.Interfaces.Repositories.UnitOfWork;
//using Ara.SmartHSE.Application.Resource;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Microsoft.Extensions.Localization;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.TransactionsOfWatchs.Commands.Delete
//{
//    public class TransactionsOfWatchDeleteHandlerTest
//    {
//        #region Props

//        private Mock<IUnitOfWork> _unitOfWork;
//        private Mock<ILogger> _logger;
//        private EquipmentDetailsDeleteHandler _handler;
//        private EquipmentDetailsDeleteCommand _request;
//        Transactions _transactionsOfWatch;
//        private readonly Mock<IStringLocalizer<SharedResources>> _sharedResources;

//        #endregion

//        public TransactionsOfWatchDeleteHandlerTest()
//        {
//            _unitOfWork = new Mock<IUnitOfWork>();
//            _logger = new Mock<ILogger>();
//            _sharedResources = new Mock<IStringLocalizer<SharedResources>>();

//            _handler = new EquipmentDetailsDeleteHandler(_unitOfWork.Object, _logger.Object, _sharedResources.Object);
//            _request = new EquipmentDetailsDeleteCommand
//            {
//                //TransactionOfWatchId = Guid.NewGuid(),
//            };
//            _transactionsOfWatch = new Transactions()
//            {
//                Deleted = false
//            };
//        }

//        #region Validation Request

//        [Fact]

//        [Trait("TransactionsOfWatchDeleteHandlerTest", "Validation Request")]

//        public async Task Validation_TransactionOfWatchId_Test()
//        {

//            //Arrange

//            //_request.TransactionOfWatchId = Guid.Empty;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//            Assert.Equal(MessageResponse.TransactionOfWatchId(), response.Message);
//        }
//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("TransactionsOfWatchDeleteHandlerTest", "Exception")]
//        public async Task Exception_Test()
//        {

//            //Arrange

//            _request = null;
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//            Assert.Equal(MessageResponse.Exception(), response.Message);
//        }
//        #endregion

//        #region Delete
//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("TransactionsOfWatchDeleteHandlerTest", "Delete")]
//        public async Task NotFound_Maintenance(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                _transactionsOfWatch = null;
//            else
//                _transactionsOfWatch.Deleted = true;

//            //_unitOfWork.Setup(s => s.TransactionsRepository.GetByIdAsync(_request.TransactionOfWatchId)).ReturnsAsync(_transactionsOfWatch);
//            //Act

//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert


//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//            Assert.Equal(MessageResponse.NotFound(), response.Message);


//        }





//        [Fact]
//        [Trait("TransactionsOfWatchDeleteHandlerTest", "Delete")]
//        public async Task Delete_Test()
//        {

//            //Arrange

//            //_unitOfWork.Setup(s => s.TransactionsRepository.GetByIdAsync(_request.TransactionOfWatchId)).ReturnsAsync(_transactionsOfWatch);
//            //Act

//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert

//            _unitOfWork.Verify(x => x.SaveChangesAsync(), Times.Once);

//            Assert.True(response.IsSuccessful);
//            Assert.True(response.Data);
//            Assert.Equal(MessageResponse.OKMessage("حذف تغییر وضعیت ساعت"), response.Message);
//        }

//        #endregion

//    }
//}
