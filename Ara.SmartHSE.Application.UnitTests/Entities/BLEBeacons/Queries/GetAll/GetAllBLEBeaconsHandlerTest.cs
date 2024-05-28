//using Ara.SmartHSE.Application.Entities.BLEBeacons.Queries.GetAll;
//using Ara.SmartHSE.Application.Entities.EquipmentDetailses;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Ara.SmartHSE.Domain.Enum;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.BLEBeacons.Queries.GetAll
//{
//    public class GetAllBLEBeaconsHandlerTest : Language
//    {
//        #region Props

//        private readonly Mock<IBLEBeaconRepository> _bLEBeaconRepository;
//        private readonly Mock<ILogger> _logger;
//        private readonly GetAllBLEBeaconsHandler _handler;
//        private GetAllBLEBeaconsQuery _request;
//        private readonly Mock<IEquipmentDetailsManager> _equipmentDetailsManager;
//        #endregion

//        public GetAllBLEBeaconsHandlerTest()
//        {
//            _bLEBeaconRepository = new Mock<IBLEBeaconRepository>();
//            _logger = new Mock<ILogger>();
//            _equipmentDetailsManager = new Mock<IEquipmentDetailsManager>();
//            _handler = new GetAllBLEBeaconsHandler(_bLEBeaconRepository.Object, _logger.Object, _sharedResources.Object, _equipmentDetailsManager.Object);
//            _request = new GetAllBLEBeaconsQuery();

//        }

//        #region Exception

//        [Fact]
//        [Trait("GetAllBLEBeaconsHandlerTest", "Exception")]
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

//        #region GetAll

//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("GetAllBLEBeaconsHandlerTest", "GetAll")]

//        public async Task GetAll_Test(bool clear)
//        {
//            //Arrange
//            var tuple = new Tuple<string, string>("test", "Ok");
//            _equipmentDetailsManager.Setup(s => s.GetDetailsOfEquipment(Guid.NewGuid())).ReturnsAsync(tuple);

//            var list = new List<BLEBeacon>()
//            {
//                new BLEBeacon()
//                {
//                    Id=Guid.NewGuid(),
//                   IndexId=1,
//                   Status=StatusOfWatch.idle,
//                   MACAddress="MACAddress",
//                   Location="1",
//                   DeliverTime=DateTime.Now,
//                   Model=new Model
//                   {
//                        ModelName="ModelName",
//                        Brand=new Brand
//                        {
//                            BrandName="BrandName",
//                        }
//                   },
//                   ModelId=Guid.NewGuid()
//                },
//                new BLEBeacon()
//                {
//                   Id=Guid.NewGuid(),
//                   IndexId=1,
//                   Status=StatusOfWatch.idle,
//                   MACAddress="MACAddress",
//                   Location="1",
//                   DeliverTime=DateTime.Now,
//                   Model=new Model
//                     {
//                        ModelName="ModelName",
//                        Brand=new Brand
//                        {
//                            BrandName="BrandName",
//                        }
//                   },
//                   ModelId=Guid.NewGuid()
//                }
//            };

//            if (clear)
//                list.Clear();


//            _bLEBeaconRepository.Setup(s => s.GetAllBLEBeaconWithIncludeAsync()).ReturnsAsync(list);



//            //Act

//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert


//            if (clear)
//            {
//                Assert.False(response.IsSuccessful);
//                Assert.Empty(response.Data);
//            }
//            else
//            {
//                Assert.True(response.IsSuccessful);
//                Assert.NotEmpty(response.Data);
//            }

//        }

//        #endregion

//    }
//}
