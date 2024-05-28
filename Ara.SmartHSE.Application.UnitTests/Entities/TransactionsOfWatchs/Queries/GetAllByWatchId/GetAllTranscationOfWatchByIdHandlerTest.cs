//using Ara.SmartHSE.Application.Dtos;
//using Ara.SmartHSE.Application.Entities.EquipmentDetailses.Queries.GetAllByEquipmentId;
//using Ara.SmartHSE.Application.Interfaces.Repositories.UnitOfWork;
//using Ara.SmartHSE.Application.Resource;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Microsoft.Extensions.Localization;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.TransactionsOfWatchs.Queries.GetAllByWatchId
//{
//    public class GetAllTranscationOfWatchByIdHandlerTest
//    {
//        #region Props

//        private Mock<IUnitOfWork> _unitOfWork;
//        private Mock<ILogger> _logger;
//        private readonly Mock<IStringLocalizer<SharedResources>> _sharedResources;
//        private GetAllByEquipmentIdHandler _handler;
//        private GetAllByEquipmentIdQuery _request;
//        List<Transactions> _trasaction;
//        #endregion

//        public GetAllTranscationOfWatchByIdHandlerTest()
//        {
//            _unitOfWork = new Mock<IUnitOfWork>();
//            _sharedResources = new Mock<IStringLocalizer<SharedResources>>();
//            _logger = new Mock<ILogger>();
//            _handler = new GetAllByEquipmentIdHandler(_unitOfWork.Object, _logger.Object,_sharedResources.Object);
//            _request = new GetAllByEquipmentIdQuery
//            {
//                EquipmetnId = Guid.NewGuid(),
//            };
//            _trasaction = new List<Transactions>
//            {
//                new Transactions {ChangeLog="QQQ"},
//                new Transactions {ChangeLog="WWW"}
//            };
//        }

//        #region Validation Request

//        [Fact]

//        [Trait("GetAllTranscationOfWatchByIdHandlerTest", "Validation Request")]

//        public async Task Validation_WatchId_Test()
//        {

//            //Arrange

//            _request.EquipmetnId = Guid.Empty;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            Assert.Equal(MessageResponse.WatchId(), response.Message);
//        }


//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("GetAllTranscationOfWatchByIdHandlerTest", "Exception")]
//        public async Task Exception_Test()
//        {

//            //Arrange

//            _request = null;
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            Assert.Equal(MessageResponse.Exception(), response.Message);
//        }
//        #endregion

//        #region GetData


//        [Fact]
//        [Trait("GetAllTranscationOfWatchByIdHandlerTest", "GetData")]
//        public async Task Not_Find_Any_Maintenance_Test()
//        {

//            //Arrange
//            _trasaction.Clear();
//            _unitOfWork.Setup(s => s.TransactionsRepository.GetAllTransactionByWatchIdAsync(_request.EquipmetnId)).ReturnsAsync(_trasaction);
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Empty(response.Data);
//            Assert.Equal(MessageResponse.NoData(), response.Message);
//        }
//        [Fact]
//        [Trait("GetAllTranscationOfWatchByIdHandlerTest", "GetData")]
//        public async Task Find_Maintenance_Test()
//        {

//            //Arrange
//            _unitOfWork.Setup(s => s.TransactionsRepository.GetAllTransactionByWatchIdAsync(_request.EquipmetnId)).ReturnsAsync(_trasaction);            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.True(response.IsSuccessful);
//            Assert.NotEmpty(response.Data);
//            Assert.Equal(MessageResponse.HasData(), response.Message);

//        }
//        #endregion

//    }
//}
