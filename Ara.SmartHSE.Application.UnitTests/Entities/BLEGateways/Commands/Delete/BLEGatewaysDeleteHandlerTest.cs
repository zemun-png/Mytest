//using Ara.SmartHSE.Application.Entities.BLEBeacons.Commands.Delete;
//using Ara.SmartHSE.Application.Entities.BLEGateways.Commands.Delete;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.BLEGateways.Commands.Delete
//{
//    public class BLEGatewaysDeleteHandlerTest : Language
//    {
//        #region Props

//        private readonly Mock<IBLEGatewaysRepository> _bLEGatewaysRepository;
//        private readonly Mock<ILogger> _logger;
//        private readonly BLEGatewayDeleteHandler _handler;
//        BLEGatewayDeleteCommand _request;
//        BLEGateway _bLEGateway;

//        #endregion

//        #region Ctor

//        public BLEGatewaysDeleteHandlerTest()
//        {
//            _bLEGatewaysRepository = new Mock<IBLEGatewaysRepository>();
//            _logger = new Mock<ILogger>();

//            _handler = new BLEGatewayDeleteHandler(_bLEGatewaysRepository.Object, _logger.Object, _sharedResources.Object);
//            _request = new BLEGatewayDeleteCommand()
//            {
//                BLEId = Guid.NewGuid(),
//            };
//            _bLEGateway = new BLEGateway
//            {
//                Id = _request.BLEId,
//            };
//        }

//        #endregion

//        #region Validation Request

//        [Fact]
//        [Trait("BLEGatewaysDeleteHandlerTest", "Validation Request")]
//        public async Task Validation_Id_Test()
//        {

//            //Arrange
//            _request.BLEId = Guid.Empty;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }
//        #endregion

//        #region Check Request In Db

//        [Fact]
//        [Trait("BLEGatewaysDeleteHandlerTest", "Check Request In Db")]
//        public async Task Valid_BLEGateways_Test()
//        {
//            //Arrange
//            _bLEGatewaysRepository.Setup(s => s.GetByIdAsync(Guid.NewGuid())).ReturnsAsync(_bLEGateway);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }

//        [Fact]
//        [Trait("BLEGatewaysDeleteHandlerTest", "Check Request In Db")]
//        public async Task Valid_BLEGateways_Test_Two()
//        {
//            //Arrange
//            _bLEGateway.Deleted = true;

//            _bLEGatewaysRepository.Setup(s => s.GetByIdAsync(_request.BLEId)).ReturnsAsync(_bLEGateway);
//            // _unitOfWork.Setup(s => s.LoRaGatewayRepository.GetByIdAsync(_loRaGateway.Id)).ReturnsAsync(_loRaGateway);


//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }

//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("BLEGatewaysDeleteHandlerTest", "Exception")]
//        public async Task Exception_Test()
//        {

//            //Arrange

//            _request = null;
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }
//        #endregion

//        #region Delete

//        [Fact]
//        [Trait("BLEGatewaysDeleteHandlerTest", "Delete")]

//        public async Task Delete_Test()
//        {

//            //Arrange

//            _bLEGatewaysRepository.Setup(s => s.GetByIdAsync(_request.BLEId)).ReturnsAsync(_bLEGateway);
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());
//            //Assert
//            _bLEGatewaysRepository.Verify(x => x.SaveChangesAsync(), Times.Once);

//            Assert.True(response.IsSuccessful);
//            Assert.True(response.Data);
//        }

//        #endregion

//    }
//}
