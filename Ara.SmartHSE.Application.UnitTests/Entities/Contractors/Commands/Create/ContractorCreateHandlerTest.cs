//using Moq;
//using Aranuma.Infrustructure.Logging;
//using Ara.SmartHSE.Application.Entities.Contractors.Commands.Create;
//using Xunit;
//using Ara.SmartHSE.Domain.Entities;
//using Microsoft.AspNetCore.Http;
//using Ara.SmartHSE.Application.Interfaces.Repositories;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Contractors.Commands.Create
//{
//    public class ContractorCreateHandlerTest : Language
//    {
//        #region Props

//        private readonly Mock<IContractorRepository> _contractorRepository;
//        private readonly Mock<IAreaRepository> _areaRepository;
//        private readonly Mock<IAssignAreaRepository> _assignAreaRepository;

//        private readonly Mock<ILogger> _logger;
//        private readonly ContractorCreateHandler _handler;
//        Mock<IFormFile> file = new Mock<IFormFile>();

//        Guid _mainId;

//        string name = "Name";
//        string address = "Address";
//        string codeUnique = "CodeUnique";
//        string image = "Image";
//        string mobileNum = "MobileNum";

//        string codeUniqueFake = "2";

//        Guid guidArea = Guid.NewGuid();
//        Guid guidArea1 = Guid.NewGuid();
//        Guid guidArea2 = Guid.NewGuid();

//        Guid guidAreaFake = Guid.NewGuid();


//        List<Guid> guidAreas = new List<Guid>();
//        List<Guid> guidAreasFake = new List<Guid>();

//        ContractorCreateCommand _request;

//        public DateTime _startTime;
//        public DateTime _endTime;

//        Contractor _contractor;

//        Area _area;
//        List<AssignArea> _assignAreas;

//        #endregion

//        public ContractorCreateHandlerTest()
//        {
//            _contractorRepository = new Mock<IContractorRepository>();
//            _areaRepository = new Mock<IAreaRepository>();
//            _assignAreaRepository = new Mock<IAssignAreaRepository>();
//            _logger = new Mock<ILogger>();
//            _handler = new ContractorCreateHandler( _logger.Object, _sharedResources.Object,
//                _contractorRepository.Object,
//                _areaRepository.Object, _assignAreaRepository.Object);

//            guidAreas.Add(guidArea);
//            //guidAreas.Add(guidArea1);
//            //guidAreas.Add(guidArea2);
//            guidAreasFake.Add(guidArea);
//            guidAreasFake.Add(guidArea1);
//            guidAreasFake.Add(guidArea2);
//            guidAreasFake.Add(guidAreaFake);

//            _startTime = DateTime.Now;
//            _endTime = DateTime.Now;

//            _mainId = Guid.NewGuid();

//            _request = new ContractorCreateCommand()
//            {
//                Name = name,
//                Address = address,
//                CodeUnique = codeUnique,
//                Image = file.Object,
//                MobileNum = mobileNum,
//                AreaIds = guidAreas,
//                TenantId = Guid.NewGuid(),
//                //    StartDate = "1390/01/01",
//                //EndDate = "1340/01/01",
//                //StartDate = DateTime.Now,
//                //EndDate = DateTime.Now,
//            };

//            _contractor = new Contractor()
//            {
//                Name = name,
//                Id = _mainId,
//                NationalId = codeUnique,
//                Image = image,
//                //MobileNum = mobileNum,
//                //Address = address,

//            };

//            _area = new Area()
//            {
//                Name = "AREATEST",
//                Id = guidArea,
//            };
//            _assignAreas = new List<AssignArea>()
//            {
//                new AssignArea() {  Area = _area}

//            };

//        }


//        #region Validation Request


//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("ContractorCreateHandler", "Validation Request")]
//        public async Task Validation_Name_Test(bool isNull)
//        {

//            //Arrange
//            //_request.Image=null;
//            if (isNull)
//                _request.Name = null;
//            else
//                _request.Name = string.Empty;


//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.UnValidContractorName(), response.Message);
//        }


//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("ContractorCreateHandler", "Validation Request")]

//        public async Task Validation_Address_Test(bool isNull)
//        {

//            //Arrange
//            //_request.Image = null;

//            if (isNull)
//                _request.Address = null;
//            else
//                _request.Address = string.Empty;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.UnValidContractorAddress(), response.Message);
//        }


//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("ContractorCreateHandler", "Validation Request")]
//        public async Task Validation_CodeUnique_Test(bool isNull)
//        {

//            //Arrange
//            //_request.Image = null;

//            if (isNull)
//                _request.CodeUnique = null;
//            else
//                _request.CodeUnique = string.Empty;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.UnValidContractorCodeUnique(), response.Message);
//        }

//        [Fact]
//        [Trait("ContractorCreateHandler", "Validation Request")]
//        public async Task Validation_Image_Test()
//        {

//            //Arrange
//            FillData();
//            _request.Image = null;
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.UnValidContractorImage(), response.Message);
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("ContractorCreateHandler", "Validation Request")]
//        public async Task Validation_MobileNum_Test(bool isNull)
//        {

//            //Arrange

//            if (isNull)
//                _request.MobileNum = null;
//            else
//                _request.MobileNum = string.Empty;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.UnValidContractorMobileNum(), response.Message);
//        }
//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("ContractorCreateHandler", "Validation Request")]
//        public async Task Validation_AreaIds_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                _request.AreaIds = null;
//            else
//                _request.AreaIds.Clear();
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.UnValidContractorAreaIds(), response.Message);
//        }

//        [Fact]
//        [Trait("ContractorCreateHandler", "Validation Request")]
//        public async Task Validation_Start_Date_Test()
//        {

//            //Arrange
//            //_request.StartDate = DateTime.Now;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.StartDate(), response.Message);
//        }

//        [Fact]
//        [Trait("ContractorCreateHandler", "Validation Request")]
//        public async Task Validation_End_Date_Test()
//        {

//            //Arrange
//            _request.StartDate = DateTime.Now;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.EndDate(), response.Message);
//        }

//        [Fact]
//        [Trait("ContractorCreateHandler", "Validation Request")]
//        public async Task Validation_TenantId_Test()
//        {

//            //Arrange
//            FillData();
//            _request.TenantId = Guid.Empty;


//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert


//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.Tenant(), response.Message);
//        }

//        #endregion

//        #region Check Request In Db

//        [Fact]
//        [Trait("ContractorCreateHandler", "Check Request In Db")]

//        public async Task Not_Valid_Contractor_Test()
//        {
//            //Arrange
//            FillData();
//            _contractorRepository.Setup(s => s.HasThisCodeUnique(codeUnique)).ReturnsAsync(true);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.Duplicate("پیمانکار"), response.Message);
//        }

//        [Fact]
//        [Trait("ContractorCreateHandler", "Check Request In Db")]

//        public async Task Not_Valid_Area_Test()
//        {
//            //Arrange
//            FillData();
//            _contractorRepository.Setup(s => s.HasThisCodeUnique(codeUniqueFake)).ReturnsAsync(true);
//            _areaRepository.Setup(s => s.ValidArea(guidAreasFake, Guid.NewGuid())).ReturnsAsync(true);

//            //Act

//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert

//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.UnValidRequest("ناحیه انتخابی"), response.Message);
//        }

//        private void FillData()
//        {
//            _request.StartDate = DateTime.Now;
//            _request.EndDate = DateTime.Now;
//        }

//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("ContractorCreateHandler", "Exception")]
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

//        #region Create

//        [Fact]
//        [Trait("ContractorCreateHandler", "Create")]

//        public async Task Create_Contractor_Test()
//        {

//            //Arrange
//            FillData();
//            _contractorRepository.Setup(s => s.HasThisCodeUnique(codeUniqueFake)).ReturnsAsync(true);
//            _contractorRepository.Setup(s => s.AddAsync(It.IsAny<Contractor>())).ReturnsAsync(_contractor);
//            _areaRepository.Setup(s => s.ValidArea(_request.AreaIds, _request.TenantId)).ReturnsAsync(true);
//            _assignAreaRepository.Setup(s => s.AddRangeAsync(new List<AssignArea>()));



//            //Act

//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            _contractorRepository.Verify(x => x.SaveChangesAsync(), Times.Once);

//            Assert.True(response.IsSuccessful);
//            Assert.NotNull(response.Data);
//            //Assert.Equal(MessageResponse.OKMessage("ثبت پیمانکار"), response.Message);
//            //Assert.Equal(response.Data.Id, _contractor.Id);
//            //Assert.Equal(response.Data.CodeUnique, _contractor.CodeUnique);
//            //Assert.Equal(response.Data.Image, _contractor.Image);
//            //Assert.Equal(response.Data.MobileNum, _contractor.MobileNum);
//            //Assert.Equal(response.Data.Name, _contractor.Name);
//            //Assert.Equal(response.Data.Address, _contractor.Address);
//        }

//        #endregion

//    }
//}
