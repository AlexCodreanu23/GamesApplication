using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public class GameViewModel
    {
        public Game Game { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }

        public GameViewModel()
        {
            Game = new Game();
            Genres = new List<SelectListItem>
            {
                new SelectListItem { Value = "Action", Text = "Action" },
                new SelectListItem { Value = "Adventure", Text = "Adventure" },
                new SelectListItem { Value = "Sports", Text = "Sports" },
                new SelectListItem { Value = "Fighting", Text = "Fighting" },
                new SelectListItem { Value = "Racing", Text = "Racing" },
                new SelectListItem { Value = "Kids and Family", Text = "Kids and Family" }
            };
        }
    }
}