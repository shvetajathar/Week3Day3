using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;
namespace dotnetapp.Controllers;
public class HomeController : Controller
{

    private readonly ApplicationDbContext context;
    public HomeController(ApplicationDbContext _context){
        context=_context;
    }

    public IActionResult Index()
    {
        // Simulate getting data from a form
        string name = "John Doe";
        int age = 25;

        // Store data in ViewBag (for simplicity, in a real-world scenario, you'd use a ViewModel)
        ViewBag.Name = name;
        ViewBag.Age = age;

        return View();
    }

    public IActionResult Contact()
    {
        // Retrieve data stored in ViewBag from the Index method
        string name = ViewBag.Name;
        int age = ViewBag.Age;

        ViewData["Name"] = name;
        ViewData["Age"] = age;

        return View();
    }
}