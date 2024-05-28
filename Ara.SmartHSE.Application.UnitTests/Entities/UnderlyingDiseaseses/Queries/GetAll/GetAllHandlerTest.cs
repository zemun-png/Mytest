//using Ara.SmartHSE.Application.Entities.UnderlyingDiseaseses.Queries.GetAll;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.UnderlyingDiseaseses.Queries.GetAll
//{
//    public class GetAllHandlerTest : Language
//    {
//        #region Fields

//        private readonly Mock<IUnderlyingDiseasesRepository> _underlyingDiseasesRepository;
//        private readonly Mock<ILogger> _logger;
//        private readonly GetAllHandler _handler;
//        public List<UnderlyingDiseases> _underlyingDiseases;
//        public Guid _guid1 = Guid.NewGuid();
//        public Guid _guid2 = Guid.NewGuid();
//        public Guid _guid3 = Guid.NewGuid();
//        public Guid _guid4 = Guid.NewGuid();
//        public string _name1 = "name1";
//        public string _name2 = "name2";
//        public string _name3 = "name3";
//        public string _name4 = "name4";
//        #endregion


//        public GetAllHandlerTest()
//        {
//            _underlyingDiseasesRepository = new Mock<IUnderlyingDiseasesRepository>();
//            _logger = new Mock<ILogger>();
//            _handler = new GetAllHandler(_underlyingDiseasesRepository.Object, _logger.Object, _sharedResources.Object);
//            FillListUnderlyingDiseases();
//        }
//        [Theory]
//        [InlineData(true)]
//        [InlineData(false)]
//        [Trait("GetAllHandlerTest", "GetAll")]

//        public async Task Get_All_For_Show_Handler_Test(bool hasData)
//        {
//            //Arrange
//            if (!hasData)
//            {
//                _underlyingDiseases.Clear();
//            }
//            _underlyingDiseasesRepository.Setup(s => s.GetAllUnderlyingDiseasAsync()).ReturnsAsync(_underlyingDiseases);

//            //Act
//            var response = await _handler.Handle(new GetAllQuery(), new CancellationToken());

//            //Assert
//            if (hasData)
//            {
//                Assert.NotNull(response.Data);
//                Assert.Equal(_underlyingDiseases.Count(), response.Data.Count());
//                Assert.True(response.IsSuccessful);
//                //Assert.Equal(response.Message, MessageResponse.HasData());
//                Assert.Equal(response.Data[0].UnderlyingDiseasId, _underlyingDiseases[0].Id);
//                Assert.Equal(response.Data[1].UnderlyingDiseasId, _underlyingDiseases[1].Id);
//                Assert.Equal(response.Data[2].UnderlyingDiseasId, _underlyingDiseases[2].Id);
//                Assert.Equal(response.Data[3].UnderlyingDiseasId, _underlyingDiseases[3].Id);
//                Assert.Equal(response.Data[0].Name, _underlyingDiseases[0].Sickness);
//                Assert.Equal(response.Data[1].Name, _underlyingDiseases[1].Sickness);
//                Assert.Equal(response.Data[2].Name, _underlyingDiseases[2].Sickness);
//                Assert.Equal(response.Data[3].Name, _underlyingDiseases[3].Sickness);
//            }
//            else
//            {
//                Assert.Empty(response.Data);
//                Assert.Equal(_underlyingDiseases.Count(), response.Data.Count());
//                Assert.False(response.IsSuccessful);
//                //Assert.Equal(response.Message, MessageResponse.NoData());
//            }
//        }


//        [Fact]
//        [Trait("GetAllHandlerTest", "Exception")]

//        public async Task Get_All_For_Show_Handler_Exception_Test()
//        {
//            //Arrange
//            //_areas = null;
//            //_unitOfWork.Setup(s => s.AreaRepository.GetAllAsync()).ReturnsAsync(_areas);

//            //Act
//            var response = await _handler.Handle(new GetAllQuery(), new CancellationToken());

//            //Assert

//            Assert.Null(response.Data);
//            //Assert.Equal(MessageResponse.Exception(), response.Message);
//            Assert.False(response.IsSuccessful);


//        }


//        private void FillListUnderlyingDiseases()
//        {
//            _underlyingDiseases = new List<UnderlyingDiseases>()
//            {
//                new UnderlyingDiseases()
//                {
//                    Id=_guid1,
//                    Sickness=_name1,
//                },
//                new UnderlyingDiseases() {
//                    Id=_guid2,
//                    Sickness=_name1,

//                },
//                new UnderlyingDiseases() {
//                   Id=_guid3,
//                    Sickness=_name1,

//                },
//                new UnderlyingDiseases() {
//              Id=_guid4,
//                Sickness=_name1,

//                },
//            };
//        }
//    }
//}
