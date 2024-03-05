using HabitTracker.test.DTOs;
using HabitTracker.test.Services.Interfaces;
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

    /// <summary>
    /// Retrieves habits available for a specific day of the week.
    /// </summary>
    /// <param name="date">A string representing the date for which habits are requested. The expected format is "YYYY-MM-DD".</param>
    /// <returns>Returns a list of habits available and/or completed for the specified day. 
    /// {
    ///"possibleHabits": [
    ///   {
    ///        "id": 1,
    ///        "title": "Beber 2L água",
    ///        "createdAt": "2022-12-31T00:00:00",
    ///       "weekDays": []
    ///   }
    /// ],
    /// "completedHabits": [1]
    ///}
    /// </returns>
    [HttpGet("day")]
    public async Task<IActionResult> GetHabitsForDay([FromQuery] string date)
    {
        try
        {
            var (possibleHabits, completedHabits) = await _habitService.GetHabitsForDay(date);
            return Ok(new { possibleHabits, completedHabits });
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

    [HttpPatch("{id}/toggle")]
    public async Task<IActionResult> ToggleHabitForDay(int id, [FromQuery] string date)
    {
        // Atualizar colocando verificação se o hábito estava disponível no dia da semana e se ele foi incluído no sistema no dia da atualização ou antes

        if (!DateTime.TryParse(date, out DateTime parsedDate))
            return BadRequest("Formato de data inválido");

        try
        {
            await _habitService.ToggleHabitForDay(id, parsedDate);
            return Ok("Hábito atualizado");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
        }
    }

    [HttpGet("summary")]
    public async Task<IActionResult> GetSummary()
    {
        try
        {
            var summary = await _habitService.GetSummary();
            return Ok(summary);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _habitService.Delete(id);
            return Ok("Hábito excluído com sucesso");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("allHabits")]
    public async Task<IActionResult> GetAllHabits()
    {
        try
        {
            var habits = await _habitService.GetAllHabits();
            return Ok(habits);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
        }
    }

}
