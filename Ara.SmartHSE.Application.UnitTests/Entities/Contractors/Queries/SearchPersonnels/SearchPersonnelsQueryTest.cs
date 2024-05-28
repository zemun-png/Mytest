//using Ara.SmartHSE.Application.Dtos;
//using Ara.SmartHSE.Application.Entities.Personnels.Queries.SearchPersonnels;
//using Ara.SmartHSE.Application.Interfaces.Repositories.UnitOfWork;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Microsoft.Extensions.Localization;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Contractors.Queries.SearchPersonnels
//{
//    public class SearchPersonnelsQueryTest
//    {
//        #region Props

//        Guid _contractorId1;
//        Guid _contractorId2;
//        Guid _contractorId3;
//        Guid _contractorId4;
//        Guid _contractorId5;
//        List<Guid> _contractorIds;

//        Guid _roleId1;
//        Guid _roleId2;
//        Guid _roleId3;
//        Guid _roleId4;
//        Guid _roleId5;
//        List<Guid> _roleIds;


//        Guid _area1;
//        Guid _area2;
//        Guid _area3;
//        //Guid _area4;
//        //Guid _area5;


//        Guid _personnelId1;
//        Guid _personnelId2;
//        Guid _personnelId3;
//        Guid _personnelId4;
//        Guid _personnelId5;
//        Guid _personnelId6;
//        Guid _personnelId7;
//        Guid _personnelId8;

//        List<Guid> _assingArea;
//        string areaName1 = "Area1";
//        string areaName2 = "Area2";
//        string areaName3 = "Area3";
//        string areaName4 = "Area4";
//        string areaName5 = "Area5";
//        string areaName6 = "Area6";

//        List<string> strings;


//        List<Personnel> _personnels;
//        List<AssignArea> _assignAreas;

//        SearchPersonnelsQuery _request;
//        SearchPersonnelsHandler _handler;
//        Mock<IUnitOfWork> _unitOfWork;
//        Mock<ILogger> _logger;
//        #endregion

//        #region Ctor

//        public SearchPersonnelsQueryTest()
//        {
//            FillData();
//        }
//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("SearchPersonnelsQuery", "Exception")]
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

//        #region GetAll
//        [Theory]
//        [InlineData("q", 0)]
//        [InlineData("J", 1)]
//        [InlineData("s", 2)]
//        [InlineData("n", 4)]
//        [InlineData("h", 4)]
//        [InlineData("i", 7)]
//        [Trait("SearchPersonnelsQuery", "GetAll")]
//        public async Task Get_By_SearchBox_Test(string value, byte countResonse)
//        {
//            //Arrange
//            _request.SearchBox = value;

//            _unitOfWork.Setup(s => s.PersonnelRepository.SearchPersonnels()).ReturnsAsync(_personnels);
//            _unitOfWork.Setup(s => s.AssignAreaRepository.GetAreaNames(_contractorId1, _personnelId1, _roleId1)).ReturnsAsync(new List<string>());
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert

//            switch (countResonse)
//            {
//                case 0:
//                    Assert.Empty(response.Data.Data);
//                    Assert.Equal(response.Message, MessageResponse.NoData());
//                    Assert.False(response.IsSuccessful);
//                    Assert.Equal(response.Data.Data.Count(), 0);
//                    break;
//                case 1:
//                    Assert.Empty(response.Data.Data);
//                    Assert.Equal(response.Message, MessageResponse.HasData());
//                    Assert.True(response.IsSuccessful);
//                    Assert.Equal(response.Data.Data.Count(), 1);
//                    break;
//                case 2:
//                    Assert.Empty(response.Data.Data);
//                    Assert.Equal(response.Message, MessageResponse.HasData());
//                    Assert.True(response.IsSuccessful);
//                    Assert.Equal(response.Data.Data.Count(), 2);
//                    break;
//                case 3:
//                    Assert.Empty(response.Data.Data);
//                    Assert.Equal(response.Message, MessageResponse.HasData());
//                    Assert.True(response.IsSuccessful);
//                    Assert.Equal(response.Data.Data.Count(), 5);
//                    break;
//                case 4:
//                    Assert.Empty(response.Data.Data);
//                    Assert.Equal(response.Message, MessageResponse.HasData());
//                    Assert.True(response.IsSuccessful);
//                    Assert.Equal(response.Data.Data.Count(), 4);
//                    break;
//                case 5:
//                    Assert.Empty(response.Data.Data);
//                    Assert.Equal(response.Message, MessageResponse.HasData());
//                    Assert.True(response.IsSuccessful);
//                    Assert.Equal(response.Data.Data.Count(), 5);
//                    break;
//            }

//        }



//        [Theory]
//        [InlineData(0)]
//        [InlineData(1)]
//        [InlineData(2)]
//        [InlineData(3)]
//        [InlineData(4)]
//        [InlineData(5)]
//        [Trait("SearchPersonnelsQuery", "GetAll")]
//        public async Task Get_By_ContractorId_Test(byte index)
//        {
//            //Arrange
//            _request.ContractorId = _contractorIds[index];

//            _unitOfWork.Setup(s => s.PersonnelRepository.SearchPersonnels()).ReturnsAsync(_personnels);
//            _unitOfWork.Setup(s => s.AssignAreaRepository.GetAreaNames(_contractorId1, _personnelId1, _roleId1)).ReturnsAsync(new List<string>());
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert

//            switch (index)
//            {
//                case 0:
//                    Assert.NotNull(response.Data);
//                    Assert.Equal(response.Message, MessageResponse.HasData());
//                    Assert.True(response.IsSuccessful);
//                    Assert.Equal(response.Data.Count(), 2);
//                    Assert.Equal(response.Data[0].PersonnelId, _personnels[index].Id);
//                    Assert.Equal(response.Data[0].Name, _personnels[index].Name);
//                    Assert.Equal(response.Data[0].ContractorId, _personnels[index].ContractorId);
//                    break;
//                case 1:
//                    Assert.NotNull(response.Data);
//                    Assert.Equal(response.Message, MessageResponse.HasData());
//                    Assert.True(response.IsSuccessful);
//                    Assert.Equal(response.Data.Count(), 1);
//                    Assert.Equal(response.Data[0].PersonnelId, _personnels[index].Id);
//                    Assert.Equal(response.Data[0].Name, _personnels[index].Name);
//                    Assert.Equal(response.Data[0].ContractorId, _personnels[index].ContractorId);
//                    break;
//                case 2:
//                    Assert.NotNull(response.Data);
//                    Assert.Equal(response.Message, MessageResponse.HasData());
//                    Assert.True(response.IsSuccessful);
//                    Assert.Equal(response.Data.Count(), 1);
//                    Assert.Equal(response.Data[0].PersonnelId, _personnels[index].Id);
//                    Assert.Equal(response.Data[0].Name, _personnels[index].Name);
//                    Assert.Equal(response.Data[0].ContractorId, _personnels[index].ContractorId);
//                    break;
//                case 3:
//                    Assert.NotNull(response.Data);
//                    Assert.Equal(response.Message, MessageResponse.HasData());
//                    Assert.True(response.IsSuccessful);
//                    Assert.Equal(response.Data.Count(), 1);
//                    Assert.Equal(response.Data[0].PersonnelId, _personnels[index].Id);
//                    Assert.Equal(response.Data[0].Name, _personnels[index].Name);
//                    Assert.Equal(response.Data[0].ContractorId, _personnels[index].ContractorId);
//                    break;
//                case 4:
//                    Assert.NotNull(response.Data);
//                    Assert.Equal(response.Message, MessageResponse.HasData());
//                    Assert.True(response.IsSuccessful);
//                    Assert.Equal(response.Data.Count(), 2);
//                    Assert.Equal(response.Data[0].PersonnelId, _personnels[index].Id);
//                    Assert.Equal(response.Data[0].Name, _personnels[index].Name);
//                    Assert.Equal(response.Data[0].ContractorId, _personnels[index].ContractorId);
//                    break;
//                case 5:
//                    Assert.Empty(response.Data);
//                    Assert.Equal(response.Message, MessageResponse.NoData());
//                    Assert.False(response.IsSuccessful);
//                    break;
//            }

//        }


//        [Theory]
//        [InlineData(0)]
//        [InlineData(1)]
//        [InlineData(2)]
//        [InlineData(3)]
//        [InlineData(4)]
//        [InlineData(5)]
//        [Trait("SearchPersonnelsQuery", "GetAll")]
//        public async Task Get_By_RoleId_Test(byte index)
//        {
//            //Arrange
//            _request.RoleId = _roleIds[index];

//            _unitOfWork.Setup(s => s.PersonnelRepository.SearchPersonnels()).ReturnsAsync(_personnels);
//            _unitOfWork.Setup(s => s.AssignAreaRepository.GetAreaNames(_contractorId1, _personnelId1, _roleId1)).ReturnsAsync(new List<string>());
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert

//            switch (index)
//            {
//                case 0:
//                    Assert.NotNull(response.Data);
//                    Assert.Equal(response.Message, MessageResponse.HasData());
//                    Assert.True(response.IsSuccessful);
//                    Assert.Equal(response.Data.Count(), 1);
//                    Assert.Equal(response.Data[0].PersonnelId, _personnels[index].Id);
//                    Assert.Equal(response.Data[0].Name, _personnels[index].Name);
//                    Assert.Equal(response.Data[0].RoleId, _personnels[index].RoleId);
//                    break;
//                case 1:
//                    Assert.NotNull(response.Data);
//                    Assert.Equal(response.Message, MessageResponse.HasData());
//                    Assert.True(response.IsSuccessful);
//                    Assert.Equal(response.Data.Count(), 1);
//                    Assert.Equal(response.Data[0].PersonnelId, _personnels[index].Id);
//                    Assert.Equal(response.Data[0].Name, _personnels[index].Name);
//                    Assert.Equal(response.Data[0].RoleId, _personnels[index].RoleId);
//                    break;
//                case 2:
//                    Assert.NotNull(response.Data);
//                    Assert.Equal(response.Message, MessageResponse.HasData());
//                    Assert.True(response.IsSuccessful);
//                    Assert.Equal(response.Data.Count(), 1);
//                    Assert.Equal(response.Data[0].PersonnelId, _personnels[index].Id);
//                    Assert.Equal(response.Data[0].Name, _personnels[index].Name);
//                    Assert.Equal(response.Data[0].RoleId, _personnels[index].RoleId);
//                    break;
//                case 3:
//                    Assert.NotNull(response.Data);
//                    Assert.Equal(response.Message, MessageResponse.HasData());
//                    Assert.True(response.IsSuccessful);
//                    Assert.Equal(response.Data.Count(), 1);
//                    Assert.Equal(response.Data[0].PersonnelId, _personnels[index].Id);
//                    Assert.Equal(response.Data[0].Name, _personnels[index].Name);
//                    Assert.Equal(response.Data[0].RoleId, _personnels[index].RoleId);
//                    break;
//                case 4:
//                    Assert.NotNull(response.Data);
//                    Assert.Equal(response.Message, MessageResponse.HasData());
//                    Assert.True(response.IsSuccessful);
//                    Assert.Equal(response.Data.Count(), 3);
//                    Assert.Equal(response.Data[0].PersonnelId, _personnels[index].Id);
//                    Assert.Equal(response.Data[0].Name, _personnels[index].Name);
//                    Assert.Equal(response.Data[0].RoleId, _personnels[index].RoleId);
//                    break;
//                case 5:
//                    Assert.Empty(response.Data);
//                    Assert.Equal(response.Message, MessageResponse.NoData());
//                    Assert.False(response.IsSuccessful);
//                    break;
//            }

//        }


//        [Theory]
//        [InlineData(0)]
//        [InlineData(1)]
//        [InlineData(2)]
//        [Trait("SearchPersonnelsQuery", "GetAll")]
//        public async Task Get_By_AreaId_Test(byte index)
//        {
//            //Arrange
//            _request.AreaId = _assingArea[index];
//            var area = _assignAreas.Where(w => w.AreaId.Equals(_request.AreaId.Value)).ToList();
//            _unitOfWork.Setup(s => s.PersonnelRepository.SearchPersonnels()).ReturnsAsync(_personnels);
//            _unitOfWork.Setup(s => s.AssignAreaRepository.GetAllAreas(_request.AreaId.Value)).ReturnsAsync(area);
//            _unitOfWork.Setup(s => s.AssignAreaRepository.GetAreaNames(_contractorId1, _personnelId1, _roleId1)).ReturnsAsync(new List<string>());
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert

//            switch (index)
//            {
//                case 0:
//                    Assert.NotNull(response.Data);
//                    Assert.Equal(response.Message, MessageResponse.HasData());
//                    Assert.True(response.IsSuccessful);
//                    Assert.Equal(response.Data.Count(), 3);

//                    break;
//                case 1:
//                    Assert.NotNull(response.Data);
//                    Assert.Equal(response.Message, MessageResponse.HasData());
//                    Assert.True(response.IsSuccessful);
//                    Assert.Equal(response.Data.Count(), 3);
//                    break;
//                case 2:
//                    Assert.NotNull(response.Data);
//                    Assert.Equal(response.Message, MessageResponse.HasData());
//                    Assert.True(response.IsSuccessful);
//                    Assert.Equal(response.Data.Count(), 5);
//                    break;

//            }

//        }

//        [Fact]
//        [Trait("SearchPersonnelsQuery", "GetAll")]
//        public async Task Not_Found_Personnel_Test()
//        {
//            //Arrange
//            _personnels.Clear();
//            _unitOfWork.Setup(s => s.PersonnelRepository.SearchPersonnels()).ReturnsAsync(_personnels);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert


//            Assert.Null(response.Data);
//            Assert.Equal(response.Message, MessageResponse.NoData());
//            Assert.False(response.IsSuccessful);
//        }
//        #endregion


//        public void FillData()
//        {
//            #region Generate

//            _contractorId1 = Guid.NewGuid();
//            _contractorId2 = Guid.NewGuid();
//            _contractorId3 = Guid.NewGuid();
//            _contractorId4 = Guid.NewGuid();
//            _contractorId5 = Guid.NewGuid();

//            _roleId1 = Guid.NewGuid();
//            _roleId2 = Guid.NewGuid();
//            _roleId3 = Guid.NewGuid();
//            _roleId4 = Guid.NewGuid();
//            _roleId5 = Guid.NewGuid();

//            _personnelId1 = Guid.NewGuid();
//            _personnelId2 = Guid.NewGuid();
//            _personnelId3 = Guid.NewGuid();
//            _personnelId4 = Guid.NewGuid();
//            _personnelId5 = Guid.NewGuid();
//            _personnelId6 = Guid.NewGuid();
//            _personnelId7 = Guid.NewGuid();
//            _personnelId8 = Guid.NewGuid();

//            _area1 = Guid.NewGuid();
//            _area2 = Guid.NewGuid();
//            _area3 = Guid.NewGuid();
//            #endregion

//            _contractorIds = new List<Guid>()
//            {
//                _contractorId1,
//                _contractorId2,
//                _contractorId3,
//                _contractorId4,
//                _contractorId5,
//                Guid.NewGuid(),
//            };

//            _roleIds = new List<Guid>()
//            {
//                _roleId1,
//                _roleId2,
//                _roleId3,
//                _roleId4,
//                _roleId5,
//                Guid.NewGuid(),
//            };

//            _assingArea = new List<Guid>()
//            {
//           _area1,
//           _area2,
//           _area3,
//            };
//            _unitOfWork = new Mock<IUnitOfWork>();

//            _logger = new Mock<ILogger>();

//            _request = new SearchPersonnelsQuery() { };
//            _sharedResources = new Mock<IStringLocalizer<SharedResources>>();
//            _handler = new SearchPersonnelsHandler(_unitOfWork.Object, _logger.Object
//   , _sharedResources.Object);

//            _personnels = new List<Personnel>() {
//                  new Personnel
//                  {
//                      Id= _personnelId1,
//                      Name="Hossein",
//                      Family="Khazaee",
//                      NationalCode="N111",
//                      //PersonnelCode="C111",
//                      DateOfBirth=DateTime.Now,
//                      MobileNum="1111111111",
//                      ContractorId=_contractorId1,
//                      RoleId=_roleId1,


//                  }
//                , new Personnel {
//                      Id= _personnelId2,
//                      Name="Esmail",
//                      Family="Khezri",
//                      NationalCode="N112",
//                      DateOfBirth=DateTime.Now,
//                      MobileNum="22222222222",
//                      //PersonnelCode="112",
//                      ContractorId=_contractorId2,
//                      RoleId=_roleId2,


//                }
//                , new Personnel {
//                      Id= _personnelId3,
//                      Name="Mohamad",
//                      Family="Motieian",
//                      NationalCode="N113",
//                      DateOfBirth=DateTime.Now,
//                      //PersonnelCode="113",
//                      ContractorId=_contractorId3,
//                      RoleId=_roleId3,
//                      MobileNum="3333333333",


//                }
//                , new Personnel {
//                      Id= _personnelId4,
//                      Name="Vahid",
//                      Family="Taheri",
//                           NationalCode="N114",
//                      DateOfBirth=DateTime.Now,
//                      //PersonnelCode="114",
//                      ContractorId=_contractorId4,
//                      RoleId=_roleId4,
//                      MobileNum="4444444444444",


//                }
//                , new Personnel {
//                      Id= _personnelId5,
//                      Name="Navid",
//                      Family="Jalilian",
//                           NationalCode="N115",
//                      DateOfBirth=DateTime.Now,
//                      //PersonnelCode="115",
//                      ContractorId=_contractorId5,
//                      RoleId=_roleId5,
//                      MobileNum="555555555555555",

//                }
//                ,
//                   new Personnel {
//                      Id= _personnelId6,
//                      Name="Mix",
//                      Family="VOne",
//                           NationalCode="N200",
//                      DateOfBirth=DateTime.Now,
//                      //PersonnelCode="200",
//                      ContractorId=_contractorId1,
//                      RoleId=_roleId5,
//                      MobileNum="666666666666",

//                }
//                ,
//                      new Personnel {
//                      Id= _personnelId7,
//                      Name="Mix",
//                      Family="VTwo",
//                           NationalCode="N201",
//                      DateOfBirth=DateTime.Now,
//                      //PersonnelCode="N201",
//                       ContractorId=_contractorId5,
//                      RoleId=_roleId5,
//                      MobileNum="7777777777777",

//                }
//                ,
//            };

//            _assignAreas = new List<AssignArea>()
//            {
//                //new AssignArea {ContractorID=_contractorId1,Personnel=_personnels[0],Area=new Area(){ Name=areaName1} },
//                //new AssignArea {RoleID=_roleId2,Personnel=_personnels[1],Area=new Area(){ Name=areaName2}},
//                //new AssignArea {RoleID=_roleId5,Personnel=_personnels[4],Area=new Area(){ Name=areaName3}},
//                //new AssignArea {RoleID=_roleId5,Personnel=_personnels[5],Area=new Area(){ Name=areaName3}},
//                //new AssignArea {RoleID=_roleId5,Personnel=_personnels[6],Area=new Area(){ Name=areaName3}},
//                //new AssignArea {PersonnelID=_personnelId3,Personnel=_personnels[2],Area=new Area(){ Name=areaName4}},
//                //new AssignArea {ContractorID=_contractorId4,Personnel=_personnels[3],Area=new Area(){ Name=areaName4}},
//                          //////////////////////////////////////////////////////////////////////////////

//                new AssignArea {AreaId=_area1,ContractorID=_contractorId1,Area=new Area(){ Name=areaName1} },
//                new AssignArea {AreaId=_area1,RoleID=_roleId2,Area=new Area(){ Name=areaName1}},
//                new AssignArea {AreaId=_area1,Area=new Area(){ Name=areaName1}},

//                new AssignArea {AreaId=_area2,RoleID=_roleId5,Area=new Area(){ Name=areaName3}},

//                new AssignArea {AreaId=_area3,RoleID=_roleId5,Area=new Area(){ Name=areaName4}},
//                new AssignArea {AreaId=_area3,PersonnelID=_personnelId3,Area=new Area(){ Name=areaName4}},
//                new AssignArea {AreaId=_area3,ContractorID=_contractorId4,Area=new Area(){ Name=areaName4}},

// };
//        }
//    }
//}
