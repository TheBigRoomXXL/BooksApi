using BooksApi.Models;
using BooksApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TagsController : ControllerBase
{
    private readonly TagsService _tagsService;
    public TagsController(TagsService tagsService)
    {

        _tagsService = tagsService;
    }

    [HttpGet]
    public async Task<List<Tag>> Get() =>
        await _tagsService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Tag>> Get(string id)
    {
        var tag = await _tagsService.GetAsync(id);

        if (tag is null)
        {
            return NotFound();
        }

        return tag;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Tag newTag)
    {
        await _tagsService.CreateIfNewAsync(newTag);

        return CreatedAtAction(nameof(Get), new { id = newTag.Id }, newTag);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Tag updatedTag)
    {
        var tag = await _tagsService.GetAsync(id);

        if (tag is null)
        {
            return NotFound();
        }

        updatedTag.Id = tag.Id;

        await _tagsService.UpdateAsync(id, updatedTag);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var tag = await _tagsService.GetAsync(id);

        if (tag is null)
        {
            return NotFound();
        }

        await _tagsService.RemoveAsync(tag.Id);

        return NoContent();
    }
}

