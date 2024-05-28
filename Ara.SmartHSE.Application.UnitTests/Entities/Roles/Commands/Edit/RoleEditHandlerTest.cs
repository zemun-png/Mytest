//using Ara.SmartHSE.Application.Entities.Roles.Commands.Edit;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Roles.Commands.Edit
//{
//    public class RoleEditHandlerTest : Language
//    {

//        #region Fields

//        string roleName = "RoleName";
//        Guid guid1;
//        Guid guid2;

//        List<Guid> guids = new List<Guid>();
//        Guid guid3;
//        Guid guid4;
//        Guid guid5;


//        private readonly Mock<IRoleRepository> _roleRepository;
//        private readonly Mock<IAreaRepository> _areaRepository;
//        private readonly Mock<IAssignAreaRepository> _assignAreaRepository;
//        private readonly Mock<ILogger> _logger;
//        private readonly RoleEditHandler _handler;

//        RoleEditCommand request;
//        Role role;
//        #endregion

//        #region Ctor

//        public RoleEditHandlerTest()
//        {
//            guid1 = Guid.NewGuid();
//            guid2 = Guid.NewGuid();
//            guid3 = Guid.NewGuid();
//            guid4 = Guid.NewGuid();
//            guid5 = Guid.NewGuid();

//            _roleRepository = new Mock<IRoleRepository>();
//            _areaRepository = new Mock<IAreaRepository>();
//            _assignAreaRepository = new Mock<IAssignAreaRepository>();
//            _logger = new Mock<ILogger>();
//            _handler = new RoleEditHandler(_roleRepository.Object, _logger.Object, _sharedResources.Object,_areaRepository.Object,_assignAreaRepository.Object);

//            guids.Add(guid2);
//            guids.Add(guid3);

//            request = new RoleEditCommand()
//            {
//                RoleName = roleName,
//                ContractorId = guid1,
//                RoleId = guid2,
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

//        [Fact]
//        [Trait("RoleEditHandler", "Validation Request")]
//        public async Task Validation_RoleId_Test()
//        {

//            //Arrange
//            request.RoleId = Guid.Empty;

//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());
//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.UnValidRoleId(), response.Message);
//        }


//        [Fact]
//        [Trait("RoleEditHandler", "Validation Request")]
//        public async Task Validation_ContractorId_Test()
//        {

//            //Arrange
//            request.ContractorId = Guid.Empty;
//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());
//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.UnValidContractorId(), response.Message);
//        }


//        [Theory]
//        [InlineData(false)]
//        [InlineData(true)]
//        [Trait("RoleEditHandler", "Validation Request")]
//        public async Task Validation_RoleName_Test(bool behavir)
//        {

//            //Arrange
//            if (behavir)
//                request.RoleName = null;
//            else
//                request.RoleName = string.Empty;

//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());
//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.NullRoleName(), response.Message);
//        }


//        [Fact]
//        [Trait("RoleEditHandler", "Validation Request")]
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
//        [Trait("RoleEditHandler", "Exception")]
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
//        [Trait("RoleEditHandler", "Check Request In Db")]
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
//        [Trait("RoleEditHandler", "Check Request In Db")]
//        public async Task Find_Role_False_Test()
//        {
//            //Arrange
//            request.AreaIds = null;
//            role = null;
//            _roleRepository.Setup(s => s.FindByContractorIdAndRoleId(request.RoleId, request.ContractorId)).ReturnsAsync(role);
//            //Act

//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert

//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }
//        #endregion


//        #region Edit

//        [Fact]
//        [Trait("RoleEditHandler", "Edit")]

//        public async Task Edit_Role_Test_One()
//        {
//            //Arrange
//            request.AreaIds = null;
//            _roleRepository.Setup(s => s.FindByContractorIdAndRoleId(request.RoleId, request.ContractorId)).ReturnsAsync(role);
//            _roleRepository.Setup(s => s.Update(It.IsAny<Role>())).ReturnsAsync(role);
//            _assignAreaRepository.Setup(s => s.RemoveOldArea(null, null, role.Id));
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
//        [Trait("RoleEditHandler", "Edit")]

//        public async Task Edit_Role_Test_Two()
//        {
//            //Arrange
//            _roleRepository.Setup(s => s.FindByContractorIdAndRoleId(request.RoleId, request.ContractorId)).ReturnsAsync(role);
//            _roleRepository.Setup(s => s.Update(It.IsAny<Role>())).ReturnsAsync(role);
//            _areaRepository.Setup(s => s.ValidArea(request.AreaIds, request.TenantId)).ReturnsAsync(true);
//            _assignAreaRepository.Setup(s => s.RemoveOldArea(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()));

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
