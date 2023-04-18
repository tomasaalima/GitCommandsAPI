using GitCommands.Models;
using GitCommands.Services;
using Microsoft.AspNetCore.Mvc;

namespace GitCommands.Controllers;

[ApiController]
[Route("[controller]")]
public class CommandsController : ControllerBase
{
    public CommandsController()
    {
    }

    [HttpGet]
public ActionResult<List<Command>> GetAll() =>
    CommandsService.GetAll();

    [HttpGet("{id}")]
public ActionResult<Command> Get(int id)
{
    var Command = CommandsService.Get(id);

    if(Command == null)
        return NotFound();

    return Command;
}

    [HttpPost]
public IActionResult Create(Command Command)
{            
    CommandsService.Add(Command);
    return CreatedAtAction(nameof(Get), new { id = Command.Id }, Command);
}

    [HttpPut("{id}")]
public IActionResult Update(int id, Command Command)
{
    if (id != Command.Id)
        return BadRequest();
           
    var existingCommand = CommandsService.Get(id);
    if(existingCommand is null)
        return NotFound();
   
    CommandsService.Update(Command);           
   
    return NoContent();
}

    [HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    var Command = CommandsService.Get(id);
   
    if (Command is null)
        return NotFound();
       
    CommandsService.Delete(id);
   
    return NoContent();
}

}