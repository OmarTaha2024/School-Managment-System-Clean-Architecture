using FluentAssertions;
using Moq;
using SchoolManagment.XUnitTest.MoqTest;
using SchoolManagment.XUnitTest.TestModels;
namespace SchoolManagment.XUnitTest
{
    public class MoqOperationTest
    {
        private readonly Mock<List<Car>> _mockService = new();
        [Fact]

        public void Add_Car()
        {
            //Arrange
            var car = new Car() { Id = 1, Name = "Toyota", Color = "Red" };
            var car2 = new Car() { Id = 2, Name = "Toyota", Color = "Red" };
            var carmoqService = new CarMoqService(_mockService.Object);
            //act
            var addResult = carmoqService.AddCar(car);
            var addResult2 = carmoqService.AddCar(car2);
            var carList = carmoqService.GetAll();
            //_mockService.Setup(x => x.AddCar(car)).Return;

            //Assert
            addResult.Should().BeTrue();
            addResult2.Should().BeTrue();
            carList.Should().NotBeNull();
            carList.Should().HaveCount(2);
        }
        //[Fact]
        //public void Remove_Car()
        //{
        //    Arrange
        //    var carmoqService = new CarMoqService(_mockService.Object);
        //    act
        //    var removeResult = carmoqService.RemoveCar(2);
        //    var carList = carmoqService.GetAll();
        //    Assert
        //    removeResult.Should().BeTrue();
        //    carList.Should().HaveCount(1);
        //}
    }
}
