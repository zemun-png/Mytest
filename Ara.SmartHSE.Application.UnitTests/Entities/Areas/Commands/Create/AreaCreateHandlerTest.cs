//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Ara.SmartHSE.Application.Entities.Areas.Commands.Create;
//using Ara.SmartHSE.Domain.Entities;
//using Xunit;
//using Ara.SmartHSE.Application.Interfaces.Repositories;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Areas.Commands.Create
//{
//    public class AreaCreateHandlerTest : Language
//    {

//        #region Fields

//        string areaCode = "AreaCode";
//        string areaName = "AreaName";
//        string areaCodeFake = "0";
//        string areaNameFake = "1";
//        string requestBy = "HseTest";
//        Guid areaId = Guid.NewGuid();
//        List<AreasLatLong> listOfPoint = new List<AreasLatLong>();
//        List<List<double>> coordinates = new List<List<double>>();

//        private readonly Mock<IAreaRepository> _areaRepository;
//        private readonly Mock<IAreasLatLongRepository> _areasLatLongRepository;
//        private readonly Mock<ILogger> _logger;

//        private readonly AreaCreateHandler _handler;

//        AreaCreateCommand request;

//        Area area;

//        #endregion

//        #region Ctor

//        public AreaCreateHandlerTest()
//        {
//            _areaRepository = new Mock<IAreaRepository>();
//            _areasLatLongRepository = new Mock<IAreasLatLongRepository>();
//            _logger = new Mock<ILogger>();

//            //Message();

//            _handler = new AreaCreateHandler(_areaRepository.Object, _logger.Object, _sharedResources.Object,_areasLatLongRepository.Object);

//            coordinates.Add(new List<double>() { 1, 2, 3, 4, });
//            coordinates.Add(new List<double>() { 5, 6, 7, 8, });

//            request = new AreaCreateCommand()
//            {
//                Code = areaCode,
//                Name = areaName,
//                RequestBy = requestBy,
//                IsDanger = false,
//                IsInDoor = false,
//                Coordinates = coordinates,
//                TenantId = Guid.NewGuid(),
//            };
//            area = new Area()
//            {
//                Id = areaId,
//                CodeArea = areaCode,
//                CreatedBy = requestBy,
//                IsDanger = false,
//                IsInDoor = true,
//                Name = areaName,
//                TenantId = request.TenantId,
//            };

//        }



//        #endregion


//        #region Validation Request

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("AreaCreateHandler", "Validation Request")]
//        public async Task Validation_Area_Code_Test(bool isNull)
//        {

//            //Arrange
//            if (isNull)
//                request.Code = null;

//            else
//                request.Code = string.Empty;


//            //Act



//            var response = await _handler.Handle(request, new CancellationToken());
//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }


//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("AreaCreateHandler", "Validation Request")]
//        public async Task Validation_Area_Name_Test(bool isNull)
//        {
//            //Arrange
//            if (isNull)
//                request.Name = null;

//            else
//                request.Name = string.Empty;

//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert


//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.UnValidAreaName(), response.Message);
//        }

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("AreaCreateHandler", "Validation Request")]
//        public async Task Validation_Coordinates_Test(bool isNull)
//        {

//            //Arrange
//            //Arrange
//            if (isNull)
//                request.Coordinates = null;

//            else
//                request.Coordinates.Clear();

//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert


//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.UnValidCoordinates(), response.Message);
//        }

//        [Fact]
//        [Trait("AreaCreateHandler", "Validation Request")]
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
//            //Assert.Equal(MessageResponse.Tenant(), response.Message);
//        }
//        #endregion

//        #region Check Request In Db

//        [Fact]
//        [Trait("AreaCreateHandler", "Check Request In Db")]
//        public async Task Has_Area_With_Name_And_Code_Test()
//        {
//            //Arrange

//            _areaRepository.Setup(s => s.ValidArea(areaName, areaCode, request.TenantId)).ReturnsAsync(true);
//            //Act

//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert

//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//        }
//        #endregion

//        #region CreateArea

//        [Fact]
//        [Trait("AreaCreateHandler", "CreateArea")]
//        public async Task Create_Area_Test()
//        {
//            //Arrange

//            for (int i = 0; i < coordinates.Count; i++)
//            {
//                listOfPoint.Add(new AreasLatLong
//                {
//                    Area = area,
//                    AreaId = area.Id,
//                    CreatedBy = request.RequestBy,
//                    Latitude = request.Coordinates[i][0],
//                    Longitude = request.Coordinates[i][1],
//                });
//            }

//            _areaRepository.Setup(s => s.ValidArea(areaNameFake, areaCodeFake, request.TenantId)).ReturnsAsync(true);
//            _areaRepository.Setup(u => u.AddAsync(It.IsAny<Area>())).Returns(Task.FromResult(area));
//            _areasLatLongRepository.Setup(s => s.AddRangeAsync(listOfPoint)).Returns(Task.FromResult(listOfPoint));


//            //Act

//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert
//            _areaRepository.Verify(x => x.SaveChangesAsync(), Times.Once);
//            Assert.True(response.IsSuccessful);
//            Assert.NotNull(response.Data);
//            Assert.Equal(response.Data.Name, request.Name);
//            Assert.Equal(response.Data.Code, request.Code);
//            Assert.Equal(response.Data.Id, area.Id);
//            //Assert.Equal(MessageResponse.OKMessage("ثبت ناحیه"), response.Message);
//        }
//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("AreaCreateHandler", "Exception")]
//        public async Task Exception_Test()
//        {

//            //Arrange


//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.Exception(), response.Message);
//        }
//        #endregion



//    }



//}
