using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using dotnetapp.Controllers;
using Microsoft.Extensions.Logging;
using dotnetapp.Models;

namespace dotnetapp.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
public void Index_ReturnsViewWithWelcomeMessage_WhenUserIsAuthenticated()
{
    // Arrange
    var userName = "TestUser";
    var httpContext = new DefaultHttpContext();
    httpContext.Session = new TestSession();
    httpContext.Session.SetString("UserName", userName);

    var logger = new Mock<ILogger<HomeController>>();
    var controller = new HomeController(logger.Object);
    controller.ControllerContext = new ControllerContext
    {
        HttpContext = httpContext,
    };

    // Act
    var result = controller.Index() as ViewResult;

    // Assert
    Assert.IsNotNull(result);
    Assert.AreEqual("Index", result.ViewName); // Specify the expected view name
    Assert.AreEqual($"Welcome, {userName}!", result.ViewData["WelcomeMessage"]);
}

[Test]
public void Index_ReturnsViewWithoutWelcomeMessage_WhenUserIsNotAuthenticated()
{
    // Arrange
    var httpContext = new DefaultHttpContext();
    httpContext.Session = new TestSession();

    var logger = new Mock<ILogger<HomeController>>();
    var controller = new HomeController(logger.Object);
    controller.ControllerContext = new ControllerContext
    {
        HttpContext = httpContext,
    };

    // Act
    var result = controller.Index() as ViewResult;

    // Assert
    Assert.IsNotNull(result);
    Assert.AreEqual("Index", result.ViewName); // Specify the expected view name
    Assert.IsNull(result.ViewData["WelcomeMessage"]);
}
[Test]
public void Privacy_ReturnsView()
{
    // Arrange
    var logger = new Mock<ILogger<HomeController>>();
    var controller = new HomeController(logger.Object);

    // Act
    var result = controller.Privacy() as ViewResult;

    // Assert
    Assert.IsNotNull(result);
    Assert.AreEqual("Privacy", result.ViewName); // Specify the expected view name
}

    }

   public class TestSession : ISession
{
    private Dictionary<string, byte[]> _sessionData = new Dictionary<string, byte[]>();

    public bool IsAvailable => true;

    public string Id => "TestSessionId";

    public IEnumerable<string> Keys => _sessionData.Keys;

    public void Clear()
    {
        _sessionData.Clear();
    }

    public Task CommitAsync(CancellationToken cancellationToken = default)
    {
        // No need to do anything here for the test session
        return Task.CompletedTask;
    }

    public Task LoadAsync(CancellationToken cancellationToken = default)
    {
        // No need to load anything for the test session
        return Task.CompletedTask;
    }

    public void Remove(string key)
    {
        _sessionData.Remove(key);
    }

    public void Set(string key, byte[] value)
    {
        _sessionData[key] = value;
    }

    public bool TryGetValue(string key, out byte[] value)
    {
        return _sessionData.TryGetValue(key, out value);
    }
}

}
