//using Ara.SmartHSE.Application.Dtos;
//using Ara.SmartHSE.Application.Interfaces.Repositories.UnitOfWork;
//using Moq;
//using Xunit;
//using Ara.SmartHSE.Application.Dtos.DeviceInfos;
//using Ara.SmartHSE.Application.Entities.Personnels.Queries.GetLastDiveceInfoByPersonnelId;
//using Ara.SmartHSE.Application.Entities.DeviceInfos;
//using Aranuma.Infrustructure.Logging;
//using Microsoft.Extensions.Localization;
//using Ara.SmartHSE.Application.Resource;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Personnels.Queries.GetLastDiveceInfoByPersonnelId
//{
//    public class GetLastDiveceInfoByPersonnelIdHandlerTest
//    {

//        #region Props

//        Guid _contractorId;
//        Guid _personnelId;
//        GetLastDiveceInfoByPersonnelIdQuery _request;
//        GetLastDiveceInfoByPersonnelIdHandler _handler;
//        Mock<IUnitOfWork> _unitOfWork;
//        Mock<IDeviceInfoManager> _iDeviceInfoManager;
//        private readonly Mock<IStringLocalizer<SharedResources>> _sharedResources;
//        Mock<ILogger> _logger;
//        HistoryOfDevice _historyOfDevice;

//        #endregion

//        #region Ctor

//        public GetLastDiveceInfoByPersonnelIdHandlerTest()
//        {
//            _contractorId = Guid.NewGuid();
//            _personnelId = Guid.NewGuid();
//            _unitOfWork = new Mock<IUnitOfWork>();
//            _logger = new Mock<ILogger>();
//            _iDeviceInfoManager = new Mock<IDeviceInfoManager>();

//            _sharedResources = new Mock<IStringLocalizer<SharedResources>>();
//            _handler = new GetLastDiveceInfoByPersonnelIdHandler(_unitOfWork.Object, _logger.Object, _iDeviceInfoManager.Object, _sharedResources.Object);
//            _request = new GetLastDiveceInfoByPersonnelIdQuery()
//            {
//                ContractorId = _contractorId,
//                PersonnelId = _personnelId,
//            };
//            _historyOfDevice = new HistoryOfDevice()
//            {
//                BatteryLevel = 1,
//                SignalLevel = 2,
//                Time=DateTime.Now
//            };

//        }
//        #endregion

//        #region Vaildations

//        [Fact]
//        [Trait("GetHealthHistoryByPersonnelIdHandler", "Vaildations")]
//        public async Task Vaildations_Personnel_Id_Test()
//        {

//            //Arrange
//            _request.PersonnelId = Guid.Empty;
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            Assert.Equal(MessageResponse.SelectPersonnel(), response.Message);
//        }

//        [Fact]
//        [Trait("GetHealthHistoryByPersonnelIdHandler", "Vaildations")]
//        public async Task Vaildations_Contractor_Id_Test()
//        {

//            //Arrange
//            _request.ContractorId = Guid.Empty;
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            Assert.Equal(MessageResponse.UnValidContractorId(), response.Message);
//        }




//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("GetHealthHistoryByPersonnelIdHandler", "Exception")]
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
//        [Trait("GetHealthHistoryByPersonnelIdHandler", "GetData")]
//        public async Task Not_Access_Test()
//        {

//            //Arrange
//            _unitOfWork.Setup(s => s.PersonnelRepository.HasThisPersonnelInContractor(_request.ContractorId, _request.PersonnelId)).ReturnsAsync(false);
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            Assert.Equal(MessageResponse.UnValidRequest("دسترسی"), response.Message);
//        }

//        [Fact]
//        [Trait("GetHealthHistoryByPersonnelIdHandler", "GetData")]
//        public async Task Find_Test_And_Response()
//        {

//            //Arrange
//            _unitOfWork.Setup(s => s.PersonnelRepository.HasThisPersonnelInContractor(_request.ContractorId, _request.PersonnelId)).ReturnsAsync(true);
//            _iDeviceInfoManager.Setup(s => s.LastStateOfDevice(_request.PersonnelId)).ReturnsAsync(_historyOfDevice);


//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.True(response.IsSuccessful);
//            Assert.NotNull(response.Data);
//            Assert.Equal(MessageResponse.HasData(), response.Message);

//            Assert.Equal(_historyOfDevice.Time, response.Data.Time);
//            Assert.Equal(_historyOfDevice.SignalLevel, response.Data.SignalLevel);
//            Assert.Equal(_historyOfDevice.BatteryLevel, response.Data.BatteryLevel);

//        }
//        #endregion

//    }
//}
