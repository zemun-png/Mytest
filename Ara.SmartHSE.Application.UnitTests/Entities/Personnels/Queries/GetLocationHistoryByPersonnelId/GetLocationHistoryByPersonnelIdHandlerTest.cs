//using Ara.SmartHSE.Application.Dtos;
//using Ara.SmartHSE.Application.Interfaces.Repositories.UnitOfWork;
//using Moq;
//using Xunit;
//using Ara.SmartHSE.Application.Entities.LocationInfos;
//using Aranuma.Infrustructure.Logging;
//using Ara.SmartHSE.Application.Dtos.LocationInfos;
//using Ara.SmartHSE.Application.Entities.Personnels.Queries.GetLocationHistoryByPersonnelId;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Personnels.Queries.GetLocationHistoryByPersonnelId
//{
//    public class GetLocationHistoryByPersonnelIdHandlerTest
//    {
//        #region Props

//        Guid _contractorId;
//        Guid _personnelId;
//        GetLocationHistoryByPersonnelIdQuery _request;
//        GetLocationHistoryByPersonnelIdHandler _handler;
//        Mock<IUnitOfWork> _unitOfWork;
//        Mock<ILocationInfoManager> _iLocationInfoManager;
//        Mock<ILogger> _logger;
//        List<HistoryOfLocation> _historyOfLocations;
//        DateTime _dateTime;
//        #endregion

//        #region Ctor

//        public GetLocationHistoryByPersonnelIdHandlerTest()
//        {
//            _contractorId = Guid.NewGuid();
//            _personnelId = Guid.NewGuid();
//            _dateTime= DateTime.Now;
//            _unitOfWork = new Mock<IUnitOfWork>();
//            _logger = new Mock<ILogger>();
//            _iLocationInfoManager = new Mock<ILocationInfoManager>();
//            //_handler = new GetLocationHistoryByPersonnelIdHandler(_unitOfWork.Object, _logger.Object, _iLocationInfoManager.Object);
//            _request = new GetLocationHistoryByPersonnelIdQuery()
//            {
//                ContractorId = _contractorId,
//                PersonnelId = _personnelId,
//            };
//            _historyOfLocations=new List<HistoryOfLocation>() 
//            {
//                new HistoryOfLocation() {DateTime=_dateTime , Latitude=47,Longitude=48},
//                new HistoryOfLocation() {DateTime=_dateTime , Latitude=51,Longitude=52},
//                new HistoryOfLocation() {DateTime=_dateTime , Latitude=65,Longitude=66},
//            };
//        }
//        #endregion

//        #region Vaildations

//        [Fact]
//        [Trait("GetLocationHistoryByPersonnelIdHandler", "Vaildations")]
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
//        [Trait("GetLocationHistoryByPersonnelIdHandler", "Vaildations")]
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

//        [Fact]
//        [Trait("GetLocationHistoryByPersonnelIdHandler", "Vaildations")]
//        public async Task Vaildations_DateTime_Test()
//        {

//            //Arrange
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            Assert.Equal(MessageResponse.NotFindDate(), response.Message);
//        }


//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("GetLocationHistoryByPersonnelIdHandler", "Exception")]
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
//        [Trait("GetLocationHistoryByPersonnelIdHandler", "GetData")]
//        public async Task Not_Access_Test()
//        {

//            //Arrange
//            //_request.date = _dateTime;
//            _unitOfWork.Setup(s => s.PersonnelRepository.HasThisPersonnelInContractor(_request.ContractorId, _request.PersonnelId)).ReturnsAsync(false);
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            Assert.Equal(MessageResponse.UnValidRequest("دسترسی"), response.Message);
//        }

//        [Fact]
//        [Trait("GetLocationHistoryByPersonnelIdHandler", "GetData")]
//        public async Task Find_Test_And_Response()
//        {

//            //Arrange
//            //_request.date = _dateTime;

//            _unitOfWork.Setup(s => s.PersonnelRepository.HasThisPersonnelInContractor(_request.ContractorId, _request.PersonnelId)).ReturnsAsync(true);
//            //_iLocationInfoManager.Setup(s => s.HistoryLocation(_request.PersonnelId, _request.date)).ReturnsAsync(_historyOfLocations);


//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.True(response.IsSuccessful);
//            Assert.NotNull(response.Data);
//            Assert.Equal(MessageResponse.HasData(), response.Message);
//            Assert.Equal(_historyOfLocations.Count, response.Data.Count);
//            Assert.Equal(_historyOfLocations[0].DateTime, response.Data[0].DateTime);
//            Assert.Equal(_historyOfLocations[0].Latitude, response.Data[0].Latitude);
//            Assert.Equal(_historyOfLocations[0].Longitude, response.Data[0].Longitude);

//            Assert.Equal(_historyOfLocations[1].DateTime, response.Data[1].DateTime);
//            Assert.Equal(_historyOfLocations[1].Latitude, response.Data[1].Latitude);
//            Assert.Equal(_historyOfLocations[1].Longitude, response.Data[1].Longitude);


//        }
//        #endregion

//    }
//}
