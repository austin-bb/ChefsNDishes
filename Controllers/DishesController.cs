using ChefsNDishes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


public class DishesController : Controller
{
  private MyContext _context;

  public DishesController(MyContext context)
  {
    _context = context;
  }

  [HttpGet("/dishes/all")]
  public IActionResult AllDishes()
  {
    List<Dish> allDishes = _context.Dishes.Include(dish => dish.Author).ToList();

    return View("AllDishes", allDishes);
  }
  
  
  [HttpGet("/dishes/new")]
  public IActionResult NewDish()
  {
    List<Chef> selectChefs = _context.Chefs.ToList();
    ViewBag.SelectChefs = selectChefs;

    return View("NewDish");
  }


  [HttpPost("/dishes/add")]
  public IActionResult AddDish(Dish newDish)
  {
    if (ModelState.IsValid == false)
    {
      return NewDish();
    }

    _context.Dishes.Add(newDish);
    _context.SaveChanges();

    return RedirectToAction("AllDishes");
  }
}