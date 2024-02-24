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

    [HttpPost("habits")]
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
}
