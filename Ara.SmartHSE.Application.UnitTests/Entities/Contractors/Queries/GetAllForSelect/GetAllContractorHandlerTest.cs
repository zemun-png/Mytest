//using Ara.SmartHSE.Application.Entities.Contractors.Queries.GetAllForSelect;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Contractors.Queries.GetAllForSelect
//{
//    public class GetAllContractorHandlerTest : Language
//    {
//        #region Props

//        Contractor _contractor1;
//        Contractor _contractor2;

//        Guid _contractorId1;
//        Guid _contractorId2;

//        Guid _areaId1;
//        Guid _areaId2;

//        List<Contractor> _contractors;

//        Personnel _personnel1;

//        Area _area1;
//        Area _area2;

//        AssignArea _assignArea1;
//        AssignArea _assignArea2;

//        GetAllContractorQuery _request;
//        GetAllContractorHandler _handler;
//        Mock<IContractorRepository> _contractorRepository;
//        Mock<ILogger> _logger;
//        #endregion

//        #region Ctor

//        public GetAllContractorHandlerTest()
//        {
//            _contractorId1 = Guid.NewGuid();
//            _contractorId2 = Guid.NewGuid();
//            _areaId1 = Guid.NewGuid();
//            _areaId2 = Guid.NewGuid();
//            _personnel1 = new Personnel()
//            {
//                Name = "Test",
//            };

//            _area1 = new Area() { Name = "Area1", Id = _areaId1 };
//            _area2 = new Area() { Name = "Area2", Id = _areaId2 };

//            _assignArea1 = new AssignArea() { ContractorID = _contractorId1, Contractor = _contractor1, Area = _area1, AreaId = _areaId1 };
//            _assignArea2 = new AssignArea() { ContractorID = _contractorId2, Contractor = _contractor2, Area = _area2, AreaId = _areaId2 };

//            _contractor1 = new Contractor()
//            {
//                Name = "ContractorId1",
//                Id = _contractorId1,
//                StartDate = DateTime.Now.AddDays(-5),
//                EndDate = DateTime.Now,
//                Personnel = new List<Personnel>() { _personnel1 },
//                ContractorAreas = new List<AssignArea>() { _assignArea1 },
//            };
//            _contractor2 = new Contractor()
//            {
//                Name = "ContractorId2",
//                Id = _contractorId1,
//                StartDate = DateTime.Now.AddDays(-3),
//                EndDate = DateTime.Now.AddDays(2),
//                Personnel = new List<Personnel>(),
//                ContractorAreas = new List<AssignArea>() { _assignArea2 },

//            };
//            _contractorRepository = new Mock<IContractorRepository>();
//            _logger = new Mock<ILogger>();
//            _handler = new GetAllContractorHandler(_contractorRepository.Object, _logger.Object, _sharedResources.Object);
//            _request = new GetAllContractorQuery();
//            _contractors = new List<Contractor>() { _contractor1, _contractor2 };
//        }
//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("GetAllContractorHandler", "Exception")]
//        public async Task Exception_Test()
//        {

//            //Arrange

//            _request = null;
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.Exception(), response.Message);
//        }
//        #endregion

//        #region GetAll
//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        public async Task Get_All_Contractor_With_Area_Name_Test(bool hasData)
//        {
//            //Arrange
//            if (!hasData)
//            {
//                _contractors.Clear();
//            }
//            _contractorRepository.Setup(s => s.GetAllContractorWithAreaName()).ReturnsAsync(_contractors);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            if (hasData)
//            {
//                Assert.NotNull(response.Data);
//                Assert.Equal(_contractors.Count(), response.Data.Count());
//                Assert.True(response.IsSuccessful);
//                //Assert.Equal(response.Message, MessageResponse.HasData());

//                Assert.Equal(response.Data[0].Id, _contractors[0].Id);
//                Assert.Equal(response.Data[0].Name, _contractors[0].Name);
//                Assert.Equal(response.Data[0].AreaName, _contractors[0].ContractorAreas.Select(s => s.Area.Name));
//                Assert.Equal(response.Data[0].StartDate, _contractors[0].StartDate);
//                Assert.Equal(response.Data[0].EndDate, _contractors[0].EndDate);
//                Assert.Equal(response.Data[0].CountPersonnel, _contractors[0].Personnel.Count());

//                Assert.Equal(response.Data[1].Id, _contractors[1].Id);
//                Assert.Equal(response.Data[1].Name, _contractors[1].Name);
//                Assert.Equal(response.Data[1].AreaName, _contractors[1].ContractorAreas.Select(s => s.Area.Name));
//                Assert.Equal(response.Data[1].StartDate, _contractors[1].StartDate);
//                Assert.Equal(response.Data[1].EndDate, _contractors[1].EndDate);
//                Assert.Equal(response.Data[1].CountPersonnel, _contractors[1].Personnel.Count());
//            }
//            else
//            {
//                Assert.Empty(response.Data);
//                Assert.Equal(_contractors.Count(), response.Data.Count());
//                Assert.False(response.IsSuccessful);
//                //Assert.Equal(response.Message, MessageResponse.NoData());
//            }
//        }

//        #endregion
//    }
//}
