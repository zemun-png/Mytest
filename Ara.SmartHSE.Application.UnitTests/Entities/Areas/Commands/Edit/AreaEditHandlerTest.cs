//using Moq;
//using Aranuma.Infrustructure.Logging;
//using Ara.SmartHSE.Application.Entities.Areas.Commands.Edit;
//using Ara.SmartHSE.Domain.Entities;
//using Xunit;
//using Ara.SmartHSE.Application.Interfaces.Repositories;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Areas.Commands.Edit
//{
//    public class AreaEditHandlerTest : Language
//    {
//        #region Props

//        private readonly Mock<IAreaRepository> _areaRepository;
//        private readonly Mock<IAreasLatLongRepository> _areasLatLongRepository;
//        private readonly Mock<ILogger> _logger;
//        private readonly AreaEditHandler _handler;
//        private readonly Guid guid = Guid.NewGuid();
//        #endregion

//        #region Fields

//        private string areaName = "AreaName";
//        private string areaCode = "AreaCode";
//        AreaEditCommand requestMain;
//        List<List<double>> coordinates = new List<List<double>>();
//        #endregion

//        public AreaEditHandlerTest()
//        {
//            _areaRepository = new Mock<IAreaRepository>();
//            _areasLatLongRepository = new Mock<IAreasLatLongRepository>();
//            _logger = new Mock<ILogger>();
//            _handler = new AreaEditHandler(_areaRepository.Object, _logger.Object, _sharedResources.Object, _areasLatLongRepository.Object);

//            coordinates.Add(new List<double>() { 1, 2, 3, 4, });
//            coordinates.Add(new List<double>() { 5, 6, 7, 8, });

//            requestMain = new AreaEditCommand()
//            {
//                AreaId = guid,
//                Code = areaCode,
//                Name = areaName,
//                Coordinates = coordinates,
//                TenantId = Guid.NewGuid(),
//            };
//        }

//        #region Validation Request

//        [Fact]
//        [Trait("AreaEditHandler", "Validation Request")]
//        public async Task Validation_AreaId_Test()
//        {

//            //Arrange
//            requestMain.AreaId = Guid.Empty;

//            //Act
//            var response = await _handler.Handle(requestMain, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.UnValidAreaId(), response.Message);
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("AreaEditHandler", "Validation Request")]
//        public async Task Validation_Area_Code_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                requestMain.Code = null;

//            else
//                requestMain.Code = string.Empty;

//            //Act
//            var response = await _handler.Handle(requestMain, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.UnValidAreaCode(), response.Message);
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("AreaEditHandler", "Validation Request")]
//        public async Task Validation_Area_Name_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                requestMain.Name = null;

//            else
//                requestMain.Name = string.Empty;

//            //Act
//            var response = await _handler.Handle(requestMain, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.UnValidAreaName(), response.Message);
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("AreaEditHandler", "Validation Request")]
//        public async Task Validation_Coordinates_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                requestMain.Coordinates = null;

//            else
//                requestMain.Coordinates.Clear();

//            //Act
//            var response = await _handler.Handle(requestMain, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.UnValidCoordinates(), response.Message);
//        }
//        [Fact]
//        [Trait("AreaEditHandler", "Validation Request")]
//        public async Task Validation_TenantId_Test()
//        {

//            //Arrange
//            //Arrange
//            requestMain.TenantId = Guid.Empty;


//            //Act
//            var response = await _handler.Handle(requestMain, new CancellationToken());

//            //Assert


//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.Tenant(), response.Message);
//        }
//        #endregion

//        #region Check Request In Db

//        [Fact]
//        [Trait("AreaEditHandler", "Check Request In Db")]

//        public async Task Duplicate_Area_With_Name_And_Code_Test()
//        {
//            //Arrange

//            //TODO :Check This Valid
//            _areaRepository.Setup(s => s.ValidArea(requestMain.AreaId.Value, areaName, areaCode, requestMain.TenantId)).ReturnsAsync(true);
//            //Act

//            var response = await _handler.Handle(requestMain, new CancellationToken());

//            //Assert

//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.Duplicate("نام و کد ناحیه"), response.Message);
//        }
//        [Fact]
//        [Trait("AreaEditHandler", "Check Request In Db")]

//        public async Task Not_Find_Area_Test_Null()
//        {
//            Area area = new Area
//            {

//            };
//            area = null;
//            _areaRepository.Setup(s => s.ValidArea(Guid.NewGuid(), areaName, areaCode, Guid.NewGuid())).ReturnsAsync(false);
//            _areaRepository.Setup(s => s.GetByIdAsync(requestMain.AreaId.Value)).ReturnsAsync(area);
//            var response = await _handler.Handle(requestMain, new CancellationToken());
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }
//        [Fact]
//        [Trait("AreaEditHandler", "Check Request In Db")]

//        public async Task Not_Find_Area_Test_Tenant()
//        {
//            Area area = new Area
//            {
//                TenantId = Guid.NewGuid(),
//            };
//            _areaRepository.Setup(s => s.ValidArea(Guid.NewGuid(), areaName, areaCode, Guid.NewGuid())).ReturnsAsync(false);
//            _areaRepository.Setup(s => s.GetByIdAsync(requestMain.AreaId.Value)).ReturnsAsync(area);
//            var response = await _handler.Handle(requestMain, new CancellationToken());
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }
//        [Fact]
//        [Trait("AreaEditHandler", "Check Request In Db")]

//        public async Task Not_Find_Area_Test_Delete()
//        {
//            Area area = new Area
//            {
//                Deleted = true,
//            };
//            _areaRepository.Setup(s => s.ValidArea(Guid.NewGuid(), areaName, areaCode, Guid.NewGuid())).ReturnsAsync(false);
//            _areaRepository.Setup(s => s.GetByIdAsync(requestMain.AreaId.Value)).ReturnsAsync(area);
//            var response = await _handler.Handle(requestMain, new CancellationToken());
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }
//        #endregion


//        #region Exception

//        [Fact]
//        [Trait("AreaEditHandler", "Exception")]

//        public async Task Exception_Test()
//        {

//            //Arrange


//            //Act
//            var response = await _handler.Handle(requestMain, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.Exception(), response.Message);
//        }
//        #endregion


//        [Fact]
//        [Trait("AreaEditHandler", "Exception")]

//        public async Task UpdateArea_ValidRequest_ReturnsSuccessResponse()
//        {
//            // Arrange

//            //var areaRepositoryMock = new Mock<IAreaRepository>();
//            //var areasLatLongRepositoryMock = new Mock<IAreasLatLongRepository>();
//            //_unitOfWork.SetupGet(s => s.AreaRepository).Returns(areaRepositoryMock.Object);
//            //_unitOfWork.SetupGet(s => s.AreasLatLongRepository).Returns(areasLatLongRepositoryMock.Object);

//            var request = new AreaEditCommand
//            {
//                AreaId = Guid.NewGuid(),
//                Name = "Updated Area",
//                Code = "Updated Code",
//                IsDanger = true,
//                RequestBy = "Test User",
//                Coordinates = new List<List<double>>
//            {
//                new List<double> { 1.234, 2.345 },
//                new List<double> { 3.456, 4.567 }
//            }
//            };

//            var existingArea = new Area
//            {
//                Id = request.AreaId.Value,
//                Name = "Existing Area",
//                CodeArea = "Existing Code",
//                IsDanger = false,
//                TenantId = request.TenantId
//            };

//            var existingLatLongs = new List<AreasLatLong>
//        {
//            new AreasLatLong
//            {
//                Id = Guid.NewGuid(),
//                AreaId = existingArea.Id,
//                Latitude = 1.234,
//                Longitude = 2.345
//            },
//            new AreasLatLong
//            {
//              Id = Guid.NewGuid(),
//                AreaId = existingArea.Id,
//                Latitude = 3.456,
//                Longitude = 4.567
//            }
//        };

//            _areaRepository.Setup(s => s.ValidArea(requestMain.AreaId.Value, areaName, areaCode, request.TenantId)).ReturnsAsync(true);
//            _areaRepository.Setup(s => s.GetByIdAsync(request.AreaId.Value)).ReturnsAsync(existingArea);
//            _areasLatLongRepository.Setup(s => s.GetByAreaId(request.AreaId.Value)).ReturnsAsync(existingLatLongs);


//            // Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            // Assert
//            _areaRepository.Verify(x => x.SaveChangesAsync(), Times.Once);
//            Assert.True(response.IsSuccessful);
//            //Assert.Equal(MessageResponse.OKMessage("ویرایش ناحیه"), response.Message);
//            Assert.NotNull(response.Data);
//            Assert.Equal(request.Code, response.Data.Code);
//            Assert.Equal(request.Name, response.Data.Name);
//            Assert.Equal(request.AreaId, response.Data.Id);

//        }

//    }
//}
