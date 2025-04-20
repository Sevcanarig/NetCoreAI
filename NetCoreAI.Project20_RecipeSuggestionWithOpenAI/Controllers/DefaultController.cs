using Microsoft.AspNetCore.Mvc;
using NetCoreAI.Project20_RecipeSuggestionWithOpenAI.Models;

namespace NetCoreAI.Project20_RecipeSuggestionWithOpenAI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly OpenAIService _OpenAIService;

        public DefaultController(OpenAIService openAIService)
        {
            _OpenAIService = openAIService;
        }

        [HttpGet]
        public IActionResult CreateRecipe()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe(string ingredients)
        {
            var result = await _OpenAIService.GetRecipeAsync(ingredients);
            ViewBag.recipe = result;
            return View();
        }
    }
}
