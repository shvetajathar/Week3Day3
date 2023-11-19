using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using dotnetapp.Controllers;

namespace dotnetapp.Tests
{
    [TestFixture]
    public class AccountControllerTests
    {
        [Test]
        public void Login_ReturnsView()
        {
            // Arrange
            var controller = new AccountController(null, null);

            // Act
            var result = controller.Login() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
