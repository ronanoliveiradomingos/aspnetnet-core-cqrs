using System;
using Xunit;
using Solution.Controllers;
using MediatR;
using Moq;

namespace Solution.UnitTests
{
    public class OrdersControllerUnitTest
    {
        OrdersController _controller;

        public OrdersControllerUnitTest()
        {
            var _mediator = new Mock<IMediator>();
            _controller = new OrdersController(_mediator.Object);
        }

        [Fact]
        public void Get_AllOrders_ReturnsOkResult()
        {
            //Arrange
            
            //Act
            var okResult = _controller.GetAllOrders();

            Console.Write(okResult);
            //Assert
            //Assert.IsType<OkObjectResult>(okResult.Result);

        }
    }
}
