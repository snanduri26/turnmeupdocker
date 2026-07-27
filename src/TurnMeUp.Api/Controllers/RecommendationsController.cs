using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TurnMeUp.Api.Models;

namespace TurnMeUp.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class RecommendationsController : ControllerBase
    {
             private readonly List<Recommendations> recommendations = new()
        {
            new Recommendations { id = 1, artist = "Lana Del Rey", song = "Shades of cool", genre = "Melancholic Pop" },
            new Recommendations { id = 2, artist = "Lana Del Rey", song = "Lust for life", genre = "Pop" },
            new Recommendations { id = 3, artist = "Dua Lipa", song = "Levitating", genre = "Pop" },
            new Recommendations { id = 4, artist = "Imagine Dragons", song = "Bones", genre = "Punk Rock" },
            new Recommendations { id = 5, artist = "The Weeknd", song = "Can't feel my face", genre = "Pop" }
        };
        [HttpGet("recommendations")]
        public IActionResult GetRecommendations()
        {
            return Ok(recommendations);
        }

        [HttpGet("recommendations/{id}")]
        public IActionResult GetRecommendationById(int id)
        {
            var recomById = recommendations.Find(r => r.id == id);
            if (recomById != null)
                return Ok(recomById);
            else
                return NotFound(new
                {
                    Message = $"Recommendation with id {id} was not found."
                });
        }
    }
}
