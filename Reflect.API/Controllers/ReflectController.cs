using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Reflect.API.Contracts;
using Reflect.DataAccess;

namespace Reflect.API.Controllers;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public class ReflectController : ControllerBase
{
    private readonly ILogger<ReflectController> _logger;

    public ReflectController(ILogger<ReflectController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetFoundItemsResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Get([FromBody] GetFilteredItemsRequest request)
    {
        var filtredItems = ItemsRepository.GetFilter(
            request.TypeContent,
            request.FilterTags,
            request.StartFilterYear,
            request.StopFilterYear
        );

        var response = new GetFoundItemsResponse
        {
            FoundItems = filtredItems.Select(x => new GetFoundItemDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Status = x.Status,
                Year = x.Year,
                Author = x.Author,
                Score = x.Score
            }).ToArray()
        };

        return Ok(response);
    }
}
