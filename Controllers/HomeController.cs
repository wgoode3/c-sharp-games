using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Videogames.Models;

namespace Videogames.Controllers
{
    public class HomeController : Controller
    {

        private MyContext context;
        
        public HomeController(MyContext mc)
        {
            context = mc;
        }

        // public static List<Videogame> Games = new List<Videogame>();

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.Games = context.Games;
            return View();
        }

        [HttpPost("add")]
        public IActionResult Add(Videogame game)
        {
            if(ModelState.IsValid)
            {
                context.Create(game);
                return Redirect("/");
            }
            ViewBag.Games = context.Games;
            return View("Index");
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            List<string> groceries = new List<string>() {
                "Eggs",
                "Milk",
                "Bacon",
                "Carrots",
                "Bagels"
            };
            return View("About", groceries);
        }

        [HttpGet("edit/{GameId}")]
        public IActionResult Edit(int GameId)
        {
            Videogame gameToEdit = context.FindOneGame(GameId);
            return View("Edit", gameToEdit);
        }

        [HttpPost("update/{GameId}")]
        public IActionResult Update(int GameId, Videogame editedGame)
        {
            if(ModelState.IsValid)
            {
                context.Update(GameId, editedGame);
                return Redirect("/");
            }
            editedGame.VideogameId = GameId;
            Console.WriteLine(editedGame.VideogameId);
            return View("Edit", editedGame);
        }
    }
}
