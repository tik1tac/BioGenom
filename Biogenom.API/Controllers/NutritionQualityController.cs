using Biogenom.Shared;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biogenom.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NutritionQualityController : ControllerBase
    {
        private readonly ApplicationContext context;
        public NutritionQualityController(ApplicationContext _context) => context = _context;

        /// <summary>
        /// Запрос который отдает достаток/недостаток - текущее суточное потребление
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurrentConsumptionStatAsync(Guid id)
        {
            var user = await context.User
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            if (user is null)
                return NotFound("User Not Found");

            var meal = await context.Meal
                .Include(p => p.User)
                .Where(p => p.User.Id == user.Id)
                .FirstOrDefaultAsync();

            if (meal is null)
                return NotFound("Meal Not Found");

            var elements = await context.Elements
                .Include(p => p.Meal)
                .Where(p => p.IdMeal == p.Meal.Id)
                .OrderBy(p => p.Name)
                .ToListAsync();

            if (!elements.Any())
                return NotFound("Elements not found");

            return Ok(elements);
        }
        /// <summary>
        /// Запрос который отдает данные для 2 раздела - новое суточное потребление с учетом препаратов
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("newDailyIntake/{id}")]
        public async Task<IActionResult> GetNewDailyIntakeAsync(Guid id)
        {
            var user = await context.User
                          .Where(p => p.Id == id)
                          .FirstOrDefaultAsync();

            if (user is null)
                return NotFound("User Not Found");

            var meal = await context.Meal
                .Include(p => p.User)
                .Where(p => p.User.Id == user.Id)
                .FirstOrDefaultAsync();

            if (meal is null)
                return NotFound("Meal Not Found");

            var dayIntake = await context.NewDailyIntake
                .Include(p => p.Meal)
                .Include(p => p.Product)
                .Include(p => p.Elements)
                .Where(p => p.IdMeal == p.Meal.Id)
                .ToListAsync();


            if (!dayIntake.Any())
                return NotFound("Elements not found");

            return Ok();
        }
        //Не понял, надо ли писать Post запрос
    }
}
