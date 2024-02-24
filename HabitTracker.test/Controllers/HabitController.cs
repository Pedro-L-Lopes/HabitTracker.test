using HabitTracker.test.DTOs;
using HabitTracker.test.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HabitTracker.test.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HabitController : ControllerBase
{
    private readonly IHabitService _habitService;

    public HabitController(IHabitService habitService)
    {
        _habitService = habitService;
    }

    /// <summary>
    /// Creates a new habit and adds it to the days of the week it will be available.
    /// </summary>
    /// <param name="habitDTO">A JSON object containing the details of the habit. The expected format is: { "title": "Exercise", "weekDays": [1, 2, 3, 4, 5] }.
    /// The "title" field is mandatory and represents the title of the habit. The "weekDays" field is a list of numbers representing the days of the week (1 for Monday, 2 for Tuesday, etc.) on which the habit will be available.</param>
    /// <returns>Returns status code 201 (Created) if the habit is successfully created.</returns>

    [HttpPost]
    public async Task<IActionResult> CreateHabit([FromBody] HabitDTO habitDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _habitService.AddHabit(habitDTO);
            return Ok("Hábito criado com sucesso");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("Day")]
    public async Task<IActionResult> GetHabitsForDay([FromQuery] string date)
    {
        try
        {
            var habitsForDay = await _habitService.GetHabitsForDay(date);
            return Ok(habitsForDay);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
        }
    }
}
