//using Ara.SmartHSE.Application.Entities.PersonnelWatches.Commands.AssignWatchtToPersonnelCommand;
//using Ara.SmartHSE.Application.Entities.PersonnelWatches.Commands.AssignWatchTToPersonnelCommand;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Aranuma.Infrustructure.Logging;
//using Moq;
//using Xunit;

//namespace Ara.SmartHSE.Application.UnitTests.Entities.PersonnelWatches.Commands.AssignWatchtToPersonnelCommand
//{
//    public class AssignWatchToPersonnelHandlerTest : Language
//    {
//        #region Fields

//        private readonly Mock<IPersonnelWatchRepository> _personnelWatchRepository;
//        private readonly Mock<IPersonnelRepository> _personnelRepository;
//        private readonly Mock<ILogger> _logger;
//        private readonly AssignWatchToPersonnelHandler _handler;
//        AssignWatchToPersonnelCommand request;
//        Guid WatchId = Guid.NewGuid();
//        Guid PersonnelId = Guid.NewGuid();
//        Watch watch;
//        Personnel personnel;
//        #endregion

//        #region Ctor

//        public AssignWatchToPersonnelHandlerTest()
//        {
//            _personnelWatchRepository = new Mock<IPersonnelWatchRepository>();
//            _personnelRepository = new Mock<IPersonnelRepository>();
//            _logger = new Mock<ILogger>();
//            _handler = new AssignWatchToPersonnelHandler(_personnelWatchRepository.Object, _logger.Object, _sharedResources.Object, _personnelRepository.Object);
//            request = new AssignWatchToPersonnelCommand
//            {
//                WatchId = WatchId,
//                PersonnelId = PersonnelId
//            };
//            watch = new Watch()
//            {
//                //Id = Guid.NewGuid(),
//                //Brand = "Test",
//                Deleted = false,
//            };
//            personnel = new Personnel()
//            {
//                Id = Guid.NewGuid(),
//                Deleted = false,
//            };
//        }
//        #endregion



//        #region Validation Request

//        [Fact]
//        [Trait("AssignWatchToPersonnelHandler", "ValidationRequest")]
//        public async Task Validation_WatchId_Test()
//        {

//            //Arrange
//            request.WatchId = Guid.Empty;

//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());
//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }

//        [Fact]
//        [Trait("AssignWatchToPersonnelHandler", "ValidationRequest")]
//        public async Task Validation_PersonnelId_Test()
//        {

//            //Arrange
//            request.PersonnelId = Guid.Empty;

//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());
//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }

//        #endregion

//        #region CheckRequestInDb

//        //[Fact]
//        //[Trait("AssignWatchToPersonnelHandler", "CheckRequestInDb")]
//        //public async Task Validation_Watch_GetByIdAsync_Null_Test()
//        //{

//        //    //Arrange

//        //    _unitOfWork.Setup(s => s.WatchRepository.GetByIdAsync(Guid.NewGuid())).ReturnsAsync(watch);

//        //    //Act

//        //    var response = await _handler.Handle(request, new CancellationToken());

//        //    //Assert

//        //    Assert.False(response.IsSuccessful);
//        //    Assert.False(response.Data);
//        //    Assert.Equal(MessageResponse.UnValidRequest("ساعت انتخابی"), response.Message);
//        //}
//        //[Fact]
//        //[Trait("AssignWatchToPersonnelHandler", "CheckRequestInDb")]
//        //public async Task Validation_Watch_GetByIdAsync_Delete_Test()
//        //{

//        //    //Arrange
//        //    watch.Deleted = true;
//        //    _unitOfWork.Setup(s => s.WatchRepository.GetByIdAsync(request.WatchId)).ReturnsAsync(watch);

//        //    //Act
//        //    var response = await _handler.Handle(request, new CancellationToken());

//        //    //Assert


//        //    Assert.False(response.IsSuccessful);
//        //    Assert.False(response.Data);
//        //    Assert.Equal(MessageResponse.UnValidRequest("ساعت انتخابی"), response.Message);
//        //}

//        [Fact]
//        [Trait("AssignWatchToPersonnelHandler", "CheckRequestInDb")]
//        public async Task Validation_Personnel_GetByIdAsync_Null_Test()
//        {

//            //Arrange
//            //_unitOfWork.Setup(s => s.WatchRepository.GetByIdAsync(request.WatchId)).ReturnsAsync(watch);
//            _personnelRepository.Setup(s => s.GetByIdAsync(Guid.NewGuid())).ReturnsAsync(personnel);
//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert


//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }
//        [Fact]
//        [Trait("AssignWatchToPersonnelHandler", "CheckRequestInDb")]
//        public async Task Validation_Personnel_GetByIdAsync_Delete_Test()
//        {

//            //Arrange
//            personnel.Deleted = true;
//            _personnelRepository.Setup(s => s.GetByIdAsync(request.PersonnelId)).ReturnsAsync(personnel);
//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert


//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }

//        [Fact]
//        [Trait("AssignWatchToPersonnelHandler", "CheckRequestInDb")]
//        public async Task Validation_IsAssginWatchToPersonnel__Test()
//        {

//            //Arrange
//            _personnelRepository.Setup(s => s.GetByIdAsync(request.PersonnelId)).ReturnsAsync(personnel);
//            _personnelWatchRepository.Setup(s => s.IsAssginWatchToPersonnel(request.WatchId, request.PersonnelId)).ReturnsAsync(true);
//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert


//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }

//        #endregion

//        #region Exception

//        [Fact]
//        [Trait("AssignWatchToPersonnelHandler", "Exception")]
//        public async Task Exception_Test()
//        {

//            //Arrange


//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert
//            Assert.False(response.IsSuccessful);
//            Assert.False(response.Data);
//        }
//        #endregion

//        #region Create

//        [Fact]
//        [Trait("AssignWatchToPersonnelHandler", "Create_Test")]
//        public async Task Create_Test()
//        {

//            //Arrange
//            _personnelRepository.Setup(s => s.GetByIdAsync(request.PersonnelId)).ReturnsAsync(personnel);
//            _personnelWatchRepository.Setup(s => s.IsAssginWatchToPersonnel(request.WatchId, request.PersonnelId)).ReturnsAsync(false);
//            //Act
//            var response = await _handler.Handle(request, new CancellationToken());

//            //Assert

//            _personnelWatchRepository.Verify(s => s.SaveChangesAsync(), Times.Once);

//            Assert.True(response.IsSuccessful);
//            Assert.True(response.Data);

//        }

//        #endregion

//    }
//}
