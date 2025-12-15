using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using OrdersDemo.Application.DTOs;
using OrdersDemo.Application.UseCases;

namespace OrdersDemo.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly GetPagedOrdersUseCase getPagedOrdersUseCase;
        private readonly SaveOrderUseCase saveOrderUseCase;

        public OrdersController(GetPagedOrdersUseCase getPagedOrdersUseCase, SaveOrderUseCase saveOrderUseCase)
        {
            this.getPagedOrdersUseCase = getPagedOrdersUseCase;
            this.saveOrderUseCase = saveOrderUseCase;
        }

        // GET: api/<OrdersController>

        [HttpGet]
        public ActionResult<PagedOrdersResultDto> Get(
            [FromQuery] string filter,
            [FromQuery] int offset,
            [FromQuery] int pageSize,
            [FromQuery] string sortColumn = "Id",
            [FromQuery] ListSortDirection sortDirection = ListSortDirection.Ascending)
        {
            var result = getPagedOrdersUseCase.Execute(filter, offset, pageSize, sortColumn, sortDirection);
            return Ok(result);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public void Post([FromBody] OrderDto order)
        {
            saveOrderUseCase.Execute(order);
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
