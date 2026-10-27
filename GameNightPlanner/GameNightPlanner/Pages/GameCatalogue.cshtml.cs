using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GameNightPlannerLogic;

namespace GameNightPlannerUI.Pages
{
    public class GameCatalogueModel : PageModel
    {
        private readonly GameService _gameService;

        public List<Game> Games { get; private set; } = new List<Game>();

        public GameCatalogueModel(GameService gameService)
        {
            _gameService = gameService;
        }
        public void OnGet()
        {
            Games = _gameService.GetAllGames();
        }
    }
}
