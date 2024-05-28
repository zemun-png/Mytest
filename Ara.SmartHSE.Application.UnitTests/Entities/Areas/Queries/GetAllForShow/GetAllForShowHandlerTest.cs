//using Ara.SmartHSE.Application.Entities.Areas.Queries.GetAllForShow;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Areas.Queries.GetAllForShow
//{
//    public class GetAllForShowHandlerTest : Language
//    {
//        #region Fields

//        private readonly Mock<IAreaRepository> _areaRepository;
//        private readonly Mock<ILogger> _logger;
//        private readonly GetAllForShowHandler _handler;
//        GetAllForShowQuery _request;
//        public List<Area> _areas;
//        public Guid _guidArea1 = Guid.NewGuid();
//        public Guid _guidArea2 = Guid.NewGuid();
//        public Guid _guidArea3 = Guid.NewGuid();
//        public Guid _guidArea4 = Guid.NewGuid();

//        #endregion


//        public GetAllForShowHandlerTest()
//        {
//            _areaRepository = new Mock<IAreaRepository>();
//            _logger = new Mock<ILogger>();
//            _handler = new GetAllForShowHandler(_areaRepository.Object, _logger.Object, _sharedResources.Object);
//            FillListArea();
//        }

//        [Fact]
//        [Trait("GetAllForShowHandlerTest", "Validation Request")]
//        public async Task Validation_TenantId_Test()
//        {

//            //Arrange
//            //Arrange
//            _request.TenantId = Guid.Empty;


//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert


//            Assert.False(response.IsSuccessful);
//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.Tenant(), response.Message);
//        }


//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("GetAllForShowHandlerTest", "Show")]

//        public async Task Get_All_For_Show_Handler_Test(bool hasData)
//        {
//            //Arrange
//            if (!hasData)
//            {
//                _areas.Clear();
//            }
//            _areaRepository.Setup(s => s.GetAll(_request.TenantId)).ReturnsAsync(_areas);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            if (hasData)
//            {
//                Assert.NotNull(response.Data);
//                Assert.Equal(_areas.Count(), response.Data.Count());
//                Assert.True(response.IsSuccessful);
//                //Assert.Equal(response.Message, MessageResponse.HasData());
//                Assert.Equal(response.Data[0].Id, _areas[0].Id);
//                Assert.Equal(response.Data[1].Id, _areas[1].Id);
//                Assert.Equal(response.Data[2].Id, _areas[2].Id);
//                Assert.Equal(response.Data[3].Id, _areas[3].Id);
//            }
//            else
//            {
//                Assert.Empty(response.Data);
//                Assert.Equal(_areas.Count(), response.Data.Count());
//                Assert.False(response.IsSuccessful);
//                //Assert.Equal(response.Message, MessageResponse.NoData());
//            }
//        }


//        [Fact]
//        [Trait("GetAllForShowHandlerTest", "Exception")]

//        public async Task Get_All_For_Show_Handler_Exception_Test()
//        {
//            //Arrange
//            //_areas = null;
//            //_unitOfWork.Setup(s => s.AreaRepository.GetAllAsync()).ReturnsAsync(_areas);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert

//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.Exception(), response.Message);
//            Assert.False(response.IsSuccessful);


//        }


//        private void FillListArea()
//        {
//            _request = new GetAllForShowQuery()
//            {
//                TenantId = Guid.NewGuid(),
//            };

//            _areas = new List<Area>()
//            {
//                new Area()
//                {
//                    Name = "Name1",
//                    CodeArea = "CodeArea1",
//                    Created=DateTime.Now,
//                    IsDanger=true,
//                    Id=_guidArea1,
//                    TenantId=_request.TenantId,
//                    AreasLatLongs=new List<AreasLatLong>(),
//                },
//                new Area() {
//                    Name = "Name2",
//                    CodeArea = "CodeArea2",
//                    Created=DateTime.Now,
//                    IsDanger=true,
//                    Id=_guidArea2,
//                    TenantId=_request.TenantId,
//                    AreasLatLongs=new List<AreasLatLong>(),

//                },
//                new Area() {
//                    Name = "Name3",
//                    CodeArea = "CodeArea3",
//                    Created=DateTime.Now,
//                    IsDanger=false,
//                    TenantId=_request.TenantId,
//                    Id=_guidArea3,
//                    AreasLatLongs=new List<AreasLatLong>(),

//                },
//                new Area() {
//                    Name = "Name4",
//                    CodeArea = "CodeArea4",
//                    Created=DateTime.Now,
//                    IsDanger=false,
//                    TenantId=_request.TenantId,
//                    AreasLatLongs=new List<AreasLatLong>(),
//                    Id=_guidArea4,
//                },
//            };
//        }
//    }
//}
