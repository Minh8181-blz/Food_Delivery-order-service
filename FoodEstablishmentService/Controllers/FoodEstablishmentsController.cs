using FoodEstablishment.Application.Dtos.Base;
using FoodEstablishment.Application.Dtos.FoodEstablishment;
using FoodEstablishment.Application.Dtos.FoodEstablishments;
using FoodEstablishment.Application.Queries.FilterFoodEstablishments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodEstablishmentService.Controllers
{
    [Route("api/food-establishments")]
    [ApiController]
    [Authorize(Roles = "Buyer")]
    public class FoodEstablishmentsController : ControllerCustomBase
    {
        private readonly IMediator _mediator;

        public FoodEstablishmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<PaginationResultModel<FoodEstablishmentDto>> Filter([FromQuery] FoodEstablishmentFilterModel model)
        {
            var query = new FilterFoodEstablishmentsQuery(model);
            return await _mediator.Send(query);
        }
    }
}
