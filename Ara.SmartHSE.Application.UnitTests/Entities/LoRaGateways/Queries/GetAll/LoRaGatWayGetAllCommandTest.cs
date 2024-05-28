//using Ara.SmartHSE.Application.Entities.EquipmentDetailses;
//using Ara.SmartHSE.Application.Entities.LoRaGateways.Queries.GetAll;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.LoRaGateways.Queries.GetAll
//{
//    public class LoRaGatWayGetAllCommandTest : Language
//    {
//        #region Props

//        private readonly Mock<ILoRaGatewayRepository> _loRaGatewayRepository;
//        private readonly Mock<ILogger> _logger;
//        private readonly LoRaGatWayGetAllHandler _handler;
//        private readonly LoRaGatWayGetAllQuery _request;
//        private readonly Mock<IEquipmentDetailsManager> _equipmentDetailsManager;
//        #endregion

//        public LoRaGatWayGetAllCommandTest()
//        {
//            _loRaGatewayRepository = new Mock<ILoRaGatewayRepository>();
//            _logger = new Mock<ILogger>();
//            _equipmentDetailsManager = new Mock<IEquipmentDetailsManager>();
//            _handler = new LoRaGatWayGetAllHandler(_loRaGatewayRepository.Object, _logger.Object, _sharedResources.Object, _equipmentDetailsManager.Object);
//            _request = new LoRaGatWayGetAllQuery() { RequestBy = "request" };

//        }

//        #region Exception

//        [Fact]
//        [Trait("LoRaGatWayGetAllCommandTest", "Exception")]
//        public async Task Exception_Test()
//        {

//            //Arrange

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
//        [Trait("LoRaGatWayGetAllCommandTest", "Create")]

//        public async Task GetAll_Test(bool clear)
//        {
//            var list = new List<LoRaGateway>()
//            {
//                new LoRaGateway()
//                {
//                    Id=Guid.NewGuid(),
//                   SerialNumber="10",
//                   Location="1",
//                   GatewayEUI="GatewayEUI",
//                   IndexId=1,
//                   FirmwareVersion="asd",
//                   DeliverTime=DateTime.Now,
//                   Model=new Model
//                   {
//                        ModelName="ModelName",
//                        Brand=new Brand
//                        {
//                            BrandName="BrandName",
//                        }
//                   }

//                },
//                new LoRaGateway()
//                {
//                   Id=Guid.NewGuid(),
//                   SerialNumber="10",
//                   Location="1",
//                   GatewayEUI="GatewayEUI",
//                   IndexId=1,
//                   FirmwareVersion="asd",
//                   DeliverTime=DateTime.Now,
//                      Model=new Model
//                   {
//                        ModelName="ModelName",
//                        Brand=new Brand
//                        {
//                            BrandName="BrandName",
//                        }
//                   }
//                }
//            };

//            //Arrange
//            if (clear)
//            {
//                list.Clear();
//            }

//            _loRaGatewayRepository.Setup(s => s.GetAllLoRaGatewayAsync()).ReturnsAsync(list);



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
//                //for (int i = 0; i < list.Count; i++)
//                //{
//                //    Assert.Equal(list[i].AliasName, response.Data[i].AliasName);
//                //    Assert.Equal(list[i].Firmware, response.Data[i].Firmware);
//                //    Assert.Equal(list[i].GatewayEUI, response.Data[i].GatewayEUI);
//                //    Assert.Equal(list[i].GatewayID, response.Data[i].GatewayID);
//                //    Assert.Equal(list[i].Id, response.Data[i].Id);
//                //    Assert.Equal(list[i].Lat, response.Data[i].Lat);
//                //    Assert.Equal(list[i].Long, response.Data[i].Long);
//                //    //Assert.Equal(list[i].Model, response.Data[i].Model);
//                //    Assert.Equal(list[i].NetworkIP, response.Data[i].NetworkIP);
//                //    Assert.Equal(list[i].SerialNumber, response.Data[i].SerialNumber);

//                //}
//            }

//        }

//        #endregion

//    }
//}
