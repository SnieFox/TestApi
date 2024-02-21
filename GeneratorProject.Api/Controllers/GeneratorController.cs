using System.Reflection.Emit;
using GeneratorProject.BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using GeneratorProject.BLL.Interfaces;

namespace GeneratorProject.Api.Controllers;

[ApiController]
[Route($"generator")]
public class GeneratorController : Controller
{
    private readonly IGeneratorService _generatorService;
    public GeneratorController(IGeneratorService generatorService) => _generatorService = generatorService;

    [HttpPost]
    [Route("addGenerator")]
    public async Task<IActionResult> AddGenerator(GeneratorRequest request)
    {
        var addGenerator = await _generatorService.AddGeneratorAsync(request);
        if (!addGenerator.IsSuccess)
            return BadRequest(addGenerator.Message);

        return Ok();
    }

    [HttpPut]
    [Route("updateGenerator")]
    public async Task<IActionResult> UpdateGenerator(GeneratorRequest request)
    {
        var updateGenerator = await _generatorService.UpdateGeneratorAsync(request);
        if (!updateGenerator.IsSuccess)
            return BadRequest(updateGenerator.Message);

        return Ok();
    }

    [HttpDelete]
    [Route("deleteGenerator")]
    public async Task<IActionResult> DeleteGenerator(GeneratorRequest request)
    {
        var deleteGenerator = await _generatorService.DeleteGeneratorAsync(request);
        if (!deleteGenerator.IsSuccess)
            return BadRequest(deleteGenerator.Message);

        return Ok();
    }

    [HttpDelete]
    [Route("deleteGeneratorById")]
    public async Task<IActionResult> DeleteGeneratorById(int id)
    {
        var deleteGeneratorById = await _generatorService.DeleteGeneratorByIdAsync(id);
        if (!deleteGeneratorById.IsSuccess)
            return BadRequest(deleteGeneratorById.Message);

        return Ok();
    }

    [HttpGet]
    [Route("getAllGenerators")]
    public async Task<IActionResult> GetAllGenerators()
    {
        var allGenerators = await _generatorService.GetAllAsync();
        if (!allGenerators.IsSuccess)
            return BadRequest(allGenerators.Message);

        return Ok(allGenerators.Entities);
    }
    
    [HttpGet]
    [Route("getGeneratorById")]
    public async Task<IActionResult> GetGeneratorById(int id)
    {
        var allGenerators = await _generatorService.GetGeneratorByIdAsync(id);
        if (!allGenerators.IsSuccess)
            return BadRequest(allGenerators.Message);

        return Ok(allGenerators.Entity);
    }
}