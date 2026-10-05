using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GameNightPlannerDal;
using GameNightPlannerLogic;

namespace GameNightPlanner.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly GameNightService _gameNightService;

        public IndexModel(ILogger<IndexModel> logger, GameNightService gameNightService)
        {
            _logger = logger;
            _gameNightService = gameNightService;
        }

        public void OnGet()
        {
            var gameNight = new GameNight(
         "Board Game Night",
         "An evening of fun board games.",
         DateTime.Now.AddDays(7),
         DateTime.Now.AddDays(14),
         1,
         1
         );
 
             _gameNightService.CreateGameNight(gameNight);
        }
    }
}
