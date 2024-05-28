//using Ara.SmartHSE.Application.Entities.Personnels.Commands.Edit;
//using Ara.SmartHSE.Application.Extentions.Calender;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Personnels.Commands.Edit
//{
//    public class PersonnelEditHandlerTest : Language
//    {
//        #region Props


//        private readonly Mock<IAreaRepository> _areaRepository;
//        private readonly Mock<IAssignAreaRepository> _assignAreaRepository;
//        private readonly Mock<IContractorRepository> _contractorRepository;
//        private readonly Mock<IPersonnelRepository> _personnelRepository;
//        private readonly Mock<IRoleRepository> _roleRepository;
//        private readonly Mock<IUnderlyingDiseasesRepository> _underlyingDiseasesRepository;
//        private readonly Mock<IUnderlyingDiseasesPersonnelRepository> _underlyingDiseasesPersonnelRepository;




//        private readonly Mock<ILogger> _logger;
//        private readonly PersonnelEditHandler _handler;
//        Guid contractorId = Guid.NewGuid();
//        Guid personnelId = Guid.NewGuid();
//        Guid roleId = Guid.NewGuid();
//        string name = "Name";
//        string family = "Family";
//        string dateOfBirth = DateTime.Now.ChangeToShamsi();
//        string nationalCode = "NationalCode";
//        string personnelCode = "PersonnelCode";
//        string mobileNum = "MobileNum";
//        List<Guid> underlyingDeseaseIds = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() };
//        List<Guid> areaIds = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() };

//        PersonnelEditCommand _request;


//        Personnel _personnel;
//        Role _role;


//        #endregion

//        #region Ctor

//        public PersonnelEditHandlerTest()
//        {
//            _areaRepository = new Mock<IAreaRepository>();
//            _assignAreaRepository = new Mock<IAssignAreaRepository>();
//            _contractorRepository = new Mock<IContractorRepository>();
//            _personnelRepository = new Mock<IPersonnelRepository>();
//            _roleRepository = new Mock<IRoleRepository>();
//            _underlyingDiseasesRepository = new Mock<IUnderlyingDiseasesRepository>();
//            _underlyingDiseasesPersonnelRepository = new Mock<IUnderlyingDiseasesPersonnelRepository>();
//            _logger = new Mock<ILogger>();
//            _handler = new PersonnelEditHandler(_logger.Object, _sharedResources.Object,_areaRepository.Object,_assignAreaRepository.Object,_contractorRepository.Object,_personnelRepository.Object,_roleRepository.Object,_underlyingDiseasesRepository.Object,_underlyingDiseasesPersonnelRepository.Object);
//            _request = new PersonnelEditCommand()
//            {
//                PersonnelId = personnelId,
//                ContractorId = contractorId,
//                RoleId = roleId,
//                Name = name,
//                Family = family,
//                //DateOfBirth=dateOfBirth,
//                NationalCode = nationalCode,
//                MobileNum = mobileNum,
//                UnderlyingDeseaseIds = underlyingDeseaseIds,
//                AreaIds = areaIds,
//                TenantId = Guid.NewGuid(),
//            };
//            _role = new Role()
//            {
//                Id = Guid.NewGuid(),
//                RoleName = "Role1",
//                Deleted = false,
//            };
//            _personnel = new Personnel()
//            {
//                Id = personnelId,
//                ContractorId = contractorId,
//                //PersonnelCode = "OldpersonnelCode",
//                CreatedBy = "Oldqwe",
//                DateOfBirth = dateOfBirth.ChangeToMiladi(),
//                Family = "Oldfamily",
//                MobileNum = "OldmobileNum",
//                Name = "Oldname",
//                NationalCode = "OldnationalCode",
//                RoleId = _role.Id,
//                Role = _role,
//                Deleted = false,
//            };
//        }

//        #endregion

//        #region Validation Request

//        [Fact]
//        [Trait("PersonnelEditHandlerTest", "Validation Request")]

//        public async Task Validation_PersonnelId_Test()
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
//        [Trait("PersonnelEditHandlerTest", "Validation Request")]

//        public async Task Validation_ContractorId_Test()
//        {

//            //Arrange
//            _request.ContractorId = Guid.Empty;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        [Fact]
//        [Trait("PersonnelEditHandlerTest", "Validation Request")]

//        public async Task Validation_RoleId_Test()
//        {

//            //Arrange
//            _request.RoleId = Guid.Empty;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("PersonnelEditHandlerTest", "Validation Request")]

//        public async Task Validation_Name_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                _request.Name = null;

//            else
//                _request.Name = string.Empty;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("PersonnelEditHandlerTest", "Validation Request")]

//        public async Task Validation_Family_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                _request.Family = null;

//            else
//                _request.Family = string.Empty;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("PersonnelEditHandlerTest", "Validation Request")]
//        public async Task Validation_DateOfBirth_Test(bool isNull)
//        {
//            //Arrange

//            if (isNull) { }
//            //_request.DateOfBirth = null;

//            else { }
//            //_request.DateOfBirth = string.Empty;
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("PersonnelEditHandlerTest", "Validation Request")]
//        public async Task Validation_NationalCode_Test(bool isNull)
//        {

//            //Arrange
//            _request.DateOfBirth = DateTime.Now;

//            if (isNull)
//                _request.NationalCode = null;

//            else
//                _request.NationalCode = string.Empty;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        //[Theory]
//        //[InlineData(true)]
//        //[InlineData(false)]
//        //[Trait("PersonnelEditHandlerTest", "Validation Request")]
//        //public async Task Validation_PersonnelCode_Test(bool isNull)
//        //{

//        //    //Arrange
//        //    _request.DateOfBirth = dateOfBirth;

//        //    if (isNull)
//        //        _request.PersonnelCode = null;

//        //    else
//        //        _request.PersonnelCode = string.Empty;

//        //    //Act
//        //    var response = await _handler.Handle(_request, new CancellationToken());

//        //    //Assert
//        //    Assert.False(response.IsSuccessful);
//        //    Assert.Null(response.Data);
//        //    Assert.Equal(MessageResponse.UnValidPersonnelCode(), response.Message);
//        //}

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("PersonnelEditHandlerTest", "Validation Request")]
//        public async Task Validation_MobileNum_Test(bool isNull)
//        {

//            //Arrange
//            _request.DateOfBirth = DateTime.Now;



//            if (isNull)
//                _request.MobileNum = null;

//            else
//                _request.MobileNum = string.Empty;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        [Fact]
//        [Trait("PersonnelEditHandlerTest", "Validation Request")]
//        public async Task Validation_TenantId_Test()
//        {

//            //Arrange

//            _request.DateOfBirth = DateTime.Now;

//            _request.TenantId = Guid.Empty;


//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert


//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }
//        #endregion

//        #region Check Request In Db


//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("PersonnelEditHandlerTest", "Check Request In Db")]
//        public async Task Valid_Persson_Test(bool isNull)
//        {
//            //Arrange
//            _request.DateOfBirth = DateTime.Now;

//            if (isNull)
//                _personnel = null;
//            else
//                _personnel.Deleted = true;

//            _personnelRepository.Setup(s => s.GetByIdPersonnel(_request.PersonnelId)).ReturnsAsync(_personnel);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }



//        [Fact]
//        [Trait("PersonnelEditHandlerTest", "Check Request In Db")]

//        public async Task Not_Valid_Area_Test()
//        {
//            //Arrange
//            _request.DateOfBirth = DateTime.Now;

//            _personnelRepository.Setup(s => s.GetByIdPersonnel(_request.PersonnelId)).ReturnsAsync(_personnel);
//            _areaRepository.Setup(s => s.ValidArea(_request.AreaIds, _request.TenantId)).ReturnsAsync(false);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        [Fact]
//        [Trait("PersonnelEditHandlerTest", "Check Request In Db")]

//        public async Task Not_Valid_Check_Contractor_Test()
//        {
//            //Arrange
//            _request.DateOfBirth = DateTime.Now;


//            _areaRepository.Setup(s => s.ValidArea(_request.AreaIds, _request.TenantId)).ReturnsAsync(true);
//            _contractorRepository.Setup(s => s.CheckContractor(_request.ContractorId)).ReturnsAsync(false);
//            _personnelRepository.Setup(s => s.GetByIdPersonnel(_request.PersonnelId)).ReturnsAsync(_personnel);


//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("PersonnelEditHandlerTest", "Check Request In Db")]
//        public async Task Valid_Role_Test(bool isNull)
//        {
//            //Arrange
//            _request.DateOfBirth = DateTime.Now;

//            if (isNull)
//                _role = null;
//            else
//                _role.Deleted = true;

//            _areaRepository.Setup(s => s.ValidArea(_request.AreaIds, _request.TenantId)).ReturnsAsync(true);
//            _contractorRepository.Setup(s => s.CheckContractor(_request.ContractorId)).ReturnsAsync(true);
//            _roleRepository.Setup(s => s.FindByContractorIdAndRoleId(_request.RoleId, _request.ContractorId)).ReturnsAsync(_role);
//            _personnelRepository.Setup(s => s.GetByIdPersonnel(_request.PersonnelId)).ReturnsAsync(_personnel);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        [Fact]
//        [Trait("PersonnelEditHandlerTest", "Check Request In Db")]
//        public async Task Valid_Underlying_Diseaseses_Test()
//        {
//            //Arrange
//            _request.DateOfBirth = DateTime.Now;

//            _areaRepository.Setup(s => s.ValidArea(_request.AreaIds, _request.TenantId)).ReturnsAsync(true);
//            _contractorRepository.Setup(s => s.CheckContractor(_request.ContractorId)).ReturnsAsync(true);
//            _personnelRepository.Setup(s => s.GetByIdPersonnel(_request.PersonnelId)).ReturnsAsync(_personnel);
//            _roleRepository.Setup(s => s.FindByContractorIdAndRoleId(_request.RoleId, _request.ContractorId)).ReturnsAsync(_role);
//            _underlyingDiseasesRepository.Setup(s => s.ValidUnderlyingDiseaseses(_request.UnderlyingDeseaseIds)).ReturnsAsync(false);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }

//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("PersonnelCreateHandler", "Exception")]
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

//        #region Edit

//        [Fact]
//        [Trait("PersonnelEditHandlerTest", "Create")]

//        public async Task Edit_Personnel_Test()
//        {

//            //Arrange
//            _request.DateOfBirth = DateTime.Now;
//            _areaRepository.Setup(s => s.ValidArea(_request.AreaIds, _request.TenantId)).ReturnsAsync(true);
//            _contractorRepository.Setup(s => s.CheckContractor(_request.ContractorId)).ReturnsAsync(true);
//            _personnelRepository.Setup(s => s.GetByIdPersonnel(_request.PersonnelId)).ReturnsAsync(_personnel);
//            _roleRepository.Setup(s => s.FindByContractorIdAndRoleId(_request.RoleId, _request.ContractorId)).ReturnsAsync(_role);
//            _underlyingDiseasesRepository.Setup(s => s.ValidUnderlyingDiseaseses(_request.UnderlyingDeseaseIds)).ReturnsAsync(true);
//            _underlyingDiseasesPersonnelRepository.Setup(s => s.RemoveOldUnderlyingDiseasesPersonnel(_request.PersonnelId));
//            _personnelRepository.Setup(s => s.Update(It.IsAny<Personnel>())).ReturnsAsync(_personnel);
//            _underlyingDiseasesPersonnelRepository.Setup(s => s.AddRangeAsync(new List<UnderlyingDiseasesPersonnel>()));
//            _assignAreaRepository.Setup(s => s.AddRangeAsync(new List<AssignArea>()));

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());
//            //Assert
//            _personnelRepository.Verify(x => x.SaveChangesAsync(), Times.Once);

//            Assert.True(response.IsSuccessful);
//            Assert.NotNull(response.Data);
//            //Assert.Equal(response.Data.DateOfBirth, _request.DateOfBirth);
//            Assert.Equal(response.Data.Family, _request.Family);
//            Assert.Equal(response.Data.PersonnelId, _personnel.Id);
//            Assert.Equal(response.Data.MobileNum, _request.MobileNum);
//            Assert.Equal(response.Data.Name, _request.Name);
//            Assert.Equal(response.Data.NationalCode, _request.NationalCode);
//            Assert.Equal(response.Data.RoleId, _role.Id);
//            Assert.Equal(response.Data.ContractorId, _request.ContractorId);

//        }

//        #endregion

//    }
//}
