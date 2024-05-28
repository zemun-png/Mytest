//using Ara.SmartHSE.Application.Dtos;
//using Ara.SmartHSE.Application.Entities.Areas.Commands.Edit;
//using Ara.SmartHSE.Application.Interfaces.Repositories.UnitOfWork;
//using Ara.SmartHSE.Application.Interfaces.Repositories;
//using Ara.SmartHSE.Domain.Entities;
//using Moq;
//using System;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using Xunit;

//namespace YourNamespace.Tests
//{
//    public class AreaEditCommandHandlerTests
//    {
//        [Fact]
//        public async Task Handle_ValidRequest_ReturnsValidResponse()
//        {
//            // Arrange
//            var request = new AreaEditCommand
//            {
//                AreaId = 1,
//                AreaName = "Test Area",
//                AreaCode = "TEST",
//                IsDanger = false,
//                RequestBy = "TestUser",
//                Coordinates = new List<Coordinate> { new Coordinate { Lat = 1.23, Long = 4.56 } }
//            };

//            var unitOfWorkMock = new Mock<IUnitOfWork>();
//            var areaRepositoryMock = new Mock<IAreaRepository>();
//            var areasLatLongRepositoryMock = new Mock<IAreasLatLongRepository>();

//            var findArea = new Area { Id = request.AreaId.Value };
//            var findLatAndLong = new List<AreasLatLong> { new AreasLatLong { AreaId = request.AreaId.Value } };

//            unitOfWorkMock.Setup(uow => uow.AreaRepository).Returns(areaRepositoryMock.Object);
//            unitOfWorkMock.Setup(uow => uow.AreasLatLongRepository).Returns(areasLatLongRepositoryMock.Object);

//            areaRepositoryMock.Setup(repo => repo.ValidArea(request.AreaId.Value, request.AreaName, request.AreaCode))
//                .ReturnsAsync(false);
//            areaRepositoryMock.Setup(repo => repo.GetByIdAsync(request.AreaId.Value))
//                .ReturnsAsync(findArea);
//            areasLatLongRepositoryMock.Setup(repo => repo.GetByAreaId(request.AreaId.Value))
//                .ReturnsAsync(findLatAndLong);
//            areasLatLongRepositoryMock.Setup(repo => repo.UpdateRange(It.IsAny<List<AreasLatLong>>()))
//                .Callback<List<AreasLatLong>>(list => list.ForEach(a => a.Deleted = true));

//            var handler = new AreaEditCommandHandler(unitOfWorkMock.Object);

//            // Act
//            var result = await handler.Handle(request, CancellationToken.None);

//            // Assert
//            Assert.NotNull(result);
//            Assert.NotNull(result.Data);
//            Assert.True(result.Success);
//            Assert.Equal(request.AreaCode, result.Data.CodeArea);
//            Assert.Equal(request.AreaName, result.Data.Name);
//            Assert.Equal(request.AreaId.Value, result.Data.Id);
//            Assert.Equal(MessageResponse.OKMessage("ویرایش ناحیه"), result.Message);
//        }

//        [Fact]
//        public async Task Handle_DuplicateArea_ReturnsErrorMessage()
//        {
//            // Arrange
//            var request = new AreaEditCommand
//            {
//                AreaId = 1,
//                AreaName = "Test Area",
//                AreaCode = "TEST",
//                IsDanger = false,
//                RequestBy = "TestUser",
//                Coordinates = new List<Coordinate> { new Coordinate { Lat = 1.23, Long = 4.56 } }
//            };

//            var unitOfWorkMock = new Mock<IUnitOfWork>();
//            var areaRepositoryMock = new Mock<IAreaRepository>();

//            unitOfWorkMock.Setup(uow => uow.AreaRepository).Returns(areaRepositoryMock.Object);

//            areaRepositoryMock.Setup(repo => repo.ValidArea(request.AreaId.Value, request.AreaName, request.AreaCode))
//                .ReturnsAsync(true);

//            var handler = new AreaEditCommandHandler(unitOfWorkMock.Object);

//            // Act
//            var result = await handler.Handle(request, CancellationToken.None);

//            // Assert
//            Assert.NotNull(result);
//            Assert.Null(result.Data);
//            Assert.False(result.Success);
//            Assert.Equal(MessageResponse.Duplicate("نام و کد ناحیه"), result.Message);
//        }

//        [Fact]
//        public async Task Handle_AreaNotFound_ReturnsErrorMessage()
//        {
//            // Arrange
//            var request = new AreaEditCommand
//            {
//                AreaId = 1,
//                AreaName = "Test Area",
//                AreaCode = "TEST",
//                IsDanger = false,
//                RequestBy = "TestUser",
//                Coordinates = new List<Coordinate> { new Coordinate { Lat = 1.23, Long = 4.56 } }
//            };
//            var unitOfWorkMock = new Mock<IUnitOfWork>();
//            var areaRepositoryMock = new Mock<IAreaRepository>();

//            unitOfWorkMock.Setup(uow => uow.AreaRepository).Returns(areaRepositoryMock.Object);

//            areaRepositoryMock.Setup(repo => repo.ValidArea(request.AreaId.Value, request.AreaName, request.AreaCode))
//                .ReturnsAsync(false);
//            areaRepositoryMock.Setup(repo => repo.GetByIdAsync(request.AreaId.Value))
//                .ReturnsAsync((Area)null);

//            var handler = new AreaEditCommandHandler(unitOfWorkMock.Object);

//            // Act
//            var result = await handler.Handle(request, CancellationToken.None);

//            // Assert
//            Assert.NotNull(result);
//            Assert.Null(result.Data);
//            Assert.False(result.Success);
//            Assert.Equal(MessageResponse.NotFound(), result.Message);
//        }
//    }

