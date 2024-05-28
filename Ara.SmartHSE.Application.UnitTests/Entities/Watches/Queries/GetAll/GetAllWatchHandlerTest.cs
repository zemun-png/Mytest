//using Ara.SmartHSE.Application.Dtos;
//using Ara.SmartHSE.Application.Entities.EquipmentDetailses;
//using Ara.SmartHSE.Application.Entities.Watches.Queries.GetAll;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Watches.Queries.GetAll
//{
//    public class GetAllWatchHandlerTest : Language
//    {
//        #region Fields

//        private readonly Mock<IWatchRepository> _watchRepository;
//        private readonly Mock<ILogger> _logger;
//        private readonly GetAllWatchHandler _handler;
//        private readonly Mock<IEquipmentDetailsManager> _equipmentDetailsManager;

//        public List<Watch> _watch;
//        public Guid _guid1 = Guid.NewGuid();
//        public Guid _guid2 = Guid.NewGuid();
//        public Guid _guid3 = Guid.NewGuid();
//        public Guid _guid4 = Guid.NewGuid();

//        #endregion


//        public GetAllWatchHandlerTest()
//        {
//            _watchRepository = new Mock<IWatchRepository>();
//            _equipmentDetailsManager = new Mock<IEquipmentDetailsManager>();
//            _logger = new Mock<ILogger>();
//            _handler = new GetAllWatchHandler(_watchRepository.Object, _logger.Object, _sharedResources.Object, _equipmentDetailsManager.Object);
//            FillListArea();
//        }
//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("GetAllWatchHandler", "GetAll")]

//        public async Task Get_All_For_Show_Handler_Test(bool hasData)
//        {
//            //Arrange
//            if (!hasData)
//            {
//                _watch.Clear();
//            }
//            _watchRepository.Setup(s => s.GetAllAsync()).ReturnsAsync(_watch);

//            //Act
//            var response = await _handler.Handle(new GetAllWatchQuery(), new CancellationToken());

//            //Assert
//            if (hasData)
//            {
//                Assert.NotNull(response.Data);
//                Assert.Equal(_watch.Count(), response.Data.Count());
//                Assert.True(response.IsSuccessful);
//                Assert.Equal(response.Message, MessageResponse.HasData());
//                Assert.Equal(response.Data[0].WatchId, _watch[0].Id);
//                Assert.Equal(response.Data[1].WatchId, _watch[1].Id);
//                Assert.Equal(response.Data[2].WatchId, _watch[2].Id);
//                Assert.Equal(response.Data[3].WatchId, _watch[3].Id);
//            }
//            else
//            {
//                Assert.Empty(response.Data);
//                Assert.Equal(_watch.Count(), response.Data.Count());
//                Assert.False(response.IsSuccessful);
//                Assert.Equal(response.Message, MessageResponse.NoData());
//            }
//        }


//        [Fact]
//        [Trait("GetAllWatchHandler", "Exception")]

//        public async Task Get_All_For_Show_Handler_Exception_Test()
//        {
//            //Arrange
//            //_areas = null;
//            //_unitOfWork.Setup(s => s.AreaRepository.GetAllAsync()).ReturnsAsync(_areas);

//            //Act
//            var response = await _handler.Handle(new GetAllWatchQuery(), new CancellationToken());

//            //Assert

//            Assert.Null(response.Data);
//            Assert.Equal(MessageResponse.Exception(), response.Message);
//            Assert.False(response.IsSuccessful);


//        }


//        private void FillListArea()
//        {
//            _watch = new List<Watch>()
//            {
//                new Watch()
//                {
//                    Id=_guid1,
//                //Brand = "1",
//                //Model = "1",
//                LoRaDevEUI = "1",
//                AppKey= "1",
//                MACAddress= "1",
//                NetworkKey= "1",
//                Status=Domain.Enum.StatusOfWatch.offline,
//                PersonnelAndWatches=new List<PersonnelWatch>()
//                {
//                    new PersonnelWatch(){TimeUnAssign=DateTime.Now,Deleted=true }
//                }
//                  },
//              new Watch()
//              {
//                Id = _guid2,
//                //Brand = "2",
//                //Model = "2",
//                LoRaDevEUI = "2",
//                AppKey = "2",
//                MACAddress = "2",
//                NetworkKey = "2",
//                        Status=Domain.Enum.StatusOfWatch.idle,
//                PersonnelAndWatches=new List<PersonnelWatch>()
//                {
//                    new PersonnelWatch(){TimeUnAssign=null,Deleted=false }
//                }
//                  },

//                new Watch()
//    {
//        Id = _guid3,
//            //             Brand = "3",
//            //Model = "3",
//                LoRaDevEUI = "3",
//                AppKey = "3",
//                MACAddress = "3",
//                NetworkKey = "3",
//                          Status=Domain.Enum.StatusOfWatch.inuse,
//                PersonnelAndWatches=new List<PersonnelWatch>()
//                {
//                    new PersonnelWatch(){TimeUnAssign=null,Deleted=false }
//                }
//                },
//                new Watch()
//    {
//        Id = _guid4,
//          //    Brand = "4",
//          //Model = "4",
//                LoRaDevEUI = "4",
//                AppKey = "4",
//                MACAddress = "4",
//                NetworkKey = "4",
//                  Status=Domain.Enum.StatusOfWatch.inuse,
//                PersonnelAndWatches=new List<PersonnelWatch>()
//                {
//                    new PersonnelWatch(){TimeUnAssign=null,Deleted=false }
//                }
//                },
//            };
//        }
//    }
//}
