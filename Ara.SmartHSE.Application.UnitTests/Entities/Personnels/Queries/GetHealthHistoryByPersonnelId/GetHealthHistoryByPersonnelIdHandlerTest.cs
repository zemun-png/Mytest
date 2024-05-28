//using Ara.SmartHSE.Application.Dtos;
//using Ara.SmartHSE.Application.Dtos.HealthInfos;
//using Ara.SmartHSE.Application.Entities.Personnels.Queries.GetHistoryByPersonnelId;
//using Ara.SmartHSE.Application.Interfaces.Repositories.UnitOfWork;
//using Aranuma.Infrustructure.Logging;
//using Azure.Core;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Personnels.Queries.GetHealthHistoryByPersonnelId
//{
//    public class GetHealthHistoryByPersonnelIdHandlerTest
//    {

//        #region Props

//        Guid _contractorId;
//        Guid _personnelId;
//        GetHistoryByPersonnelIdQuery _request;
//        GetHistoryByPersonnelIdHandler _handler;
//        Mock<IUnitOfWork> _unitOfWork;
//        Mock<IHealthInfoManager> _iHealthInfoManager;
//        Mock<ILogger> _logger;
//        HistoryHealthInfo _historyHealthInfo;

//        #endregion

//        #region Ctor

//        public GetHealthHistoryByPersonnelIdHandlerTest()
//        {
//            _contractorId = Guid.NewGuid();
//            _personnelId = Guid.NewGuid();
//            _unitOfWork = new Mock<IUnitOfWork>();
//            _logger = new Mock<ILogger>();
//            _iHealthInfoManager = new Mock<IHealthInfoManager>();
//            //_handler = new GetHealthHistoryByPersonnelIdHandler(_unitOfWork.Object, _logger.Object, _iHealthInfoManager.Object);
//            _request = new GetHistoryByPersonnelIdQuery()
//            {
//                ContractorId = _contractorId,
//                PersonnelId = _personnelId,
//            };
//            _historyHealthInfo = new HistoryHealthInfo("10", "11", "12", "13", "14", "15", "16", 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, "29", "30", "31", "32", "33", "34", "35", "36", "37", "38");

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
//            _iHealthInfoManager.Setup(s => s.GetLastStateAndSevenDaysAgoByPersonnelId(_request.PersonnelId)).ReturnsAsync(_historyHealthInfo);


//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.True(response.IsSuccessful);
//            Assert.NotNull(response.Data);
//            Assert.Equal(MessageResponse.HasData(), response.Message);
//            //Assert.Equal(_historyHealthInfo.MainStatus, response.Data.MainStatus);
//            //Assert.Equal(_historyHealthInfo.MainColor, response.Data.MainColor);
//            //Assert.Equal(_historyHealthInfo.LastBloodPressure, response.Data.LastBloodPressure);
//            //Assert.Equal(_historyHealthInfo.BloodPressureStatus, response.Data.BloodPressureStatus);
//            //Assert.Equal(_historyHealthInfo.BloodPressureColor, response.Data.BloodPressureColor);
//            //Assert.Equal(_historyHealthInfo.MinBloodPressureSYS, response.Data.MinBloodPressureSYS);
//            //Assert.Equal(_historyHealthInfo.AvgBloodPressureSYS, response.Data.AvgBloodPressureSYS);
//            //Assert.Equal(_historyHealthInfo.MaxBloodPressureSYS, response.Data.MaxBloodPressureSYS);
//            //Assert.Equal(_historyHealthInfo.MinBloodPressureDIA, response.Data.MinBloodPressureDIA);
//            //Assert.Equal(_historyHealthInfo.AvgBloodPressureDIA, response.Data.AvgBloodPressureDIA);
//            //Assert.Equal(_historyHealthInfo.MaxBloodPressureDIA, response.Data.MaxBloodPressureDIA);

//            //Assert.Equal(_historyHealthInfo.LastTemperature, response.Data.LastTemperature);
//            //Assert.Equal(_historyHealthInfo.TemperatureStatus, response.Data.TemperatureStatus);
//            //Assert.Equal(_historyHealthInfo.TemperatureColor, response.Data.TemperatureColor);
//            //Assert.Equal(_historyHealthInfo.MinTemperature, response.Data.MinTemperature);
//            //Assert.Equal(_historyHealthInfo.AvgTemperature, response.Data.AvgTemperature);
//            //Assert.Equal(_historyHealthInfo.MaxTemperature, response.Data.MaxTemperature);

//            //Assert.Equal(_historyHealthInfo.LastHeartBeat, response.Data.LastHeartBeat);
//            //Assert.Equal(_historyHealthInfo.HeartbeatStatus, response.Data.HeartbeatStatus);
//            //Assert.Equal(_historyHealthInfo.HeartbeatColor, response.Data.HeartbeatColor);
//            //Assert.Equal(_historyHealthInfo.MinHeartBeat, response.Data.MinHeartBeat);
//            //Assert.Equal(_historyHealthInfo.AvgHeartBeat, response.Data.AvgHeartBeat);
//            //Assert.Equal(_historyHealthInfo.MaxHeartBeat, response.Data.MaxHeartBeat);

//            //Assert.Equal(_historyHealthInfo.LastBloodOxygen, response.Data.LastBloodOxygen);
//            //Assert.Equal(_historyHealthInfo.BloodOxygenStatus, response.Data.BloodOxygenStatus);
//            //Assert.Equal(_historyHealthInfo.BloodOxygenColor, response.Data.BloodOxygenColor);
//            //Assert.Equal(_historyHealthInfo.MinBloodOxygen, response.Data.MinBloodOxygen);
//            //Assert.Equal(_historyHealthInfo.AvgBloodOxygen, response.Data.AvgBloodOxygen);
//            //Assert.Equal(_historyHealthInfo.MaxBloodOxygen, response.Data.MaxBloodOxygen);

//        }
//        #endregion

//    }
//}
