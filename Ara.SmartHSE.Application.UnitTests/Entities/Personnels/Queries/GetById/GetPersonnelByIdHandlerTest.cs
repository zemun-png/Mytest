//using Ara.SmartHSE.Application.Entities.Personnels.Queries.GetById;
//using Ara.SmartHSE.Application.Entities.WatchInfos;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Personnels.Queries.GetById
//{
//    public class GetPersonnelByIdHandlerTest : Language
//    {
//        #region Props

//        Guid _contractorId;
//        Guid _personnelId;
//        Guid _roleId;
//        GetPersonnelByIdQuery _request;
//        GetPersonnelByIdHandler _handler;
//        Mock<IPersonnelRepository> _personnelRepository;
//        Mock<IAssignAreaRepository> _assignAreaRepository;
//        Mock<IWatchInfoManager> _watchInfo;
//        Mock<ILogger> _logger;
//        Personnel _personnel;

//        #endregion

//        #region Ctor

//        public GetPersonnelByIdHandlerTest()
//        {
//            _contractorId = Guid.NewGuid();
//            _personnelId = Guid.NewGuid();
//            _roleId = Guid.NewGuid();
//            _personnelRepository = new Mock<IPersonnelRepository>();
//            _assignAreaRepository = new Mock<IAssignAreaRepository>();
//            _watchInfo = new Mock<IWatchInfoManager>();
//            _logger = new Mock<ILogger>();

//            _handler = new GetPersonnelByIdHandler(_personnelRepository.Object, _logger.Object, _sharedResources.Object, _watchInfo.Object,_assignAreaRepository.Object);
//            _request = new GetPersonnelByIdQuery()
//            {
//                ContractorId = _contractorId,
//                PersonnelId = _personnelId,
//            };
//            _personnel = new Personnel()
//            {
//                Id = _personnelId,
//                //PersonnelCode = "code",
//                ContractorId = _contractorId,
//                DateOfBirth = DateTime.Now,
//                Name = "name",
//                Family = "family",
//                NationalCode = "nationalCode",
//                MobileNum = "mobile",
//                Role = new Role() { Id = _roleId, RoleName = "RoleName" },
//                RoleId = _roleId,
//                PersonnelArea = new List<AssignArea>()
//                {
//                    new AssignArea(){Area=new Area(){Name="Q"}},
//                    new AssignArea(){Area=new Area(){Name="W"}},
//                    new AssignArea(){Area=new Area(){Name="E"}},
//                }

//            };
//        }
//        #endregion

//        #region Vaildations

//        [Fact]
//        [Trait("GetPersonnelByIdHandler", "Vaildations")]
//        public async Task Vaildations_Personnel_Id_Test()
//        {

//            //Arrange
//            _request.PersonnelId = Guid.Empty;
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        [Fact]
//        [Trait("GetPersonnelByIdHandler", "Vaildations")]
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
//        [Trait("GetPersonnelByIdHandler", "Exception")]
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
//        [Trait("GetPersonnelByIdHandler", "GetData")]
//        public async Task Not_Find_Personnel_Test()
//        {

//            //Arrange
//            _personnel = null;
//            _personnelRepository.Setup(s => s.GetByIdAndContractorId(_request)).ReturnsAsync(_personnel);
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("GetPersonnelByIdHandler", "GetData")]
//        public async Task Find_Personnel_Test(bool hasAreaAndRole)
//        {

//            //Arrange
//            var area = new List<string>() { "Q", "W", "E" };

//            if (!hasAreaAndRole)
//            {
//                area.Clear();
//                _personnel.Role = null;
//                _personnel.RoleId = Guid.Empty;
//            }

//            _personnelRepository.Setup(s => s.GetByIdAndContractorId(_request)).ReturnsAsync(_personnel);
//            _assignAreaRepository.Setup(s => s.GetAreaNames(_contractorId, _personnelId, _roleId)).ReturnsAsync(area);


//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.True(response.IsSuccessful);
//            Assert.NotNull(response.Data);
//            Assert.Equal(_personnel.Id, response.Data.PersonnelId);
//            Assert.Equal(_personnel.Name, response.Data.Name);
//            Assert.Equal(_personnel.Family, response.Data.Family);
//            //Assert.Equal(_personnel.DateOfBirth, response.Data.DateOfBirth);
//            Assert.Equal(_personnel.NationalCode, response.Data.NationalCode);
//            //Assert.Equal(_personnel.PersonnelCode, response.Data.PersonnelCode);
//            Assert.Equal(_personnel.MobileNum, response.Data.MobileNum);

//            if (!hasAreaAndRole)
//            {
//                //"تعیین نشده است"
//                Assert.Equal("تعیین نشده است", response.Data.RoleName);
//                Assert.Equal(new List<string>(), response.Data.AreaName);
//                Assert.Equal(null, response.Data.RoleId);
//            }
//            else
//            {
//                Assert.Equal(_personnel.Role.RoleName, response.Data.RoleName);
//                Assert.Equal(_personnel.PersonnelArea.Select(s => s.Area.Name), response.Data.AreaName);
//                Assert.Equal(_personnel.RoleId, response.Data.RoleId);
//            }
//        }
//        #endregion

//    }
//}
