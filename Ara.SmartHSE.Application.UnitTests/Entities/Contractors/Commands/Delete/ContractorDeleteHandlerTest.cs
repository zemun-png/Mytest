//using Ara.SmartHSE.Application.Entities.Contractors.Commands.Delete;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Contractors.Commands.Delete
//{
//    public class ContractorDeleteHandlerTest : Language
//    {

//        #region Props

//        private readonly Mock<IContractorRepository> _contractorRepository;
//        private readonly Mock<ILogger> _logger;
//        private readonly ContractorDeleteHandler _handler;
//        ContractorDeleteCommand request;
//        #endregion

//        public ContractorDeleteHandlerTest()
//        {
//            _contractorRepository = new Mock<IContractorRepository>();
//            _logger = new Mock<ILogger>();
//            _handler = new ContractorDeleteHandler(_contractorRepository.Object, _logger.Object, _sharedResources.Object);
//            request = new ContractorDeleteCommand()
//            {
//                Id = Guid.NewGuid(),
//            };
//        }

//        #region Validation Request

//        [Fact]
//        [Trait("ContractorDeleteHandler", "Validation Request")]

//        public async Task ValidationConteractorId()
//        {

//            //Arrange
//            request.Id = null;

//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(false);
//            //Assert.Equal(MessageResponse.UnValidContractorId(), response.Message);
//        }
//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("ContractorDeleteHandler", "Exception")]
//        public async Task Exception_Test()
//        {

//            //Arrange

//            request = null;
//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//            //Assert.Equal(MessageResponse.Exception(), response.Message);
//        }
//        #endregion


//        #region Delete

//        [Fact]
//        [Trait("ContractorDeleteHandler", "Delete")]
//        public async Task Delete_Test()
//        {
//            //Arrange
//            _contractorRepository.Setup(s => s.SoftDeleteContractor(request.Id.Value));

//            //Act

//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert
//            _contractorRepository.Verify(s => s.SaveChangesAsync(), Times.Once);
//            Assert.True(response.IsSuccessful);
//            Assert.True(response.Data);
//            //Assert.Equal(MessageResponse.OKMessage("حذف"), response.Message);
//        }
//        #endregion


//    }
//}
