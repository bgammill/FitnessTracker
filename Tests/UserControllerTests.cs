using FitnessTracker.Controllers;
using Xunit;

namespace MyFirstUnitTests
{
    public class UserControllerTests
    {
        UsersController _controller;

        [Fact]
        public void CreateAndDelete()
        {
            var result = _controller.Put(100);
            Assert.Equal(result.Value.Id, 100);

            var response = _controller.Delete(3);
            Assert.Equal(response.StatusCode, 200);
        }
    }
}