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

        [BindProperty]
        public string? Name { get; set; }

        [BindProperty]
        public string? Description { get; set; }

        [BindProperty]
        public DateTime ProposalDeadline { get; set; }

        [BindProperty]
        public DateTime VotingDeadline { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            try
            {
                var gameNight = new GameNight(
                    Name,
                    Description,
                    ProposalDeadline,
                    VotingDeadline,
                    1, // Hardcoded for now
                    1  // Hardcoded for now
                );

                _gameNightService.CreateGameNight(gameNight);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }
    }
}