//using Ara.SmartHSE.Application.Entities.Roles.Queries.GetAllByContractorId;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Roles.Queries.GetAllByContractorId
//{
//    public class GetAllByContractorIdHandlerTest : Language
//    {
//        #region Fields

//        private readonly Mock<IRoleRepository> _roleRepository;
//        private readonly Mock<ILogger> _logger;
//        private readonly GetAllByContractorIdHandler _handler;
//        public GetAllByContractorIdQuery _request;
//        public Guid _guid1;
//        public List<Role> _roles;

//        public Guid _role1;
//        public Guid _role2;

//        public Guid _area1;
//        public Guid _area2;


//        public string role1 = "Role1";
//        public string role2 = "Role2";

//        public string area1 = "Area1";
//        public string area2 = "Area2";


//        #endregion

//        #region Ctor
//        public GetAllByContractorIdHandlerTest()
//        {
//            _roleRepository = new Mock<IRoleRepository>();
//            _logger = new Mock<ILogger>();

//            _handler = new GetAllByContractorIdHandler(_roleRepository.Object, _logger.Object, _sharedResources.Object);

//            _guid1 = Guid.NewGuid();
//            _role1 = Guid.NewGuid();
//            _role2 = Guid.NewGuid();
//            _area1 = Guid.NewGuid();
//            _area2 = Guid.NewGuid();
//            _request = new GetAllByContractorIdQuery
//            {
//                ContractorId = _guid1,
//            };
//            _roles = new List<Role> {
//                new Role()
//                {
//                    ContractorId=_guid1,
//                    Id=_role1,
//                    RoleName=role1,
//                    RoleArea=new List<AssignArea> { new AssignArea() { Area = new Area() { Id = _area1, Name = area1 } } },
//                },
//                 new Role()
//                {
//                    ContractorId=_guid1,
//                    Id=_role2,
//                    RoleName=role2,
//                    RoleArea=new List<AssignArea> { new AssignArea() { Area = new Area() { Id = _area2, Name = area2 } } },
//                }
//            };

//        }
//        #endregion



//        #region Validation Request

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("GetAllByContractorIdHandler", "Validation Request")]
//        public async Task Validation_ContractorId_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                _request = null;

//            else
//                _request.ContractorId = Guid.Empty;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());
//            //Assert
//            if (isNull)
//            {
//                Assert.False(response.IsSuccessful);
//                Assert.Null(response.Data);
//                //Assert.Equal(MessageResponse.Exception(), response.Message);
//            }
//            else
//            {
//                Assert.False(response.IsSuccessful);
//                Assert.Null(response.Data);
//                //Assert.Equal(MessageResponse.UnValidContractorId(), response.Message);
//            }

//        }
//        #endregion


//        #region Check Request In Db

//        [Fact]
//        [Trait("GetAllByContractorIdHandler", "Check Request In Db")]
//        public async Task Find_Roles_By_ContractorId_Null_Test()
//        {
//            //Arrange
//            _roles = null;
//            _roleRepository.Setup(s => s.FindRolesByContractorId(_request.ContractorId)).ReturnsAsync(_roles);
//            //Act

//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert

//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.NotFound(), response.Message);
//        }
//        [Fact]
//        [Trait("GetAllByContractorIdHandler", "Check Request In Db")]
//        public async Task Find_Roles_By_ContractorId_And_Return_Value_Test()
//        {
//            //Arrange
//            _roleRepository.Setup(s => s.FindRolesByContractorId(_request.ContractorId)).ReturnsAsync(_roles);
//            //Act

//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert

//            Assert.True(response.IsSuccessful);
//            Assert.NotNull(response.Data);
//            Assert.Equal(response.Data.Count, _roles.Count);
//            Assert.Equal(response.Data[0].Id, _roles[0].Id);
//            Assert.Equal(response.Data[1].Name, _roles[1].RoleName);
//            Assert.Equal(response.Data[0].AreaName[0].Name, _roles[0].RoleArea[0].Area.Name);
//            Assert.Equal(response.Data[1].AreaName[0].Name, _roles[1].RoleArea[0].Area.Name);
//            Assert.Equal(response.Data[0].AreaName[0].Id, _roles[0].RoleArea[0].Area.Id);
//            Assert.Equal(response.Data[1].AreaName[0].Id, _roles[1].RoleArea[0].Area.Id);
//            //Assert.Equal(MessageResponse.HasData(), response.Message);
//        }

//        [Fact]
//        [Trait("GetAllByContractorIdHandler", "Check Request In Db")]
//        public async Task Not_Find_Roles_By_ContractorId_And_Return_Value_Test()
//        {
//            //Arrange
//            _roles.Clear();
//            _roleRepository.Setup(s => s.FindRolesByContractorId(_request.ContractorId)).ReturnsAsync(_roles);
//            //Act

//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert

//            Assert.False(response.IsSuccessful);
//            Assert.NotNull(response.Data);
//            Assert.Equal(response.Data.Count, _roles.Count);
//            //Assert.Equal(MessageResponse.NoData(), response.Message);
//        }




//        #endregion



//    }
//}
