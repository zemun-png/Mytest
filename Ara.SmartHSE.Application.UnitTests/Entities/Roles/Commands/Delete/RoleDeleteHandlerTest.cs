//using Ara.SmartHSE.Application.Entities.Roles.Commands.Delete;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Roles.Commands.Delete
//{
//    public class RoleDeleteHandlerTest : Language
//    {

//        #region Fields

//        string roleName = "RoleName";
//        Guid guid1 = Guid.NewGuid();
//        Guid guid2 = Guid.NewGuid();
//        Guid guid3 = Guid.NewGuid();
//        //List<Guid> guids = new List<Guid>();

//        //Guid guid4 = Guid.NewGuid();


//        private readonly Mock<IRoleRepository> _roleRepository;
//        private readonly Mock<ILogger> _logger;
//        private readonly RoleDeleteHandler _handler;

//        RoleDeleteCommand request;
//        Role role;

//        #endregion

//        #region Ctor

//        public RoleDeleteHandlerTest()
//        {
//            _roleRepository = new Mock<IRoleRepository>();
//            _logger = new Mock<ILogger>();
//            _handler = new RoleDeleteHandler(_roleRepository.Object, _logger.Object, _sharedResources.Object);
//            request = new RoleDeleteCommand()
//            {
//                ContractorId = guid1,
//                RoleId = guid2,
//            };
//            role = new Role()
//            {
//                Id = guid3,
//                RoleName = roleName,

//            };

//        }
//        #endregion

//        #region Validation Request

//        [Fact]
//        [Trait("RoleDeleteHandler", "Validation Request")]
//        public async Task Validation_RoleId_Test()
//        {

//            //Arrange
//            request.RoleId = Guid.Empty;

//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());
//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }

//        [Fact]
//        [Trait("RoleDeleteHandler", "Validation Request")]
//        public async Task Validation_ContractorId_Test()
//        {

//            //Arrange
//            request.ContractorId = Guid.Empty;

//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());
//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }
//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("RoleDeleteHandler", "Exception")]
//        public async Task Exception_Test()
//        {

//            //Arrange

//            request = null;
//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }
//        #endregion

//        #region Check Request In Db

//        [Fact]
//        [Trait("RoleDeleteHandler", "Check Request In Db")]
//        public async Task FindBy_ContractorId_And_RoleId_Test()
//        {
//            //Arrange
//            role = null;
//            _roleRepository.Setup(s => s.FindByContractorIdAndRoleId(request.RoleId, request.ContractorId)).ReturnsAsync(role);
//            //Act

//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert

//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }
//        #endregion


//        #region Delete

//        [Fact]
//        [Trait("RoleDeleteHandler", "Delete")]
//        public async Task Delete_Test()
//        {
//            //Arrange

//            _roleRepository.Setup(s => s.FindByContractorIdAndRoleId(request.RoleId, request.ContractorId)).ReturnsAsync(role);
//            _roleRepository.Setup(s => s.SoftDeleteRole(role));
//            //Act

//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert
//            _roleRepository.Verify(s => s.SaveChangesAsync(), Times.Once);
//            Assert.True(response.IsSuccessful);
//            Assert.True(response.Data);
//        }
//        #endregion


//    }
//}
