//using Ara.SmartHSE.Application.Entities.Personnels.Commands.Delete;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.Personnels.Commands.Delete
//{
//    public class PersonnelDeleteHandlerTest : Language
//    {
//        #region Props

//        private readonly Mock<IPersonnelRepository> _personnelRepository;
//        private readonly Mock<ILogger> _logger;
//        private readonly PersonnelDeleteHandler _handler;
//        PersonnelDeleteCommand _request;
//        List<Personnel> _personnels;
//        #endregion

//        #region Ctor

//        public PersonnelDeleteHandlerTest()
//        {
//            _personnelRepository = new Mock<IPersonnelRepository>();
//            _logger = new Mock<ILogger>();
//            _handler = new PersonnelDeleteHandler(_personnelRepository.Object, _logger.Object, _sharedResources.Object);
//            _request = new PersonnelDeleteCommand()
//            {
//                Ids = new List<Guid> { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() }
//            };
//            _personnels = new List<Personnel>()
//            {
//                new Personnel(),
//                new Personnel(),
//                new Personnel(),
//                new Personnel(),
//                new Personnel(),
//            };
//        }

//        #endregion

//        #region Validation Request

//        [Fact]
//        [Trait("PersonnelDeleteHandlerTest", "Validation Request")]
//        public async Task Validation_Ids_Test()
//        {

//            //Arrange
//            _request.Ids = null;

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }
//        #endregion

//        #region Check Request In Db


//        [Fact]
//        [Trait("PersonnelDeleteHandlerTest", "Check Request In Db")]
//        public async Task Not_Find_Personnel_Test()
//        {
//            //Arrange
//            _personnels.Clear();
//            _personnelRepository.Setup(s => s.GetByIdsAsync(_request.Ids)).ReturnsAsync(_personnels);

//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }
//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("PersonnelDeleteHandlerTest", "Exception")]
//        public async Task Exception_Test()
//        {

//            //Arrange

//            _request = null;
//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }
//        #endregion

//        #region Delete

//        [Fact]
//        [Trait("PersonnelDeleteHandlerTest", "Create")]

//        public async Task Edit_Personnel_Test()
//        {

//            //Arrange
//            _personnelRepository.Setup(s => s.GetByIdsAsync(_request.Ids)).ReturnsAsync(_personnels);
//            _personnelRepository.Setup(s => s.SoftDeletePersonnel(_personnels)).ReturnsAsync(true);


//            //Act
//            var response = await _handler.Handle(_request, new CancellationToken());
//            //Assert
//            _personnelRepository.Verify(x => x.SaveChangesAsync(), Times.Once);

//            Assert.True(response.IsSuccessful);
//            Assert.True(response.Data);
//        }

//        #endregion

//    }
//}
