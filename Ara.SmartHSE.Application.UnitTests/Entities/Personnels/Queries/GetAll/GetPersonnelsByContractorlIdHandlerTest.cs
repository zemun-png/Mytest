//using Ara.SmartHSE.Application.Entities.Personnels.Queries.GetAll;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Personnels.Queries.GetAll
//{
//    public class GetPersonnelsByContractorlIdHandlerTest : Language
//    {
//        #region Props

//        Guid _contractorId;
//        GetPersonnelsByContractorlIdQuery _request;
//        GetPersonnelsByContractorlIdHandler _handler;
//        Mock<IPersonnelRepository> mock;
//        Mock<ILogger> _logger;
//        List<Personnel> _personnels;
//        List<string> _areaName1;
//        #endregion

//        #region Ctor

//        public GetPersonnelsByContractorlIdHandlerTest()
//        {
//            _contractorId = Guid.NewGuid();
//            mock = new Mock<IPersonnelRepository>();
//            _logger = new Mock<ILogger>();
//            _handler = new GetPersonnelsByContractorlIdHandler(mock.Object, _logger.Object, _sharedResources.Object);
//            _request = new GetPersonnelsByContractorlIdQuery()
//            {
//                ContractorId = _contractorId
//            };
//            _personnels = new List<Personnel>()
//            {
//                new Personnel()
//                {
//                ContractorId=_contractorId,
//                //PersonnelCode="CodeP1",
//                Family="Family1",
//                Name="Name1",
//                NationalCode="NC1",
//                Id=Guid.NewGuid(),
//                RoleId=Guid.NewGuid(),
//                PersonnelArea=new List<AssignArea>()
//                {
//                    new AssignArea(){Area=new Area(){Name="Area1" } },
//                    new AssignArea(){Area=new Area(){Name="Area11" } },
//                },

//                DateOfBirth=DateTime.Now.AddYears(-10),
//                MobileNum="0000000000",
//                Watches=new List<PersonnelWatch>(){ new PersonnelWatch() { WatchId=new Guid() ,Watch=new Watch() { MACAddress="AAA"} }  },
//                },
//                new Personnel()
//                {
//                ContractorId=_contractorId,
//                //PersonnelCode="CodeP2",
//                Family="Family2",
//                Name="Name2",
//                NationalCode="NC2",
//                Id=Guid.NewGuid(),
//                RoleId=Guid.NewGuid(),
//                DateOfBirth=DateTime.Now.AddYears(-10),
//                MobileNum="0000000000",
//                UnderlyingDiseasesAndPersonnel=new List<UnderlyingDiseasesPersonnel>()
//                {
//                    new UnderlyingDiseasesPersonnel(){UnderlyingDiseasesId=Guid.NewGuid()},
//                    new UnderlyingDiseasesPersonnel(){UnderlyingDiseasesId=Guid.NewGuid()}
//                }
//                },
//            };
//            _areaName1 = new List<string>() {
//            "Area11","Area12",
//            };
//        }
//        #endregion


//        #region Vaildations

//        [Fact]
//        [Trait("GetPersonnelsByContractorlIdHandlerTest", "Vaildations")]
//        public async Task Vaildations_Contractor_Id_Test()
//        {

//            //Arrange
//            _request.ContractorId = Guid.Empty;
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }
//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("GetPersonnelsByContractorlIdHandlerTest", "Exception")]
//        public async Task Exception_Test()
//        {

//            //Arrange

//            _request = null;
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }
//        #endregion

//        #region GetData


//        [Fact]
//        [Trait("GetPersonnelsByContractorlIdHandlerTest", "GetData")]
//        public async Task Not_Find_Any_Personnel_Test()
//        {

//            //Arrange
//            _personnels.Clear();
//            mock.Setup(s => s.GetPersonnelsByContractorId(_request)).ReturnsAsync(_personnels);
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Empty(response.Data);
//        }
//        [Fact]
//        [Trait("GetPersonnelsByContractorlIdHandlerTest", "GetData")]
//        public async Task Find_Personnel_Test()
//        {

//            //Arrange
//            mock.Setup(s => s.GetPersonnelsByContractorId(_request)).ReturnsAsync(_personnels);
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.True(response.IsSuccessful);
//            Assert.NotEmpty(response.Data);

//            for (int i = 0; i < _personnels.Count; i++)
//            {
//                //TODO :Failed
//                Assert.Equal(_personnels[i].ContractorId, response.Data[i].ContractorId);
//                //Assert.Equal(_personnels[i].PersonnelCode, response.Data[i].PersonnelCode);
//                Assert.Equal(_personnels[i].Family, response.Data[i].Family);
//                Assert.Equal(_personnels[i].Name, response.Data[i].Name);
//                Assert.Equal(_personnels[i].NationalCode, response.Data[i].NationalCode);
//                Assert.Equal(_personnels[i].Id, response.Data[i].PersonnelId);
//                Assert.Equal(_personnels[i].RoleId, response.Data[i].RoleId);
//                Assert.Equal(_personnels[i].PersonnelArea?.Select(s => s.Area.Name).ToList(), response.Data[i].AreaName);
//                Assert.Equal(_personnels[i].DateOfBirth, response.Data[i].DateOfBirth);
//                Assert.Equal(_personnels[i].MobileNum, response.Data[i].MobileNum);
//                Assert.Equal(_personnels[i].UnderlyingDiseasesAndPersonnel?.Select(s => s.UnderlyingDiseasesId).ToList(), response.Data[i].UnderlyingDiseaseIds);
//                Assert.Equal(_personnels[i].Watches?.Select(s => s.WatchId).FirstOrDefault(), response.Data[i].WatchId);
//                Assert.Equal(_personnels[i].Watches?.Select(s => s.Watch.MACAddress).FirstOrDefault(), response.Data[i].MACAddress);

//            }
//        }
//        #endregion  
//    }
//}
