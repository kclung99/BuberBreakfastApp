using BuberBreakfast.Contract.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers
{
    [ApiController]
    [Route("breakfasts")]
    public class BreakfastsController : ControllerBase
    {
        private readonly IBreakfastService _breakfastService;

        public BreakfastsController(IBreakfastService breakfastService)
        {
            _breakfastService = breakfastService;
        }

        [HttpPost]
        public IActionResult CreateBreakfast(CreateBreakfastRequest request)
        {
            // Map request to the internal service model
            var breakfast = new Breakfast(
                Guid.NewGuid(),
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                DateTime.UtcNow,
                request.Savory,
                request.Sweet);

            // TODO: save to db
            _breakfastService.CreateBreakfast(breakfast);

            // Map result to response contract
            var response = new BreakfastResponse(
                breakfast.Id,
                breakfast.Name,
                breakfast.Description,
                breakfast.StartDateTime,
                breakfast.EndDateTime,
                breakfast.LastModifiedDateTime,
                breakfast.Savory,
                breakfast.Sweet);

            // Return created action
            return CreatedAtAction(
                actionName: nameof(GetBreakfast),
                routeValues:  new {id = response.Id},
                value: response);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetBreakfast(Guid id)
        {
            var breakfast = _breakfastService.GetBreakfast(id);

            // Map internal model to response model
            var response = new BreakfastResponse(
                breakfast.Id,
                breakfast.Name,
                breakfast.Description,
                breakfast.StartDateTime,
                breakfast.EndDateTime,
                breakfast.LastModifiedDateTime,
                breakfast.Savory,
                breakfast.Sweet);

            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpsertBreakfast(Guid id, CreateBreakfastRequest request)
        {
            var breakfast = new Breakfast(
                id,
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                DateTime.UtcNow,
                request.Savory,
                request.Sweet);

            _breakfastService.UpsertBreakfast(id, breakfast);

            // TODO: cerate new breakfast if id doesn't exist

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBreakfast(Guid id)
        {
            _breakfastService.DeleteBreakfast(id);

            return NoContent();
        }
    }
}
