using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Xml.Linq;

namespace MvcMovie.Controllers;

public class OlaMundoController : Controller
{
    // 
    // GET: /HelloWorld/
    public IActionResult Index()
    {
        return View();
    }
    // 
    // GET: /HelloWorld/Welcome/ 
    public IActionResult BemVindo(string nome = "Ailton", int numTimes = 1)
    {
        ViewData["Message"] = "Olá " + nome;
        ViewData["NumTimes"] = numTimes;
        return View();
    }
}