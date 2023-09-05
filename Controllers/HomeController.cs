using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyMVC.Models;

namespace DojoSurveyMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]  /// #13 showing im about to write a action
    [Route("")]   // #14 Has a empty base route
    public ViewResult DojoForm()  // #15writing the function here for the base route
    {
        return View("DojoForm");
    }


    [HttpGet("results")]
    public ViewResult DojoResult()
    {
        return View();  //rendering the page
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    [HttpPost("process")]
    public IActionResult Process(Dojo model)
    {
        if (ModelState.IsValid)  // Process and save the data if it's valid
        {


            return View("DojoResult", model);    // You can access model.Name, model.Location, etc. here
        }


        return View("DojoForm", model); // If there are validation errors, render the form again
    }
}
