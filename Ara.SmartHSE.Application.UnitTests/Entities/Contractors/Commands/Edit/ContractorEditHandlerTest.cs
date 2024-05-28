//using Ara.SmartHSE.Application.Entities.Contractors.Commands.Edit;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Microsoft.AspNetCore.Http;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Contractors.Commands.Edit
//{
//    public class ContractorEditHandlerTest : Language
//    {
//        #region Props

//        private readonly Mock<IContractorRepository> _contractorRepository;
//        private readonly Mock<IAreaRepository> _areaRepository;
//        private readonly Mock<IAssignAreaRepository> _assignAreaRepository;
//        private readonly Mock<ILogger> _logger;
//        private readonly ContractorEditHandler _handler;
//        Mock<IFormFile> file = new Mock<IFormFile>();

//        ContractorEditCommand _request;
//        Guid _id;
//        Contractor _contractor;

//        #endregion

//        public ContractorEditHandlerTest()
//        {
//            _contractorRepository = new Mock<IContractorRepository>();
//            _areaRepository = new Mock<IAreaRepository>();
//            _assignAreaRepository = new Mock<IAssignAreaRepository>();
//            _logger = new Mock<ILogger>();
//            _handler = new ContractorEditHandler(_logger.Object, _sharedResources.Object,
//                _contractorRepository.Object,
//                _areaRepository.Object,
//                _assignAreaRepository.Object);
//            _id = Guid.NewGuid();
//            _request = new ContractorEditCommand()
//            {
//                Id = _id,
//                Name = "Name",
//                Address = "Address",
//                CodeUnique = "CodeUnique",
//                Image = file.Object,
//                MobileNum = "MobileNum",
//                //StartDate = "1390/01/01",
//                //EndDate = "1340/01/01",
//                //StartDate = DateTime.Now,
//                //EndDate = DateTime.Now,
//                AreaIds = new List<Guid>()
//            {
//                Guid.NewGuid (),
//            },
//                TenantId = Guid.NewGuid(),
//            };
//            _contractor = new Contractor()
//            {
//                Id = _id,
//                Deleted = true
//            };

//        }


//        #region Validation Request
//        [Fact]
//        [Trait("ContractorEditHandler", "Validation Request")]
//        public async Task Validation_Id_Test()
//        {

//            //Arrange
//            _request.Id = Guid.Empty;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.UnValidContractorId(), response.Message);
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("ContractorEditHandler", "Validation Request")]
//        public async Task Validation_Name_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                _request.Name = string.Empty;

//            else
//                _request.Name = null;

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
//        [Trait("ContractorEditHandler", "Validation Request")]
//        public async Task Validation_Address_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                _request.Address = string.Empty;

//            else
//                _request.Address = null;

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
//        [Trait("ContractorEditHandler", "Validation Request")]
//        public async Task Validation_Code_Unique_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                _request.CodeUnique = string.Empty;

//            else
//                _request.CodeUnique = null;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.UnValidContractorCodeUnique(), response.Message);
//        }

//        //[Fact]
//        //[Trait("ContractorEditHandler", "Validation Request")]
//        //public async Task Validation_Image_Test()
//        //{
//        //    //Arrange
//        //    FillDate();
//        //    _request.Image = null;

//        //    //Act
//        //    var response = await _handler.Handle(_request, new CancellationToken());

//        //    //Assert
//        //    Assert.False(response.IsSuccessful);
//        //    Assert.Null(response.Data);
//        //    Assert.Equal(MessageResponse.UnValidContractorImage(), response.Message);
//        //}

//        private void FillDate()
//        {
//            _request.StartDate = DateTime.Now;
//            _request.EndDate = DateTime.Now;
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("ContractorEditHandler", "Validation Request")]
//        public async Task Validation_Mobile_Num_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                _request.MobileNum = string.Empty;

//            else
//                _request.MobileNum = null;


//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.UnValidContractorMobileNum(), response.Message);
//        }

//        [Fact]
//        [Trait("ContractorEditHandler", "Validation Request")]
//        public async Task Validation_Start_Date_Test()
//        {

//            //Arrange



//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.StartDate(), response.Message);
//        }
//        [Fact]
//        [Trait("ContractorEditHandler", "Validation Request")]
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
//        [Trait("ContractorEditHandler", "Validation Request")]
//        public async Task Validation_AreaIds_Test()
//        {

//            //Arrange
//            FillDate();
//            _request.AreaIds = null;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.UnValidContractorAreaIds(), response.Message);
//        }

//        [Fact]
//        [Trait("ContractorEditHandler", "Validation Request")]
//        public async Task Validation_TenantId_Test()
//        {

//            //Arrange
//            FillDate();

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
//        [Trait("ContractorEditHandler", "Check Request In Db")]
//        public async Task Duplicate_Contractor_Test()
//        {
//            //Arrange
//            FillDate();

//            _contractorRepository.Setup(s => s.HasThisCodeUnique(_request.CodeUnique, _request.Id)).ReturnsAsync(true);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.Duplicate("پیمانکار"), response.Message);
//        }

//        [Fact]
//        [Trait("ContractorEditHandler", "Check Request In Db")]
//        public async Task Valid_Area_Test()
//        {
//            //Arrange
//            FillDate();

//            _contractorRepository.Setup(s => s.HasThisCodeUnique(_request.CodeUnique, _request.Id)).ReturnsAsync(false);
//            _areaRepository.Setup(s => s.ValidArea(_request.AreaIds, _request.TenantId)).ReturnsAsync(false);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.UnValidRequest("ناحیه انتخابی"), response.Message);
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("ContractorEditHandler", "Check Request In Db")]
//        public async Task GetByIdAsync_Test(bool isNull)
//        {

//            //Arrange
//            FillDate();

//            if (isNull)
//            {
//                _contractor = null;
//            }

//            _contractorRepository.Setup(s => s.HasThisCodeUnique(_request.CodeUnique, _request.Id)).ReturnsAsync(false);
//            _areaRepository.Setup(s => s.ValidArea(_request.AreaIds, _request.TenantId)).ReturnsAsync(true);
//            _contractorRepository.Setup(s => s.GetByIdAsync(_request.Id)).ReturnsAsync(_contractor);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.NotFound(), response.Message);
//        }

//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("ContractorEditHandler", "Exception")]
//        public async Task Exception_Test()
//        {

//            //Arrange
//            FillDate();

//            _request = null;
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.Exception(), response.Message);
//        }
//        #endregion






//    }
//}
