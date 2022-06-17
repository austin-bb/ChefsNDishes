using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers;

public class ChefsController : Controller
{
  private MyContext _context;

  public ChefsController(MyContext context)
  {
    _context = context;
  }

  [HttpGet("/chefs/all")]
  public IActionResult AllChefs()
  {
    List<Chef> allChefs = _context.Chefs.Include(chef => chef.Dishes).ToList();

    return View("AllChefs", allChefs);
  }

  [HttpGet("/chefs/new")]
  public IActionResult NewChef()
  {
    return View("NewChef");
  }

  [HttpPost("/chefs/add")]
  public IActionResult AddChef(Chef newChef)
  {
    if (ModelState.IsValid == false)
    {
      return NewChef();
    }

    _context.Chefs.Add(newChef);
    _context.SaveChanges();

    return RedirectToAction("AllChefs");
  }
}