using System.Xml.Linq;

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
                .Where(p => p.IdUser == user.Id)
                .FirstOrDefaultAsync();

            if (meal is null)
                return NotFound("Meal Not Found");

            var elements = await context.MealElements
                .Include(p => p.Meal)
                .Include(p => p.Elements)
                .Where(p => p.IdMeal == meal.Id)
                .Select(p => new { p.Elements, p.CurrentValue })
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

            var elements = await context.MealElements
                .Include(p => p.Meal)
                .Include(p => p.Elements)
                .Where(p => p.IdMeal == meal.Id)
                .Select(p => new
                {
                    dayIntake=p.Elements.IdNewDailyIntake,
                    Element = p.Elements.Name,
                    Value = p.CurrentValue
                })
                .ToListAsync();

            var dayIntake = await context.NewDailyIntake
                .Include(p => p.Meal)
                .Where(p => p.IdMeal == meal.Id)
                .Include(p => p.Elements)
                .Include(p => p.RecommendetaionDietary)
                .ToListAsync();

            var elemDin = (from elem in elements
                          join din in dayIntake on elem.dayIntake equals din.Id
                          where elem.dayIntake == din.Id
                          select new
                          {
                              Id=din.Id,
                              FromProduct=din.FromProduct,
                              FromMeal=din.FromMeal,
                              Description=din.Description,
                              RecommendetaionDietary=din.RecommendetaionDietary,
                              IdMeal=din.IdMeal,
                              Elements=din.Elements,
                              CurrentValue =elem.Value
                          }).ToList();

            var elenDayIntakeProd = (from res in elemDin
                                     join prod in context.Products on res.Id equals prod.IdNewDailyIntake
                                     where res.Id == prod.IdNewDailyIntake
                                     select new
                                     {
                                         Id = res.Id,
                                         FromProduct = res.FromProduct,
                                         FromMeal = res.FromMeal,
                                         Description = res.Description,
                                         RecommendetaionDietary = res.RecommendetaionDietary,
                                         IdMeal = res.IdMeal,
                                         Elements = res.Elements,
                                         CurrentValue = res.CurrentValue,
                                         Products=prod
                                     }).ToList();

            if (!dayIntake.Any())
                return NotFound("Elements not found");

            return Ok(elenDayIntakeProd);
        }
    }
}
