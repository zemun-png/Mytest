//using Ara.SmartHSE.Application.Entities.Roles.Commands.Create;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Roles.Commands.Create
//{
//    public class RoleCreateHandlerTest : Language
//    {
//        #region Fields

//        string roleName = "RoleName";
//        Guid guid1 = Guid.NewGuid();

//        List<Guid> guids = new List<Guid>();
//        Guid guid2 = Guid.NewGuid();
//        Guid guid3 = Guid.NewGuid();
//        Guid guid4 = Guid.NewGuid();


//        private readonly Mock<IRoleRepository> _roleRepository;
//        private readonly Mock<IAreaRepository> _areaRepository;
//        private readonly Mock<IAssignAreaRepository> _assignAreaRepository;
//        private readonly Mock<ILogger> _logger;
//        private readonly RoleCreateHandler _handler;
//        RoleCreateCommand request;
//        Role role;

//        #endregion

//        #region Ctor

//        public RoleCreateHandlerTest()
//        {
//            _roleRepository = new Mock<IRoleRepository>();
//            _areaRepository = new Mock<IAreaRepository>();
//            _assignAreaRepository = new Mock<IAssignAreaRepository>();
//            _logger = new Mock<ILogger>();
//            _handler = new RoleCreateHandler(_roleRepository.Object, _logger.Object, _sharedResources.Object,_areaRepository.Object,_assignAreaRepository.Object);

//            guids.Add(guid2);
//            guids.Add(guid3);

//            request = new RoleCreateCommand()
//            {
//                RoleName = roleName,
//                ContractorId = guid1,
//                AreaIds = guids,
//                TenantId = Guid.NewGuid(),
//            };
//            role = new Role()
//            {
//                Id = guid4,
//                RoleName = roleName,

//            };

//        }
//        #endregion

//        #region Validation Request

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("RoleCreateHandler", "Validation Request")]
//        public async Task Validation_RoleName_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                request.RoleName = null;
//            else
//                request.RoleName = string.Empty;

//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());
//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        [Fact]
//        [Trait("RoleCreateHandler", "Validation Request")]
//        public async Task Validation_ContractorId_Test()
//        {

//            //Arrange
//            request.ContractorId = Guid.Empty;

//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());
//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        [Fact]
//        [Trait("RoleCreateHandler", "Validation Request")]
//        public async Task Validation_TenantId_Test()
//        {

//            //Arrange
//            //Arrange
//            request.TenantId = Guid.Empty;


//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert


//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("RoleCreateHandler", "Exception")]
//        public async Task Exception_Test()
//        {

//            //Arrange

//            request = null;
//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }
//        #endregion

//        #region Check Request In Db

//        [Fact]
//        [Trait("RoleCreateHandler", "Check Request In Db")]
//        public async Task Has_AreaId_And_Not_Valid_Area_Test()
//        {
//            //Arrange

//            _areaRepository.Setup(s => s.ValidArea(request.AreaIds, request.TenantId)).ReturnsAsync(false);
//            //Act

//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert

//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }
//        [Fact]
//        [Trait("RoleCreateHandler", "Check Request In Db")]
//        public async Task Find_Role_True_Test()
//        {
//            //Arrange
//            request.AreaIds = null;
//            _roleRepository.Setup(s => s.FindRole(request.RoleName, request.ContractorId)).ReturnsAsync(true);
//            //Act

//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert

//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }
//        [Fact]
//        [Trait("RoleCreateHandler", "Check Request In Db")]
//        public async Task Find_Role_False_Test()
//        {
//            //Arrange
//            request.AreaIds = null;
//            _roleRepository.Setup(s => s.FindRole(request.RoleName, request.ContractorId)).ReturnsAsync(true);
//            //Act

//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert

//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }



//        #endregion

//        #region Create

//        [Fact]
//        [Trait("RoleCreateHandler", "Create")]

//        public async Task Create_Role_Test_One()
//        {
//            //Arrange

//            request.AreaIds = null;
//            _roleRepository.Setup(s => s.FindRole(request.RoleName, request.ContractorId)).ReturnsAsync(false);
//            _assignAreaRepository.Setup(s => s.AddRangeAsync(new List<AssignArea>()));
//            _roleRepository.Setup(s => s.AddAsync(It.IsAny<Role>())).ReturnsAsync(role);

//            //Act

//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert
//            _roleRepository.Verify(x => x.SaveChangesAsync(), Times.Once);

//            Assert.True(response.IsSuccessful);
//            Assert.NotNull(response.Data);
//            Assert.Equal(response.Data.Id, role.Id);
//            Assert.Equal(response.Data.Name, role.RoleName);
//        }

//        [Fact]
//        [Trait("RoleCreateHandler", "Create")]

//        public async Task Create_Role_Test_Two()
//        {
//            //Arrange
//            _roleRepository.Setup(s => s.FindRole(request.RoleName, request.ContractorId)).ReturnsAsync(false);
//            _areaRepository.Setup(s => s.ValidArea(request.AreaIds, request.TenantId)).ReturnsAsync(true);

//            _assignAreaRepository.Setup(s => s.AddRangeAsync(new List<AssignArea>()));
//            _roleRepository.Setup(s => s.AddAsync(It.IsAny<Role>())).ReturnsAsync(role);
//            //Act

//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert
//            _roleRepository.Verify(x => x.SaveChangesAsync(), Times.Once);

//            Assert.True(response.IsSuccessful);
//            Assert.NotNull(response.Data);
//            Assert.Equal(response.Data.Id, role.Id);
//            Assert.Equal(response.Data.Name, role.RoleName);
//        }

//        #endregion



//    }
//}
