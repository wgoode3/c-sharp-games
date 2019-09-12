using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace Videogames.Models
{
    public class MyContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<Videogame> Games {get;set;}

        public void Create(Videogame game) 
        {
            Games.Add(game);
            SaveChanges();
        }

        public Videogame FindOneGame(int GameId)
        {
            return Games.FirstOrDefault(x => x.VideogameId == GameId);
        }

        public void Update(int GameId, Videogame editedGame)
        {
            Videogame gameToEdit = this.FindOneGame(GameId);
            gameToEdit.title = editedGame.title;
            gameToEdit.studio = editedGame.studio;
            gameToEdit.year = editedGame.year;
            gameToEdit.genre = editedGame.genre;
            gameToEdit.updatedAt = DateTime.Now;
            SaveChanges();
        }
        
    }
}